using MLPROXYLib;
using System;

public class DecoderlibLic
{
    private static CoMLProxyClass m_objMLProxy;
    private static string strLicInfo = "[MediaLooks]\r\nLicense.ProductName=Decoder lib\r\nLicense.IssuedTo=Digiphoto Entertainment Imaging (DIGI PHOTO STUDIO)\r\nLicense.CompanyID=9935\r\nLicense.UUID={CAC391B7-218B-410B-9269-881276411AF3}\r\nLicense.Key={8361373E-7C62-4E40-9231-C290BCD94A0B}\r\nLicense.Name=MPlaylist Module\r\nLicense.UpdateExpirationDate=June 22, 2017\r\nLicense.Edition=MDecoders\r\nLicense.AllowedModule=*.*\r\nLicense.Signature=BEFC5A2332886E72C6D6CCAF130772D68038BEF3D0ADED7BB564AA0B7FF030C7D253141F78A243B54E59216D75829AFC22F73848600529A2133A086911108061ADE8F264E2DAA5D11CE9EF2DC0015D6EA2502D6311B266F448120D1DEBFCC1B15DA1F10B050E38DC663DF93FFBD2BE4F96D9D5875AFCAC4BB2C7B672186AE746\r\n\r\n[MediaLooks]\r\nLicense.ProductName=Decoder lib\r\nLicense.IssuedTo=Digiphoto Entertainment Imaging (DIGI PHOTO STUDIO)\r\nLicense.CompanyID=9935\r\nLicense.UUID={72F1AEC9-A74D-48AD-B5E6-4A2ADB89FD94}\r\nLicense.Key={9DC01825-9316-06D3-94A1-76DAD3352A3D}\r\nLicense.Name=MFile Module\r\nLicense.UpdateExpirationDate=June 22, 2017\r\nLicense.Edition=MDecoders\r\nLicense.AllowedModule=*.*\r\nLicense.Signature=6238F712AAF0F520B9F6084C54E5DD5C1F01B6F57126A2FAA7E2B20C4A15E75BE233DF1ABB1C00B01708760C7491353AD2DFF65B6B707ED233BA770384CEE3FE9697757821425126727CF9ABA498D001EA7091AE4FB18BD22347817A3DBBD6B10F715E35A37DEF1BBED9DF9612427274574E8D8480D0135E5F1FD99A516B2A33\r\n\r\n[MediaLooks]\r\nLicense.ProductName=Decoder lib\r\nLicense.IssuedTo=Digiphoto Entertainment Imaging (DIGI PHOTO STUDIO)\r\nLicense.CompanyID=9935\r\nLicense.UUID={3A11BCFD-AA9C-4BFE-BAAA-369B442DD720}\r\nLicense.Key={9DC01825-FA59-2230-B66C-F1F5757FD85C}\r\nLicense.Name=MMixer Module (BETA)\r\nLicense.UpdateExpirationDate=June 22, 2017\r\nLicense.Edition=MDecoders\r\nLicense.AllowedModule=*.*\r\nLicense.Signature=EE1F7549FED0C3F3EB0F17461EEF430908163E2E665F1B698CEE4552A48B97A0E1EB2E7601C9769746C81AE13A97D18A35A36DDEC25157BFE61349C1A79936C22A81292E60EAFEBCD6AE8E43B8979F00D243323FE37A093D9B5C1D9C2D217896DB57D039A129BA6830CCCF514BD950319082FC299A530086007EED3989468459\r\n\r\n";

    public static void IntializeProtection()
    {
        if (m_objMLProxy == null)
        {
            m_objMLProxy = new CoMLProxyClass();
            m_objMLProxy.PutString(strLicInfo);
        }
        UpdatePersonalProtection();
    }

    private static uint SummBits(uint _nValue)
    {
        uint num = 0;
        while (_nValue > 0)
        {
            num += _nValue & 1;
            _nValue = _nValue >> 1;
        }
        return (num % 2);
    }

    private static void UpdatePersonalProtection()
    {
        try
        {
            int num = 0;
            int num2 = 0;
            m_objMLProxy.GetData(out num, out num2);
            long num3 = (num * 0x3b7b123L) % 0x335c5ffL;
            long num4 = (num2 * 0x31c1b5dL) % 0x34e01afL;
            uint num5 = SummBits((uint) (num3 + num4));
            long num6 = ((num - 0x1d) * (num - 0x17)) % ((long) num2);
            int num7 = new Random().Next(0x7fff);
            int num8 = ((int) num6) + (num7 * ((num5 > 0) ? 1 : -1));
            m_objMLProxy.SetData(num, num2, (int) num6, num8);
        }
        catch (Exception)
        {
        }
    }
}

