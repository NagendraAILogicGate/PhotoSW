using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhotoSW.Orders
{
    public class DirectoryItem
    {
        public string text { get; set; }
        public decimal SizeOnDisc { get; set; }
        public DirectoryItem(string text)
        {
            this.text = text;
        }
    }
}
