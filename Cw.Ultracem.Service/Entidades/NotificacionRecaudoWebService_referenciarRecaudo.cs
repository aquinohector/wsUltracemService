using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Cw.Ultracem.Service.Entidades
{
    [System.ServiceModel.MessageContract(WrapperNamespace = "http://presentacion.ws.recaudos.v2/",IsWrapped =false)]
    
    public class NotificacionRecaudoWebService_referenciarRecaudo
    {
        [System.ServiceModel.MessageBodyMember]
        [System.Xml.Serialization.XmlElement("referenciarRecaudo")]

        public referenciarRecaudo parameters{ get; set; }

    }
}