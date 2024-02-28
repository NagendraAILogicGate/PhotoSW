using DigiPhoto.IMIX.DataAccess;
using DigiPhoto.IMIX.Model;
using SmartAssembly.Delegates;
using SmartAssembly.HouseOfCards;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace DigiPhoto.IMIX.Business
{
	public class CardBusiness : BaseBusiness
	{
		[CompilerGenerated]
		private sealed class 
		{
			public ImageCardTypeInfo ;

			public CardBusiness ;

			public string ;

			public int ;

			public void ()
			{
				if (4 != 0)
				{
					CardTypeDao cardTypeDao = new CardTypeDao(this..Transaction);
					this. = cardTypeDao.GetValidCodeType(this., this.);
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public ImageCardTypeInfo ;

			public CardBusiness ;

			public int ;

			public void ()
			{
				do
				{
					CardTypeDao cardTypeDao;
					if (!false)
					{
						cardTypeDao = new CardTypeDao(this..Transaction);
					}
					this. = cardTypeDao.GetImageIdentificationType(this.);
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public ImageCardTypeInfo ;

			public CardBusiness ;

			public string ;

			public int ;

			public void ()
			{
				if (4 != 0)
				{
					CardTypeDao cardTypeDao = new CardTypeDao(this..Transaction);
					this. = cardTypeDao.IsValidPrepaidCodeType(this., this.);
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public ImageCardTypeInfo ;

			public CardBusiness ;

			public string ;

			public void ()
			{
				do
				{
					CardTypeDao cardTypeDao;
					if (!false)
					{
						cardTypeDao = new CardTypeDao(this..Transaction);
					}
					this. = cardTypeDao.GetCardImageLimitById(this.);
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public int ;

			public List<string> ;

			public CardBusiness ;

			public string ;

			public void ()
			{
				do
				{
					OrderDetailsDao orderDetailsDao;
					if (!false)
					{
						orderDetailsDao = new OrderDetailsDao(this..Transaction);
					}
					this. = orderDetailsDao.GetCardImageSoldById(this.);
				}
				while (false);
			}

			public void (string )
			{
				this. += .Split(new char[]
				{
					','
				}).Length;
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public List<iMixImageCardTypeInfo> ;

			public CardBusiness ;

			public void ()
			{
				CardTypeDao cardTypeDao = new CardTypeDao(this..Transaction);
				this. = cardTypeDao.SelectCardTypeList();
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public List<ImageCardTypeInfo> ;

			public CardBusiness ;

			public void ()
			{
				CardTypeDao cardTypeDao = new CardTypeDao(this..Transaction);
				this. = cardTypeDao.GetCardTypeList();
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public iMixImageCardTypeInfo ;

			public CardBusiness ;

			public int ;

			public void ()
			{
				do
				{
					CardTypeDao cardTypeDao;
					if (!false)
					{
						cardTypeDao = new CardTypeDao(this..Transaction);
					}
					this. = cardTypeDao.GetCardTypeListDetails(this.);
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public bool ;

			public CardBusiness ;

			public int ;

			public void ()
			{
				do
				{
					CardTypeDao cardTypeDao;
					if (!false)
					{
						cardTypeDao = new CardTypeDao(this..Transaction);
					}
					this. = cardTypeDao.UPD_iMixImageCardType(this.);
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public List<ImageCardTypeInfo> ;

			public CardBusiness ;

			public string ;

			public void ()
			{
				do
				{
					CardTypeDao cardTypeDao;
					if (!false)
					{
						cardTypeDao = new CardTypeDao(this..Transaction);
					}
					this. = cardTypeDao.GetCardSeries(this.);
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public bool ;

			public CardBusiness ;

			public int ;

			public string ;

			public string ;

			public int ;

			public bool? ;

			public int ;

			public string ;

			public bool ;

			public int ;

			public bool ;

			public void ()
			{
				CardTypeDao cardTypeDao = new CardTypeDao(this..Transaction);
				this. = cardTypeDao.INS_iMixImageCardType(this., this., this., this., this., this., this., this., this., this.);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public List<ValueTypeInfo> ;

			public CardBusiness ;

			public void ()
			{
				ValueTypeDao valueTypeDao = new ValueTypeDao(this..Transaction);
				this. = valueTypeDao.GetCardTypes();
			}
		}

		[NonSerialized]
		internal static SmartAssembly.Delegates.GetString ;

		public bool IsValidCodeType(string QRCode, int CardTypeId)
		{
			CardBusiness.  = new CardBusiness.();
			. = QRCode;
			. = CardTypeId;
			. = this;
			if (8 != 0)
			{
				if (false)
				{
					goto IL_6E;
				}
				. = new ImageCardTypeInfo();
				if (!false)
				{
					this.operation = new BaseBusiness.TransactionMethod(.);
				}
			}
			int arg_71_0 = base.Start(false) ? 1 : 0;
			if (!false)
			{
				if (. != null)
				{
					goto IL_6E;
				}
				arg_71_0 = 0;
			}
			int arg_6F_0;
			int expr_71 = arg_6F_0 = arg_71_0;
			if (expr_71 == 0)
			{
				return expr_71 != 0;
			}
			return arg_6F_0 != 0;
			IL_6E:
			arg_6F_0 = 1;
			return arg_6F_0 != 0;
		}

		public string GetCardCode(int ImageIdentificationType)
		{
			CardBusiness.  = new CardBusiness.();
			string result;
			while (true)
			{
				. = ImageIdentificationType;
				. = this;
				result = string.Empty;
				. = new ImageCardTypeInfo();
				while (!false)
				{
					this.operation = new BaseBusiness.TransactionMethod(.);
					while (true)
					{
						base.Start(false);
						if (. == null)
						{
							break;
						}
						if (!false)
						{
							goto Block_3;
						}
					}
					IL_69:
					if (3 != 0)
					{
						return result;
					}
					continue;
					Block_3:
					result = ..CardIdentificationDigit;
					goto IL_69;
				}
			}
			return result;
		}

		public bool IsValidPrepaidCodeType(string QRCode, int CardTypeId)
		{
			CardBusiness.  = new CardBusiness.();
			. = QRCode;
			. = CardTypeId;
			. = this;
			if (8 != 0)
			{
				if (false)
				{
					goto IL_6E;
				}
				. = new ImageCardTypeInfo();
				if (!false)
				{
					this.operation = new BaseBusiness.TransactionMethod(.);
				}
			}
			int arg_71_0 = base.Start(false) ? 1 : 0;
			if (!false)
			{
				if (. != null)
				{
					goto IL_6E;
				}
				arg_71_0 = 0;
			}
			int arg_6F_0;
			int expr_71 = arg_6F_0 = arg_71_0;
			if (expr_71 == 0)
			{
				return expr_71 != 0;
			}
			return arg_6F_0 != 0;
			IL_6E:
			arg_6F_0 = 1;
			return arg_6F_0 != 0;
		}

		public int GetCardImageLimit(string code)
		{
			CardBusiness.  = new CardBusiness.();
			. = code;
			. = this;
			while (true)
			{
				int arg_3B_0 = ..Length;
				if (!false)
				{
					if (arg_3B_0 < 4)
					{
						break;
					}
					. = new ImageCardTypeInfo();
					this.operation = new BaseBusiness.TransactionMethod(.);
					if (false)
					{
						goto IL_9A;
					}
					base.Start(false);
				}
				if (. == null)
				{
					goto IL_A2;
				}
				IL_73:
				if (false)
				{
					continue;
				}
				int? maxImages = ..MaxImages;
				if (3 == 0)
				{
					break;
				}
				if (maxImages.HasValue)
				{
					goto Block_5;
				}
				IL_A2:
				if (4 != 0)
				{
					return 0;
				}
				goto IL_73;
			}
			return 0;
			Block_5:
			int? maxImages2 = ..MaxImages;
			IL_9A:
			return maxImages2.Value;
		}

		public int GetCardImageSold(string code)
		{
			CardBusiness.  = new CardBusiness.();
			do
			{
				. = code;
				. = this;
				. = 0;
				. = new List<string>();
			}
			while (false);
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
			..ForEach(new Action<string>(.));
			return .;
		}

		public List<iMixImageCardTypeInfo> GetCardTypeList()
		{
			if (!false)
			{
				if (!false)
				{
				}
				do
				{
					. = this;
				}
				while (false);
				. = new List<iMixImageCardTypeInfo>();
				do
				{
					this.operation = new BaseBusiness.TransactionMethod(.);
				}
				while (2 == 0);
				base.Start(false);
			}
			return .;
		}

		public Dictionary<string, int> GetCardCodeTypes()
		{
			Dictionary<string, int> dictionary;
			if (7 != 0)
			{
				if (false)
				{
					goto IL_3C;
				}
				Dictionary<string, int> expr_73 = new Dictionary<string, int>();
				if (!false)
				{
					dictionary = expr_73;
				}
				dictionary.Add(CardBusiness.(363), 405);
			}
			dictionary.Add(CardBusiness.(380), 403);
			IL_3C:
			dictionary.Add(CardBusiness.(389), 404);
			dictionary.Add(CardBusiness.(398), 406);
			return dictionary;
		}

		public List<ImageCardTypeInfo> GetCardTypeListview()
		{
			if (!false)
			{
				if (!false)
				{
				}
				do
				{
					. = this;
				}
				while (false);
				. = new List<ImageCardTypeInfo>();
				do
				{
					this.operation = new BaseBusiness.TransactionMethod(.);
				}
				while (2 == 0);
				base.Start(false);
			}
			return .;
		}

		public iMixImageCardTypeInfo GetCardTypeList(int ID)
		{
			CardBusiness.  = new CardBusiness.();
			. = ID;
			. = this;
			. = new iMixImageCardTypeInfo();
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
			return .;
		}

		public bool ChangeCardStatus(int cardId)
		{
			CardBusiness.  = new CardBusiness.();
			. = cardId;
			. = this;
			. = true;
			this.operation = new BaseBusiness.TransactionMethod(.);
			bool arg_46_0 = base.Start(false);
			do
			{
				if (5 != 0)
				{
					arg_46_0 = .;
				}
			}
			while (2 == 0);
			return arg_46_0;
		}

		public bool IsCardSeriesExits(string series)
		{
			CardBusiness.  = new CardBusiness.();
			while (true)
			{
				. = series;
				while (true)
				{
					. = this;
					if (8 == 0)
					{
						goto IL_65;
					}
					if (false)
					{
						break;
					}
					string arg_30_0 = string.Empty;
					do
					{
						. = new List<ImageCardTypeInfo>();
					}
					while (8 == 0);
					this.operation = new BaseBusiness.TransactionMethod(.);
					base.Start(false);
					if (. != null)
					{
						goto IL_65;
					}
					if (!false)
					{
						goto Block_5;
					}
				}
			}
			Block_5:
			int arg_64_0 = 0;
			return arg_64_0 != 0;
			IL_65:
			int expr_66 = arg_64_0 = 1;
			if (expr_66 != 0)
			{
				return expr_66 != 0;
			}
			return arg_64_0 != 0;
		}

		public bool SetCardTypeInfo(int cardId, string strCardTypeName, string strCardSeries, int strcodeType, bool? status, int maxImage, string strDescription, bool IsPrepaid, int PackageId, bool IsWaterMark)
		{
			if (2 == 0)
			{
				goto IL_61;
			}
			CardBusiness.  = new CardBusiness.();
			. = cardId;
			IL_1C:
			if (false)
			{
				goto IL_59;
			}
			. = strCardTypeName;
			IL_2E:
			. = strCardSeries;
			. = strcodeType;
			. = status;
			. = maxImage;
			IL_59:
			. = strDescription;
			IL_61:
			. = IsPrepaid;
			if (!true)
			{
				goto IL_1C;
			}
			. = PackageId;
			. = IsWaterMark;
			. = this;
			if (2 != 0)
			{
				. = true;
				this.operation = new BaseBusiness.TransactionMethod(.);
				bool arg_B3_0 = base.Start(false);
				do
				{
					if (!false)
					{
						arg_B3_0 = .;
					}
				}
				while (4 == 0);
				return arg_B3_0;
			}
			goto IL_2E;
		}

		public List<ValueTypeInfo> GetCardTypes()
		{
			if (!false)
			{
				if (!false)
				{
				}
				do
				{
					. = this;
				}
				while (false);
				. = null;
				do
				{
					this.operation = new BaseBusiness.TransactionMethod(.);
				}
				while (2 == 0);
				base.Start(false);
			}
			return .;
		}

		static CardBusiness()
		{
			// Note: this type is marked as 'beforefieldinit'.
			SmartAssembly.HouseOfCards.Strings.CreateGetStringDelegate(typeof(CardBusiness));
		}
	}
}
