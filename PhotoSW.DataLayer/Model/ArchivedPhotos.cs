using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;


namespace PhotoSW.DataLayer.Model
    {
    [EdmEntityType(NamespaceName = "PhotoSW", Name = "ArchivedPhotos"), DataContract(IsReference = true)]
	[Serializable]
    public class ArchivedPhotos:EntityObject
        {
        private long _ArchivedPhotoId;

        private int _DG_Photos_pkey;

        private string _DG_Photos_FileName;

        private DateTime _DG_Photos_CreatedOn;

        private string _DG_Photos_RFID;

        private int? _DG_Photos_UserID;

        private string _DG_Photos_Background;

        private string _DG_Photos_Frame;

        private DateTime? _DG_Photos_DateTime;

        private string _DG_Photos_Layering;

        private string _DG_Photos_Effects;

        private bool? _DG_Photos_IsCroped;

        private bool? _DG_Photos_IsRedEye;

        private bool? _DG_Photos_IsGreen;

        private string _DG_Photos_MetaData;

        private string _DG_Photos_Sizes;

        private bool? _DG_Photos_Archive;

        private int? _DG_Location_Id;

        private int? _DG_SubStoreId;

        private DateTime _CreatedOn;

        private bool _FileDeleted;

        private DateTime? _FileDeletedOn;

       

        //[NonSerialized]
        //internal static GetString ;

        [EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
		public long ArchivedPhotoId
		{
			get
			{
				return this._ArchivedPhotoId;
			}
			set
			{
				if (!true)
				{
					goto IL_29;
				}
				if (this._ArchivedPhotoId == value)
				{
					goto IL_42;
				}
                IL_0E:
                //this.ReportPropertyChanging(ArchivedPhotos.(5227));
                this._ArchivedPhotoId = StructuralObject.SetValidValue(value);

				IL_29:
				if (false)
				{
					goto IL_0E;
				}
				//this.ReportPropertyChanged(ArchivedPhotos.(5227));
				IL_42:
				if (!false)
				{
					return;
				}
				goto IL_0E;
			}
		}


        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]      
        public int DG_Photos_pkey
		{
			get
			{
				return this._DG_Photos_pkey;
			}
            set
            {
               // this.ReportPropertyChanging(ArchivedPhotos.(5248));
                this._DG_Photos_pkey = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(ArchivedPhotos.(5248));

              
               //this.ReportPropertyChanged("DG_Photos_pkey");
         
            }
		}

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
		public string DG_Photos_FileName
		{
			get
			{
				return this._DG_Photos_FileName;
			}
			set
			{
				do
				{
                    //this.ReportPropertyChanging(ArchivedPhotos.(5269));
                    this._DG_Photos_FileName = StructuralObject.SetValidValue(value, false);
               
                    ////do
                    ////{
                    ////    if (!false)
                    ////    {
                    ////        this.ReportPropertyChanged(ArchivedPhotos.(5269));
                    ////    }
                    ////}
                    ////while (false);
				}
				while (false);
			}
		}

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
		public DateTime DG_Photos_CreatedOn
		{
			get
			{
				return this._DG_Photos_CreatedOn;
			}
			set
			{
				//.ReportPropertyChanging(ArchivedPhotos.(5294));
			    this._DG_Photos_CreatedOn = StructuralObject.SetValidValue(value);
				//this.ReportPropertyChanged(ArchivedPhotos.(5294));

               
			}
		}

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
		public string DG_Photos_RFID
		{
			get
			{
				return this._DG_Photos_RFID;
			}
			set
			{
				do
				{
                    //this.ReportPropertyChanging(ArchivedPhotos.(5323));
                    this._DG_Photos_RFID = StructuralObject.SetValidValue(value, true);

                  
                    //do
                    //{
                    //    if (!false)
                    //    {
                    //        this.ReportPropertyChanged(ArchivedPhotos.(5323));
                    //    }
                    //}
                    //while (false);
				}
				while (false);
			}
		}

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
		public int? DG_Photos_UserID
		{
			get
			{
				return this._DG_Photos_UserID;
			}
			set
			{
                //this.ReportPropertyChanging(ArchivedPhotos.(5344));
                this._DG_Photos_UserID = StructuralObject.SetValidValue(value);
                //this.ReportPropertyChanged(ArchivedPhotos.(5344));

               
			}
		}

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
		public string DG_Photos_Background
		{
			get
			{
				return this._DG_Photos_Background;
			}
			set
			{
				do
				{
                    //this.ReportPropertyChanging(ArchivedPhotos.(5369));
                    this._DG_Photos_Background = StructuralObject.SetValidValue(value, true);
                    
                    //do
                    //{
                    //    if (!false)
                    //    {
                    //        this.ReportPropertyChanged(ArchivedPhotos.(5369));
                    //    }
                    //}
                    //while (false);
				}
				while (false);
			}
		}

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
		public string DG_Photos_Frame
		{
			get
			{
				return this._DG_Photos_Frame;
			}
			set
			{
				do
				{
                    //this.ReportPropertyChanging(ArchivedPhotos.(5398));
                    this._DG_Photos_Frame = StructuralObject.SetValidValue(value, true);
                  
                    //do
                    //{
                    //    if (!false)
                    //    {
                    //        this.ReportPropertyChanged(ArchivedPhotos.(5398));
                    //    }
                    //}
                    //while (false);
				}
				while (false);
			}
		}

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
		public DateTime? DG_Photos_DateTime
		{
			get
			{
				return this._DG_Photos_DateTime;
			}
			set
			{
                //this.ReportPropertyChanging(ArchivedPhotos.(5419));
                this._DG_Photos_DateTime = StructuralObject.SetValidValue(value);
                //this.ReportPropertyChanged(ArchivedPhotos.(5419));

               
			}
		}

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
		public string DG_Photos_Layering
		{
			get
			{
				return this._DG_Photos_Layering;
			}
			set
			{
				do
				{
                    //this.ReportPropertyChanging(ArchivedPhotos.(5444));
                    this._DG_Photos_Layering = StructuralObject.SetValidValue(value, true);
                   
                    //do
                    //{
                    //    if (!false)
                    //    {
                    //        this.ReportPropertyChanged(ArchivedPhotos.(5444));
                    //    }
                    //}
                    //while (false);
				}
				while (false);
			}
		}

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
		public string DG_Photos_Effects
		{
			get
			{
				return this._DG_Photos_Effects;
			}
			set
			{
				do
				{
                    //this.ReportPropertyChanging(ArchivedPhotos.(5469));
                    this._DG_Photos_Effects = StructuralObject.SetValidValue(value, true);
                   
                    //do
                    //{
                    //    if (!false)
                    //    {
                    //        this.ReportPropertyChanged(ArchivedPhotos.(5469));
                    //    }
                    //}
                    //while (false);
				}
				while (false);
			}
		}

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
		public bool? DG_Photos_IsCroped
		{
			get
			{
				return this._DG_Photos_IsCroped;
			}
			set
			{
                //this.ReportPropertyChanging(ArchivedPhotos.(5494));
                this._DG_Photos_IsCroped = StructuralObject.SetValidValue(value);
                //this.ReportPropertyChanged(ArchivedPhotos.(5494));

                
			}
		}

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
		public bool? DG_Photos_IsRedEye
		{
			get
			{
				return this._DG_Photos_IsRedEye;
			}
			set
			{
                //this.ReportPropertyChanging(ArchivedPhotos.(5519));
                this._DG_Photos_IsRedEye = StructuralObject.SetValidValue(value);
                //this.ReportPropertyChanged(ArchivedPhotos.(5519));

                this._DG_Photos_IsRedEye =  value;
			}
		}

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
		public bool? DG_Photos_IsGreen
		{
			get
			{
				return this._DG_Photos_IsGreen;
			}
			set
			{
				//this.ReportPropertyChanging(ArchivedPhotos.(5544));
				this._DG_Photos_IsGreen = StructuralObject.SetValidValue(value);
			//	this.ReportPropertyChanged(ArchivedPhotos.(5544));
			}
		}

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
		public string DG_Photos_MetaData
		{
			get
			{
				return this._DG_Photos_MetaData;
			}
			set
			{
				do
				{
					//this.ReportPropertyChanging(ArchivedPhotos.(5569));
					this._DG_Photos_MetaData = StructuralObject.SetValidValue(value, true);
                    //do
                    //{
                    //    if (!false)
                    //    {
                    //        this.ReportPropertyChanged(ArchivedPhotos.(5569));
                    //    }
                    //}
                    //while (false);
				}
				while (false);
			}
		}

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
		public string DG_Photos_Sizes
		{
			get
			{
				return this._DG_Photos_Sizes;
			}
			set
			{
				do
				{
					//this.ReportPropertyChanging(ArchivedPhotos.(5594));
					this._DG_Photos_Sizes = StructuralObject.SetValidValue(value, true);
                    //do
                    //{
                    //    if (!false)
                    //    {
                    //        this.ReportPropertyChanged(ArchivedPhotos.(5594));
                    //    }
                    //}
                    //while (false);
				}
				while (false);
			}
		}

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
		public bool? DG_Photos_Archive
		{
			get
			{
				return this._DG_Photos_Archive;
			}
			set
			{
				//this.ReportPropertyChanging(ArchivedPhotos.(5615));
				this._DG_Photos_Archive = StructuralObject.SetValidValue(value);
			//	this.ReportPropertyChanged(ArchivedPhotos.(5615));
			}
		}

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
		public int? DG_Location_Id
		{
			get
			{
				return this._DG_Location_Id;
			}
			set
			{
				//this.ReportPropertyChanging(ArchivedPhotos.(5640));
				this._DG_Location_Id = StructuralObject.SetValidValue(value);
				//this.ReportPropertyChanged(ArchivedPhotos.(5640));
			}
		}

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
		public int? DG_SubStoreId
		{
			get
			{
				return this._DG_SubStoreId;
			}
			set
			{
				//this.ReportPropertyChanging(ArchivedPhotos.(5661));
				this._DG_SubStoreId = StructuralObject.SetValidValue(value);
				//this.ReportPropertyChanged(ArchivedPhotos.(5661));
			}
		}

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
		public DateTime CreatedOn
		{
			get
			{
				return this._CreatedOn;
			}
			set
			{
			//	this.ReportPropertyChanging(ArchivedPhotos.(5682));
				this._CreatedOn = StructuralObject.SetValidValue(value);
			//	this.ReportPropertyChanged(ArchivedPhotos.(5682));
			}
		}

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
		public bool FileDeleted
		{
			get
			{
				return this._FileDeleted;
			}
			set
			{
				//this.ReportPropertyChanging(ArchivedPhotos.(5695));
				this._FileDeleted = StructuralObject.SetValidValue(value);
				//this.ReportPropertyChanged(ArchivedPhotos.(5695));
			}
		}

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
		public DateTime? FileDeletedOn
		{
			get
			{
				return this._FileDeletedOn;
			}
			set
			{
				//this.ReportPropertyChanging(ArchivedPhotos.(5712));
				this._FileDeletedOn = StructuralObject.SetValidValue(value);
            //this.ReportPropertyChanged(ArchivedPhotos.(5712));
			}
		}

		public static ArchivedPhotos CreateArchivedPhotos(long archivedPhotoId, int dG_Photos_pkey, string dG_Photos_FileName, DateTime dG_Photos_CreatedOn, DateTime createdOn, bool fileDeleted)
		{
			ArchivedPhotos archivedPhotos = new ArchivedPhotos();
			while (true)
			{
				archivedPhotos.ArchivedPhotoId = archivedPhotoId;
				while (!false)
				{
					archivedPhotos.DG_Photos_pkey = dG_Photos_pkey;
					if (6 != 0)
					{
						archivedPhotos.DG_Photos_FileName = dG_Photos_FileName;
					}
					archivedPhotos.DG_Photos_CreatedOn = dG_Photos_CreatedOn;
					do
					{
						archivedPhotos.CreatedOn = createdOn;
					}
					while (false);
					archivedPhotos.FileDeleted = fileDeleted;
					if (-1 != 0)
					{
						return archivedPhotos;
					}
				}
			}
			return archivedPhotos;
		}



        }
    }
