using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cw.Ultracem.Service.Entidades
{
    [System.ServiceModel.MessageContract(WrapperNamespace = "http://presentacion.ws.recaudos.v2/", IsWrapped = false)]
    public class NotificacionRecaudoWebService_consultarRecaudo
    {

        [System.ServiceModel.MessageBodyMember]//no colcar esto genera otro schema
        //[return:System.ServiceModel.MessageParameter(Name ="xyz")]
        [System.Xml.Serialization.XmlElement("consultarRecaudo")]
        public consultarRecaudo parameters { get; set; }

    }
}