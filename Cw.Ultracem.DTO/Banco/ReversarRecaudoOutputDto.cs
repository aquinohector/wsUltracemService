using System;
using System.Collections.Generic;
using System.Text;

namespace Cw.Ultracem.DTO.Banco
{
    public class ReversarRecaudoOutputDto
    {
        /// <summary>
        /// [N3] Indica el tipo operación que se solicita. El valor para la Consulta de Recaudo es 139.
        /// </summary> 
        public string TipoRegistro { get; set; }

        /// <summary>
        /// [N4] Código de error al procesar la solicitud. Si no hay error este valor debe ser 0.
        /// </summary> 
        public string ErrorCodigo { get; set; }

        /// <summary>
		/// [AN100] Mensaje descriptivo del error originado. Si no hay error este puede estar vacio.
		/// </summary> 
        public string ErrorDescripcion { get; set; }

    }
}
