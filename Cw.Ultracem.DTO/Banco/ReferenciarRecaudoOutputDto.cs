using System;
using System.Collections.Generic;
using System.Text;

namespace Cw.Ultracem.DTO.Banco
{
    public class ReferenciarRecaudoOutputDto
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ReferenciarRecaudoOutputDto"/> class.
        /// </summary>
        public ReferenciarRecaudoOutputDto()
        {
        }

        #endregion

        #region Properties

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

        /// <summary>
        ///  [AN24] Número de referencia principal del recaudo (ej: número de factura).
        /// </summary> 
        public string Referencia1 { get; set; }

        /// <summary>
        /// [AN24] Segunda referencia del recaudo. También puede estar vacio para ser devuelto en la respuesta de este mensaje.
        /// </summary> 
        public string Referencia2 { get; set; }

        #endregion

        #region Methods And Functions

        #endregion
    }
}
