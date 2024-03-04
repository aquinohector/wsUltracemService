using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cw.Ultracem.Service.Entidades
{
    //[System.ServiceModel.MessageContract(WrapperName = "NotificacionRecaudoWebService_confirmarRecaudo")]
    [System.ServiceModel.MessageContract(WrapperNamespace = "http://presentacion.ws.recaudos.v2/", IsWrapped = false)]
    public class NotificacionRecaudoWebService_confirmarRecaudo
    {
        [System.ServiceModel.MessageBodyMember] // no colcar esto genera otro schema
        [System.Xml.Serialization.XmlElement("confirmarRecaudo")]
        public confirmarRecaudo parameters { get; set; }
    }
}