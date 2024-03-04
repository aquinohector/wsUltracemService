using System.Runtime.Serialization;
using System.ServiceModel;

namespace Cw.Ultracem.Service.Entidades
{
    [System.ServiceModel.MessageContract(WrapperNamespace = "http://presentacion.ws.recaudos.v2", IsWrapped = false)]
    public class NotificacionRecaudoWebService_reversarRecaudoResponse
    {
        [System.ServiceModel.MessageBodyMember]
        [System.Xml.Serialization.XmlElement("reversarRecaudoResponse")]
        public reversarRecaudoResponse parameters { get; set; }
    }
}