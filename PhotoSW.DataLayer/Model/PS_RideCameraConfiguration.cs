using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmEntityType(NamespaceName = "DigiphotoModel", Name = "DG_RideCameraConfiguration"), DataContract(IsReference = true)]
    [Serializable]
    public class PS_RideCameraConfiguration : EntityObject
        {
        private int _PS_RideCamera_pkey;

        private string _PS_RideCamera_Id;

        private string _AcquisitionFrameCount;

        private string _AcquisitionFrameRateAbs;

        private string _AcquisitionFrameRateLimit;

        private string _AcquisitionMode;

        private string _BalanceRatioAbs;

        private string _BalanceRatioSelector;

        private string _BalanceWhiteAuto;

        private string _BalanceWhiteAutoAdjustTol;

        private string _BalanceWhiteAutoRate;

        private string _EventSelector;

        private string _EventsEnable1;

        private string _ExposureAuto;

        private string _ExposureAutoAdjustTol;

        private string _ExposureAutoAlg;

        private string _ExposureAutoMax;

        private string _ExposureAutoMin;

        private string _ExposureAutoOutliers;

        private string _ExposureAutoRate;

        private string _ExposureAutoTarget;

        private string _ExposureTimeAbs;

        private string _GainAuto;

        private string _GainAutoAdjustTol;

        private string _GainAutoMax;

        private string _GainAutoMin;

        private string _GainAutoOutliers;

        private string _GainAutoRate;

        private string _GainAutoTarget;

        private string _GainRaw;

        private string _GainSelector;

        private string _StrobeDelay;

        private string _StrobeDuration;

        private string _StrobeDurationMode;

        private string _StrobeSource;

        private string _SyncInGlitchFilter;

        private string _SyncInLevels;

        private string _SyncInSelector;

        private string _SyncOutLevels;

        private string _SyncOutPolarity;

        private string _SyncOutSelector;

        private string _SyncOutSource;

        private string _TriggerActivation;

        private string _TriggerDelayAbs;

        private string _TriggerMode;

        private string _TriggerOverlap;

        private string _TriggerSelector;

        private string _TriggerSource;

        private string _UserSetDefaultSelector;

        private string _UserSetSelector;

        private string _Width;

        private string _WidthMax;

        private string _Height;

        private string _HeightMax;

        private string _ImageSize;

        //[NonSerialized]
        //internal static GetString ;

		[EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public int PS_RideCamera_pkey
            {
            get
                {
                return this._PS_RideCamera_pkey;
                }
            set
                {
                if(!true)
                    {
                    goto IL_29;
                    }
                if(this._PS_RideCamera_pkey == value)
                    {
                    goto IL_42;
                    }
                IL_0E:
               // this.ReportPropertyChanging(DG_RideCameraConfiguration.(13968));
                this._PS_RideCamera_pkey = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
              //  this.ReportPropertyChanged(DG_RideCameraConfiguration.(13968));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_RideCamera_Id
            {
            get
                {
                return this._PS_RideCamera_Id;
                }
            set
                {
                do
                    {
                   // this.ReportPropertyChanging(DG_RideCameraConfiguration.(13993));
                    this._PS_RideCamera_Id = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_RideCameraConfiguration.(13993));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string AcquisitionFrameCount
            {
            get
                {
                return this._AcquisitionFrameCount;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(DG_RideCameraConfiguration.(14018));
                    this._AcquisitionFrameCount = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_RideCameraConfiguration.(14018));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string AcquisitionFrameRateAbs
            {
            get
                {
                return this._AcquisitionFrameRateAbs;
                }
            set
                {
                do
                    {
                   // this.ReportPropertyChanging(DG_RideCameraConfiguration.(14047));
                    this._AcquisitionFrameRateAbs = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_RideCameraConfiguration.(14047));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string AcquisitionFrameRateLimit
            {
            get
                {
                return this._AcquisitionFrameRateLimit;
                }
            set
                {
                do
                    {
                   // this.ReportPropertyChanging(DG_RideCameraConfiguration.(14080));
                    this._AcquisitionFrameRateLimit = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_RideCameraConfiguration.(14080));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string AcquisitionMode
            {
            get
                {
                return this._AcquisitionMode;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(DG_RideCameraConfiguration.(14117));
                    this._AcquisitionMode = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_RideCameraConfiguration.(14117));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string BalanceRatioAbs
            {
            get
                {
                return this._BalanceRatioAbs;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(DG_RideCameraConfiguration.(14138));
                    this._BalanceRatioAbs = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_RideCameraConfiguration.(14138));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string BalanceRatioSelector
            {
            get
                {
                return this._BalanceRatioSelector;
                }
            set
                {
                do
                    {
                 //   this.ReportPropertyChanging(DG_RideCameraConfiguration.(14159));
                    this._BalanceRatioSelector = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_RideCameraConfiguration.(14159));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string BalanceWhiteAuto
            {
            get
                {
                return this._BalanceWhiteAuto;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(DG_RideCameraConfiguration.(14188));
                    this._BalanceWhiteAuto = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_RideCameraConfiguration.(14188));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string BalanceWhiteAutoAdjustTol
            {
            get
                {
                return this._BalanceWhiteAutoAdjustTol;
                }
            set
                {
                do
                    {
                //    this.ReportPropertyChanging(DG_RideCameraConfiguration.(14213));
                    this._BalanceWhiteAutoAdjustTol = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_RideCameraConfiguration.(14213));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string BalanceWhiteAutoRate
            {
            get
                {
                return this._BalanceWhiteAutoRate;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(DG_RideCameraConfiguration.(14250));
                    this._BalanceWhiteAutoRate = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_RideCameraConfiguration.(14250));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string EventSelector
            {
            get
                {
                return this._EventSelector;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(DG_RideCameraConfiguration.(14279));
                    this._EventSelector = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_RideCameraConfiguration.(14279));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string EventsEnable1
            {
            get
                {
                return this._EventsEnable1;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(DG_RideCameraConfiguration.(14300));
                    this._EventsEnable1 = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_RideCameraConfiguration.(14300));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string ExposureAuto
            {
            get
                {
                return this._ExposureAuto;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(DG_RideCameraConfiguration.(14321));
                    this._ExposureAuto = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_RideCameraConfiguration.(14321));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string ExposureAutoAdjustTol
            {
            get
                {
                return this._ExposureAutoAdjustTol;
                }
            set
                {
                do
                    {
                   // this.ReportPropertyChanging(DG_RideCameraConfiguration.(14338));
                    this._ExposureAutoAdjustTol = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_RideCameraConfiguration.(14338));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string ExposureAutoAlg
            {
            get
                {
                return this._ExposureAutoAlg;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(DG_RideCameraConfiguration.(14367));
                    this._ExposureAutoAlg = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_RideCameraConfiguration.(14367));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string ExposureAutoMax
            {
            get
                {
                return this._ExposureAutoMax;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(DG_RideCameraConfiguration.(14388));
                    this._ExposureAutoMax = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_RideCameraConfiguration.(14388));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string ExposureAutoMin
            {
            get
                {
                return this._ExposureAutoMin;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(DG_RideCameraConfiguration.(14409));
                    this._ExposureAutoMin = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_RideCameraConfiguration.(14409));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string ExposureAutoOutliers
            {
            get
                {
                return this._ExposureAutoOutliers;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(DG_RideCameraConfiguration.(14430));
                    this._ExposureAutoOutliers = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_RideCameraConfiguration.(14430));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string ExposureAutoRate
            {
            get
                {
                return this._ExposureAutoRate;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(DG_RideCameraConfiguration.(14459));
                    this._ExposureAutoRate = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_RideCameraConfiguration.(14459));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string ExposureAutoTarget
            {
            get
                {
                return this._ExposureAutoTarget;
                }
            set
                {
                do
                    {
                   // this.ReportPropertyChanging(DG_RideCameraConfiguration.(14484));
                    this._ExposureAutoTarget = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_RideCameraConfiguration.(14484));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string ExposureTimeAbs
            {
            get
                {
                return this._ExposureTimeAbs;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(DG_RideCameraConfiguration.(14509));
                    this._ExposureTimeAbs = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_RideCameraConfiguration.(14509));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string GainAuto
            {
            get
                {
                return this._GainAuto;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(DG_RideCameraConfiguration.(14530));
                    this._GainAuto = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_RideCameraConfiguration.(14530));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string GainAutoAdjustTol
            {
            get
                {
                return this._GainAutoAdjustTol;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(DG_RideCameraConfiguration.(14543));
                    this._GainAutoAdjustTol = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_RideCameraConfiguration.(14543));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string GainAutoMax
            {
            get
                {
                return this._GainAutoMax;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(DG_RideCameraConfiguration.(14568));
                    this._GainAutoMax = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_RideCameraConfiguration.(14568));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string GainAutoMin
            {
            get
                {
                return this._GainAutoMin;
                }
            set
                {
                do
                    {
                   // this.ReportPropertyChanging(DG_RideCameraConfiguration.(14585));
                    this._GainAutoMin = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_RideCameraConfiguration.(14585));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string GainAutoOutliers
            {
            get
                {
                return this._GainAutoOutliers;
                }
            set
                {
                do
                    {
                   // this.ReportPropertyChanging(DG_RideCameraConfiguration.(14602));
                    this._GainAutoOutliers = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_RideCameraConfiguration.(14602));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string GainAutoRate
            {
            get
                {
                return this._GainAutoRate;
                }
            set
                {
                do
                    {
                   // this.ReportPropertyChanging(DG_RideCameraConfiguration.(14627));
                    this._GainAutoRate = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_RideCameraConfiguration.(S14627));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string GainAutoTarget
            {
            get
                {
                return this._GainAutoTarget;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(DG_RideCameraConfiguration.(14644));
                    this._GainAutoTarget = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_RideCameraConfiguration.(14644));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string GainRaw
            {
            get
                {
                return this._GainRaw;
                }
            set
                {
                do
                    {
                   // this.ReportPropertyChanging(DG_RideCameraConfiguration.(14665));
                    this._GainRaw = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_RideCameraConfiguration.(14665));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string GainSelector
            {
            get
                {
                return this._GainSelector;
                }
            set
                {
                do
                    {
                 //   this.ReportPropertyChanging(DG_RideCameraConfiguration.(14678));
                    this._GainSelector = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_RideCameraConfiguration.(14678));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string StrobeDelay
            {
            get
                {
                return this._StrobeDelay;
                }
            set
                {
                do
                    {
                 //   this.ReportPropertyChanging(DG_RideCameraConfiguration.(14695));
                    this._StrobeDelay = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_RideCameraConfiguration.(14695));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string StrobeDuration
            {
            get
                {
                return this._StrobeDuration;
                }
            set
                {
                do
                    {
                   // this.ReportPropertyChanging(DG_RideCameraConfiguration.(14712));
                    this._StrobeDuration = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_RideCameraConfiguration.(14712));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string StrobeDurationMode
            {
            get
                {
                return this._StrobeDurationMode;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(DG_RideCameraConfiguration.(14733));
                    this._StrobeDurationMode = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_RideCameraConfiguration.(14733));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string StrobeSource
            {
            get
                {
                return this._StrobeSource;
                }
            set
                {
                do
                    {
                 //   this.ReportPropertyChanging(DG_RideCameraConfiguration.(14758));
                    this._StrobeSource = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_RideCameraConfiguration.(14758));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string SyncInGlitchFilter
            {
            get
                {
                return this._SyncInGlitchFilter;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(DG_RideCameraConfiguration.(14775));
                    this._SyncInGlitchFilter = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_RideCameraConfiguration.(14775));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string SyncInLevels
            {
            get
                {
                return this._SyncInLevels;
                }
            set
                {
                do
                    {
                 //   this.ReportPropertyChanging(DG_RideCameraConfiguration.(14800));
                    this._SyncInLevels = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_RideCameraConfiguration.(14800));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string SyncInSelector
            {
            get
                {
                return this._SyncInSelector;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(DG_RideCameraConfiguration.(14817));
                    this._SyncInSelector = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_RideCameraConfiguration.(14817));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string SyncOutLevels
            {
            get
                {
                return this._SyncOutLevels;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(DG_RideCameraConfiguration.(14838));
                    this._SyncOutLevels = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_RideCameraConfiguration.(14838));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string SyncOutPolarity
            {
            get
                {
                return this._SyncOutPolarity;
                }
            set
                {
                do
                    {
                 //   this.ReportPropertyChanging(DG_RideCameraConfiguration.(14859));
                    this._SyncOutPolarity = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_RideCameraConfiguration.(14859));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string SyncOutSelector
            {
            get
                {
                return this._SyncOutSelector;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(DG_RideCameraConfiguration.(14880));
                    this._SyncOutSelector = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_RideCameraConfiguration.(14880));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string SyncOutSource
            {
            get
                {
                return this._SyncOutSource;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(DG_RideCameraConfiguration.(14901));
                    this._SyncOutSource = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_RideCameraConfiguration.(14901));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string TriggerActivation
            {
            get
                {
                return this._TriggerActivation;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(DG_RideCameraConfiguration.(14922));
                    this._TriggerActivation = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_RideCameraConfiguration.(14922));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string TriggerDelayAbs
            {
            get
                {
                return this._TriggerDelayAbs;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(DG_RideCameraConfiguration.(14947));
                    this._TriggerDelayAbs = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_RideCameraConfiguration.(14947));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string TriggerMode
            {
            get
                {
                return this._TriggerMode;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(DG_RideCameraConfiguration.(14968));
                    this._TriggerMode = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_RideCameraConfiguration.(14968));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string TriggerOverlap
            {
            get
                {
                return this._TriggerOverlap;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(DG_RideCameraConfiguration.(14985));
                    this._TriggerOverlap = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_RideCameraConfiguration.(14985));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string TriggerSelector
            {
            get
                {
                return this._TriggerSelector;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(DG_RideCameraConfiguration.(15006));
                    this._TriggerSelector = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_RideCameraConfiguration.(15006));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string TriggerSource
            {
            get
                {
                return this._TriggerSource;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(DG_RideCameraConfiguration.(15027));
                    this._TriggerSource = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_RideCameraConfiguration.(15027));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string UserSetDefaultSelector
            {
            get
                {
                return this._UserSetDefaultSelector;
                }
            set
                {
                do
                    {
                 //   this.ReportPropertyChanging(DG_RideCameraConfiguration.(15048));
                    this._UserSetDefaultSelector = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_RideCameraConfiguration.(15048));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string UserSetSelector
            {
            get
                {
                return this._UserSetSelector;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(DG_RideCameraConfiguration.(15081));
                    this._UserSetSelector = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_RideCameraConfiguration.(15081));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string Width
            {
            get
                {
                return this._Width;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(DG_RideCameraConfiguration.(15102));
					this._Width = StructuralObject.SetValidValue(value, true);
					//do
					//{
					//	if (!false)
					//	{
					//		this.ReportPropertyChanged(DG_RideCameraConfiguration.(15102));
					//	}
					//}
					//while (false);
				}
				while (false);
			}
		}

		[EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
		public string WidthMax
		{
			get
			{
				return this._WidthMax;
			}
			set
			{
				do
				{
					//this.ReportPropertyChanging(DG_RideCameraConfiguration.(15111));
					this._WidthMax = StructuralObject.SetValidValue(value, true);
					//do
					//{
					//	if (!false)
					//	{
					//		this.ReportPropertyChanged(DG_RideCameraConfiguration.(15111));
					//	}
					//}
					//while (false);
				}
				while (false);
			}
		}

		[EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
		public string Height
		{
			get
			{
				return this._Height;
			}
			set
			{
				do
				{
					//this.ReportPropertyChanging(DG_RideCameraConfiguration.(15124));
					this._Height = StructuralObject.SetValidValue(value, true);
					//do
					//{
					//	if (!false)
					//	{
					//		this.ReportPropertyChanged(DG_RideCameraConfiguration.(15124));
					//	}
					//}
					//while (false);
				}
				while (false);
			}
		}

		[EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
		public string HeightMax
		{
			get
			{
				return this._HeightMax;
			}
			set
			{
				do
				{
					//this.ReportPropertyChanging(DG_RideCameraConfiguration.(15133));
					this._HeightMax = StructuralObject.SetValidValue(value, true);
					//do
					//{
					//	if (!false)
					//	{
					//		this.ReportPropertyChanged(DG_RideCameraConfiguration.(15133));
					//	}
					//}
					//while (false);
				}
				while (false);
			}
		}

		[EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
		public string ImageSize
		{
			get
			{
				return this._ImageSize;
			}
			set
			{
				do
				{
					//this.ReportPropertyChanging(DG_RideCameraConfiguration.(15146));
					this._ImageSize = StructuralObject.SetValidValue(value, false);
					//do
					//{
					//	if (!false)
					//	{
					//		this.ReportPropertyChanged(DG_RideCameraConfiguration.(15146));
					//	}
					//}
					//while (false);
				}
				while (false);
			}
		}

		public static PS_RideCameraConfiguration CreateDG_RideCameraConfiguration(int dG_RideCamera_pkey, string imageSize)
		{
			return new PS_RideCameraConfiguration
			{
				PS_RideCamera_pkey = dG_RideCamera_pkey,
				ImageSize = imageSize
			};
		}

		static PS_RideCameraConfiguration()
		{
			// Note: this type is marked as 'beforefieldinit'.
			//Strings.CreateGetStringDelegate(typeof(DG_RideCameraConfiguration));
		}

        }
    }
