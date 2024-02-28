
using PhotoSW.IMIX.Model;
using SmartAssembly.Delegates;
using SmartAssembly.HouseOfCards;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PhotoSW.IMIX.DataAccess
{
	public class ValueTypeDao : BaseDataAccess
	{
		//[NonSerialized]
		//internal static SmartAssembly.Delegates.GetString ;
        internal  static SmartAssembly.Delegates.GetString getValueTypeDao;

		public ValueTypeDao(BaseDataAccess baseaccess) : base(baseaccess)
		{
		}

		public ValueTypeDao()
		{
		}

		public DateTime GetServerDateTime()
		{
            string dt =DateTime.Now.ToString();////edited
			object obj = base.ExecuteScalar(dt);
			return (DateTime)obj;
		}

		public List<ValueTypeInfo> GetScanTypes()
		{
			IDataReader dataReader=null;
			List<ValueTypeInfo> result;
			while (true)
			{
				if (!false)
				{
					//dataReader = base.ExecuteReader(#1j.#ej);
				}
				while (!false)
				{
					List<ValueTypeInfo> expr_3A = this.ValueTypeInfojd(dataReader);
					if (!false)
					{
						result = expr_3A;
					}
					if (7 == 0)
					{
						break;
					}
					if (8 != 0)
					{
						goto Block_3;
					}
				}
			}
			Block_3:
			dataReader.Close();
			return result;
		}

		private List<ValueTypeInfo> ValueTypeInfojd(IDataReader IDataReader)
		{
			List<ValueTypeInfo> list = new List<ValueTypeInfo>();
			while (true)
			{
                //if (4 == 0)
                //{
                //    goto IL_6B;
                //}
				IL_72:
				ValueTypeInfo valueTypeInfo;
				if (!IDataReader.Read())
				{
					if (5 != 0)
					{
						break;
					}
				}
				else if (8 != 0)
				{
					if (5 == 0)
					{
						continue;
					}
					valueTypeInfo = new ValueTypeInfo();
					valueTypeInfo.ValueTypeId = base.GetFieldValue(IDataReader, ValueTypeDao.getValueTypeDao (30641), 0);
				}
				if (!false)
				{
					valueTypeInfo.Name = base.GetFieldValue(IDataReader, ValueTypeDao.getValueTypeDao (546), string.Empty);
				}
				ValueTypeInfo item = valueTypeInfo;
				IL_6B:
				list.Add(item);
				goto IL_72;
			}
			return list;
		}

		public List<ValueTypeInfo> GetCardTypes()
		{
			IDataReader dataReader=null;
			List<ValueTypeInfo> result;
			while (true)
			{
				if (!false)
				{
					//dataReader = base.ExecuteReader(#1j.#nj);
				}
				while (!false)
				{
					List<ValueTypeInfo> expr_3A = this.ValueTypeInfokd(dataReader);
					if (!false)
					{
						result = expr_3A;
					}
					if (7 == 0)
					{
						break;
					}
					if (8 != 0)
					{
						goto Block_3;
					}
				}
			}
			Block_3:
			dataReader.Close();
			return result;
		}

		private List<ValueTypeInfo> ValueTypeInfokd(IDataReader IDataReader)
		{
			List<ValueTypeInfo> list = new List<ValueTypeInfo>();
			while (true)
			{
                //if (4 == 0)
                //{
                //    goto IL_6B;
                //}
				IL_72:
				ValueTypeInfo valueTypeInfo;
				if (!IDataReader.Read())
				{
					if (5 != 0)
					{
						break;
					}
				}
				else if (8 != 0)
				{
					if (5 == 0)
					{
						continue;
					}
					valueTypeInfo = new ValueTypeInfo();
					valueTypeInfo.ValueTypeId = base.GetFieldValue(IDataReader, ValueTypeDao.getValueTypeDao (30641), 0);
				}
				if (!false)
				{
					valueTypeInfo.Name = base.GetFieldValue(IDataReader, ValueTypeDao.getValueTypeDao (546), string.Empty);
				}
				ValueTypeInfo item = valueTypeInfo;
				IL_6B:
				list.Add(item);
				goto IL_72;
			}
			return list;
		}

		public List<ValueTypeInfo> SelectValueTypeInfoList(int valueTypeGroupId)
		{
			
			List<SqlParameter> expr_51 = base.DBParameters;
			if (!false)
			{
				expr_51.Clear();
			}
            //if (-1 == 0)
            //{
            //    goto IL_49;
            //}
			base.AddParameter(ValueTypeDao.getValueTypeDao (30658), base.SetNullIntegerValue(new int?(valueTypeGroupId)));
			IL_29:
			IDataReader dataReader=null;
			List<ValueTypeInfo> result=null;
            //if (!false)
            //{
            //    dataReader = base.ExecuteReader(#1j.#eg);
            //    result = this.#kd(dataReader);
            //}
            //IL_40:
            //if (-1 == 0)
            //{
            //    goto IL_29;
            //}
			dataReader.Close();
            //IL_49:
            //if (!false)
            //{
            //    return result;
            //}
            //goto IL_40;
            return result;
		}

		public List<ValueTypeInfo> SelectValueTypeList()
		{
			if (7 != 0 && !false)
			{
				base.DBParameters.Clear();
				base.OpenConnection();
				base.AddParameter(ValueTypeDao.getValueTypeDao (30658) , base.SetNullIntegerValue(null));
			}
			List<ValueTypeInfo> result;
			if (!false)
			{
				IDataReader dataReader =null;
                //if (3 != 0)
                //{
                //    dataReader = base.ExecuteReader(#1j.#eg);
                //}
				if (3 != 0)
				{
					result = this.ValueTypeInfold(dataReader);
				}
				dataReader.Close();
			}
			return result;
		}

		private List<ValueTypeInfo> ValueTypeInfold(IDataReader IDataReader)
		{
			List<ValueTypeInfo> list = new List<ValueTypeInfo>();
			while (IDataReader.Read())
			{
				ValueTypeInfo item = new ValueTypeInfo
				{
					ValueTypeId = base.GetFieldValue(IDataReader, ValueTypeDao.getValueTypeDao (30641), 0),
					Name = base.GetFieldValue(IDataReader, ValueTypeDao.getValueTypeDao (546), string.Empty),
					ValueTypeGroupId = base.GetFieldValue(IDataReader, ValueTypeDao.getValueTypeDao (30691), 0),
                    DisplayOrder = base.GetFieldValue(IDataReader, ValueTypeDao.getValueTypeDao(30716), 0)
				};
				list.Add(item);
			}
			return list;
		}

		static ValueTypeDao()
		{
			// Note: this type is marked as 'beforefieldinit'.
			SmartAssembly.HouseOfCards.Strings.CreateGetStringDelegate(typeof(ValueTypeDao));
		}
	}
}
