using System;
using System.Xml;

namespace PhotoSW.Common
{
	public interface ICanXMLExportImport
	{
		string ExportXML();

		void ImportXML(XmlTextReader reader);
	}
}
