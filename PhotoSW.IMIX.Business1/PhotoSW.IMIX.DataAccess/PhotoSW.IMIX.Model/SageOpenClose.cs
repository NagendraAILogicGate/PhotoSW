using System;
using System.Xml.Serialization;

namespace PhotoSW.IMIX.Model
{
	public class SageOpenClose
	{
		[XmlElement("ClosingFrom")]
		public SageInfoClosing objClose
		{
			get;
			set;
		}

		[XmlElement("OpeningFrom")]
		public SageInfo objOpen
		{
			get;
			set;
		}
	}
}
