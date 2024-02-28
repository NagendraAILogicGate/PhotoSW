using System;
using System.Linq;

namespace PhotoSW
{
	public class GenerateQRCode
	{
		private static System.Random random = new System.Random();

		public static string GetNextQRCode(int QRCodeLenth)
		{
			return new string((from s in Enumerable.Repeat<string>("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", QRCodeLenth)
			select s[GenerateQRCode.random.Next(s.Length)]).ToArray<char>());
		}
	}
}
