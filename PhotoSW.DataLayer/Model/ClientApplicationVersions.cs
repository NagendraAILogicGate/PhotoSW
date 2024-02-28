using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmEntityType(NamespaceName = "DigiphotoModel", Name = "ClientApplicationVersions"), DataContract(IsReference = true)]
    [Serializable]
    public class ClientApplicationVersions : EntityObject
        {
        private int _ClientApplicationVersionID;

		private string _VersionName;

		private string _MACAddress;

		private string _IPAddress;

		private int _Major;

		private int _Minor;

		private int _Revision;

		private int _BuildNumber;

		private DateTime _ReleaseDate;

		private bool _IsActive;

		private string _Path;

        //[NonSerialized]
        //internal static GetString ;

		[EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
		public int ClientApplicationVersionID
		{
			get
			{
				return this._ClientApplicationVersionID;
			}
			set
			{
				if (!true)
				{
					goto IL_29;
				}
				if (this._ClientApplicationVersionID == value)
				{
					goto IL_42;
				}
				IL_0E:
				//this.ReportPropertyChanging(ClientApplicationVersions.(5979));
				this._ClientApplicationVersionID = StructuralObject.SetValidValue(value);
				IL_29:
				if (false)
				{
					goto IL_0E;
				}
				//this.ReportPropertyChanged(ClientApplicationVersions.(5979));
				IL_42:
				if (!false)
				{
					return;
				}
				goto IL_0E;
			}
		}

		[EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
		public string VersionName
		{
			get
			{
				return this._VersionName;
			}
			set
			{
				do
				{
					//this.ReportPropertyChanging(ClientApplicationVersions.(6016));
					this._VersionName = StructuralObject.SetValidValue(value, false);
                    //do
                    //{
                    //    if (!false)
                    //    {
                    //        this.ReportPropertyChanged(ClientApplicationVersions.(6016));
                    //    }
                    //}
                    //while (false);
				}
				while (false);
			}
		}

		[EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
		public string MACAddress
		{
			get
			{
				return this._MACAddress;
			}
			set
			{
				do
				{
					//this.ReportPropertyChanging(ClientApplicationVersions.(6033));
					this._MACAddress = StructuralObject.SetValidValue(value, false);
                    //do
                    //{
                    //    if (!false)
                    //    {
                    //        this.ReportPropertyChanged(ClientApplicationVersions.(6033));
                    //    }
                    //}
                    //while (false);
				}
				while (false);
			}
		}

		[EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
		public string IPAddress
		{
			get
			{
				return this._IPAddress;
			}
			set
			{
				do
				{
					//this.ReportPropertyChanging(ClientApplicationVersions.(6050));
					this._IPAddress = StructuralObject.SetValidValue(value, false);
                    //do
                    //{
                    //    if (!false)
                    //    {
                    //        this.ReportPropertyChanged(ClientApplicationVersions.(6050));
                    //    }
                    //}
                    //while (false);
				}
				while (false);
			}
		}

		[EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
		public int Major
		{
			get
			{
				return this._Major;
			}
			set
			{
				//this.ReportPropertyChanging(ClientApplicationVersions.(6063));
				this._Major = StructuralObject.SetValidValue(value);
				//this.ReportPropertyChanged(ClientApplicationVersions.(6063));
			}
		}

		[EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
		public int Minor
		{
			get
			{
				return this._Minor;
			}
			set
			{
				//this.ReportPropertyChanging(ClientApplicationVersions.(6072));
				this._Minor = StructuralObject.SetValidValue(value);
				//this.ReportPropertyChanged(ClientApplicationVersions.(6072));
			}
		}

		[EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
		public int Revision
		{
			get
			{
				return this._Revision;
			}
			set
			{
				//this.ReportPropertyChanging(ClientApplicationVersions.(6081));
				this._Revision = StructuralObject.SetValidValue(value);
				//this.ReportPropertyChanged(ClientApplicationVersions.(6081));
			}
		}

		[EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
		public int BuildNumber
		{
			get
			{
				return this._BuildNumber;
			}
			set
			{
				//this.ReportPropertyChanging(ClientApplicationVersions.(6094));
				this._BuildNumber = StructuralObject.SetValidValue(value);
				//this.ReportPropertyChanged(ClientApplicationVersions.(6094));
			}
		}

		[EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
		public DateTime ReleaseDate
		{
			get
			{
				return this._ReleaseDate;
			}
			set
			{
				//this.ReportPropertyChanging(ClientApplicationVersions.(6111));
				this._ReleaseDate = StructuralObject.SetValidValue(value);
				//this.ReportPropertyChanged(ClientApplicationVersions.(6111));
			}
		}

		[EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
		public bool IsActive
		{
			get
			{
				return this._IsActive;
			}
			set
			{
				//this.ReportPropertyChanging(ClientApplicationVersions.(6128));
				this._IsActive = StructuralObject.SetValidValue(value);
				//this.ReportPropertyChanged(ClientApplicationVersions.(6128));
			}
		}

		[EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
		public string Path
		{
			get
			{
				return this._Path;
			}
			set
			{
				do
				{
					//this.ReportPropertyChanging(ClientApplicationVersions.(6141));
					this._Path = StructuralObject.SetValidValue(value, true);
                    //do
                    //{
                    //    if (!false)
                    //    {
                    //        this.ReportPropertyChanged(ClientApplicationVersions.(6141));
                    //    }
                    //}
                    //while (false);
				}
				while (false);
			}
		}

		public static ClientApplicationVersions CreateClientApplicationVersions(int clientApplicationVersionID, string versionName, string mACAddress, string iPAddress, int major, int minor, int revision, int buildNumber, DateTime releaseDate, bool isActive)
		{
			ClientApplicationVersions clientApplicationVersions = new ClientApplicationVersions();
			clientApplicationVersions.ClientApplicationVersionID = clientApplicationVersionID;
			ClientApplicationVersions expr_74 = clientApplicationVersions;
			if (true)
			{
				expr_74.VersionName = versionName;
			}
			clientApplicationVersions.MACAddress = mACAddress;
			clientApplicationVersions.IPAddress = iPAddress;
			do
			{
				clientApplicationVersions.Major = major;
				clientApplicationVersions.Minor = minor;
				clientApplicationVersions.Revision = revision;
				clientApplicationVersions.BuildNumber = buildNumber;
			}
			while (5 == 0);
			clientApplicationVersions.ReleaseDate = releaseDate;
			clientApplicationVersions.IsActive = isActive;
			return clientApplicationVersions;
		}

		static ClientApplicationVersions()
		{
			// Note: this type is marked as 'beforefieldinit'.
			//Strings.CreateGetStringDelegate(typeof(ClientApplicationVersions));
		}




        }
    }
