using MLPROXYLib;
using System;

public class EncoderlibLic
{
    private static CoMLProxyClass m_objMLProxy;
    private static string strLicInfo = "[MediaLooks]\r\nLicense.ProductName=Encoder lib\r\nLicense.IssuedTo=Digiphoto Entertainment Imaging (DIGI PHOTO STUDIO)\r\nLicense.CompanyID=9935\r\nLicense.UUID={A22853AE-4178-4613-AF5F-F3AF2F9557BA}\r\nLicense.Key={D81E2815-FAF3-7B3D-ABD9-67764DF2CA83}\r\nLicense.Name=MRenderer Module\r\nLicense.UpdateExpirationDate=June 22, 2017\r\nLicense.Edition=MWriter\r\nLicense.AllowedModule=*.*\r\nLicense.Signature=828DDBDD6FC4619D5F547D588CA6F9D9711C1E9061D9B3B2565AEE5764DEA31AB0729B59414AC8E810BBE03C64C1D260B56466276B07954F5E964AB3CFC162736ED06542E5CA790349459138C408E9E362B98E823316EE203B85E888243D1D5FAD733FF93C0A6F3B794ADEE5FF758322BC136E85A75A6469737643DD7BD32247\r\n\r\n[MediaLooks]\r\nLicense.ProductName=Encoder lib\r\nLicense.IssuedTo=Digiphoto Entertainment Imaging (DIGI PHOTO STUDIO)\r\nLicense.CompanyID=9935\r\nLicense.UUID={825D2A96-6A05-4C75-A699-0906D521B06A}\r\nLicense.Key={68909C79-A451-A1DE-3500-60E62776C7A2}\r\nLicense.Name=MWriter Module\r\nLicense.UpdateExpirationDate=June 22, 2017\r\nLicense.Edition=MWriter\r\nLicense.AllowedModule=*.*\r\nLicense.Signature=0A89F3C277E3C40D03E62B0FA49FC1CE6DD4CFF2F3DEDC9AB5E1590A529BA2AD5E31E94001EEBA00DAB22A5AEFA617114BF0B010F1A911FDB22469E304C58EE51FF560D2C63A5C850959ADF739AC5DBD733F3B10AC79E96C0FC4569417D3AE0AF4ADCD9F9B622DBF586B52163FEDFF8984691E34474A99A504AE1B76FD808A1E\r\n\r\n";

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

