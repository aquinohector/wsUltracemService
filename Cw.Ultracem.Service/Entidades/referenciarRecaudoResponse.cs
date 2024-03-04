using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Cw.Ultracem.Service.Entidades
{
    [XmlType]
    public class referenciarRecaudoResponse
    {

        [XmlElement(ElementName = "return", IsNullable = true)]
        public string retorno { get; set; }
    }
}