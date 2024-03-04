﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cw.Ultracem.ConsumoERP.ServicioSiesa {
    using System.Data;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServicioSiesa.WSUNOEESoap")]
    public interface WSUNOEESoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/CrearConexionXML", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        bool CrearConexionXML(string pvstrxmlConexion);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/CrearConexionXML", ReplyAction="*")]
        System.Threading.Tasks.Task<bool> CrearConexionXMLAsync(string pvstrxmlConexion);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/EjecutarConsultaXML", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet EjecutarConsultaXML(string pvstrxmlParametros);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/EjecutarConsultaXML", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> EjecutarConsultaXMLAsync(string pvstrxmlParametros);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/LeerEsquemaParametros", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string LeerEsquemaParametros(string pvstrxmlParametros);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/LeerEsquemaParametros", ReplyAction="*")]
        System.Threading.Tasks.Task<string> LeerEsquemaParametrosAsync(string pvstrxmlParametros);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SiesaCFD", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        object SiesaCFD(short pvintcia, string pvstrCo, string pvstrTipoDocto, long pvintConsecInicial, long pvintConsecFinal, string pvintConexion, long pvintTimeOut);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SiesaCFD", ReplyAction="*")]
        System.Threading.Tasks.Task<object> SiesaCFDAsync(short pvintcia, string pvstrCo, string pvstrTipoDocto, long pvintConsecInicial, long pvintConsecFinal, string pvintConexion, long pvintTimeOut);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ImportarXML", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Cw.Ultracem.ConsumoERP.ServicioSiesa.ImportarXMLResponse ImportarXML(Cw.Ultracem.ConsumoERP.ServicioSiesa.ImportarXMLRequest request);
        
        // CODEGEN: Generando contrato de mensaje, ya que la operación tiene múltiples valores de devolución.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ImportarXML", ReplyAction="*")]
        System.Threading.Tasks.Task<Cw.Ultracem.ConsumoERP.ServicioSiesa.ImportarXMLResponse> ImportarXMLAsync(Cw.Ultracem.ConsumoERP.ServicioSiesa.ImportarXMLRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/InicializarVariablesImportacion", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        void InicializarVariablesImportacion();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/InicializarVariablesImportacion", ReplyAction="*")]
        System.Threading.Tasks.Task InicializarVariablesImportacionAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SiesaWEBContabilizar", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        short SiesaWEBContabilizar(string pvstrParametros);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SiesaWEBContabilizar", ReplyAction="*")]
        System.Threading.Tasks.Task<short> SiesaWEBContabilizarAsync(string pvstrParametros);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ImportarXML", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class ImportarXMLRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public string pvstrDatos;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public short printTipoError;
        
        public ImportarXMLRequest() {
        }
        
        public ImportarXMLRequest(string pvstrDatos, short printTipoError) {
            this.pvstrDatos = pvstrDatos;
            this.printTipoError = printTipoError;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ImportarXMLResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class ImportarXMLResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public System.Data.DataSet ImportarXMLResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public short printTipoError;
        
        public ImportarXMLResponse() {
        }
        
        public ImportarXMLResponse(System.Data.DataSet ImportarXMLResult, short printTipoError) {
            this.ImportarXMLResult = ImportarXMLResult;
            this.printTipoError = printTipoError;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface WSUNOEESoapChannel : Cw.Ultracem.ConsumoERP.ServicioSiesa.WSUNOEESoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WSUNOEESoapClient : System.ServiceModel.ClientBase<Cw.Ultracem.ConsumoERP.ServicioSiesa.WSUNOEESoap>, Cw.Ultracem.ConsumoERP.ServicioSiesa.WSUNOEESoap {
        
        public WSUNOEESoapClient() {
        }
        
        public WSUNOEESoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WSUNOEESoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WSUNOEESoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WSUNOEESoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool CrearConexionXML(string pvstrxmlConexion) {
            return base.Channel.CrearConexionXML(pvstrxmlConexion);
        }
        
        public System.Threading.Tasks.Task<bool> CrearConexionXMLAsync(string pvstrxmlConexion) {
            return base.Channel.CrearConexionXMLAsync(pvstrxmlConexion);
        }
        
        public System.Data.DataSet EjecutarConsultaXML(string pvstrxmlParametros) {
            return base.Channel.EjecutarConsultaXML(pvstrxmlParametros);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> EjecutarConsultaXMLAsync(string pvstrxmlParametros) {
            return base.Channel.EjecutarConsultaXMLAsync(pvstrxmlParametros);
        }
        
        public string LeerEsquemaParametros(string pvstrxmlParametros) {
            return base.Channel.LeerEsquemaParametros(pvstrxmlParametros);
        }
        
        public System.Threading.Tasks.Task<string> LeerEsquemaParametrosAsync(string pvstrxmlParametros) {
            return base.Channel.LeerEsquemaParametrosAsync(pvstrxmlParametros);
        }
        
        public object SiesaCFD(short pvintcia, string pvstrCo, string pvstrTipoDocto, long pvintConsecInicial, long pvintConsecFinal, string pvintConexion, long pvintTimeOut) {
            return base.Channel.SiesaCFD(pvintcia, pvstrCo, pvstrTipoDocto, pvintConsecInicial, pvintConsecFinal, pvintConexion, pvintTimeOut);
        }
        
        public System.Threading.Tasks.Task<object> SiesaCFDAsync(short pvintcia, string pvstrCo, string pvstrTipoDocto, long pvintConsecInicial, long pvintConsecFinal, string pvintConexion, long pvintTimeOut) {
            return base.Channel.SiesaCFDAsync(pvintcia, pvstrCo, pvstrTipoDocto, pvintConsecInicial, pvintConsecFinal, pvintConexion, pvintTimeOut);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Cw.Ultracem.ConsumoERP.ServicioSiesa.ImportarXMLResponse Cw.Ultracem.ConsumoERP.ServicioSiesa.WSUNOEESoap.ImportarXML(Cw.Ultracem.ConsumoERP.ServicioSiesa.ImportarXMLRequest request) {
            return base.Channel.ImportarXML(request);
        }
        
        public System.Data.DataSet ImportarXML(string pvstrDatos, ref short printTipoError) {
            Cw.Ultracem.ConsumoERP.ServicioSiesa.ImportarXMLRequest inValue = new Cw.Ultracem.ConsumoERP.ServicioSiesa.ImportarXMLRequest();
            inValue.pvstrDatos = pvstrDatos;
            inValue.printTipoError = printTipoError;
            Cw.Ultracem.ConsumoERP.ServicioSiesa.ImportarXMLResponse retVal = ((Cw.Ultracem.ConsumoERP.ServicioSiesa.WSUNOEESoap)(this)).ImportarXML(inValue);
            printTipoError = retVal.printTipoError;
            return retVal.ImportarXMLResult;
        }
        
        public System.Threading.Tasks.Task<Cw.Ultracem.ConsumoERP.ServicioSiesa.ImportarXMLResponse> ImportarXMLAsync(Cw.Ultracem.ConsumoERP.ServicioSiesa.ImportarXMLRequest request) {
            return base.Channel.ImportarXMLAsync(request);
        }
        
        public void InicializarVariablesImportacion() {
            base.Channel.InicializarVariablesImportacion();
        }
        
        public System.Threading.Tasks.Task InicializarVariablesImportacionAsync() {
            return base.Channel.InicializarVariablesImportacionAsync();
        }
        
        public short SiesaWEBContabilizar(string pvstrParametros) {
            return base.Channel.SiesaWEBContabilizar(pvstrParametros);
        }
        
        public System.Threading.Tasks.Task<short> SiesaWEBContabilizarAsync(string pvstrParametros) {
            return base.Channel.SiesaWEBContabilizarAsync(pvstrParametros);
        }
    }
}