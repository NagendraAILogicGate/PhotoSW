using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.ViewModels
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
