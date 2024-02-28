using DigiPhoto.IMIX.DataAccess;
using DigiPhoto.IMIX.Model;
using ErrorHandler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;

namespace DigiPhoto.IMIX.Business
{
	public class RfidBusiness : BaseBusiness
	{
		[CompilerGenerated]
		private sealed class 
		{
			public RfidBusiness ;

			public RFIDTagInfo ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public RfidBusiness. ;

			public bool ;

			public void ()
			{
				if (4 != 0)
				{
					RfidAccess rfidAccess = new RfidAccess(this...Transaction);
					if (!false)
					{
						this. = rfidAccess.SaveRfidTag(this..);
					}
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public RfidBusiness ;

			public DataTable ;

			public string ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public RfidBusiness. ;

			public bool ;

			public void ()
			{
				RfidAccess rfidAccess = new RfidAccess(this...Transaction);
				this. = rfidAccess.AssociateRFIDtoPhotosAdvance(this.., this..);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public List<RFIDField> ;

			public RfidBusiness ;

			public void ()
			{
				RfidAccess rfidAccess = new RfidAccess(this..Transaction);
				this. = rfidAccess.GetSubStoreList();
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public bool ;

			public RfidBusiness ;

			public void ()
			{
				RfidAccess rfidAccess = new RfidAccess(this..Transaction);
				this. = rfidAccess.AssociateRFIDtoPhotos();
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public RfidBusiness ;

			public int ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public RfidBusiness. ;

			public bool ;

			public void ()
			{
				if (4 != 0)
				{
					RfidAccess rfidAccess = new RfidAccess(this...Transaction);
					if (!false)
					{
						this. = rfidAccess.ArchiveRFIDTags(this..);
					}
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public RfidBusiness ;

			public RFIDTagInfo ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public RfidBusiness. ;

			public bool ;

			public void ()
			{
				if (4 != 0)
				{
					RfidAccess rfidAccess = new RfidAccess(this...Transaction);
					if (!false)
					{
						this. = rfidAccess.SaveDummyRFIDTagsInfo(this..);
					}
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public bool ;

			public RfidBusiness ;

			public int ;

			public void ()
			{
				do
				{
					RfidAccess rfidAccess;
					if (!false)
					{
						rfidAccess = new RfidAccess(this..Transaction);
					}
					this. = rfidAccess.DeleteDummyRFIDTagsInfo(this.);
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public List<RFIDImageAssociationInfo> ;

			public RfidBusiness ;

			public int ;

			public int ;

			public DateTime ;

			public DateTime ;

			public void ()
			{
				RfidAccess rfidAccess = new RfidAccess(this..Transaction);
				this. = rfidAccess.GetRFIDAssociationSearch(this., this., this., this.);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public List<PhotoDetail> ;

			public RfidBusiness ;

			public RFIDPhotoDetails ;

			public void ()
			{
				do
				{
					RfidAccess rfidAccess;
					if (!false)
					{
						rfidAccess = new RfidAccess(this..Transaction);
					}
					this. = rfidAccess.GetRFIDNotAssociatedPhotos(this.);
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public List<RFIDTagInfo> ;

			public RfidBusiness ;

			public int ;

			public void ()
			{
				do
				{
					RfidAccess rfidAccess;
					if (!false)
					{
						rfidAccess = new RfidAccess(this..Transaction);
					}
					this. = rfidAccess.GetDummyRFIDTagsInfo(this.);
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public RfidBusiness ;

			public string ;

			public string ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public RfidBusiness. ;

			public bool ;

			public void ()
			{
				RfidAccess rfidAccess = new RfidAccess(this...Transaction);
				this. = rfidAccess.MapNonAssociatedImages(this.., this..);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public int? ;

			public RfidBusiness ;

			public int ;

			public void ()
			{
				do
				{
					RfidAccess rfidAccess;
					if (!false)
					{
						rfidAccess = new RfidAccess(this..Transaction);
					}
					this. = rfidAccess.GetPhotographerRFIDEnabledLocation(this.);
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public List<RfidFlushHistotyInfo> ;

			public RfidBusiness ;

			public int ;

			public DateTime ;

			public DateTime ;

			public void ()
			{
				while (true)
				{
					RfidAccess rfidAccess;
					if (-1 != 0)
					{
						rfidAccess = new RfidAccess(this..Transaction);
						goto IL_10;
					}
					IL_33:
					if (!false)
					{
						if (false)
						{
							continue;
						}
						if (5 != 0)
						{
							break;
						}
					}
					IL_10:
					this. = rfidAccess.GetFlushHistoryData(this., this., this.);
					goto IL_33;
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public RfidBusiness ;

			public RfidFlushHistotyInfo ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public RfidBusiness. ;

			public bool ;

			public void ()
			{
				if (4 != 0)
				{
					RfidAccess rfidAccess = new RfidAccess(this...Transaction);
					if (!false)
					{
						this. = rfidAccess.SaveRfidFlushHistory(this..);
					}
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public RfidBusiness ;

			public int ;

			public int ;

			public int ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public RfidBusiness. ;

			public bool ;

			public void ()
			{
				RfidAccess rfidAccess = new RfidAccess(this...Transaction);
				this. = rfidAccess.RfidFlushNow(this.., this.., this..);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public List<LocationInfo> ;

			public RfidBusiness ;

			public void ()
			{
				RfidAccess rfidAccess = new RfidAccess(this..Transaction);
				this. = rfidAccess.GetAllLocations();
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public RfidBusiness ;

			public SeperatorTagInfo ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public RfidBusiness. ;

			public bool ;

			public void ()
			{
				if (4 != 0)
				{
					RfidAccess rfidAccess = new RfidAccess(this...Transaction);
					if (!false)
					{
						this. = rfidAccess.SaveSeperatorRFIDTagsInfo(this..);
					}
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public RfidBusiness ;

			public int ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public RfidBusiness. ;

			public bool ;

			public void ()
			{
				if (4 != 0)
				{
					RfidAccess rfidAccess = new RfidAccess(this...Transaction);
					if (!false)
					{
						this. = rfidAccess.DeleteSeperatorRFIDTagsInfo(this..);
					}
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public List<SeperatorTagInfo> ;

			public RfidBusiness ;

			public int ;

			public void ()
			{
				do
				{
					RfidAccess rfidAccess;
					if (!false)
					{
						rfidAccess = new RfidAccess(this..Transaction);
					}
					this. = rfidAccess.GetSeperatorRFIDTagsInfo(this.);
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public List<PhotographerRFIDAssociationInfo> ;

			public RfidBusiness ;

			public int? ;

			public DateTime ;

			public DateTime ;

			public void ()
			{
				while (true)
				{
					RfidAccess rfidAccess;
					if (-1 != 0)
					{
						rfidAccess = new RfidAccess(this..Transaction);
						goto IL_10;
					}
					IL_33:
					if (!false)
					{
						if (false)
						{
							continue;
						}
						if (5 != 0)
						{
							break;
						}
					}
					IL_10:
					this. = rfidAccess.GetPhotographerRFIDAssociation(this., this., this.);
					goto IL_33;
				}
			}
		}

		public bool SaveRfidTag(RFIDTagInfo rfidTag)
		{
			RfidBusiness.  = new RfidBusiness.();
			. = rfidTag;
			. = this;
			bool result;
			try
			{
				RfidBusiness.  = new RfidBusiness.();
				do
				{
					. = ;
					if (4 != 0)
					{
						. = false;
						this.operation = new BaseBusiness.TransactionMethod(.);
						if (false)
						{
							goto IL_68;
						}
						if (!false)
						{
							base.Start(false);
						}
					}
					if (false)
					{
						continue;
					}
					result = .;
					IL_68:;
				}
				while (6 == 0);
			}
			catch (Exception serviceException)
			{
				ErrorHandler.LogFileWrite(ErrorHandler.CreateErrorMessage(serviceException));
				result = false;
			}
			return result;
		}

		public bool AssociateRFIDtoPhotosAdvance(DataTable dt_Rfid, string SerailNo)
		{
			RfidBusiness.  = new RfidBusiness.();
			. = dt_Rfid;
			bool result;
			if (!false)
			{
				. = SerailNo;
				. = this;
				try
				{
					if (!false)
					{
					}
					. = ;
					. = false;
					if (6 != 0)
					{
						this.operation = new BaseBusiness.TransactionMethod(.);
						base.Start(false);
					}
					result = .;
				}
				catch (Exception serviceException)
				{
					ErrorHandler.LogFileWrite(ErrorHandler.CreateErrorMessage(serviceException));
					result = false;
				}
			}
			return result;
		}

		public List<RFIDField> GetSubStoreList()
		{
			if (!false)
			{
				if (!false)
				{
				}
				do
				{
					. = this;
				}
				while (false);
				. = new List<RFIDField>();
				do
				{
					this.operation = new BaseBusiness.TransactionMethod(.);
				}
				while (2 == 0);
				base.Start(false);
			}
			return .;
		}

		public bool AssociateRFIDtoPhotos()
		{
			bool result;
			try
			{
				RfidBusiness.  = new RfidBusiness.();
				if (4 == 0)
				{
					goto IL_3F;
				}
				. = this;
				bool expr_36;
				while (true)
				{
					IL_10:
					. = false;
					this.operation = new BaseBusiness.TransactionMethod(.);
					base.Start(false);
					while (7 != 0)
					{
						expr_36 = .;
						if (2 != 0)
						{
							goto Block_4;
						}
					}
				}
				Block_4:
				result = expr_36;
				IL_3F:
				if (false)
				{
					goto IL_10;
				}
			}
			catch (Exception serviceException)
			{
				if (6 != 0)
				{
					ErrorHandler.LogFileWrite(ErrorHandler.CreateErrorMessage(serviceException));
					result = false;
				}
			}
			return result;
		}

		public bool ArchiveRFIDTags(int subStoreId)
		{
			RfidBusiness.  = new RfidBusiness.();
			. = subStoreId;
			. = this;
			bool result;
			try
			{
				RfidBusiness.  = new RfidBusiness.();
				do
				{
					. = ;
					if (4 != 0)
					{
						. = false;
						this.operation = new BaseBusiness.TransactionMethod(.);
						if (false)
						{
							goto IL_68;
						}
						if (!false)
						{
							base.Start(false);
						}
					}
					if (false)
					{
						continue;
					}
					result = .;
					IL_68:;
				}
				while (6 == 0);
			}
			catch (Exception serviceException)
			{
				ErrorHandler.LogFileWrite(ErrorHandler.CreateErrorMessage(serviceException));
				result = false;
			}
			return result;
		}

		public bool SaveUpdateDummyRFIDTags(RFIDTagInfo rfidTag)
		{
			RfidBusiness.  = new RfidBusiness.();
			. = rfidTag;
			. = this;
			bool result;
			try
			{
				RfidBusiness.  = new RfidBusiness.();
				do
				{
					. = ;
					if (4 != 0)
					{
						. = false;
						this.operation = new BaseBusiness.TransactionMethod(.);
						if (false)
						{
							goto IL_68;
						}
						if (!false)
						{
							base.Start(false);
						}
					}
					if (false)
					{
						continue;
					}
					result = .;
					IL_68:;
				}
				while (6 == 0);
			}
			catch (Exception serviceException)
			{
				ErrorHandler.LogFileWrite(ErrorHandler.CreateErrorMessage(serviceException));
				result = false;
			}
			return result;
		}

		public bool DeleteDummyRFIDTags(int DummyRFIDTagID)
		{
			RfidBusiness.  = new RfidBusiness.();
			. = DummyRFIDTagID;
			. = this;
			. = false;
			this.operation = new BaseBusiness.TransactionMethod(.);
			bool arg_46_0 = base.Start(false);
			do
			{
				if (5 != 0)
				{
					arg_46_0 = .;
				}
			}
			while (2 == 0);
			return arg_46_0;
		}

		public List<RFIDImageAssociationInfo> GetRFIDAssociationSearch(int photoGrapherId, int deviceId, DateTime dtFrom, DateTime dtTo)
		{
			RfidBusiness. ;
			do
			{
				 = new RfidBusiness.();
				do
				{
					IL_0A:
					. = photoGrapherId;
					. = deviceId;
					. = dtFrom;
					do
					{
						. = dtTo;
						if (false)
						{
							goto IL_0A;
						}
						. = this;
						if (!false)
						{
							. = new List<RFIDImageAssociationInfo>();
						}
					}
					while (false);
				}
				while (false);
				this.operation = new BaseBusiness.TransactionMethod(.);
				base.Start(false);
			}
			while (4 == 0);
			return .;
		}

		public List<PhotoDetail> GetRFIDNotAssociatedPhotos(RFIDPhotoDetails RFIDPhotoObj)
		{
			RfidBusiness.  = new RfidBusiness.();
			. = RFIDPhotoObj;
			. = this;
			. = new List<PhotoDetail>();
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
			return .;
		}

		public List<RFIDTagInfo> GetDummyRFIDTags(int DummyRFIDTagID)
		{
			RfidBusiness.  = new RfidBusiness.();
			. = DummyRFIDTagID;
			. = this;
			. = new List<RFIDTagInfo>();
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
			return .;
		}

		public bool MapNonAssociatedImages(string cardUniqueIdentifier, string photoIDS)
		{
			RfidBusiness.  = new RfidBusiness.();
			. = cardUniqueIdentifier;
			bool result;
			if (!false)
			{
				. = photoIDS;
				. = this;
				try
				{
					if (!false)
					{
					}
					. = ;
					. = false;
					if (6 != 0)
					{
						this.operation = new BaseBusiness.TransactionMethod(.);
						base.Start(false);
					}
					result = .;
				}
				catch (Exception serviceException)
				{
					ErrorHandler.LogFileWrite(ErrorHandler.CreateErrorMessage(serviceException));
					result = false;
				}
			}
			return result;
		}

		public int? GetPhotographerRFIDEnabledLocation(int photographerID)
		{
			RfidBusiness.  = new RfidBusiness.();
			. = photographerID;
			. = this;
			. = null;
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
			return .;
		}

		public List<RfidFlushHistotyInfo> GetFlushHistoryData(int SubStoreId, DateTime fromDate, DateTime toDate)
		{
			RfidBusiness.  = new RfidBusiness.();
			. = SubStoreId;
			. = fromDate;
			. = toDate;
			. = this;
			. = new List<RfidFlushHistotyInfo>();
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
			return .;
		}

		public bool SaveRfidFlushHistory(RfidFlushHistotyInfo rfidFlush)
		{
			if (!false && -1 != 0)
			{
			}
			. = rfidFlush;
			. = this;
			bool result;
			try
			{
				RfidBusiness.  = new RfidBusiness.();
				if (!false)
				{
					. = ;
				}
				. = false;
				this.operation = new BaseBusiness.TransactionMethod(.);
				bool arg_67_0 = base.Start(false);
				if (!false && 4 != 0)
				{
					arg_67_0 = .;
				}
				result = arg_67_0;
			}
			catch
			{
				result = false;
			}
			return result;
		}

		public bool RfidFlushNow(int SubStoreId, int LocationId, int NoOfExcludeDays)
		{
			bool result;
			do
			{
				if (false)
				{
					return result;
				}
				int  = LocationId;
				int  = NoOfExcludeDays;
			}
			while (false);
			. = this;
			try
			{
				RfidBusiness.  = new RfidBusiness.();
				. = ;
				if (6 != 0)
				{
					. = false;
					this.operation = new BaseBusiness.TransactionMethod(.);
					base.Start(false);
				}
				result = .;
			}
			catch
			{
				result = false;
			}
			return result;
		}

		public List<LocationInfo> GetAllLocations()
		{
			if (!false)
			{
				if (!false)
				{
				}
				do
				{
					. = this;
				}
				while (false);
				. = new List<LocationInfo>();
				do
				{
					this.operation = new BaseBusiness.TransactionMethod(.);
				}
				while (2 == 0);
				base.Start(false);
			}
			return .;
		}

		public bool SaveSeperatorRFIDTagsInfo(SeperatorTagInfo rfidTag)
		{
			RfidBusiness.  = new RfidBusiness.();
			. = rfidTag;
			. = this;
			bool result;
			try
			{
				RfidBusiness.  = new RfidBusiness.();
				do
				{
					. = ;
					if (4 != 0)
					{
						. = false;
						this.operation = new BaseBusiness.TransactionMethod(.);
						if (false)
						{
							goto IL_68;
						}
						if (!false)
						{
							base.Start(false);
						}
					}
					if (false)
					{
						continue;
					}
					result = .;
					IL_68:;
				}
				while (6 == 0);
			}
			catch (Exception serviceException)
			{
				ErrorHandler.LogFileWrite(ErrorHandler.CreateErrorMessage(serviceException));
				result = false;
			}
			return result;
		}

		public bool DeleteSeperatorTag(int seperatorTagID)
		{
			RfidBusiness.  = new RfidBusiness.();
			. = seperatorTagID;
			. = this;
			bool result;
			try
			{
				RfidBusiness.  = new RfidBusiness.();
				do
				{
					. = ;
					if (4 != 0)
					{
						. = false;
						this.operation = new BaseBusiness.TransactionMethod(.);
						if (false)
						{
							goto IL_68;
						}
						if (!false)
						{
							base.Start(false);
						}
					}
					if (false)
					{
						continue;
					}
					result = .;
					IL_68:;
				}
				while (6 == 0);
			}
			catch (Exception serviceException)
			{
				ErrorHandler.LogFileWrite(ErrorHandler.CreateErrorMessage(serviceException));
				result = false;
			}
			return result;
		}

		public List<SeperatorTagInfo> GetSeperatorRFIDTags(int seperatorRFIDTagID)
		{
			RfidBusiness.  = new RfidBusiness.();
			. = seperatorRFIDTagID;
			. = this;
			. = new List<SeperatorTagInfo>();
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
			return .;
		}

		public List<PhotographerRFIDAssociationInfo> GetPhotographerRFIDAssociation(int? photoGrapherId, DateTime dtFrom, DateTime dtTo)
		{
			RfidBusiness.  = new RfidBusiness.();
			. = photoGrapherId;
			. = dtFrom;
			. = dtTo;
			. = this;
			. = new List<PhotographerRFIDAssociationInfo>();
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
			return .;
		}
	}
}
