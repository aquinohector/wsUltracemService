using System;
using System.Collections.Generic;
using System.Text;

namespace Cw.Ultracem.DTO.Banco
{
    public class ConfirmarRecaudoInputDto
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfirmarRecaudoInputDto"/> class.
        /// </summary>
        public ConfirmarRecaudoInputDto()
        {
        }

        #endregion

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
        ///  [AN24] Número de referencia principal del recaudo (ej: número de factura).
        /// </summary> 
        public string referencia1 { get; set; }

        /// <summary>
        /// [AN24] Segunda referencia del recaudo. También puede estar vacio para ser devuelto en la respuesta de este mensaje.
        /// </summary> 
        public string referencia2 { get; set; }

        /// <summary>
        /// [N17] Valor en efectivo que paga el usuario. Los dos últimos digitos son decimales.
        /// </summary> 
        public string efectivo { get; set; }

        /// <summary>
		/// [N17] Valor en cheques propios del Banco de Occidente que paga el usuario. Los dos últimos digitos son decimales.
		/// </summary> 
        public string ch_propios { get; set; }

        /// <summary>
        /// [N17] Valor en cheques de otros bancos (distintos a Banco de Occidente) que paga el usuario. Los dos últimos digitos son decimales.
        /// </summary> 
        public string canje { get; set; }

        /// <summary>
        ///  [N16] Número de autorización de la transacción. Id de la transacción.
        /// </summary> 
        public string nro_autorizacion { get; set; }

        /// <summary>
        ///  [N17] Valor en otra forma de pago que se presente por parte del Banco. Los dos últimos digitos son decimales. Ver nota al inicio.
        /// </summary> 
        public string ingreso_vario { get; set; }

        /// <summary>
        /// [N17] Valor total en todas las formas de pago. Los dos últimos digitos son decimales.
        /// </summary> 
        public string total_transaccion { get; set; }

        /// <summary>
        ///  [N11] Numero de talonario para cuenta de ahorros
        /// </summary> 
        public string nro_docto { get; set; }

        /// <summary>
        /// [AN30] Nombre del pagador.
        /// </summary> 
        public string nombre_pagador { get; set; }

        /// <summary>
        /// [N1] Indicador número de registro de notificación. Es constante: 1
        /// </summary> 
        public string nro_registros { get; set; }

        /// <summary>
        ///  [N1] Indicador de trama de notificación. Es constante: 0
        /// </summary> 
        public string ind_notificacion { get; set; }

        /// <summary>
        /// [N1] Indicador de jornada adicional: 0 (Jornada Normal). 2 (Jornada Adicional).
        /// </summary> 
        public string ind_extemporaneidad { get; set; }

        /// <summary>
        /// [N5] Código que identifica la transacción.
        /// </summary> 
        public string cod_operacion { get; set; }

        /// <summary>
        /// [N24] Numero de documento adicional usado para recaudos especiales 
        /// </summary> 
        public string nro_docto_adic { get; set; }

        /// <summary>
        ///  [N5] Código del servicio
        /// </summary> 
        public string cod_empresa { get; set; }

        /// <summary>
        /// [N14 ]Constante: EXITOSO SAM
        /// </summary> 
        public string arreglo_1_9 { get; set; }

        #endregion

        #region Methods And Functions

        #endregion
    }
}
