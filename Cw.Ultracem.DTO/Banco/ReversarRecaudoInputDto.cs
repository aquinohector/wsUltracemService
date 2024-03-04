using System;
using System.Collections.Generic;
using System.Text;

namespace Cw.Ultracem.DTO.Banco
{
    public class ReversarRecaudoInputDto
    {

        #region Properties

        /// <summary>
        /// [AN16] usuario que usa el Banco de Occidente para identificarse
        /// </summary> 
        public string usuario { get; set; }

        /// <summary>
        /// [AN16] Clave de usuario
        /// </summary> 
        public string clave { get; set; }

        /// <summary>
        ///  [N3] Código de la entidad: Es constante: 023
        /// </summary> 
        public string cod_banco { get; set; }

        /// <summary>
        /// [N3] Indica el tipo operación que se solicita. El valor para la Consulta de Recaudo es 139.
        /// </summary> 
        public string tipo_registro { get; set; }

        /// <summary>
		/// [N10] Canal de la transacción. (oficina, internet, etc.) Para este caso, será 99: oficinas
		/// </summary> 
        public string canal { get; set; }

        /// <summary>
        /// [N3] Código de la oficina que origina la transacción
        /// </summary> 
        public string oficina { get; set; }

        /// <summary>
        ///  [N2] tipo de cuenta: 05 (Corriente), 10 (Ahorros) de la cuenta afectada
        /// </summary> 
        public string cod_producto { get; set; }

        /// <summary>
        /// [N9] Numero de la cuenta del cliente
        /// </summary> 
        public string nro_cuenta { get; set; }

        /// <summary>
		/// [N5] código del operador (cajero) en oficina que ejecuta la transacción en Banco.
		/// </summary> 
        public string operador { get; set; }

        /// <summary>
        /// [N8] Fecha de compensación de la transacción. Formato AAAMMDD
        /// </summary> 
        public string fecha_transaccion { get; set; }

        /// <summary>
        /// [N1] Jornada laboral, 1: Normal, 2: Adicional.
        /// </summary> 
        public string jornada { get; set; }

        /// <summary>
        ///  [N6] Hora de la terminal origen de la transacción.
        /// </summary> 
        public string hora_transaccion { get; set; }

        /// <summary>
        /// [AN6] identificación de la terminal origen de la transacción.
        /// </summary> 
        public string nro_terminal { get; set; }

        /// <summary>
        /// [N3] Código del motivo del reverso
        /// </summary> 
        public string cod_motivo { get; set; }

        /// <summary>
        /// [N16] Número de autorización de la transacción. Id de la transacción que se reversa.
        /// </summary> 
        public string nro_autorizacion { get; set; }

        /// <summary>
        /// [AN24] Número de la transacción del Cliente que se reversa.
        /// </summary> 
        public string nro_transac_cli { get; set; }

        #endregion

    }
}
