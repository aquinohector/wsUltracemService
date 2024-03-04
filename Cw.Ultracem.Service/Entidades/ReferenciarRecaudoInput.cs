
using System;
using System.IO;

namespace Cw.Ultracem.Service.Entidades
{
    [Serializable]
    public class ReferenciarRecaudoInput
    {
        #region Properties

        /// <summary>
        /// [AN16] usuario que usa el Banco de Occidente para identificarse
        /// </summary> 
        //[MessageBodyMember(Name ="usuario")]
        public string usuario { get; set; }

        /// <summary>
        /// [AN16] clave de usuario
        /// </summary> 
        //[MessageBodyMember(Name = "clave")]
        public string clave { get; set; }

        /// <summary>
        ///  [N3] Código de la entidad: Es constante: 023
        /// </summary> 
        //[MessageBodyMember(Name = "cod_banco")]
        public string cod_banco { get; set; }

        /// <summary>
        /// [N3] Indica el tipo operación que se solicita. El valor para la Consulta de Recaudo es 139.
        /// </summary> 
        //[MessageBodyMember(Name = "tipo_registro")]
        public string tipo_registro { get; set; }

        /// <summary>
        /// [N10] Canal de la transacción. (oficina, internet, etc.) Para este caso, será 99: oficinas
        /// </summary> 
        //[MessageBodyMember(Name = "canal")]
        public string canal { get; set; }

        /// <summary>
        /// [N3] Código de la oficina que origina la transacción
        /// </summary> 
        //[MessageBodyMember(Name = "oficina")]
        public string oficina { get; set; }

        /// <summary>
        ///  [N2] tipo de cuenta: 05 (Corriente), 10 (Ahorros) de la cuenta afectada
        /// </summary> 
        //[MessageBodyMember(Name = "cod_producto")]
        public string cod_producto { get; set; }

        /// <summary>
        /// [N9] Numero de la cuenta del cliente
        /// </summary> 
        //[MessageBodyMember(Name = "nro_cuenta")]
        public string nro_cuenta { get; set; }

        /// <summary>
		/// [N5] código del operador (cajero) en oficina que ejecuta la transacción en Banco.
		/// </summary> 
        //[MessageBodyMember(Name = "operador")]
        public string operador { get; set; }

        /// <summary>
        /// [N8] Fecha de compensación de la transacción. Formato AAAMMDD
        /// </summary> 
        //[MessageBodyMember(Name = "fecha_transaccion")]
        public string fecha_transaccion { get; set; }

        /// <summary>
        /// [N1] Jornada laboral, 1: Normal, 2: Adicional.
        /// </summary> 
        //[MessageBodyMember(Name = "jornada")]
        public string jornada { get; set; }

        /// <summary>
        ///  [N6] Hora de la terminal origen de la transacción.
        /// </summary> 
        //[MessageBodyMember(Name = "hora_transaccion")]
        public string hora_transaccion { get; set; }

        /// <summary>
		/// [AN6] identificación de la terminal origen de la transacción.
		/// </summary> 
        //[MessageBodyMember(Name = "nro_terminal")]
        public string nro_terminal { get; set; }

        /// <summary>
        ///  [AN24] Número de referencia principal del recaudo (ej: número de factura).
        /// </summary> 
        //[MessageBodyMember(Name = "referencia1")]
        public string referencia1 { get; set; }

        /// <summary>
        /// [AN24] Segunda referencia del recaudo. También puede estar vacio para ser devuelto en la respuesta de este mensaje.
        /// </summary> 
        //[MessageBodyMember(Name = "referencia2")]
        public string referencia2 { get; set; }

        /// <summary>
        /// [N17] Valor en efectivo que paga el usuario. Los dos últimos digitos son decimales.
        /// </summary> 
        //[MessageBodyMember(Name = "efectivo")]
        public string efectivo { get; set; }

        /// <summary>
		/// [N17] Valor en cheques propios del Banco de Occidente que paga el usuario. Los dos últimos digitos son decimales.
		/// </summary> 
        //[MessageBodyMember(Name = "ch_propios")]
        public string ch_propios { get; set; }

        /// <summary>
        /// [N17] Valor en cheques de otros bancos (distintos a Banco de Occidente) que paga el usuario. Los dos últimos digitos son decimales.
        /// </summary> 
        //[MessageBodyMember(Name = "canje")]
        public string canje { get; set; }

        /// <summary>
        ///  [N17] Valor en otra forma de pago que se presente por parte del Banco. Los dos últimos digitos son decimales. Ver nota al inicio.
        /// </summary> 
        //[MessageBodyMember(Name = "ingreso_vario")]
        public string ingreso_vario { get; set; }

        /// <summary>
        /// [N17] Valor total en todas las formas de pago. Los dos últimos digitos son decimales.
        /// </summary> 
        //[MessageBodyMember(Name = "total_transaccion")]
        public string total_transaccion { get; set; }

        /// <summary>
        ///  [N11] Numero de talonario para cuenta de ahorros
        /// </summary> 
        //[MessageBodyMember(Name = "nro_docto")]
        public string nro_docto { get; set; }

        /// <summary>
        /// [AN30] Nombre del pagador.
        /// </summary> 
        //[MessageBodyMember(Name = "nombre_pagador")]
        public string nombre_pagador { get; set; }

        /// <summary>
        /// [N1] Indicador número de registro de notificación. Es constante: 1
        /// </summary> 
        //[MessageBodyMember(Name = "nro_registros")]
        public string nro_registros { get; set; }

        /// <summary>
        ///  [N1] Indicador de trama de notificación. Es constante: 0
        /// </summary> 
        //[MessageBodyMember(Name = "ind_notificacion")]
        public string ind_notificacion { get; set; }

        /// <summary>
        /// [N1] Indicador de jornada adicional: 0 (Jornada Normal). 2 (Jornada Adicional).
        /// </summary> 
        //[MessageBodyMember(Name = "ind_extemporaneidad")]
        public string ind_extemporaneidad { get; set; }

        /// <summary>
        /// [N5] Código que identifica la transacción.
        /// </summary> 
        //[MessageBodyMember(Name = "cod_operacion")]
        public string cod_operacion { get; set; }

        /// <summary>
        ///  [N2] Indicador de recaudo
        /// </summary> 
        //[MessageBodyMember(Name = "ind_recaudo")]
        public string ind_recaudo { get; set; }

        /// <summary>
        /// [N24] Numero de documento adicional usado para recaudos especiales 
        /// </summary> 
        //[MessageBodyMember(Name = "nro_docto_adicional")]
        public string nro_docto_adicional { get; set; }

        /// <summary>
        ///  [N5] Código del servicio
        /// </summary> 
        //[MessageBodyMember(Name = "cod_empresa")]
        public string cod_empresa { get; set; }

        /// <summary>
        /// [N14 ]Constante: EXITOSO SAM
        /// </summary> 
        //[MessageBodyMember(Name = "arreglo_1_9")]
        public string arreglo_1_9 { get; set; }

        #endregion

        /// <summary>
        /// Metodo utilizado para deserializar el xml y llenar las propiedades de la clase 
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static ReferenciarRecaudoInput Deserialize(string xml)
        {
            System.Xml.Serialization.XmlSerializer xs = new System.Xml.Serialization.XmlSerializer(typeof(ReferenciarRecaudoInput));
            TextReader reader = new StringReader(xml);
            ReferenciarRecaudoInput c = (ReferenciarRecaudoInput)xs.Deserialize(reader);
            reader.Close();
            return c;
        }

    }
}