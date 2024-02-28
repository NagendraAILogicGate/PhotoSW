using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PhotoSW.Common
{
	[System.Diagnostics.DebuggerDisplay("Id={Id}, Queues={DebugQueueCount}, ScheduledTasks = {DebugTaskCount}"), System.Diagnostics.DebuggerTypeProxy(typeof(StackedTaskScheduler.StackedTaskSchedulerDebugView))]
	public sealed class StackedTaskScheduler : TaskScheduler, System.IDisposable
	{
		private class StackedTaskSchedulerDebugView
		{
			private StackedTaskScheduler _scheduler;

			public System.Collections.Generic.IEnumerable<Task> ScheduledTasks
			{
				get
				{
					System.Collections.Generic.IEnumerable<Task> arg_29_0;
					if (this._scheduler._targetScheduler == null)
					{
						System.Collections.Generic.IEnumerable<Task> blockingTaskQueue = this._scheduler._blockingTaskQueue;
						arg_29_0 = blockingTaskQueue;
					}
					else
					{
						arg_29_0 = this._scheduler._nonthreadsafeTaskQueue;
					}
					System.Collections.Generic.IEnumerable<Task> source = arg_29_0;
					return (from t in source
					where t != null
					select t).ToList<Task>();
				}
			}

			public System.Collections.Generic.IEnumerable<TaskScheduler> Queues
			{
				get
				{
					System.Collections.Generic.List<TaskScheduler> list = new System.Collections.Generic.List<TaskScheduler>();
					foreach (System.Collections.Generic.KeyValuePair<int, StackedTaskScheduler.QueueGroup> current in this._scheduler._queueGroups)
					{
						list.AddRange(current.Value);
					}
					return list;
				}
			}

			public StackedTaskSchedulerDebugView(StackedTaskScheduler scheduler)
			{
				if (scheduler == null)
				{
					throw new System.ArgumentNullException("scheduler");
				}
				this._scheduler = scheduler;
			}
		}

		private class QueueGroup : System.Collections.Generic.List<StackedTaskScheduler.StackedTaskSchedulerQueue>
		{
			public int NextQueueIndex = 0;

			public System.Collections.Generic.IEnumerable<int> CreateSearchOrder()
			{
				for (int i = this.NextQueueIndex; i < base.Count; i++)
				{
					yield return i;
				}
				for (int j = 0; j < this.NextQueueIndex; j++)
				{
					yield return j;
				}
				yield break;
			}
		}

		[System.Diagnostics.DebuggerDisplay("QueuePriority = {_priority}, WaitingTasks = {WaitingTasks}"), System.Diagnostics.DebuggerTypeProxy(typeof(StackedTaskScheduler.StackedTaskSchedulerQueue.StackedTaskSchedulerQueueDebugView))]
		private sealed class StackedTaskSchedulerQueue : TaskScheduler, System.IDisposable
		{
			private sealed class StackedTaskSchedulerQueueDebugView
			{
				private readonly StackedTaskScheduler.StackedTaskSchedulerQueue _queue;

				public int Priority
				{
					get
					{
						return this._queue._priority;
					}
				}

				public int Id
				{
					get
					{
						return this._queue.Id;
					}
				}

				public System.Collections.Generic.IEnumerable<Task> ScheduledTasks
				{
					get
					{
						return this._queue.GetScheduledTasks();
					}
				}

				public StackedTaskScheduler AssociatedScheduler
				{
					get
					{
						return this._queue._pool;
					}
				}

				public StackedTaskSchedulerQueueDebugView(StackedTaskScheduler.StackedTaskSchedulerQueue queue)
				{
					if (queue == null)
					{
						throw new System.ArgumentNullException("queue");
					}
					this._queue = queue;
				}
			}

			private readonly StackedTaskScheduler _pool;

			internal readonly Stack<Task> _workItems;

			internal bool _disposed;

			internal int _priority;

			internal int WaitingTasks
			{
				get
				{
					return this._workItems.Count;
				}
			}

			public override int MaximumConcurrencyLevel
			{
				get
				{
					return this._pool.MaximumConcurrencyLevel;
				}
			}

			internal StackedTaskSchedulerQueue(int priority, StackedTaskScheduler pool)
			{
				this._priority = priority;
				this._pool = pool;
				this._workItems = new Stack<Task>();
			}

			protected override System.Collections.Generic.IEnumerable<Task> GetScheduledTasks()
			{
				return this._workItems.ToList<Task>();
			}

			protected override void QueueTask(Task task)
			{
				if (this._disposed)
				{
					throw new System.ObjectDisposedException(base.GetType().Name);
				}
				lock (this._pool._queueGroups)
				{
					this._workItems.Push(task);
				}
				this._pool.NotifyNewWorkItem();
			}

			protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyStacked)
			{
				return StackedTaskScheduler._taskProcessingThread.Value && base.TryExecuteTask(task);
			}

			internal void ExecuteTask(Task task)
			{
				base.TryExecuteTask(task);
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
		}

		private readonly SortedList<int, StackedTaskScheduler.QueueGroup> _queueGroups;

		private readonly CancellationTokenSource _disposeCancellation;

		private readonly int _concurrencyLevel;

		private static ThreadLocal<bool> _taskProcessingThread = new ThreadLocal<bool>();

		private readonly TaskScheduler _targetScheduler;

		private readonly Stack<Task> _nonthreadsafeTaskQueue;

		private int _delegatesStackedOrRunning;

		private readonly System.Threading.Thread[] _threads;

		private readonly BlockingCollection<Task> _blockingTaskQueue;

		private int DebugQueueCount
		{
			get
			{
				int num = 0;
				foreach (System.Collections.Generic.KeyValuePair<int, StackedTaskScheduler.QueueGroup> current in this._queueGroups)
				{
					num += current.Value.Count;
				}
				return num;
			}
		}

		private int DebugTaskCount
		{
			get
			{
				System.Collections.Generic.IEnumerable<Task> arg_39_0;
				if (this._targetScheduler == null)
				{
					System.Collections.Generic.IEnumerable<Task> blockingTaskQueue = this._blockingTaskQueue;
					arg_39_0 = blockingTaskQueue;
				}
				else
				{
					arg_39_0 = this._nonthreadsafeTaskQueue;
				}
				return (from t in arg_39_0
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

		public StackedTaskScheduler() : this(TaskScheduler.Default, 0)
		{
		}

		public StackedTaskScheduler(TaskScheduler targetScheduler) : this(targetScheduler, 0)
		{
		}

		public StackedTaskScheduler(TaskScheduler targetScheduler, int maxConcurrencyLevel)
		{
			this._queueGroups = new SortedList<int, StackedTaskScheduler.QueueGroup>();
			this._disposeCancellation = new CancellationTokenSource();
			this._delegatesStackedOrRunning = 0;
			//base..ctor();
			if (targetScheduler == null)
			{
				throw new System.ArgumentNullException("underlyingScheduler");
			}
			if (maxConcurrencyLevel < 0)
			{
				throw new System.ArgumentOutOfRangeException("concurrencyLevel");
			}
			this._targetScheduler = targetScheduler;
			this._nonthreadsafeTaskQueue = new Stack<Task>();
			this._concurrencyLevel = ((maxConcurrencyLevel != 0) ? maxConcurrencyLevel : System.Environment.ProcessorCount);
			if (targetScheduler.MaximumConcurrencyLevel > 0 && targetScheduler.MaximumConcurrencyLevel < this._concurrencyLevel)
			{
				this._concurrencyLevel = targetScheduler.MaximumConcurrencyLevel;
			}
		}

		public StackedTaskScheduler(int threadCount) : this(threadCount, string.Empty, false, System.Threading.ThreadPriority.Normal, System.Threading.ApartmentState.MTA, 0, null, null)
		{
		}

		public StackedTaskScheduler(int threadCount, string threadName = "", bool useForegroundThreads = false, System.Threading.ThreadPriority threadPriority = System.Threading.ThreadPriority.Normal, System.Threading.ApartmentState threadApartmentState = System.Threading.ApartmentState.MTA, int threadMaxStackSize = 0, Action threadInit = null, Action threadFinally = null)
		{
			this._queueGroups = new SortedList<int, StackedTaskScheduler.QueueGroup>();
			this._disposeCancellation = new CancellationTokenSource();
			this._delegatesStackedOrRunning = 0;
			//base..ctor();
			StackedTaskScheduler obj = this;
			if (threadCount < 0)
			{
				throw new System.ArgumentOutOfRangeException("concurrencyLevel");
			}
			if (threadCount == 0)
			{
				this._concurrencyLevel = System.Environment.ProcessorCount;
			}
			else
			{
				this._concurrencyLevel = threadCount;
			}
			this._blockingTaskQueue = new BlockingCollection<Task>(new ConcurrentStack<Task>());
			this._threads = new System.Threading.Thread[threadCount];
			for (int i = 0; i < threadCount; i++)
			{
                this._threads[i] = new System.Threading.Thread((ThreadStart)delegate
				{
                    obj.ThreadBasedDispatchLoop(threadInit, threadFinally);
				}, threadMaxStackSize)
				{
					Priority = threadPriority,
					IsBackground = !useForegroundThreads
				};
				if (threadName != null)
				{
					this._threads[i].Name = string.Concat(new object[]
					{
						threadName,
						" (",
						i,
						")"
					});
				}
				this._threads[i].SetApartmentState(threadApartmentState);
			}
			System.Threading.Thread[] threads = this._threads;
			for (int j = 0; j < threads.Length; j++)
			{
				System.Threading.Thread thread = threads[j];
				thread.Start();
			}
		}

		private void ThreadBasedDispatchLoop(Action threadInit, Action threadFinally)
		{
			StackedTaskScheduler._taskProcessingThread.Value = true;
			if (threadInit != null)
			{
				threadInit();
			}
			try
			{
				while (true)
				{
					try
					{
						foreach (Task current in this._blockingTaskQueue.GetConsumingEnumerable(this._disposeCancellation.Token))
						{
							if (current != null)
							{
								base.TryExecuteTask(current);
							}
							else
							{
								Task task;
								StackedTaskScheduler.StackedTaskSchedulerQueue stackedTaskSchedulerQueue;
								lock (this._queueGroups)
								{
									this.FindNextTask_NeedsLock(out task, out stackedTaskSchedulerQueue);
								}
								if (task != null)
								{
									stackedTaskSchedulerQueue.ExecuteTask(task);
								}
							}
						}
					}
					catch (System.Threading.ThreadAbortException)
					{
						if (!System.Environment.HasShutdownStarted && !System.AppDomain.CurrentDomain.IsFinalizingForUnload())
						{
							System.Threading.Thread.ResetAbort();
						}
					}
				}
			}
			catch (System.OperationCanceledException)
			{
			}
			finally
			{
				if (threadFinally != null)
				{
					threadFinally();
				}
				StackedTaskScheduler._taskProcessingThread.Value = false;
			}
		}

		private void FindNextTask_NeedsLock(out Task targetTask, out StackedTaskScheduler.StackedTaskSchedulerQueue queueForTargetTask)
		{
			targetTask = null;
			queueForTargetTask = null;
			foreach (System.Collections.Generic.KeyValuePair<int, StackedTaskScheduler.QueueGroup> current in this._queueGroups)
			{
				StackedTaskScheduler.QueueGroup value = current.Value;
				foreach (int current2 in value.CreateSearchOrder())
				{
					queueForTargetTask = value[current2];
					Stack<Task> workItems = queueForTargetTask._workItems;
					if (workItems.Count > 0)
					{
						targetTask = workItems.Pop();
						if (queueForTargetTask._disposed && workItems.Count == 0)
						{
							this.RemoveQueue_NeedsLock(queueForTargetTask);
						}
						value.NextQueueIndex = (value.NextQueueIndex + 1) % current.Value.Count;
						return;
					}
				}
			}
		}

		protected override void QueueTask(Task task)
		{
			if (this._disposeCancellation.IsCancellationRequested)
			{
				throw new System.ObjectDisposedException(base.GetType().Name);
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

		private void ProcessPrioritizedAndBatchedTasks()
		{
			bool flag = true;
			while (!this._disposeCancellation.IsCancellationRequested && flag)
			{
				try
				{
					StackedTaskScheduler._taskProcessingThread.Value = true;
					while (!this._disposeCancellation.IsCancellationRequested)
					{
						Task task;
						lock (this._nonthreadsafeTaskQueue)
						{
							if (this._nonthreadsafeTaskQueue.Count == 0)
							{
								break;
							}
							task = this._nonthreadsafeTaskQueue.Pop();
						}
						StackedTaskScheduler.StackedTaskSchedulerQueue stackedTaskSchedulerQueue = null;
						if (task == null)
						{
							lock (this._queueGroups)
							{
								this.FindNextTask_NeedsLock(out task, out stackedTaskSchedulerQueue);
							}
						}
						if (task != null)
						{
							if (stackedTaskSchedulerQueue != null)
							{
								stackedTaskSchedulerQueue.ExecuteTask(task);
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
					lock (this._nonthreadsafeTaskQueue)
					{
						if (this._nonthreadsafeTaskQueue.Count == 0)
						{
							this._delegatesStackedOrRunning--;
							flag = false;
							StackedTaskScheduler._taskProcessingThread.Value = false;
						}
					}
				}
			}
		}

		private void NotifyNewWorkItem()
		{
			this.QueueTask(null);
		}

		protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyStacked)
		{
			return StackedTaskScheduler._taskProcessingThread.Value && base.TryExecuteTask(task);
		}

		protected override System.Collections.Generic.IEnumerable<Task> GetScheduledTasks()
		{
			System.Collections.Generic.IEnumerable<Task> result;
			if (this._targetScheduler == null)
			{
				result = (from t in this._blockingTaskQueue
				where t != null
				select t).ToList<Task>();
			}
			else
			{
				result = (from t in this._nonthreadsafeTaskQueue
				where t != null
				select t).ToList<Task>();
			}
			return result;
		}

		public void Dispose()
		{
			this._disposeCancellation.Cancel();
		}

		public TaskScheduler ActivateNewQueue()
		{
			return this.ActivateNewQueue(0);
		}

		public TaskScheduler ActivateNewQueue(int priority)
		{
			StackedTaskScheduler.StackedTaskSchedulerQueue stackedTaskSchedulerQueue = new StackedTaskScheduler.StackedTaskSchedulerQueue(priority, this);
			lock (this._queueGroups)
			{
				StackedTaskScheduler.QueueGroup queueGroup;
				if (!this._queueGroups.TryGetValue(priority, out queueGroup))
				{
					queueGroup = new StackedTaskScheduler.QueueGroup();
					this._queueGroups.Add(priority, queueGroup);
				}
				queueGroup.Add(stackedTaskSchedulerQueue);
			}
			return stackedTaskSchedulerQueue;
		}

		private void RemoveQueue_NeedsLock(StackedTaskScheduler.StackedTaskSchedulerQueue queue)
		{
			StackedTaskScheduler.QueueGroup queueGroup = this._queueGroups[queue._priority];
			int num = queueGroup.IndexOf(queue);
			if (queueGroup.NextQueueIndex >= num)
			{
				queueGroup.NextQueueIndex--;
			}
			queueGroup.RemoveAt(num);
		}
	}
}
