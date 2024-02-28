using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PhotoSW.Common
{
	public class ObservableCollection2D<T, T2, T3>
	{
		private System.Collections.Generic.Dictionary<T, System.Collections.Generic.Dictionary<T2, T3>> _content = new System.Collections.Generic.Dictionary<T, System.Collections.Generic.Dictionary<T2, T3>>();

		private ObservableCollection<T3> _output = new ObservableCollection<T3>();

		public ObservableCollection<T3> Output
		{
			get
			{
				return this._output;
			}
		}

		public int Count
		{
			get
			{
				int num = 0;
				foreach (System.Collections.Generic.Dictionary<T2, T3> current in this._content.Values)
				{
					num += current.Count;
				}
				return num;
			}
		}

		public ObservableCollection2D()
		{
		}

		public ObservableCollection2D(ObservableCollection<T3> linkOutput)
		{
			this._output = linkOutput;
		}

		public int CountIn(T key1)
		{
			int result;
			if (this.HasKey(key1))
			{
				result = this._content[key1].Count;
			}
			else
			{
				result = 0;
			}
			return result;
		}

		public bool HasKey(T key1)
		{
			return this._content.ContainsKey(key1);
		}

		public bool HasKey(T key1, T2 key2)
		{
			return this.HasKey(key1) && this._content[key1].ContainsKey(key2);
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
				System.Collections.Generic.Dictionary<T2, T3> dictionary = this._content[key1];
				T3[] array = new T3[dictionary.Count];
				dictionary.Values.CopyTo(array, 0);
				int num = this._output.IndexOf(array[array.Length - 1]);
				if (num + 1 == this._output.Count)
				{
					this._output.Add(item);
				}
				else
				{
					this._output.Insert(num + 1, item);
				}
				dictionary.Add(key2, item);
			}
			else
			{
				this._output.Add(item);
				System.Collections.Generic.Dictionary<T2, T3> dictionary2 = new System.Collections.Generic.Dictionary<T2, T3>();
				dictionary2.Add(key2, item);
				this._content.Add(key1, dictionary2);
			}
		}

		public void Remove(T key1)
		{
			if (this.HasKey(key1))
			{
				System.Collections.Generic.Dictionary<T2, T3> dictionary = this._content[key1];
				foreach (T2 current in dictionary.Keys)
				{
					this.Remove(key1, current);
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

		public System.Collections.Generic.Dictionary<T2, T3> Get(T key1)
		{
			return this._content[key1];
		}

		public T3 Get(T key1, T2 key2)
		{
			return this._content[key1][key2];
		}
	}
}
