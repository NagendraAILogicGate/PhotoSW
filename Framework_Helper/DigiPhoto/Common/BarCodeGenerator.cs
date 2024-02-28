namespace DigiPhoto.Common
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Drawing;
    using System.Drawing.Imaging;

    public class BarCodeGenerator
    {
        public class Code39
        {
            private static Brush brush = Brushes.Black;
            private string code;
            private static Dictionary<char, Pattern> codes;
            private static Pen pen = new Pen(Color.Black);
            private BarCodeGenerator.Code39Settings settings;

            static Code39()
            {
                object[][] objArray = new object[][] { 
                    new object[] { '0', "n n n w w n w n n" }, new object[] { '1', "w n n w n n n n w" }, new object[] { '2', "n n w w n n n n w" }, new object[] { '3', "w n w w n n n n n" }, new object[] { '4', "n n n w w n n n w" }, new object[] { '5', "w n n w w n n n n" }, new object[] { '6', "n n w w w n n n n" }, new object[] { '7', "n n n w n n w n w" }, new object[] { '8', "w n n w n n w n n" }, new object[] { '9', "n n w w n n w n n" }, new object[] { 'A', "w n n n n w n n w" }, new object[] { 'B', "n n w n n w n n w" }, new object[] { 'C', "w n w n n w n n n" }, new object[] { 'D', "n n n n w w n n w" }, new object[] { 'E', "w n n n w w n n n" }, new object[] { 'F', "n n w n w w n n n" }, 
                    new object[] { 'G', "n n n n n w w n w" }, new object[] { 'H', "w n n n n w w n n" }, new object[] { 'I', "n n w n n w w n n" }, new object[] { 'J', "n n n n w w w n n" }, new object[] { 'K', "w n n n n n n w w" }, new object[] { 'L', "n n w n n n n w w" }, new object[] { 'M', "w n w n n n n w n" }, new object[] { 'N', "n n n n w n n w w" }, new object[] { 'O', "w n n n w n n w n" }, new object[] { 'P', "n n w n w n n w n" }, new object[] { 'Q', "n n n n n n w w w" }, new object[] { 'R', "w n n n n n w w n" }, new object[] { 'S', "n n w n n n w w n" }, new object[] { 'T', "n n n n w n w w n" }, new object[] { 'U', "w w n n n n n n w" }, new object[] { 'V', "n w w n n n n n w" }, 
                    new object[] { 'W', "w w w n n n n n n" }, new object[] { 'X', "n w n n w n n n w" }, new object[] { 'Y', "w w n n w n n n n" }, new object[] { 'Z', "n w w n w n n n n" }, new object[] { '-', "n w n n n n w n w" }, new object[] { '.', "w w n n n n w n n" }, new object[] { ' ', "n w w n n n w n n" }, new object[] { '*', "n w n n w n w n n" }, new object[] { '$', "n w n w n w n n n" }, new object[] { '/', "n w n w n n n w n" }, new object[] { '+', "n w n n n w n w n" }, new object[] { '%', "n n n w n w n w n" }
                 };
                codes = new Dictionary<char, Pattern>();
                foreach (object[] objArray2 in objArray)
                {
                    codes.Add((char) objArray2[0], Pattern.Parse((string) objArray2[1]));
                }
            }

            public Code39(string code) : this(code, new BarCodeGenerator.Code39Settings())
            {
            }

            public Code39(string code, BarCodeGenerator.Code39Settings settings)
            {
                foreach (char ch in code)
                {
                    if (!codes.ContainsKey(ch))
                    {
                        throw new ArgumentException("Invalid character encountered in specified code.");
                    }
                }
                if (!code.StartsWith("*"))
                {
                    code = "*" + code;
                }
                if (!code.EndsWith("*"))
                {
                    code = code + "*";
                }
                this.code = code;
                this.settings = settings;
            }

            public Bitmap Paint()
            {
                string text = this.code.Trim(new char[] { '*' });
                SizeF ef = Graphics.FromImage(new Bitmap(1, 1)).MeasureString(text, this.settings.Font);
                int width = this.settings.LeftMargin + this.settings.RightMargin;
                foreach (char ch in this.code)
                {
                    width += codes[ch].GetWidth(this.settings) + this.settings.InterCharacterGap;
                }
                width -= this.settings.InterCharacterGap;
                int height = (this.settings.TopMargin + this.settings.BottomMargin) + this.settings.BarCodeHeight;
                if (this.settings.DrawText)
                {
                    height += this.settings.BarCodeToTextGapHeight + ((int) ef.Height);
                }
                Bitmap image = new Bitmap(width, height, PixelFormat.Format32bppArgb);
                Graphics g = Graphics.FromImage(image);
                g.Clear(Color.White);
                int leftMargin = this.settings.LeftMargin;
                foreach (char ch in this.code)
                {
                    leftMargin += codes[ch].Paint(this.settings, g, leftMargin) + this.settings.InterCharacterGap;
                }
                if (this.settings.DrawText)
                {
                    int num4 = this.settings.LeftMargin + ((((width - this.settings.LeftMargin) - this.settings.RightMargin) - ((int) ef.Width)) / 2);
                    if (num4 < 0)
                    {
                        num4 = 0;
                    }
                    int num5 = (this.settings.TopMargin + this.settings.BarCodeHeight) + this.settings.BarCodeToTextGapHeight;
                }
                return image;
            }

            private class Pattern
            {
                private bool[] nw = new bool[9];

                public int GetWidth(BarCodeGenerator.Code39Settings settings)
                {
                    int num = 0;
                    for (int i = 0; i < 9; i++)
                    {
                        num += this.nw[i] ? settings.WideWidth : settings.NarrowWidth;
                    }
                    return num;
                }

                public int Paint(BarCodeGenerator.Code39Settings settings, Graphics g, int left)
                {
                    int x = left;
                    int num2 = 0;
                    for (int i = 0; i < 9; i++)
                    {
                        int width = this.nw[i] ? settings.WideWidth : settings.NarrowWidth;
                        if ((i % 2) == 0)
                        {
                            Rectangle rect = new Rectangle(x, settings.TopMargin, width, settings.BarCodeHeight);
                            g.FillRectangle(BarCodeGenerator.Code39.brush, rect);
                        }
                        x += width;
                        num2 += width;
                    }
                    return num2;
                }

                public static BarCodeGenerator.Code39.Pattern Parse(string s)
                {
                    Debug.Assert(s != null);
                    s = s.Replace(" ", "").ToLower();
                    Debug.Assert(s.Length == 9);
                    Debug.Assert(s.Replace("n", "").Replace("w", "").Length == 0);
                    BarCodeGenerator.Code39.Pattern pattern = new BarCodeGenerator.Code39.Pattern();
                    int num = 0;
                    foreach (char ch in s)
                    {
                        pattern.nw[num++] = ch == 'w';
                    }
                    return pattern;
                }
            }
        }

        public class Code39Settings
        {
            private int bottomMargin = 0;
            private int codeToTextGapHeight = 0;
            private bool drawText = true;
            private System.Drawing.Font font = new System.Drawing.Font(FontFamily.GenericSansSerif, 8f);
            private int height = 20;
            private int interCharacterGap = 2;
            private int leftMargin = 10;
            private int narrowWidth = 2;
            private int rightMargin = 10;
            private int topMargin = 0;
            private int wideWidth = 6;

            public int BarCodeHeight
            {
                get
                {
                    return this.height;
                }
                set
                {
                    this.height = value;
                }
            }

            public int BarCodeToTextGapHeight
            {
                get
                {
                    return this.codeToTextGapHeight;
                }
                set
                {
                    this.codeToTextGapHeight = value;
                }
            }

            public int BottomMargin
            {
                get
                {
                    return this.bottomMargin;
                }
                set
                {
                    this.bottomMargin = value;
                }
            }

            public bool DrawText
            {
                get
                {
                    return this.drawText;
                }
                set
                {
                    this.drawText = value;
                }
            }

            public System.Drawing.Font Font
            {
                get
                {
                    return this.font;
                }
                set
                {
                    this.font = value;
                }
            }

            public int InterCharacterGap
            {
                get
                {
                    return this.interCharacterGap;
                }
                set
                {
                    this.interCharacterGap = value;
                }
            }

            public int LeftMargin
            {
                get
                {
                    return this.leftMargin;
                }
                set
                {
                    this.leftMargin = value;
                }
            }

            public int NarrowWidth
            {
                get
                {
                    return this.narrowWidth;
                }
                set
                {
                    this.narrowWidth = value;
                }
            }

            public int RightMargin
            {
                get
                {
                    return this.rightMargin;
                }
                set
                {
                    this.rightMargin = value;
                }
            }

            public int TopMargin
            {
                get
                {
                    return this.topMargin;
                }
                set
                {
                    this.topMargin = value;
                }
            }

            public int WideWidth
            {
                get
                {
                    return this.wideWidth;
                }
                set
                {
                    this.wideWidth = value;
                }
            }
        }
    }
}

