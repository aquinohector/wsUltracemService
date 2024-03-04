using System.IO;

namespace Cw.Ultracem.Service.Entidades
{
    public class ConsultarRecaudoInput
    {
        /// <summary>
        /// Metodo de deserializar el objeto de consultar
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static ConsultarRecaudoInput Deserialize(string xml)
        {
            System.Xml.Serialization.XmlSerializer xs = new System.Xml.Serialization.XmlSerializer(typeof(ConsultarRecaudoInput));
            TextReader reader = new StringReader(xml);
            ConsultarRecaudoInput c = (ConsultarRecaudoInput)xs.Deserialize(reader);
            reader.Close();
            return c;
        }
    }
}