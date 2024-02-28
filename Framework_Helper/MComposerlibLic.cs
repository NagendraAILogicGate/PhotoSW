using MLPROXYLib;
using System;

public class MComposerlibLic
{
    private static CoMLProxyClass m_objMLProxy;
    private static string strLicInfo = "[MediaLooks]\r\nLicense.ProductName=MComposer lib\r\nLicense.IssuedTo=Digiphoto Entertainment Imaging (DIGI PHOTO STUDIO)\r\nLicense.CompanyID=9935\r\nLicense.UUID={87FCE46A-486B-44FA-9A87-2949C8014D95}\r\nLicense.Key={186756CF-E445-AB2F-F945-E9F8C1422D9F}\r\nLicense.Name=MComposer Module\r\nLicense.UpdateExpirationDate=June 22, 2017\r\nLicense.Edition=Professional MDecoders\r\nLicense.AllowedModule=*.*\r\nLicense.Signature=91CB55D1501CAAC10A414E3B58D8526E7A64E22CB21223DB666C3EEBC86DAF4D14D24EE48D65EFB7EE2AD08B81796B8844F3EB338410A76BC144347C80DD84333624FFC797C5A1629657AA106385D983EA9BC2F88F9A60AAFA72342DD03D5CF5FE7945FA3DE74F380D57E59D74D20F3052A2F9361C0135C98E7FC821976FC628\r\n\r\n";

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

