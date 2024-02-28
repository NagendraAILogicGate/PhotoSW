using System;
using System.Security.Cryptography;
using System.Text;

namespace PhotoSW
{
	public class CryptorEngine
	{
		public static string Encrypt(string toEncrypt, bool useHashing)
		{
			byte[] bytes = System.Text.Encoding.UTF8.GetBytes(toEncrypt);
			string s = "mykey";
			byte[] key;
			if (useHashing)
			{
				System.Security.Cryptography.MD5CryptoServiceProvider mD5CryptoServiceProvider = new System.Security.Cryptography.MD5CryptoServiceProvider();
				key = mD5CryptoServiceProvider.ComputeHash(System.Text.Encoding.UTF8.GetBytes(s));
				mD5CryptoServiceProvider.Clear();
			}
			else
			{
				key = System.Text.Encoding.UTF8.GetBytes(s);
			}
			System.Security.Cryptography.TripleDESCryptoServiceProvider tripleDESCryptoServiceProvider = new System.Security.Cryptography.TripleDESCryptoServiceProvider();
			tripleDESCryptoServiceProvider.Key = key;
			tripleDESCryptoServiceProvider.Mode = System.Security.Cryptography.CipherMode.ECB;
			tripleDESCryptoServiceProvider.Padding = System.Security.Cryptography.PaddingMode.PKCS7;
			System.Security.Cryptography.ICryptoTransform cryptoTransform = tripleDESCryptoServiceProvider.CreateEncryptor();
			byte[] array = cryptoTransform.TransformFinalBlock(bytes, 0, bytes.Length);
			tripleDESCryptoServiceProvider.Clear();
			return System.Convert.ToBase64String(array, 0, array.Length);
		}

		public static string Decrypt(string cipherString, bool useHashing)
		{
			byte[] array = System.Convert.FromBase64String(cipherString);
			string s = "mykey";
			byte[] key;
			if (useHashing)
			{
				System.Security.Cryptography.MD5CryptoServiceProvider mD5CryptoServiceProvider = new System.Security.Cryptography.MD5CryptoServiceProvider();
				key = mD5CryptoServiceProvider.ComputeHash(System.Text.Encoding.UTF8.GetBytes(s));
				mD5CryptoServiceProvider.Clear();
			}
			else
			{
				key = System.Text.Encoding.UTF8.GetBytes(s);
			}
			System.Security.Cryptography.TripleDESCryptoServiceProvider tripleDESCryptoServiceProvider = new System.Security.Cryptography.TripleDESCryptoServiceProvider();
			tripleDESCryptoServiceProvider.Key = key;
			tripleDESCryptoServiceProvider.Mode = System.Security.Cryptography.CipherMode.ECB;
			tripleDESCryptoServiceProvider.Padding = System.Security.Cryptography.PaddingMode.PKCS7;
			System.Security.Cryptography.ICryptoTransform cryptoTransform = tripleDESCryptoServiceProvider.CreateDecryptor();
			byte[] bytes = cryptoTransform.TransformFinalBlock(array, 0, array.Length);
			tripleDESCryptoServiceProvider.Clear();
			return System.Text.Encoding.UTF8.GetString(bytes);
		}
	}
}
