using MLPROXYLib;
using System;

public class MPlatformSDKLic
{
    private static CoMLProxyClass m_objMLProxy;
    private static string strLicInfo = "[MediaLooks]\r\nLicense.ProductName=MPlatform SDK\r\nLicense.IssuedTo=Digiphoto Entertainment Imaging (DIGI PHOTO STUDIO)\r\nLicense.CompanyID=9935\r\nLicense.UUID={CAC391B7-218B-410B-9269-881276411AF3}\r\nLicense.Key={AB2EAC69-CD8C-1289-C5B9-06F91BC7D922}\r\nLicense.Name=MPlaylist Module\r\nLicense.UpdateExpirationDate=June 22, 2017\r\nLicense.Edition=Standard\r\nLicense.AllowedModule=*.*\r\nLicense.Signature=3C486C8ECAF31EF562A21176F537B2730ED20EA2742CC12D303F2982D0D8FDA5AEDF22DD352532EB9770F071AEF40BB11B66049C7074AB4448FF83605E1D9CC6099D4B3D29F5C737CA989BB588DE828CB25BD68561FC4A9CD9EBD838C3D47D447FB9D3187DAAB18B3BC7A236FF9E2C99E2065A5230FA175714DDE52BFD84F893\r\n\r\n[MediaLooks]\r\nLicense.ProductName=MPlatform SDK\r\nLicense.IssuedTo=Digiphoto Entertainment Imaging (DIGI PHOTO STUDIO)\r\nLicense.CompanyID=9935\r\nLicense.UUID={72F1AEC9-A74D-48AD-B5E6-4A2ADB89FD94}\r\nLicense.Key={68909C79-0283-4FC7-AF7C-48B05278325B}\r\nLicense.Name=MFile Module\r\nLicense.UpdateExpirationDate=June 22, 2017\r\nLicense.Edition=Standard\r\nLicense.AllowedModule=*.*\r\nLicense.Signature=554BCBE97DCCE14F17C1E26D1F11395596A6F188BC068E5E8AC75616432CCA5E965593FB173E3F712D9B3A34FF604798C7597FAFD586A5D3AF532554138A7FB82ED4CDF7E712642D4F235087CDBA77EEE9508D1EB840A1919224A3AFEEBFEEA5AFA4B443B2E8E6B12EA08B9182D5B9EB46413CB050C5D3A53BAB8C5DF1EB27A5\r\n\r\n[MediaLooks]\r\nLicense.ProductName=MPlatform SDK\r\nLicense.IssuedTo=Digiphoto Entertainment Imaging (DIGI PHOTO STUDIO)\r\nLicense.CompanyID=9935\r\nLicense.UUID={2334607D-0337-42D6-9FAB-4FB0AFDE1BC1}\r\nLicense.Key={DCEB663F-4A5F-1409-EFB4-3831DAAA6B3E}\r\nLicense.Name=MLive Module\r\nLicense.UpdateExpirationDate=June 22, 2017\r\nLicense.Edition=Standard\r\nLicense.AllowedModule=*.*\r\nLicense.Signature=6B9E986B4F82E8CE4472B3492DCF625B282B0ADF7505CA898BF5E5DB5B95395F828E9F59F29306435F9D9439416A29583FD38B09FD509BC19A09423DB7533CDCDE0B593CA4380648B44EE231A9B126584900A963AFD7DEE777ABACE24881FCF59AD596CAC77BC2CF56912021A8783A1A5A7BBE2B4546F36F27028DC4D5FEC3BB\r\n\r\n[MediaLooks]\r\nLicense.ProductName=MPlatform SDK\r\nLicense.IssuedTo=Digiphoto Entertainment Imaging (DIGI PHOTO STUDIO)\r\nLicense.CompanyID=9935\r\nLicense.UUID={A22853AE-4178-4613-AF5F-F3AF2F9557BA}\r\nLicense.Key={D66FB4F2-C986-E47B-91B3-52570887ABF5}\r\nLicense.Name=MRenderer Module\r\nLicense.UpdateExpirationDate=June 22, 2017\r\nLicense.Edition=Standard\r\nLicense.AllowedModule=*.*\r\nLicense.Signature=B6982EED57071FDFFFA246F3DF183406E3626F63A715D6FC4779818D062BE6A348316563826DA6353785BA3E63EB0FA75800E6CF256B8CCEA2204A214FC49C75A79A290BA4848453F821CD3A374B2C0CDB028E40F7ABF882E6E364D5C9731883412FAB1488FACBA6084A9F50347623CB2DC203DD86FB413A6E23BC5DD3ED477D\r\n\r\n[MediaLooks]\r\nLicense.ProductName=MPlatform SDK\r\nLicense.IssuedTo=Digiphoto Entertainment Imaging (DIGI PHOTO STUDIO)\r\nLicense.CompanyID=9935\r\nLicense.UUID={0ADCF421-3111-48EA-951E-714FAF77E165}\r\nLicense.Key={DCEB663F-E421-976B-182C-47DF79A10691}\r\nLicense.Name=MTransportDS Module\r\nLicense.UpdateExpirationDate=June 22, 2017\r\nLicense.Edition=Standard\r\nLicense.AllowedModule=*.*\r\nLicense.Signature=E576D36B89BDEBCAB6725EFC2347048003F07C22C5C747F7D00AE6E3DE21A317909E9743B9CB4222E44E815C55F771D712742F6521E5544C59A883D58A84189559536A4CFDD7636E1CF7E23A77E54D91F3706C53EE20A5D7DA07D94F83BD2795465741B6F05C784241B6A53DAAD0DCA52AE0D25242C776CA0AF14D903DE65B0E\r\n\r\n[MediaLooks]\r\nLicense.ProductName=MPlatform SDK\r\nLicense.IssuedTo=Digiphoto Entertainment Imaging (DIGI PHOTO STUDIO)\r\nLicense.CompanyID=9935\r\nLicense.UUID={3A11BCFD-AA9C-4BFE-BAAA-369B442DD720}\r\nLicense.Key={F513A451-22C7-A315-CC46-5470C744D55C}\r\nLicense.Name=MMixer Module (BETA)\r\nLicense.UpdateExpirationDate=June 22, 2017\r\nLicense.Edition=Standard\r\nLicense.AllowedModule=*.*\r\nLicense.Signature=1D1417FB7A44F89ACB9AD69F51CEB8C0C8353E409003EDD8AB9148E1C891E3ACCA1452DF8AED3B2AB8C1854E8607E4F50E6AD9AF4724CF5C977B68246EE0A70F0517C73F2AAB79124EE86A3CAC62483B1880350646F913D5F061FFFD9DE5FAE39062D2378C956273C530C873BAB1DF4375A2E170BF6EBF1CFD015C5D384EE366\r\n\r\n[MediaLooks]\r\nLicense.ProductName=MPlatform SDK\r\nLicense.IssuedTo=Digiphoto Entertainment Imaging (DIGI PHOTO STUDIO)\r\nLicense.CompanyID=9935\r\nLicense.UUID={A73E6BBE-9E66-47A5-83EB-7E6BD5BE8D73}\r\nLicense.Key={3E325EC7-0DF8-CBCF-DA7B-093A47362195}\r\nLicense.Name=MediaLooks Character Generator\r\nLicense.UpdateExpirationDate=June 22, 2017\r\nLicense.Edition=Professional\r\nLicense.AllowedModule=*.*\r\nLicense.Signature=B935A93A8BE8684DCB60FFE6675DD1EB29EF99063B67C96157B2F43C2A854D328CE533BFD4B67C85F5D55D5DC844C0B3A953F04D6F0D9156F3AB993F857B70ACCE041FC89EA34954762F7E4D2F915B4ABFC1A97E16E12570CE3849E4863402C3D562C9A5A0B749172BFA07F06A30F842E4AD023FE6EAFC8C0E639491EC9E7497\r\n\r\n[MediaLooks]\r\nLicense.ProductName=MPlatform SDK\r\nLicense.IssuedTo=Digiphoto Entertainment Imaging (DIGI PHOTO STUDIO)\r\nLicense.CompanyID=9935\r\nLicense.UUID={6C6EF419-D9D5-434F-8723-BDC3EA250079}\r\nLicense.Key={A5897550-7FAF-BC19-8591-A8682E10C415}\r\nLicense.Name=MPlatform Module\r\nLicense.UpdateExpirationDate=June 22, 2017\r\nLicense.Edition=Standard\r\nLicense.AllowedModule=*.*\r\nLicense.Signature=E23A81DD02C7BF88268690BE998B7892D7461658C7F2AC654B03128B3278F13BE39BC902B539EC53DF0C51C542990B505630EDBDA805B88FFEF498633E1CED00D467FE3186CB4F82CCB4DCFD9C5C9563E3D2534D67A85ED2F69A565FD648CBE794CD8ABAA560595AD698E38510B4EA2E40B7DCD529DA0CC67D4972477769209F\r\n\r\n[MediaLooks]\r\nLicense.ProductName=MPlatform SDK\r\nLicense.IssuedTo=Digiphoto Entertainment Imaging (DIGI PHOTO STUDIO)\r\nLicense.CompanyID=9935\r\nLicense.UUID={7A337CB0-F944-47C4-8CCF-880310D22063}\r\nLicense.Key={9A4FCB62-711E-10D5-3D92-86F0F9DC9566}\r\nLicense.Name=Medialooks DXGI Screen Capture\r\nLicense.UpdateExpirationDate=June 22, 2017\r\nLicense.Edition=Standard\r\nLicense.AllowedModule=*.*\r\nLicense.Signature=5C305D282F1116A77F1FB2A073CB44148663329A6ED3FA213A1613A4F8921C47CCAF6885691332641AC815B2902CB69C0D8958041214525B24194B88B2052BAD8EAD81BF4A4C4B05A777D4A36540662B37F398149001100A368D0F1A0773C49C01531BE8AA4006B60B10E32FBA004AED8B8D21A4712E72FAD6E90B5EF9C76727\r\n\r\n[MediaLooks]\r\nLicense.ProductName=MPlatform SDK\r\nLicense.IssuedTo=Digiphoto Entertainment Imaging (DIGI PHOTO STUDIO)\r\nLicense.CompanyID=9935\r\nLicense.UUID={474848C6-A064-4BEE-A893-86BDB1B2328C}\r\nLicense.Key={E0CE9DF9-0711-D879-7454-A3622D7A1BF2}\r\nLicense.Name=MWebRTC module\r\nLicense.UpdateExpirationDate=June 22, 2017\r\nLicense.Edition=Standard\r\nLicense.AllowedModule=*.*\r\nLicense.Signature=2425256ADC1EB7C8B1E786F46FE1B24B8D674F890A7AA62692C837C36F3E8A0AF8513E7FFAC862A9FA30751413F62B5314B0EBAB074139968A0CD599C78ABEF30337011192023DACBD261E968CA1181B4062B889B38661117F0663349D367C4E62AA551D3C98B909BACA5452F924143710356CF03F2EDA09F38FC2DFE0A5822E\r\n\r\n";

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

