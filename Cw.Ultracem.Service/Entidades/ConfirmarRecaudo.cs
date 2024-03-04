using System.Runtime.Serialization;
using System.ServiceModel;
using System.Xml.Serialization;

namespace Cw.Ultracem.Service.Entidades
{
    // //[DataContract(Namespace = "http://presentacion.ws.recaudos.v2")]
    // [MessageContract(WrapperName = "confirmarRecaudo")]//, WrapperNamespace = "http://presentacion.ws.recaudos.v2"
    // //[MessageContract(WrapperName = "NotificacionRecaudoWebService_confirmarRecaudo")]//, WrapperNamespace = "http://presentacion.ws.recaudos.v2"
    //[XmlType("confirmarRecaudo")]
    [XmlType]
    public class confirmarRecaudo
    {
        /// <summary>
        /// CDATA xml de confirmacion enviado por el banco
        /// </summary>
        //[MessageBodyMember(Name = "confirmacionInputXML")]
        [XmlElement(IsNullable = true)]
        public string confirmacionInputXML { get; set; }
    }
}