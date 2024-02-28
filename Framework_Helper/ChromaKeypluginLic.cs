using MLPROXYLib;
using System;

public class ChromaKeypluginLic
{
    private static CoMLProxyClass m_objMLProxy;
    private static string strLicInfo = "[MediaLooks]\r\nLicense.ProductName=Chroma Key plugin\r\nLicense.IssuedTo=Digiphoto Entertainment Imaging (DIGI PHOTO STUDIO)\r\nLicense.CompanyID=9935\r\nLicense.UUID={B24CE135-BD9E-4138-91A5-EC446DF2F441}\r\nLicense.Key={A13C3F36-9DA4-1827-8AD0-28F327726ED5}\r\nLicense.Name=Medialooks Chroma-Keying Filter\r\nLicense.UpdateExpirationDate=June 22, 2017\r\nLicense.Edition=Professional\r\nLicense.AllowedModule=*.*\r\nLicense.Signature=6F3304FAE8EE74108A71D001C7FB65E702DB54B373EC58CDB5C3F08F30C7743B19D2219CE56754D7AE42CE5A72F96FB2AB724868295B43EDF9E7F20E4DF939BF11A136268FC9652F06C13B52D94E6FA5D3BA6A9F61FC4F21C4C9F590D49505200687A63AEF167A8145A80C7A5968528E303872355F102EEB2FE4E526D02F9A89\r\n\r\n";

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

