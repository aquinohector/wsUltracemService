using System.Runtime.Serialization;
using System.ServiceModel;
using System.Xml.Serialization;

namespace Cw.Ultracem.Service.Entidades
{
    // //[DataContract( Namespace = "http://presentacion.ws.recaudos.v2")]
    // //[MessageContract(WrapperName = "NotificacionRecaudoWebService_reversarRecaudo")]//, WrapperNamespace = "http://presentacion.ws.recaudos.v2"
    //[MessageContract(WrapperName = "reversarRecaudo")]//, WrapperNamespace = "http://presentacion.ws.recaudos.v2"
    [XmlType]
    public class reversarRecaudo
    {
        /// <summary>
        /// CDATA xml de confirmacion enviado por el banco
        /// </summary>
        //[MessageBodyMember(Name = "reversoInputXML")]
        [XmlElement(IsNullable = true)]
        public string reversoInputXML { get; set; }
    }
}