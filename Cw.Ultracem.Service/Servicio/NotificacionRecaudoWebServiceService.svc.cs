using AutoMapper;
using Cw.Ultracem.BL.Implementacion;
using Cw.Ultracem.BL.Interface;
using Cw.Ultracem.DTO.Banco;
using Cw.Ultracem.Service.Configuracion;
using Cw.Ultracem.Service.Entidades;
using Cw.Ultracem.Service.Interface;
using Cw.Ultracem.Service.Utilidades;
using System;
using System.ServiceModel;
using System.Threading.Tasks;


namespace Cw.Ultracem.Service.Servicio
{
    [AutomapServiceBehavior]
    [ServiceBehavior(Namespace = "http://presentacion.ws.recaudos.v2/", Name = "NotificacionRecaudoWebServiceService")] 
    public class NotificacionRecaudoWebServiceService : IServiceUltracem
    {
        public IServiceUltracemBL ServiceUltracemBL { get; set; }

        /// <summary>
        /// Metodo para referenciar un pago y autorizar su aplicación en el banco
        /// </summary>
        /// <param name="referenciacionInputXML">xml con los datos de referenciacion enviado por el banco</param>
        /// <returns>ReferenciarRecaudoOutput</returns>        
        public async Task<NotificacionRecaudoWebService_referenciarRecaudoResponse> ReferenciarRecaudo(NotificacionRecaudoWebService_referenciarRecaudo referenciarInput)
        {
            try
            {
                ServiceUltracemBL = new ServiceUltracemBL();

                //Se realiza el reemplazo del nombre del objeto para hacer la deserialización correctamente
                string referenciacionInputXML = referenciarInput.parameters.referenciacionInputXML.ToString().Replace("referenciar-recaudo-input", "ReferenciarRecaudoInput");
                ReferenciarRecaudoInput referenciarRecaudoInput = ReferenciarRecaudoInput.Deserialize(referenciacionInputXML.Trim());
                ReferenciarRecaudoInputDto referenciarRecaudoInputDto = Mapper.Map<ReferenciarRecaudoInputDto>(referenciarRecaudoInput);
                ReferenciarRecaudoOutputDto referenciarRecaudoOutputDto = await ServiceUltracemBL.ReferenciarRecaudo(referenciarRecaudoInputDto);
                //mapear a ReferenciarReacudoOutput
                ReferenciarRecaudoOutput referenciarRecaudoOutput= Mapper.Map<ReferenciarRecaudoOutput>(referenciarRecaudoOutputDto);
                //Instanciar referenciarRecaudoResponse
                referenciarRecaudoResponse referenciarrecaudoResponse = new referenciarRecaudoResponse();

                Utilidades.Utilidades utilidades  = new Utilidades.Utilidades();
                referenciarrecaudoResponse.retorno = utilidades.serializar<ReferenciarRecaudoOutput>(referenciarRecaudoOutput);// "serializacion de referenciarRecaudoOutput";
                //serializar ReferenciaReacudoOutput y guardarla en retorno de referenciarRecaudoResponse
                
                


                //asignara a NotificacionRecaudoWebService_referenciarRecaudoResponse
                NotificacionRecaudoWebService_referenciarRecaudoResponse notificacionRecaudoWebService_referenciarRecaudoResponse = new NotificacionRecaudoWebService_referenciarRecaudoResponse(); //Mapper.Map<NotificacionRecaudoWebService_referenciarRecaudoResponse>(referenciarRecaudoOutputDto);
                notificacionRecaudoWebService_referenciarRecaudoResponse.parameters = referenciarrecaudoResponse;
                return notificacionRecaudoWebService_referenciarRecaudoResponse;
            }
            catch (Exception e)
            {
                throw new FaultException(e.ToString());
            }
            
        }
        
        /// <summary>
        /// Metodo utilizado para confirmar el recaudo
        /// </summary>
        /// <param name="confirmacionInputXML">xml de confirmacion enviado por el banco</param>
        /// <returns>ConfirmarRecaudoOutput</returns>
        public async Task<NotificacionRecaudoWebService_confirmarRecaudoResponse> ConfirmarRecaudoAsync(NotificacionRecaudoWebService_confirmarRecaudo confirmacionInput)
        {
            try
            {
                ServiceUltracemBL = new ServiceUltracemBL();
                //.confirmarReacudo
                //Se realiza el reemplazo del nombre del objeto para hacer la deserialización correctamente
                string confirmacionInputXML = confirmacionInput.parameters.confirmacionInputXML.Replace("confirmar-recaudo-input", "ConfirmarRecaudoInput");
                ConfirmarRecaudoInput confirmarRecaudoInput = ConfirmarRecaudoInput.Deserialize(confirmacionInputXML);
                ConfirmarRecaudoInputDto confirmarRecaudoInputDto = Mapper.Map<ConfirmarRecaudoInputDto>(confirmarRecaudoInput);
                ConfirmarRecaudoOutputDto confirmarRecaudoOutputDto = await ServiceUltracemBL.ConfirmarRecaudoAsync(confirmarRecaudoInputDto);
                //
                ConfirmarRecaudoOutput confirmarRecaudoOutput= Mapper.Map<ConfirmarRecaudoOutput>(confirmarRecaudoOutputDto);
                //
                confirmarRecaudoResponse confirmarrecaudoResponse = new confirmarRecaudoResponse();
                Utilidades.Utilidades utilidades = new Utilidades.Utilidades();

                confirmarrecaudoResponse.retorno = utilidades.serializar< ConfirmarRecaudoOutput>(confirmarRecaudoOutput);//"serializacion de confirmarRecaudoOutput";

                NotificacionRecaudoWebService_confirmarRecaudoResponse notificacionRecaudoWebService_confirmarRecaudoResponse = new NotificacionRecaudoWebService_confirmarRecaudoResponse();
                notificacionRecaudoWebService_confirmarRecaudoResponse.parameters = confirmarrecaudoResponse;
                return notificacionRecaudoWebService_confirmarRecaudoResponse;
            }
            catch (Exception e)
            {
                throw new FaultException(e.ToString());
            }
        }
        
        /// <summary>
        /// Metodo utilizado para confirmar el recaudo
        /// </summary>
        /// <param name="reversoInput">xml de reversion enviado por el banco</param>
        /// <returns>ReversarRecaudoOutput</returns>
        public async Task<NotificacionRecaudoWebService_reversarRecaudoResponse> ReversarRecaudoAsync(NotificacionRecaudoWebService_reversarRecaudo reversoInput)
        {
            try
            {
                ServiceUltracemBL = new ServiceUltracemBL();

                //Se realiza el reemplazo del nombre del objeto para hacer la deserialización correctamente
                string reversoInputXML = reversoInput.parameters.reversoInputXML.Replace("reversar-recaudo-input", "ReversarRecaudoInput");
                ReversarRecaudoInput reversarRecaudoInput = ReversarRecaudoInput.Deserialize(reversoInputXML);
                ReversarRecaudoInputDto reversarRecaudoInputDto = Mapper.Map<ReversarRecaudoInputDto>(reversarRecaudoInput);
                ReversarRecaudoOutputDto reversarRecaudoOutputDto = await ServiceUltracemBL.ReversarRecaudoAsync(reversarRecaudoInputDto);
                //
                ReversarRecaudoOutput reversarRecaudoOutput= Mapper.Map<ReversarRecaudoOutput>(reversarRecaudoOutputDto);
                reversarRecaudoResponse reversarrecaudoResponse = new reversarRecaudoResponse();
                Utilidades.Utilidades utilidades = new Utilidades.Utilidades();

                reversarrecaudoResponse.retorno = utilidades.serializar<ReversarRecaudoOutput>(reversarRecaudoOutput); //"serializacion de reversarRecaudoOutput";

                NotificacionRecaudoWebService_reversarRecaudoResponse notificacionRecaudoWebService_reversarRecaudoResponse = new NotificacionRecaudoWebService_reversarRecaudoResponse();
                notificacionRecaudoWebService_reversarRecaudoResponse.parameters = reversarrecaudoResponse;
                return notificacionRecaudoWebService_reversarRecaudoResponse;
            }
            catch (Exception e)
            {
                throw new FaultException(e.ToString());
            }
        }


        /// <summary>
        /// Metodo utiliado para contultar el recaudo
        /// </summary>
        /// <param name="consultaRecaudo"></param>
        /// <returns></returns>
        //public async Task<NotificacionRecaudoWebService_consultarRecaudoResponse> ConsultarRecaudoAsync(NotificacionRecaudoWebService_consultarRecaudo consultaRecaudo)
        //{
        //    try
        //    {
        //        ServiceUltracemBL = new ServiceUltracemBL();

        //        //Se realiza el reemplazo del nombre del objeto para hacer la deserialización correctamente
        //        string consultaInputXML = consultaRecaudo.consultarInputXML.Replace("consultar-recaudo-input", "ConsultarRecaudoInput");
        //        ConsultarRecaudoInput consultarRecaudoInput = ConsultarRecaudoInput.Deserialize(consultaInputXML);
        //        ConsultarRecaudoInputDto consultarRecaudoInputDto = Mapper.Map<ConsultarRecaudoInputDto>(consultarRecaudoInput);
        //        ConsultarRecaudoOutputDto consultarRecaudoOutputDto = await ServiceUltracemBL.ConsultarRecaudoAsync(consultarRecaudoInputDto);
        //        NotificacionRecaudoWebService_consultarRecaudoResponse consultarRecaudoOutput = Mapper.Map<NotificacionRecaudoWebService_consultarRecaudoResponse>(consultarRecaudoOutputDto);
        //        return consultarRecaudoOutput;
        //    }
        //    catch (Exception e)
        //    {
        //        throw new FaultException(e.ToString());
        //    }
        //}

        public async Task<NotificacionRecaudoWebService_consultarRecaudoResponse> ConsultarRecaudoAsync(NotificacionRecaudoWebService_consultarRecaudo consultaRecaudo)
        {
            try
            {
                ServiceUltracemBL = new ServiceUltracemBL();

                //Se realiza el reemplazo del nombre del objeto para hacer la deserialización correctamente
                string consultaInputXML = consultaRecaudo.parameters.consultaInputXML.Replace("consultar-recaudo-input", "ConsultarRecaudoInput");
                ConsultarRecaudoInput consultarRecaudoInput = ConsultarRecaudoInput.Deserialize(consultaInputXML);
                ConsultarRecaudoInputDto consultarRecaudoInputDto = Mapper.Map<ConsultarRecaudoInputDto>(consultarRecaudoInput);
                ConsultarRecaudoOutputDto consultarRecaudoOutputDto = await ServiceUltracemBL.ConsultarRecaudoAsync(consultarRecaudoInputDto);

                consultarRecaudoResponse consultarrecaudoResponse = new consultarRecaudoResponse();
                consultarrecaudoResponse.retorno = "0";


                NotificacionRecaudoWebService_consultarRecaudoResponse notificacionRecaudoWebService_consultarRecaudoResponse = new NotificacionRecaudoWebService_consultarRecaudoResponse();
                notificacionRecaudoWebService_consultarRecaudoResponse.parameters = consultarrecaudoResponse;
                return notificacionRecaudoWebService_consultarRecaudoResponse;
            }
            catch (Exception e)
            {
                throw new FaultException(e.ToString());
            }
        }
    }
}
