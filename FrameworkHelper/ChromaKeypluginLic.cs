using MLPROXYLib;
using System;

public class ChromaKeypluginLic
{
	private static CoMLProxyClass m_objMLProxy;

	private static string strLicInfo = "[MediaLooks]\r\nLicense.ProductName=Chroma Key plugin\r\nLicense.IssuedTo=Digiphoto Entertainment Imaging (DIGI PHOTO STUDIO)\r\nLicense.CompanyID=9935\r\nLicense.UUID={B24CE135-BD9E-4138-91A5-EC446DF2F441}\r\nLicense.Key={A13C3F36-9DA4-1827-8AD0-28F327726ED5}\r\nLicense.Name=Medialooks Chroma-Keying Filter\r\nLicense.UpdateExpirationDate=June 22, 2017\r\nLicense.Edition=Professional\r\nLicense.AllowedModule=*.*\r\nLicense.Signature=6F3304FAE8EE74108A71D001C7FB65E702DB54B373EC58CDB5C3F08F30C7743B19D2219CE56754D7AE42CE5A72F96FB2AB724868295B43EDF9E7F20E4DF939BF11A136268FC9652F06C13B52D94E6FA5D3BA6A9F61FC4F21C4C9F590D49505200687A63AEF167A8145A80C7A5968528E303872355F102EEB2FE4E526D02F9A89\r\n\r\n";

	public static void IntializeProtection()
	{
		if (ChromaKeypluginLic.m_objMLProxy == null)
		{
			ChromaKeypluginLic.m_objMLProxy = new CoMLProxyClass();
			ChromaKeypluginLic.m_objMLProxy.PutString(ChromaKeypluginLic.strLicInfo);
		}
		ChromaKeypluginLic.UpdatePersonalProtection();
	}

	private static void UpdatePersonalProtection()
	{
		try
		{
			int num = 0;
			int num2 = 0;
			ChromaKeypluginLic.m_objMLProxy.GetData(out num, out num2);
			long num3 = (long)num * 62370083L % 53855743L;
			long num4 = (long)num2 * 52173661L % 55443887L;
			uint num5 = ChromaKeypluginLic.SummBits((uint)(num3 + num4));
			long num6 = (long)(num - 29) * (long)(num - 23) % (long)num2;
			int num7 = new System.Random().Next(32767);
			int nSecondRes = (int)num6 + num7 * ((num5 > 0u) ? 1 : -1);
			ChromaKeypluginLic.m_objMLProxy.SetData(num, num2, (int)num6, nSecondRes);
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
