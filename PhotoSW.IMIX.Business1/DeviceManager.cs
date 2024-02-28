using DigiPhoto.IMIX.DataAccess;
using DigiPhoto.IMIX.Model;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace DigiPhoto.IMIX.Business
{
	public class DeviceManager : BaseBusiness
	{
		[CompilerGenerated]
		private sealed class 
		{
			public DeviceManager ;

			public int ;

			public string ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public DeviceManager. ;

			public bool ;

			public void ()
			{
				ManageDeviceAccess manageDeviceAccess = new ManageDeviceAccess(this...Transaction);
				this. = manageDeviceAccess.IsDeviceAssociatedToOthers(this.., this..);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public DeviceManager ;

			public int ;

			public string ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public DeviceManager. ;

			public bool ;

			public void ()
			{
				ManageDeviceAccess manageDeviceAccess = new ManageDeviceAccess(this...Transaction);
				this. = manageDeviceAccess.SaveCameraDeviceAssociation(this.., this..);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public DeviceManager ;

			public int ;

			public int ;

			public int? ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public DeviceManager. ;

			public bool ;

			public void ()
			{
				ManageDeviceAccess manageDeviceAccess = new ManageDeviceAccess(this...Transaction);
				this. = manageDeviceAccess.SaveCameraCharacterAssociation(this.., this.., this..);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public DeviceManager ;

			public int ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public DeviceManager. ;

			public bool ;

			public void ()
			{
				if (4 != 0)
				{
					ManageDeviceAccess manageDeviceAccess = new ManageDeviceAccess(this...Transaction);
					if (!false)
					{
						this. = manageDeviceAccess.DeleteCameraDeviceAssociation(this..);
					}
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public List<CameraDeviceAssociationInfo> ;

			public DeviceManager ;

			public void ()
			{
				do
				{
					ManageDeviceAccess manageDeviceAccess;
					if (!false)
					{
						manageDeviceAccess = new ManageDeviceAccess(this..Transaction);
					}
					this. = manageDeviceAccess.GetCameraDeviceList(0L);
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public DeviceManager ;

			public int ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public DeviceManager. ;

			public List<CameraDeviceAssociationInfo> ;

			public void ()
			{
				ManageDeviceAccess manageDeviceAccess = new ManageDeviceAccess(this...Transaction);
				this. = manageDeviceAccess.GetCameraDeviceList((long)this..);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public List<DeviceInfo> ;

			public DeviceManager ;

			public int ;

			public void ()
			{
				do
				{
					ManageDeviceAccess manageDeviceAccess;
					if (!false)
					{
						manageDeviceAccess = new ManageDeviceAccess(this..Transaction);
					}
					this. = manageDeviceAccess.GetPhotoGrapherDeviceList(this.);
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public DeviceManager ;

			public DeviceInfo ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public DeviceManager. ;

			public bool ;

			public void ()
			{
				if (4 != 0)
				{
					ManageDeviceAccess manageDeviceAccess = new ManageDeviceAccess(this...Transaction);
					if (!false)
					{
						this. = manageDeviceAccess.SaveDevice(this..);
					}
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public DeviceManager ;

			public int ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public DeviceManager. ;

			public bool ;

			public void ()
			{
				ManageDeviceAccess manageDeviceAccess = new ManageDeviceAccess(this...Transaction);
				this. = manageDeviceAccess.DeleteDevice((long)this..);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public List<DeviceInfo> ;

			public DeviceManager ;

			public void ()
			{
				do
				{
					ManageDeviceAccess manageDeviceAccess;
					if (!false)
					{
						manageDeviceAccess = new ManageDeviceAccess(this..Transaction);
					}
					this. = manageDeviceAccess.GetDeviceList(0L);
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public DeviceManager ;

			public int ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public DeviceManager. ;

			public List<DeviceInfo> ;

			public void ()
			{
				ManageDeviceAccess manageDeviceAccess = new ManageDeviceAccess(this...Transaction);
				this. = manageDeviceAccess.GetDeviceList((long)this..);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public int ;

			public DeviceManager ;

			public int ;

			public string ;

			public void ()
			{
				if (4 != 0)
				{
					ManageDeviceAccess manageDeviceAccess = new ManageDeviceAccess(this..Transaction);
					this. = manageDeviceAccess.DeletCameraDeviceSyncDetailsAccess(this., this.);
				}
			}
		}

		public bool IsDeviceAssociatedToOthers(int CameraId, string DeviceIds)
		{
			DeviceManager.  = new DeviceManager.();
			bool result;
			do
			{
				. = CameraId;
				if (!false)
				{
					. = DeviceIds;
					. = this;
					try
					{
						DeviceManager.  = new DeviceManager.();
						. = ;
						. = false;
						this.operation = new BaseBusiness.TransactionMethod(.);
						base.Start(false);
						if (6 != 0)
						{
							result = .;
						}
					}
					catch
					{
						do
						{
							result = false;
						}
						while (2 == 0);
					}
				}
			}
			while (3 == 0);
			return result;
		}

		public bool SaveCameraDeviceAssociation(int CameraId, string DeviceIds)
		{
			DeviceManager.  = new DeviceManager.();
			bool result;
			do
			{
				. = CameraId;
				if (!false)
				{
					. = DeviceIds;
					. = this;
					try
					{
						DeviceManager.  = new DeviceManager.();
						. = ;
						. = false;
						this.operation = new BaseBusiness.TransactionMethod(.);
						base.Start(false);
						if (6 != 0)
						{
							result = .;
						}
					}
					catch
					{
						do
						{
							result = false;
						}
						while (2 == 0);
					}
				}
			}
			while (3 == 0);
			return result;
		}

		public bool SaveCameraCharacterAssociation(int CameraId, int Camerapkey, int? CharacterIds)
		{
			bool result;
			do
			{
				if (false)
				{
					return result;
				}
				int  = Camerapkey;
				int?  = CharacterIds;
			}
			while (false);
			. = this;
			try
			{
				DeviceManager.  = new DeviceManager.();
				. = ;
				if (6 != 0)
				{
					. = false;
					this.operation = new BaseBusiness.TransactionMethod(.);
					base.Start(false);
				}
				result = .;
			}
			catch
			{
				result = false;
			}
			return result;
		}

		public bool DeleteCameraDeviceAssociation(int cameraId)
		{
			if (!false && -1 != 0)
			{
			}
			. = cameraId;
			. = this;
			bool result;
			try
			{
				DeviceManager.  = new DeviceManager.();
				if (!false)
				{
					. = ;
				}
				. = false;
				this.operation = new BaseBusiness.TransactionMethod(.);
				bool arg_67_0 = base.Start(false);
				if (!false && 4 != 0)
				{
					arg_67_0 = .;
				}
				result = arg_67_0;
			}
			catch
			{
				result = false;
			}
			return result;
		}

		public List<CameraDeviceAssociationInfo> GetCameraDeviceList()
		{
			List<CameraDeviceAssociationInfo> result;
			try
			{
				if (!false)
				{
					DeviceManager.  = new DeviceManager.();
					. = this;
					if (8 != 0)
					{
						if (false)
						{
							goto IL_3C;
						}
						. = new List<CameraDeviceAssociationInfo>();
						this.operation = new BaseBusiness.TransactionMethod(.);
					}
					base.Start(false);
					IL_3C:
					result = .;
				}
			}
			catch
			{
				if (2 != 0)
				{
					result = null;
				}
			}
			return result;
		}

		public List<CameraDeviceAssociationInfo> GetCameraDeviceList(int CameraId)
		{
			if (!false && -1 != 0)
			{
			}
			. = CameraId;
			. = this;
			List<CameraDeviceAssociationInfo> result;
			try
			{
				DeviceManager.  = new DeviceManager.();
				if (!false)
				{
					. = ;
				}
				. = new List<CameraDeviceAssociationInfo>();
				if (6 != 0)
				{
					this.operation = new BaseBusiness.TransactionMethod(.);
					if (!false)
					{
						base.Start(false);
						result = .;
					}
				}
			}
			catch
			{
				result = null;
			}
			return result;
		}

		public List<DeviceInfo> GetPhotoGrapherDeviceList(int photographerId)
		{
			BaseBusiness.TransactionMethod transactionMethod;
			if (4 != 0)
			{
				transactionMethod = null;
				if (4 == 0)
				{
					goto IL_31;
				}
			}
			. = this;
			IL_31:
			. = new List<DeviceInfo>();
			List<DeviceInfo> 2;
			try
			{
				if (7 != 0)
				{
					if (transactionMethod == null)
					{
						transactionMethod = new BaseBusiness.TransactionMethod(.2);
					}
					this.operation = transactionMethod;
				}
				base.Start(false);
				2 = .;
			}
			catch
			{
				do
				{
					2 = .;
				}
				while (6 == 0 || 2 == 0);
			}
			return 2;
		}

		public bool SaveDevice(DeviceInfo device)
		{
			if (!false && -1 != 0)
			{
			}
			. = device;
			. = this;
			bool result;
			try
			{
				DeviceManager.  = new DeviceManager.();
				if (!false)
				{
					. = ;
				}
				. = false;
				this.operation = new BaseBusiness.TransactionMethod(.);
				bool arg_67_0 = base.Start(false);
				if (!false && 4 != 0)
				{
					arg_67_0 = .;
				}
				result = arg_67_0;
			}
			catch
			{
				result = false;
			}
			return result;
		}

		public bool DeleteDevice(int deviceId)
		{
			if (!false && -1 != 0)
			{
			}
			. = deviceId;
			. = this;
			bool result;
			try
			{
				DeviceManager.  = new DeviceManager.();
				if (!false)
				{
					. = ;
				}
				. = false;
				this.operation = new BaseBusiness.TransactionMethod(.);
				bool arg_67_0 = base.Start(false);
				if (!false && 4 != 0)
				{
					arg_67_0 = .;
				}
				result = arg_67_0;
			}
			catch
			{
				result = false;
			}
			return result;
		}

		public List<DeviceInfo> GetDeviceList()
		{
			List<DeviceInfo> result;
			try
			{
				if (!false)
				{
					DeviceManager.  = new DeviceManager.();
					. = this;
					if (8 != 0)
					{
						if (false)
						{
							goto IL_3C;
						}
						. = new List<DeviceInfo>();
						this.operation = new BaseBusiness.TransactionMethod(.);
					}
					base.Start(false);
					IL_3C:
					result = .;
				}
			}
			catch
			{
				if (2 != 0)
				{
					result = null;
				}
			}
			return result;
		}

		public List<DeviceInfo> GetDevice(int DeviceId)
		{
			do
			{
			}
			while (false);
			List<DeviceInfo> result;
			if (!false)
			{
				. = this;
				try
				{
					IL_2E:
					DeviceManager. ;
					while (6 != 0)
					{
						DeviceManager. expr_85 = new DeviceManager.();
						if (!false)
						{
							 = expr_85;
						}
						. = ;
						. = new List<DeviceInfo>();
						if (. <= 0)
						{
							break;
						}
						this.operation = new BaseBusiness.TransactionMethod(.);
						base.Start(false);
						do
						{
							result = .;
							if (8 == 0)
							{
								goto IL_2E;
							}
						}
						while (3 == 0);
						return result;
					}
					result = .;
				}
				catch
				{
					result = null;
				}
			}
			return result;
		}

		public int DeleteCameraDeviceSyncDetails(int CameraId, string DeviceIds)
		{
			BaseBusiness.TransactionMethod transactionMethod;
			if (6 != 0)
			{
				if (!false)
				{
					transactionMethod = null;
				}
				. = this;
			}
			. = 0;
			int 2;
			try
			{
				while (true)
				{
					if (transactionMethod == null)
					{
						transactionMethod = new BaseBusiness.TransactionMethod(.2);
					}
					this.operation = transactionMethod;
					base.Start(false);
					if (!false)
					{
						2 = .;
						if (6 != 0)
						{
							break;
						}
					}
				}
			}
			catch
			{
				do
				{
					2 = .;
				}
				while (6 == 0);
			}
			return 2;
		}
	}
}
