//using SmartAssembly.Delegates;
//using SmartAssembly.HouseOfCards;
using System;
using System.Security.Cryptography;
using System.Text;

namespace PhotoSW.IMIX.Business
{
	public class CryptorEngine
	{
        internal static SmartAssembly.Delegates.GetString getCryptorEngine;
		public static string Encrypt(string toEncrypt, bool useHashing)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(toEncrypt);
			string s = CryptorEngine.getCryptorEngine (1402);
			byte[] key;
			if (useHashing)
			{
				MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
				key = mD5CryptoServiceProvider.ComputeHash(Encoding.UTF8.GetBytes(s));
				mD5CryptoServiceProvider.Clear();
			}
			else
			{
				key = Encoding.UTF8.GetBytes(s);
			}
			TripleDESCryptoServiceProvider tripleDESCryptoServiceProvider = new TripleDESCryptoServiceProvider();
			tripleDESCryptoServiceProvider.Key = key;
			tripleDESCryptoServiceProvider.Mode = CipherMode.ECB;
			tripleDESCryptoServiceProvider.Padding = PaddingMode.PKCS7;
			ICryptoTransform cryptoTransform = tripleDESCryptoServiceProvider.CreateEncryptor();
			byte[] array = cryptoTransform.TransformFinalBlock(bytes, 0, bytes.Length);
			tripleDESCryptoServiceProvider.Clear();
			return Convert.ToBase64String(array, 0, array.Length);
		}

		public static string Decrypt(string cipherString, bool useHashing)
		{
			TripleDESCryptoServiceProvider tripleDESCryptoServiceProvider;
			byte[] bytes;
			while (true)
			{
				byte[] array = Convert.FromBase64String(cipherString);
				while (true)
				{
					byte[] key;
					if (3 != 0)
					{
                        string s = CryptorEngine.getCryptorEngine(1402);
						if (useHashing)
						{
							MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
							key = mD5CryptoServiceProvider.ComputeHash(Encoding.UTF8.GetBytes(s));
							mD5CryptoServiceProvider.Clear();
						}
						else
						{
							key = Encoding.UTF8.GetBytes(s);
						}
					}
					IL_61:
					tripleDESCryptoServiceProvider = new TripleDESCryptoServiceProvider();
					if (!false)
					{
						tripleDESCryptoServiceProvider.Key = key;
						tripleDESCryptoServiceProvider.Mode = CipherMode.ECB;
					}
					tripleDESCryptoServiceProvider.Padding = PaddingMode.PKCS7;
					if (false)
					{
						break;
					}
					ICryptoTransform cryptoTransform = tripleDESCryptoServiceProvider.CreateDecryptor();
					bytes = cryptoTransform.TransformFinalBlock(array, 0, array.Length);
					if (!false)
					{
						goto Block_4;
					}
					continue;
					goto IL_61;
				}
			}
			Block_4:
			tripleDESCryptoServiceProvider.Clear();
			return Encoding.UTF8.GetString(bytes);
		}

		static CryptorEngine()
		{
			// Note: this type is marked as 'beforefieldinit'.
			SmartAssembly.HouseOfCards.Strings.CreateGetStringDelegate(typeof(CryptorEngine));
		}
	}
}
