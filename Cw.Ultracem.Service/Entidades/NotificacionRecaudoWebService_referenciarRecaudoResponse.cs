using System.Runtime.Serialization;
using System.ServiceModel;

namespace Cw.Ultracem.Service.Entidades
{
    [System.ServiceModel.MessageContract(WrapperNamespace = "http://presentacion.ws.recaudos.v2/", IsWrapped = false)]
    public class NotificacionRecaudoWebService_referenciarRecaudoResponse
    {
        [System.ServiceModel.MessageBodyMember]
        [System.Xml.Serialization.XmlElement("referenciarRecaudoResponse")]
        public referenciarRecaudoResponse parameters { get; set; }

    }
}