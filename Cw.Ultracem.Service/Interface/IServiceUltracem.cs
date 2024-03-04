using Cw.Ultracem.Service.Entidades;
using System.ServiceModel;
using System.Threading.Tasks;

namespace Cw.Ultracem.Service.Interface
{
    [ServiceContract(Namespace = "http://presentacion.ws.recaudos.v2/", Name = "NotificacionRecaudo")]
    public interface IServiceUltracem
    {
        /// <summary>
        /// Metodo para referenciar un pago y autorizar su aplicación en el banco
        /// </summary>
        /// <param name="referenciacionInput">CDATA xml con los datos de referenciacion enviado por el banco</param>
        /// <returns>ReferenciarRecaudoOutput</returns>
        /// ,Action = "http://presentacion.ws.recaudos.v2/referenciarRecaudo"
        [XmlSerializerFormat, OperationContract(Name = "referenciarRecaudo")]
        Task<NotificacionRecaudoWebService_referenciarRecaudoResponse> ReferenciarRecaudo(NotificacionRecaudoWebService_referenciarRecaudo referenciarRecaudoInput);
        
        /// <summary>
        /// Metodo utilizado para confirmar el recaudo
        /// </summary>
        /// <param name="confirmacionInput">CDATA xml de confirmacion enviado por el banco</param>
        /// <returns>ConfirmarRecaudoOutput</returns>
        /// ,Action = "http://presentacion.ws.recaudos.v2/confirmarRecaudo"
        [XmlSerializerFormat, OperationContract(Name = "confirmarRecaudo")]
       
        Task<NotificacionRecaudoWebService_confirmarRecaudoResponse> ConfirmarRecaudoAsync(NotificacionRecaudoWebService_confirmarRecaudo confirmacionInput);
        
        /// <summary>
        /// Metodo utilizado para confirmar el recaudo
        /// </summary>
        /// <param name="reversoInput">CDATA xml de reversion enviado por el banco</param>
        /// <returns>ReversarRecaudoOutput</returns>
        /// ,Action = "http://presentacion.ws.recaudos.v2/reversarRecaudo"
        [XmlSerializerFormat, OperationContract(Name = "reversarRecaudo")]
        Task<NotificacionRecaudoWebService_reversarRecaudoResponse> ReversarRecaudoAsync(NotificacionRecaudoWebService_reversarRecaudo reversoInput);
        /*
        /// <summary>
        /// Metodo utiliado para contultar el recaudo
        /// </summary>
        /// <param name="consultaRecaudo"></param>
        /// <returns></returns>
        //[OperationContract(Name = "consultarRecaudo", Action = "https://ws.ultracem.co/wsBancoOccidente/NotificacionRecaudoWebService/consultarRecaudo")]
        //Task<NotificacionRecaudoWebService_consultarRecaudoResponse> ConsultarRecaudoAsync(NotificacionRecaudoWebService_consultarRecaudo consultaRecaudo);
        */

        [XmlSerializerFormat, OperationContract(Name = "consultarRecaudo")]

        Task<NotificacionRecaudoWebService_consultarRecaudoResponse> ConsultarRecaudoAsync(NotificacionRecaudoWebService_consultarRecaudo consultaRecaudo);

    }
}
