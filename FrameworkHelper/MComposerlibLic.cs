using MLPROXYLib;
using System;

public class MComposerlibLic
{
	private static CoMLProxyClass m_objMLProxy;

	private static string strLicInfo = "[MediaLooks]\r\nLicense.ProductName=MComposer lib\r\nLicense.IssuedTo=Digiphoto Entertainment Imaging (DIGI PHOTO STUDIO)\r\nLicense.CompanyID=9935\r\nLicense.UUID={87FCE46A-486B-44FA-9A87-2949C8014D95}\r\nLicense.Key={186756CF-E445-AB2F-F945-E9F8C1422D9F}\r\nLicense.Name=MComposer Module\r\nLicense.UpdateExpirationDate=June 22, 2017\r\nLicense.Edition=Professional MDecoders\r\nLicense.AllowedModule=*.*\r\nLicense.Signature=91CB55D1501CAAC10A414E3B58D8526E7A64E22CB21223DB666C3EEBC86DAF4D14D24EE48D65EFB7EE2AD08B81796B8844F3EB338410A76BC144347C80DD84333624FFC797C5A1629657AA106385D983EA9BC2F88F9A60AAFA72342DD03D5CF5FE7945FA3DE74F380D57E59D74D20F3052A2F9361C0135C98E7FC821976FC628\r\n\r\n";

	public static void IntializeProtection()
	{
		if (MComposerlibLic.m_objMLProxy == null)
		{
			MComposerlibLic.m_objMLProxy = new CoMLProxyClass();
			MComposerlibLic.m_objMLProxy.PutString(MComposerlibLic.strLicInfo);
		}
		MComposerlibLic.UpdatePersonalProtection();
	}

	private static void UpdatePersonalProtection()
	{
		try
		{
			int num = 0;
			int num2 = 0;
			MComposerlibLic.m_objMLProxy.GetData(out num, out num2);
			long num3 = (long)num * 62370083L % 53855743L;
			long num4 = (long)num2 * 52173661L % 55443887L;
			uint num5 = MComposerlibLic.SummBits((uint)(num3 + num4));
			long num6 = (long)(num - 29) * (long)(num - 23) % (long)num2;
			int num7 = new System.Random().Next(32767);
			int nSecondRes = (int)num6 + num7 * ((num5 > 0u) ? 1 : -1);
			MComposerlibLic.m_objMLProxy.SetData(num, num2, (int)num6, nSecondRes);
		}
		catch (System.Exception)
		{
		}
	}

	private static uint SummBits(uint _nValue)
	{
		uint num = 0u;
		while (_nValue > 0u)
		{
			num += (_nValue & 1u);
			_nValue >>= 1;
		}
		return num % 2u;
	}
}
