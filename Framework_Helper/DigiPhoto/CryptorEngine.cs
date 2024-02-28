namespace DigiPhoto
{
    using System;
    using System.Security.Cryptography;
    using System.Text;

    public class CryptorEngine
    {
        public static string Decrypt(string cipherString, bool useHashing)
        {
            byte[] buffer;
            byte[] inputBuffer = Convert.FromBase64String(cipherString);
            string s = "mykey";
            if (useHashing)
            {
                MD5CryptoServiceProvider provider = new MD5CryptoServiceProvider();
                buffer = provider.ComputeHash(Encoding.UTF8.GetBytes(s));
                provider.Clear();
            }
            else
            {
                buffer = Encoding.UTF8.GetBytes(s);
            }
            TripleDESCryptoServiceProvider provider2 = new TripleDESCryptoServiceProvider {
                Key = buffer,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };
            byte[] bytes = provider2.CreateDecryptor().TransformFinalBlock(inputBuffer, 0, inputBuffer.Length);
            provider2.Clear();
            return Encoding.UTF8.GetString(bytes);
        }

        public static string Encrypt(string toEncrypt, bool useHashing)
        {
            byte[] buffer;
            byte[] bytes = Encoding.UTF8.GetBytes(toEncrypt);
            string s = "mykey";
            if (useHashing)
            {
                MD5CryptoServiceProvider provider = new MD5CryptoServiceProvider();
                buffer = provider.ComputeHash(Encoding.UTF8.GetBytes(s));
                provider.Clear();
            }
            else
            {
                buffer = Encoding.UTF8.GetBytes(s);
            }
            TripleDESCryptoServiceProvider provider2 = new TripleDESCryptoServiceProvider {
                Key = buffer,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };
            byte[] inArray = provider2.CreateEncryptor().TransformFinalBlock(bytes, 0, bytes.Length);
            provider2.Clear();
            return Convert.ToBase64String(inArray, 0, inArray.Length);
        }
    }
}

