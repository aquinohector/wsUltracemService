using System.Runtime.Serialization;
using System.ServiceModel;
using System.Xml.Serialization;

namespace Cw.Ultracem.Service.Entidades
{
    [XmlType("consultarRecaudo")]
    public class consultarRecaudo
    {
        [XmlElement(IsNullable = true)]
        public string consultaInputXML { get; set; }
    }
}