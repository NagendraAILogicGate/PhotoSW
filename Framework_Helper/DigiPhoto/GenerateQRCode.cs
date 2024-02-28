namespace DigiPhoto
{
    using System;
    using System.Linq;

    public class GenerateQRCode
    {
        private static Random random = new Random();

        public static string GetNextQRCode(int QRCodeLenth)
        {
            return new string((from s in Enumerable.Repeat<string>("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", QRCodeLenth) select s[random.Next(s.Length)]).ToArray<char>());
        }
    }
}

