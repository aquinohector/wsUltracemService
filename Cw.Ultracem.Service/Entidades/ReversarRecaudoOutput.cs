using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Cw.Ultracem.Service.Entidades
{
    [Serializable]
    [XmlType(typeName: "reversar-recaudo-output")]
    public class ReversarRecaudoOutput
    {
        /// <summary>
        /// [N3] Indica el tipo operación que se solicita. El valor para la Consulta de Recaudo es 139.
        /// </summary> 
    //    [MessageBodyMember(Name = "tipo_registro")]
        [XmlElement(ElementName = "tipo_registro")]
        public string TipoRegistro { get; set; }

        /// <summary>
        /// [N4] Código de error al procesar la solicitud. Si no hay error este valor debe ser 0.
        /// </summary> 
     //   [MessageBodyMember(Name = "error_codigo")]
        [XmlElement(ElementName = "error_codigo")]
        public string ErrorCodigo { get; set; }

        /// <summary>
		/// [AN100] Mensaje descriptivo del error originado. Si no hay error este puede estar vacio.
		/// </summary> 
     //   [MessageBodyMember(Name = "error_descripcion")]
        [XmlElement(ElementName = "error_descripcion")]
        public string ErrorDescripcion { get; set; }
    }
}