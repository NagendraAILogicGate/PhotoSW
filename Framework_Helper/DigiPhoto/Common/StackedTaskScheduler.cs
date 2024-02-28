namespace DigiPhoto.Common
{
    using System;
    using System.Collections;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Threading.Tasks;

    [DebuggerTypeProxy(typeof(StackedTaskScheduler.StackedTaskSchedulerDebugView)), DebuggerDisplay("Id={Id}, Queues={DebugQueueCount}, ScheduledTasks = {DebugTaskCount}")]
    public sealed class StackedTaskScheduler : TaskScheduler, IDisposable
    {
        private readonly BlockingCollection<Task> _blockingTaskQueue;
        private readonly int _concurrencyLevel;
        private int _delegatesStackedOrRunning;
        private readonly CancellationTokenSource _disposeCancellation;
        private readonly Stack<Task> _nonthreadsafeTaskQueue;
        private readonly SortedList<int, QueueGroup> _queueGroups;
        private readonly TaskScheduler _targetScheduler;
        private static ThreadLocal<bool> _taskProcessingThread = new ThreadLocal<bool>();
        private readonly Thread[] _threads;

        public StackedTaskScheduler() : this(TaskScheduler.Default, 0)
        {
        }

        public StackedTaskScheduler(int threadCount) : this(threadCount, string.Empty, false, ThreadPriority.Normal, ApartmentState.MTA, 0, null, null)
        {
        }

        public StackedTaskScheduler(TaskScheduler targetScheduler) : this(targetScheduler, 0)
        {
        }

        public StackedTaskScheduler(TaskScheduler targetScheduler, int maxConcurrencyLevel)
        {
            this._queueGroups = new SortedList<int, QueueGroup>();
            this._disposeCancellation = new CancellationTokenSource();
            this._delegatesStackedOrRunning = 0;
            if (targetScheduler == null)
            {
                throw new ArgumentNullException("underlyingScheduler");
            }
            if (maxConcurrencyLevel < 0)
            {
                throw new ArgumentOutOfRangeException("concurrencyLevel");
            }
            this._targetScheduler = targetScheduler;
            this._nonthreadsafeTaskQueue = new Stack<Task>();
            this._concurrencyLevel = (maxConcurrencyLevel != 0) ? maxConcurrencyLevel : Environment.ProcessorCount;
            if ((targetScheduler.MaximumConcurrencyLevel > 0) && (targetScheduler.MaximumConcurrencyLevel < this._concurrencyLevel))
            {
                this._concurrencyLevel = targetScheduler.MaximumConcurrencyLevel;
            }
        }

        public StackedTaskScheduler(int threadCount, string threadName = "", bool useForegroundThreads = false, ThreadPriority threadPriority = 2, ApartmentState threadApartmentState = 1, int threadMaxStackSize = 0, Action threadInit = null, Action threadFinally = null)
        {
            ThreadStart start = null;
            this._queueGroups = new SortedList<int, QueueGroup>();
            this._disposeCancellation = new CancellationTokenSource();
            this._delegatesStackedOrRunning = 0;
            if (threadCount < 0)
            {
                throw new ArgumentOutOfRangeException("concurrencyLevel");
            }
            if (threadCount == 0)
            {
                this._concurrencyLevel = Environment.ProcessorCount;
            }
            else
            {
                this._concurrencyLevel = threadCount;
            }
            this._blockingTaskQueue = new BlockingCollection<Task>(new ConcurrentStack<Task>());
            this._threads = new Thread[threadCount];
            for (int i = 0; i < threadCount; i++)
            {
                if (start == null)
                {
                    start = () => this.ThreadBasedDispatchLoop(threadInit, threadFinally);
                }
                this._threads[i] = new Thread(start, threadMaxStackSize) { Priority = threadPriority, IsBackground = !useForegroundThreads };
                if (threadName != null)
                {
                    this._threads[i].Name = string.Concat(new object[] { threadName, " (", i, ")" });
                }
                this._threads[i].SetApartmentState(threadApartmentState);
            }
            foreach (Thread thread2 in this._threads)
            {
                thread2.Start();
            }
        }

        public TaskScheduler ActivateNewQueue()
        {
            return this.ActivateNewQueue(0);
        }

        public TaskScheduler ActivateNewQueue(int priority)
        {
            StackedTaskSchedulerQueue item = new StackedTaskSchedulerQueue(priority, this);
            lock (this._queueGroups)
            {
                QueueGroup group;
                if (!this._queueGroups.TryGetValue(priority, out group))
                {
                    group = new QueueGroup();
                    this._queueGroups.Add(priority, group);
                }
                group.Add(item);
            }
            return item;
        }

        public void Dispose()
        {
            this._disposeCancellation.Cancel();
        }

        private void FindNextTask_NeedsLock(out Task targetTask, out StackedTaskSchedulerQueue queueForTargetTask)
        {
            targetTask = null;
            queueForTargetTask = null;
            foreach (KeyValuePair<int, QueueGroup> pair in this._queueGroups)
            {
                QueueGroup group = pair.Value;
                foreach (int num in group.CreateSearchOrder())
                {
                    queueForTargetTask = group[num];
                    Stack<Task> stack = queueForTargetTask._workItems;
                    if (stack.Count > 0)
                    {
                        targetTask = stack.Pop();
                        if (queueForTargetTask._disposed && (stack.Count == 0))
                        {
                            this.RemoveQueue_NeedsLock(queueForTargetTask);
                        }
                        group.NextQueueIndex = (group.NextQueueIndex + 1) % pair.Value.Count;
                        break;
                    }
                }
            }
        }

        protected override IEnumerable<Task> GetScheduledTasks()
        {
            if (this._targetScheduler == null)
            {
                return (from t in this._blockingTaskQueue
                    where t != null
                    select t).ToList<Task>();
            }
            return (from t in this._nonthreadsafeTaskQueue
                where t != null
                select t).ToList<Task>();
        }

        private void NotifyNewWorkItem()
        {
            this.QueueTask(null);
        }

        private void ProcessPrioritizedAndBatchedTasks()
        {
            bool flag = true;
            while (!this._disposeCancellation.IsCancellationRequested && flag)
            {
                Stack<Task> stack;
                try
                {
                    _taskProcessingThread.Value = true;
                    while (!this._disposeCancellation.IsCancellationRequested)
                    {
                        Task task;
                        lock ((stack = this._nonthreadsafeTaskQueue))
                        {
                            if (this._nonthreadsafeTaskQueue.Count == 0)
                            {
                                continue;
                            }
                            task = this._nonthreadsafeTaskQueue.Pop();
                        }
                        StackedTaskSchedulerQueue queueForTargetTask = null;
                        if (task == null)
                        {
                            lock (this._queueGroups)
                            {
                                this.FindNextTask_NeedsLock(out task, out queueForTargetTask);
                            }
                        }
                        if (task != null)
                        {
                            if (queueForTargetTask != null)
                            {
                                queueForTargetTask.ExecuteTask(task);
                            }
                            else
                            {
                                base.TryExecuteTask(task);
                            }
                        }
                    }
                }
                finally
                {
                    lock ((stack = this._nonthreadsafeTaskQueue))
                    {
                        if (this._nonthreadsafeTaskQueue.Count == 0)
                        {
                            this._delegatesStackedOrRunning--;
                            flag = false;
                            _taskProcessingThread.Value = false;
                        }
                    }
                }
            }
        }

        protected override void QueueTask(Task task)
        {
            if (this._disposeCancellation.IsCancellationRequested)
            {
                throw new ObjectDisposedException(base.GetType().Name);
            }
            if (this._targetScheduler == null)
            {
                this._blockingTaskQueue.Add(task);
            }
            else
            {
                bool flag = false;
                lock (this._nonthreadsafeTaskQueue)
                {
                    this._nonthreadsafeTaskQueue.Push(task);
                    if (this._delegatesStackedOrRunning < this._concurrencyLevel)
                    {
                        this._delegatesStackedOrRunning++;
                        flag = true;
                    }
                }
                if (flag)
                {
                    Task.Factory.StartNew(new Action(this.ProcessPrioritizedAndBatchedTasks), CancellationToken.None, TaskCreationOptions.None, this._targetScheduler);
                }
            }
        }

        private void RemoveQueue_NeedsLock(StackedTaskSchedulerQueue queue)
        {
            QueueGroup group = this._queueGroups[queue._priority];
            int index = group.IndexOf(queue);
            if (group.NextQueueIndex >= index)
            {
                group.NextQueueIndex--;
            }
            group.RemoveAt(index);
        }

        private void ThreadBasedDispatchLoop(Action threadInit, Action threadFinally)
        {
            _taskProcessingThread.Value = true;
            if (threadInit != null)
            {
                threadInit();
            }
            try
            {
                bool flag2;
                goto Label_0100;
            Label_0025:;
                try
                {
                    foreach (Task task in this._blockingTaskQueue.GetConsumingEnumerable(this._disposeCancellation.Token))
                    {
                        if (task != null)
                        {
                            base.TryExecuteTask(task);
                        }
                        else
                        {
                            Task task2;
                            StackedTaskSchedulerQueue queue;
                            lock (this._queueGroups)
                            {
                                this.FindNextTask_NeedsLock(out task2, out queue);
                            }
                            if (task2 != null)
                            {
                                queue.ExecuteTask(task2);
                            }
                        }
                    }
                }
                catch (ThreadAbortException)
                {
                    if (!(Environment.HasShutdownStarted || AppDomain.CurrentDomain.IsFinalizingForUnload()))
                    {
                        Thread.ResetAbort();
                    }
                }
            Label_0100:
                flag2 = true;
                goto Label_0025;
            }
            catch (OperationCanceledException)
            {
            }
            finally
            {
                if (threadFinally != null)
                {
                    threadFinally();
                }
                _taskProcessingThread.Value = false;
            }
        }

        protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyStacked)
        {
            return (_taskProcessingThread.Value && base.TryExecuteTask(task));
        }

        private int DebugQueueCount
        {
            get
            {
                int num = 0;
                foreach (KeyValuePair<int, QueueGroup> pair in this._queueGroups)
                {
                    num += pair.Value.Count;
                }
                return num;
            }
        }

        private int DebugTaskCount
        {
            get
            {
                return (from t in (this._targetScheduler != null) ? ((IEnumerable<Task>) this._nonthreadsafeTaskQueue) : ((IEnumerable<Task>) this._blockingTaskQueue)
                    where t != null
                    select t).Count<Task>();
            }
        }

        public override int MaximumConcurrencyLevel
        {
            get
            {
                return this._concurrencyLevel;
            }
        }

        private class QueueGroup : List<StackedTaskScheduler.StackedTaskSchedulerQueue>
        {
            public int NextQueueIndex = 0;

            public IEnumerable<int> CreateSearchOrder()
            {
                for (int i = this.NextQueueIndex; i < this.Count; i++)
                {
                    yield return i;
                }
                for (int j = 0; j < this.NextQueueIndex; j++)
                {
                    yield return j;
                }
            }

        }

        private class StackedTaskSchedulerDebugView
        {
            private StackedTaskScheduler _scheduler;

            public StackedTaskSchedulerDebugView(StackedTaskScheduler scheduler)
            {
                if (scheduler == null)
                {
                    throw new ArgumentNullException("scheduler");
                }
                this._scheduler = scheduler;
            }

            public IEnumerable<TaskScheduler> Queues
            {
                get
                {
                    List<TaskScheduler> list = new List<TaskScheduler>();
                    foreach (KeyValuePair<int, StackedTaskScheduler.QueueGroup> pair in this._scheduler._queueGroups)
                    {
                        list.AddRange(pair.Value);
                    }
                    return list;
                }
            }

            public IEnumerable<Task> ScheduledTasks
            {
                get
                {
                    IEnumerable<Task> enumerable = (this._scheduler._targetScheduler != null) ? ((IEnumerable<Task>) this._scheduler._nonthreadsafeTaskQueue) : ((IEnumerable<Task>) this._scheduler._blockingTaskQueue);
                    return (from t in enumerable
                        where t != null
                        select t).ToList<Task>();
                }
            }
        }

        [DebuggerTypeProxy(typeof(StackedTaskScheduler.StackedTaskSchedulerQueue.StackedTaskSchedulerQueueDebugView)), DebuggerDisplay("QueuePriority = {_priority}, WaitingTasks = {WaitingTasks}")]
        private sealed class StackedTaskSchedulerQueue : TaskScheduler, IDisposable
        {
            internal bool _disposed;
            private readonly StackedTaskScheduler _pool;
            internal int _priority;
            internal readonly Stack<Task> _workItems;

            internal StackedTaskSchedulerQueue(int priority, StackedTaskScheduler pool)
            {
                this._priority = priority;
                this._pool = pool;
                this._workItems = new Stack<Task>();
            }

            public void Dispose()
            {
                if (!this._disposed)
                {
                    lock (this._pool._queueGroups)
                    {
                        if (this._workItems.Count == 0)
                        {
                            this._pool.RemoveQueue_NeedsLock(this);
                        }
                    }
                    this._disposed = true;
                }
            }

            internal void ExecuteTask(Task task)
            {
                base.TryExecuteTask(task);
            }

            protected override IEnumerable<Task> GetScheduledTasks()
            {
                return this._workItems.ToList<Task>();
            }

            protected override void QueueTask(Task task)
            {
                if (this._disposed)
                {
                    throw new ObjectDisposedException(base.GetType().Name);
                }
                lock (this._pool._queueGroups)
                {
                    this._workItems.Push(task);
                }
                this._pool.NotifyNewWorkItem();
            }

            protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyStacked)
            {
                return (StackedTaskScheduler._taskProcessingThread.Value && base.TryExecuteTask(task));
            }

            public override int MaximumConcurrencyLevel
            {
                get
                {
                    return this._pool.MaximumConcurrencyLevel;
                }
            }

            internal int WaitingTasks
            {
                get
                {
                    return this._workItems.Count;
                }
            }

            private sealed class StackedTaskSchedulerQueueDebugView
            {
                private readonly StackedTaskScheduler.StackedTaskSchedulerQueue _queue;

                public StackedTaskSchedulerQueueDebugView(StackedTaskScheduler.StackedTaskSchedulerQueue queue)
                {
                    if (queue == null)
                    {
                        throw new ArgumentNullException("queue");
                    }
                    this._queue = queue;
                }

                public StackedTaskScheduler AssociatedScheduler
                {
                    get
                    {
                        return this._queue._pool;
                    }
                }

                public int Id
                {
                    get
                    {
                        return this._queue.Id;
                    }
                }

                public int Priority
                {
                    get
                    {
                        return this._queue._priority;
                    }
                }

                public IEnumerable<Task> ScheduledTasks
                {
                    get
                    {
                        return this._queue.GetScheduledTasks();
                    }
                }
            }
        }
    }
}

