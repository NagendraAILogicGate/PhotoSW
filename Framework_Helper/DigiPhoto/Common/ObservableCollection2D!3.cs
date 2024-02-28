namespace DigiPhoto.Common
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public class ObservableCollection2D<T, T2, T3>
    {
        private Dictionary<T, Dictionary<T2, T3>> _content;
        private ObservableCollection<T3> _output;

        public ObservableCollection2D()
        {
            this._content = new Dictionary<T, Dictionary<T2, T3>>();
            this._output = new ObservableCollection<T3>();
        }

        public ObservableCollection2D(ObservableCollection<T3> linkOutput)
        {
            this._content = new Dictionary<T, Dictionary<T2, T3>>();
            this._output = new ObservableCollection<T3>();
            this._output = linkOutput;
        }

        public int CountIn(T key1)
        {
            if (this.HasKey(key1))
            {
                return this._content[key1].Count;
            }
            return 0;
        }

        public Dictionary<T2, T3> Get(T key1)
        {
            return this._content[key1];
        }

        public T3 Get(T key1, T2 key2)
        {
            return this._content[key1][key2];
        }

        public bool HasKey(T key1)
        {
            return this._content.ContainsKey(key1);
        }

        public bool HasKey(T key1, T2 key2)
        {
            return (this.HasKey(key1) && this._content[key1].ContainsKey(key2));
        }

        public void Remove(T key1)
        {
            if (this.HasKey(key1))
            {
                Dictionary<T2, T3> dictionary = this._content[key1];
                foreach (T2 local in dictionary.Keys)
                {
                    this.Remove(key1, local);
                }
                this._content.Remove(key1);
            }
        }

        public void Remove(T key1, T2 key2)
        {
            if (this.HasKey(key1, key2))
            {
                this._output.Remove(this._content[key1][key2]);
                this._content[key1].Remove(key2);
            }
        }

        public void Set(T key1, T2 key2, T3 item)
        {
            if (this._content.ContainsKey(key1) && this._content[key1].ContainsKey(key2))
            {
                int index = this._output.IndexOf(this._content[key1][key2]);
                this._output[index] = item;
                this._content[key1][key2] = item;
            }
            else if (this._content.ContainsKey(key1))
            {
                Dictionary<T2, T3> dictionary = this._content[key1];
                T3[] array = new T3[dictionary.Count];
                dictionary.Values.CopyTo(array, 0);
                int num2 = this._output.IndexOf(array[array.Length - 1]);
                if ((num2 + 1) == this._output.Count)
                {
                    this._output.Add(item);
                }
                else
                {
                    this._output.Insert(num2 + 1, item);
                }
                dictionary.Add(key2, item);
            }
            else
            {
                this._output.Add(item);
                Dictionary<T2, T3> dictionary2 = new Dictionary<T2, T3>();
                dictionary2.Add(key2, item);
                this._content.Add(key1, dictionary2);
            }
        }

        public int Count
        {
            get
            {
                int num = 0;
                foreach (Dictionary<T2, T3> dictionary in this._content.Values)
                {
                    num += dictionary.Count;
                }
                return num;
            }
        }

        public ObservableCollection<T3> Output
        {
            get
            {
                return this._output;
            }
        }
    }
}

