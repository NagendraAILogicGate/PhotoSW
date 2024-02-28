using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.Cache.Data
    {
    public sealed class ClientConstant
        {
        public const short NullInt = -32768;

        public const int NullInt32 = -2147483648;

        public const long NullInt64 = -9223372036854775808L;

        public const byte NullByte = 0;

        public const decimal NullDecimal = 79228162514264337593543950335m;

        public const short NullShort = -32768;

        public const decimal DefaultZeroDecimal = 0;

        public const string YesString = "Y";

        public const string NoString = "N";

        public const string YesCompleteString = "Yes";

        public const string NoCompleteString = "No";

        public const char SeperatorComma = ',';

        public const bool NullBoolean = false;

        public const double NullDouble = -1.7976931348623157E+308;

        public const sbyte NullSByte = -128;

        public const float NullSingle = -3.40282347E+38f;

        public const ushort NullUInt16 = 0;

        public const uint NullUInt32 = 0u;

        public const ulong NullUInt64 = 0uL;

        public const char NullChar = '\0';

        public const string DecimalValueEffectiveSignificantDigitFormat = "{0:0.######}";

        public static readonly DateTime NullDate;

        public static DateTime MinimunDateValue;

        public static TimeSpan NullTimespan;

        public static readonly DateTime NullDbDate;

        public static readonly DateTime MaxDbDate;

        static ClientConstant ()
            {
            // Note: this type is marked as 'beforefieldinit'.
           
                ClientConstant.NullDate = DateTime.MinValue;
              
          //  ClientConstant.NullDecimal = -32768m;
            int arg_80_0;
            int arg_79_0;
            int expr_19 = arg_79_0 = (arg_80_0 = 0);
            int arg_80_1;
            int arg_79_1;
            int expr_1A = arg_79_1 = (arg_80_1 = 0);
            int arg_3F_0;
            int expr_1C = arg_3F_0 = 0;
            if(expr_1C != 0)
                {
                goto IL_3F;
                }
          //  ClientConstant.DefaultZeroDecimal = new decimal(expr_19, expr_1A, expr_1C, false, 2);
            arg_79_0 = 1753;
            arg_79_1 = 1;
            IL_2E:
            int arg_79_2 = 1;
            IL_2F:
            ClientConstant.MinimunDateValue = new DateTime(arg_79_0, arg_79_1, arg_79_2);
            int arg_8E_0;
            arg_80_0 = (arg_79_0 = (arg_8E_0 = 0));
            int expr_38 = arg_79_1 = 0;
            if(expr_38 != 0)
                {
                goto IL_2E;
                }
            int arg_8E_1 = expr_38;
            arg_80_1 = expr_38;
            arg_79_1 = expr_38;
            if(expr_38 != 0)
                {
                goto IL_5D;
                }
            arg_3F_0 = 0;
            IL_3F:
            int expr_3F = arg_79_2 = arg_3F_0;
            if(expr_3F != 0)
                {
                goto IL_2F;
                }
            ClientConstant.NullTimespan = new TimeSpan(arg_80_0, arg_80_1, expr_3F);
            ClientConstant.NullDbDate = new DateTime(1900, 1, 1);
            arg_8E_0 = 2079;
            arg_8E_1 = 6;
            IL_5D:
            ClientConstant.MaxDbDate = new DateTime(arg_8E_0, arg_8E_1, 6, 23, 59, 0);
            }
        }
    }
