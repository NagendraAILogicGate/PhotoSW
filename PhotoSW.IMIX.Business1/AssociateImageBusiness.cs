using DigiPhoto.IMIX.DataAccess;
using DigiPhoto.IMIX.Model;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace DigiPhoto.IMIX.Business
{
	public class AssociateImageBusiness : BaseBusiness
	{
		[CompilerGenerated]
		private sealed class 
		{
			public AssociateImageBusiness ;

			public string ;

			public bool ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public AssociateImageBusiness. ;

			public List<iMixImageAssociationInfo> ;

			public void ()
			{
				IMixImageAssociationDao mixImageAssociationDao = new IMixImageAssociationDao(this...Transaction);
				this. = mixImageAssociationDao.GetUniqueCodeExists(this.., this..);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public string ;

			public AssociateImageBusiness ;

			public string ;

			public string ;

			public int ;

			public bool ;

			public void ()
			{
				AssociatedImageDao associatedImageDao = new AssociatedImageDao(this..Transaction);
				this. = associatedImageDao.AssociateImage(this., this., this., this.);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public AssociateImageBusiness ;

			public string ;

			public int ;

			public void ()
			{
				do
				{
					AssociatedImageDao associatedImageDao;
					if (!false)
					{
						associatedImageDao = new AssociatedImageDao(this..Transaction);
					}
					associatedImageDao.AssociateMobileImage(this., this.);
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public AssociateImageBusiness ;

			public int ;

			public int ;

			public void ()
			{
				do
				{
					AssociatedImageDao associatedImageDao;
					if (!false)
					{
						associatedImageDao = new AssociatedImageDao(this..Transaction);
					}
					associatedImageDao.AssociateVideos(this., this.);
				}
				while (false);
			}
		}

		public bool IsUniqueCodeExists(string QRCode, bool IsAnonymousQrCodeEnabled)
		{
			AssociateImageBusiness.  = new AssociateImageBusiness.();
			. = QRCode;
			bool result;
			while (true)
			{
				. = IsAnonymousQrCodeEnabled;
				while (true)
				{
					. = this;
					try
					{
						AssociateImageBusiness.  = new AssociateImageBusiness.();
						. = ;
						. = new List<iMixImageAssociationInfo>();
						this.operation = new BaseBusiness.TransactionMethod(.);
						while (true)
						{
							if (8 == 0)
							{
								goto IL_6C;
							}
							int arg_80_0 = base.Start(false) ? 1 : 0;
							if (!false)
							{
								goto IL_6C;
							}
							IL_7F:
							if (arg_80_0 <= 0)
							{
								goto IL_8C;
							}
							result = true;
							if (false)
							{
								break;
							}
							if (!false)
							{
								break;
							}
							continue;
							IL_6C:
							if (. != null)
							{
								arg_80_0 = ..Count;
								goto IL_7F;
							}
							goto IL_8C;
						}
						goto IL_9C;
						IL_8C:
						result = false;
					}
					catch
					{
						result = false;
					}
					IL_9C:
					if (5 == 0)
					{
						break;
					}
					if (!false)
					{
						return result;
					}
				}
			}
			return result;
		}

		public string AssociateImage(int CodeType, string QRCode, string PhotoIds, int OverWriteStatus, bool IsAnonymousEnabled)
		{
			AssociateImageBusiness.  = new AssociateImageBusiness.();
			. = QRCode;
			. = PhotoIds;
			. = OverWriteStatus;
			. = IsAnonymousEnabled;
			. = this;
			. = string.Empty;
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
			return ..ToString();
		}

		public void AssociateMobileImage(string QRCode, int PhotoId)
		{
			AssociateImageBusiness.  = new AssociateImageBusiness.();
			. = QRCode;
			. = PhotoId;
			. = this;
			string arg_24_0 = string.Empty;
			do
			{
				if (!false)
				{
					this.operation = new BaseBusiness.TransactionMethod(.);
				}
				base.Start(false);
			}
			while (2 == 0);
		}

		public void AssociateVideos(int PhotoId, int VideoId)
		{
			AssociateImageBusiness.  = new AssociateImageBusiness.();
			. = PhotoId;
			. = VideoId;
			. = this;
			string arg_24_0 = string.Empty;
			do
			{
				if (!false)
				{
					this.operation = new BaseBusiness.TransactionMethod(.);
				}
				base.Start(false);
			}
			while (2 == 0);
		}
	}
}
