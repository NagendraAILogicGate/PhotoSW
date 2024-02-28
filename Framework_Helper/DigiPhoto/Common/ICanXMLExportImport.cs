namespace DigiPhoto.Common
{
    using System;
    using System.Xml;

    public interface ICanXMLExportImport
    {
        string ExportXML();
        void ImportXML(XmlTextReader reader);
    }
}

