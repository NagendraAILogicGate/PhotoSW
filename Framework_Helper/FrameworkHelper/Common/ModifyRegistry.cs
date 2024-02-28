namespace FrameworkHelper.Common
{
    using Microsoft.Win32;
    using System;
    using System.Reflection;

    public class ModifyRegistry
    {
        private RegistryKey baseRegistryKey = Registry.LocalMachine;
        private bool showError = false;
        private string subKey = @"SOFTWARE\Wow6432Node\DigiPhoto Entertainment Imaging";

        public bool DeleteKey(string KeyName)
        {
            try
            {
                RegistryKey key2 = this.baseRegistryKey.CreateSubKey(this.subKey);
                if (key2 != null)
                {
                    key2.DeleteValue(KeyName);
                }
                return true;
            }
            catch (Exception exception)
            {
                this.ShowErrorMessage(exception, "Deleting SubKey " + this.subKey);
                return false;
            }
        }

        public bool DeleteSubKeyTree()
        {
            try
            {
                RegistryKey baseRegistryKey = this.baseRegistryKey;
                if (baseRegistryKey.OpenSubKey(this.subKey) != null)
                {
                    baseRegistryKey.DeleteSubKeyTree(this.subKey);
                }
                return true;
            }
            catch (Exception exception)
            {
                this.ShowErrorMessage(exception, "Deleting SubKey " + this.subKey);
                return false;
            }
        }

        public string Read(string KeyName)
        {
            RegistryKey key2 = this.baseRegistryKey.OpenSubKey(this.subKey);
            if (key2 == null)
            {
                return null;
            }
            try
            {
                return (string) key2.GetValue(KeyName.ToUpper());
            }
            catch (Exception exception)
            {
                this.ShowErrorMessage(exception, "Reading registry " + KeyName.ToUpper());
                return null;
            }
        }

        private void ShowErrorMessage(Exception e, string Title)
        {
        }

        public int SubKeyCount()
        {
            try
            {
                RegistryKey key2 = this.baseRegistryKey.OpenSubKey(this.subKey);
                if (key2 != null)
                {
                    return key2.SubKeyCount;
                }
                return 0;
            }
            catch (Exception exception)
            {
                this.ShowErrorMessage(exception, "Retriving subkeys of " + this.subKey);
                return 0;
            }
        }

        public int ValueCount()
        {
            try
            {
                RegistryKey key2 = this.baseRegistryKey.OpenSubKey(this.subKey);
                if (key2 != null)
                {
                    return key2.ValueCount;
                }
                return 0;
            }
            catch (Exception exception)
            {
                this.ShowErrorMessage(exception, "Retriving keys of " + this.subKey);
                return 0;
            }
        }

        public bool Write(string KeyName, object Value)
        {
            try
            {
                this.baseRegistryKey.CreateSubKey(this.subKey).SetValue(KeyName.ToUpper(), Value);
                return true;
            }
            catch (Exception exception)
            {
                this.ShowErrorMessage(exception, "Writing registry " + KeyName.ToUpper());
                return false;
            }
        }

        public static string AssemblyProductVersion
        {
            get
            {
                object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyInformationalVersionAttribute), false);
                return ((customAttributes.Length == 0) ? "" : ((AssemblyInformationalVersionAttribute) customAttributes[0]).InformationalVersion);
            }
        }

        public RegistryKey BaseRegistryKey
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
    }
}

