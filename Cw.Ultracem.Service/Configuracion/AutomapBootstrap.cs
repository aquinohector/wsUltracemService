using AutoMapper;
using Cw.Ultracem.DTO.Banco;
using Cw.Ultracem.Service.Entidades;
using System;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;

namespace Cw.Ultracem.Service.Configuracion
{
    public class AutomapBootstrap
    {
        /// <summary>
        /// Metodo que inicializa todas las clases que se van a mapear
        /// </summary>
        public static void InicializarMapper()
        {
            Mapper.CreateMap<ReferenciarRecaudoInput, ReferenciarRecaudoInputDto>();
            Mapper.CreateMap<ReferenciarRecaudoOutputDto, NotificacionRecaudoWebService_referenciarRecaudoResponse>();
            Mapper.CreateMap<ConfirmarRecaudoInput, ConfirmarRecaudoInputDto>();
            Mapper.CreateMap<ConfirmarRecaudoOutputDto, NotificacionRecaudoWebService_confirmarRecaudoResponse>();
            Mapper.CreateMap<ReversarRecaudoInput, ReversarRecaudoInputDto>();
            Mapper.CreateMap<ReversarRecaudoOutputDto, NotificacionRecaudoWebService_reversarRecaudoResponse>();
            Mapper.CreateMap<ConsultarRecaudoInput, ConsultarRecaudoInputDto>();
            Mapper.CreateMap<ConsultarRecaudoOutputDto, NotificacionRecaudoWebService_consultarRecaudoResponse>();
        }

    }

    /// <summary>
    /// Clase sellada que contiene la iniciación del Mapper.
    /// </summary>
    public sealed class AutomapServiceBehavior : Attribute, IServiceBehavior
    {
        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
        {
            AutomapBootstrap.InicializarMapper();
        }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {

        }

        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {

        }
    }
}