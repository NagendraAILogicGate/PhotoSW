using Microsoft.Win32;
using System;
using System.Reflection;

namespace FrameworkHelper.Common
{
	public class ModifyRegistry
	{
		private bool showError = false;

		private string subKey = "SOFTWARE\\Wow6432Node\\DigiPhoto Entertainment Imaging";

		private Microsoft.Win32.RegistryKey baseRegistryKey = Microsoft.Win32.Registry.LocalMachine;

		public bool ShowError
		{
			get
			{
				return this.showError;
			}
			set
			{
				this.showError = value;
			}
		}

		public string SubKey
		{
			get
			{
				return this.subKey;
			}
			set
			{
				this.subKey = value;
			}
		}

		public Microsoft.Win32.RegistryKey BaseRegistryKey
		{
			get
			{
				return this.baseRegistryKey;
			}
			set
			{
				this.baseRegistryKey = value;
			}
		}

		public static string AssemblyProductVersion
		{
			get
			{
				object[] customAttributes = System.Reflection.Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(System.Reflection.AssemblyInformationalVersionAttribute), false);
				return (customAttributes.Length == 0) ? "" : ((System.Reflection.AssemblyInformationalVersionAttribute)customAttributes[0]).InformationalVersion;
			}
		}

		public string Read(string KeyName)
		{
			Microsoft.Win32.RegistryKey registryKey = this.baseRegistryKey;
			Microsoft.Win32.RegistryKey registryKey2 = registryKey.OpenSubKey(this.subKey);
			string result;
			if (registryKey2 == null)
			{
				result = null;
			}
			else
			{
				try
				{
					result = (string)registryKey2.GetValue(KeyName.ToUpper());
				}
				catch (System.Exception e)
				{
					this.ShowErrorMessage(e, "Reading registry " + KeyName.ToUpper());
					result = null;
				}
			}
			return result;
		}

		public bool Write(string KeyName, object Value)
		{
			bool result;
			try
			{
				Microsoft.Win32.RegistryKey registryKey = this.baseRegistryKey;
				Microsoft.Win32.RegistryKey registryKey2 = registryKey.CreateSubKey(this.subKey);
				registryKey2.SetValue(KeyName.ToUpper(), Value);
				result = true;
			}
			catch (System.Exception e)
			{
				this.ShowErrorMessage(e, "Writing registry " + KeyName.ToUpper());
				result = false;
			}
			return result;
		}

		public bool DeleteKey(string KeyName)
		{
			bool result;
			try
			{
				Microsoft.Win32.RegistryKey registryKey = this.baseRegistryKey;
				Microsoft.Win32.RegistryKey registryKey2 = registryKey.CreateSubKey(this.subKey);
				if (registryKey2 == null)
				{
					result = true;
				}
				else
				{
					registryKey2.DeleteValue(KeyName);
					result = true;
				}
			}
			catch (System.Exception e)
			{
				this.ShowErrorMessage(e, "Deleting SubKey " + this.subKey);
				result = false;
			}
			return result;
		}

		public bool DeleteSubKeyTree()
		{
			bool result;
			try
			{
				Microsoft.Win32.RegistryKey registryKey = this.baseRegistryKey;
				Microsoft.Win32.RegistryKey registryKey2 = registryKey.OpenSubKey(this.subKey);
				if (registryKey2 != null)
				{
					registryKey.DeleteSubKeyTree(this.subKey);
				}
				result = true;
			}
			catch (System.Exception e)
			{
				this.ShowErrorMessage(e, "Deleting SubKey " + this.subKey);
				result = false;
			}
			return result;
		}

		public int SubKeyCount()
		{
			int result;
			try
			{
				Microsoft.Win32.RegistryKey registryKey = this.baseRegistryKey;
				Microsoft.Win32.RegistryKey registryKey2 = registryKey.OpenSubKey(this.subKey);
				if (registryKey2 != null)
				{
					result = registryKey2.SubKeyCount;
				}
				else
				{
					result = 0;
				}
			}
			catch (System.Exception e)
			{
				this.ShowErrorMessage(e, "Retriving subkeys of " + this.subKey);
				result = 0;
			}
			return result;
		}

		public int ValueCount()
		{
			int result;
			try
			{
				Microsoft.Win32.RegistryKey registryKey = this.baseRegistryKey;
				Microsoft.Win32.RegistryKey registryKey2 = registryKey.OpenSubKey(this.subKey);
				if (registryKey2 != null)
				{
					result = registryKey2.ValueCount;
				}
				else
				{
					result = 0;
				}
			}
			catch (System.Exception e)
			{
				this.ShowErrorMessage(e, "Retriving keys of " + this.subKey);
				result = 0;
			}
			return result;
		}

		private void ShowErrorMessage(System.Exception e, string Title)
		{
		}
	}
}
