using System.Runtime.Serialization;
using System.ServiceModel;
using System.Xml.Serialization;

namespace Cw.Ultracem.Service.Entidades
{
    //[DataContract(Name = "referenciarRecaudo")]//, Namespace = "http://presentacion.ws.recaudos.v2"
    ////[MessageContract(WrapperName = "NotificacionRecaudoWebService_referenciarRecaudo")]//, WrapperNamespace = "http://presentacion.ws.recaudos.v2"
    //[MessageContract(WrapperName = "referenciarRecaudo", WrapperNamespace = "http://presentacion.ws.recaudos.v2")]//, WrapperNamespace = "http://presentacion.ws.recaudos.v2"
    ////ReferenciarRecaudo
    [XmlType]
    public class referenciarRecaudo

    {
        /// <summary>
        /// CDATA xml de confirmacion enviado por el banco
        /// </summary> 
        //[MessageBodyMember(Name = "referenciacionInputXML")]
        //[DataMember]
        [XmlElement(IsNullable = true)]
        public string referenciacionInputXML { get; set; }
    }
}
