using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace Cw.Ultracem.Service.Entidades
{
    //[System.ServiceModel.MessageContract(WrapperName = "NotificacionRecaudoWebService_reversarRecaudo")]
    [System.ServiceModel.MessageContract(WrapperNamespace = "http://presentacion.ws.recaudos.v2/", IsWrapped = false)]
    public class NotificacionRecaudoWebService_reversarRecaudo
    {
        [MessageBodyMember]
        [System.Xml.Serialization.XmlElement("reversarRecaudo")]
        public reversarRecaudo parameters { get; set; }
    }
}