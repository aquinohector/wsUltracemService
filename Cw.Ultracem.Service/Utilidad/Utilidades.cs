using System;
using System.Text;
using System.Xml.Serialization;

namespace Cw.Ultracem.Service.Utilidades
{
    public class Utilidades
    {
        public string serializar<T>(T obj)
        {

            XmlSerializer x = new XmlSerializer(typeof(T));

            String resp = "";

            using (StringWriterUtf8 textWriter = new StringWriterUtf8())
            {
                x.Serialize(textWriter, obj);
                resp = textWriter.ToString();
                //resp = SecurityElement.Escape(resp);
            }
            return resp;
        }

        public class StringWriterUtf8 : System.IO.StringWriter
        {
            public override Encoding Encoding
            {
                get
                {
                    return Encoding.UTF8;
                }
            }
        }
    }
}