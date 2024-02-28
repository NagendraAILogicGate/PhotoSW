//using SmartAssembly.Delegates;
//using SmartAssembly.HouseOfCards;
using System;

namespace PhotoSW.IMIX.DataAccess
{
	public class DataMigrationAccess : BaseDataAccess
	{
        //[NonSerialized]
        //internal static SmartAssembly.Delegates.GetString ;
        internal static GetString getDataMigrationAccess;

        public DataMigrationAccess (BaseDataAccess baseaccess) : base(baseaccess)
		{
		}

		public DataMigrationAccess()
		{
		}

		public string ExecuteDataMigration(string _databasename, string backUpPath)
		{
			base.DBParameters.Clear();
			base.AddParameter(DataMigrationAccess.getDataMigrationAccess(34856), _databasename);
			base.AddParameter(DataMigrationAccess.getDataMigrationAccess(34877), backUpPath);
			object obj = base.ExecuteScalar(DataMigrationAccess.getDataMigrationAccess(34894));
			string result = string.Empty;
			do
			{
				if (obj != null)
				{
					result = obj.ToString();
				}
			}
			while (3 == 0);
			return result;
		}

		static DataMigrationAccess()
		{
			// Note: this type is marked as 'beforefieldinit'.
			//SmartAssembly.HouseOfCards.Strings.CreateGetStringDelegate(typeof(DataMigrationAccess));
		}
	}
}
