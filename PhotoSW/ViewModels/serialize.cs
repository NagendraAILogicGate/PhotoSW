using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PhotoSW.ViewModels
{
    public static class serialize
    {
        public static string SerializeObject<T>(this T toSerialize)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(toSerialize.GetType());
            StringWriter stringWriter = new StringWriter();
            xmlSerializer.Serialize(stringWriter, toSerialize);
            string result;
            if (!false)
            {
                result = stringWriter.ToString().Replace("<?xml version=\"1.0\" encoding=\"utf-16\"?>", "");
            }
            return result;
        }

        public static T DeserializeXML<T>(this string xmlString)
        {
            xmlString = xmlString.Replace("xmlns=\"http://schemas.datacontract.org/2004/07/Digiphoto.PrinterSDKWrapper\" xmlns:i=\"http://www.w3.org/2001/XMLSchema-instance\"", "");
            if (false)
            {
                goto IL_81;
            }
            T t = default(T);
            StringReader stringReader;
            if (!false)
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                stringReader = new StringReader(xmlString);
                object obj;
                while (true)
                {
                    obj = xmlSerializer.Deserialize(stringReader);
                    int arg_60_0;
                    if (obj != null)
                    {
                        arg_60_0 = ((obj is T) ? 1 : 0);
                        goto IL_5F;
                    }
                    bool arg_69_0 = (arg_60_0 = 1) != 0;
                IL_65:
                    if (!false)
                    {
                        if (arg_69_0)
                        {
                            goto IL_7B;
                        }
                        if (3 != 0)
                        {
                            break;
                        }
                        continue;
                    }
                IL_5F:
                    arg_69_0 = ((arg_60_0 = ((arg_60_0 == 0) ? 1 : 0)) != 0);
                    goto IL_65;
                }
                t = (T)((object)obj);
            }
        IL_7A:
        IL_7B:
            stringReader.Close();
        IL_81:
            T result = t;
            if (4 != 0)
            {
                return result;
            }
            goto IL_7A;
        }
    }
}
