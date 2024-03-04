using Cw.Ultracem.BL.Config;
using Cw.Ultracem.BL.Interface;
using Cw.Ultracem.DTO.Banco;
using System;
using System.IO;
using Cw.Ultracem.ConsumoERP.Interface;
using Cw.Ultracem.ConsumoERP.Implementacion;
using System.Threading.Tasks;
using System.Xml.Linq;
using Cw.Ultracem.Data.Models;
using System.Xml.Serialization;
using Cw.Ultracem.Data.Interface;
using Cw.Ultracem.Data.Implementacion;
using System.Data;
using System.Net.Mail;
using System.Net;
using System.Collections.Generic;

namespace Cw.Ultracem.BL.Implementacion
{
    public class ServiceUltracemBL : IServiceUltracemBL
    {
        /// <summary>
        /// Interfaz que contiene el consumo al ERP de Siesa
        /// </summary>
        public IConsumo Consumo { set; get; }

        /// <summary>
        /// Interfaz que contiene la comunicación con DB
        /// </summary>
        public ILogBancoSiesaDao LogBancoSiesaDao { set; get; }

        /// <summary>
        /// Metodo que implementa la logica de referenciar recaudo
        /// </summary>
        /// <param name="referenciarRecaudoInput"></param>
        /// <returns></returns>
        public async Task<ReferenciarRecaudoOutputDto> ReferenciarRecaudo(ReferenciarRecaudoInputDto referenciarRecaudoInput)
        {
            try
            {
                //Leer el archivo de configuracion
                string file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"configEjecutar.xml");
                ConfiguracionEjecutar conf = ConfiguracionEjecutar.Deserialize(file);

                ReferenciarRecaudoOutputDto referenciarRecaudoOutputDto = new ReferenciarRecaudoOutputDto
                {
                    ErrorCodigo = "0",
                    ErrorDescripcion = "",
                    TipoRegistro = "390",
                    Referencia1 = referenciarRecaudoInput.referencia1,
                    Referencia2 = referenciarRecaudoInput.referencia2
                };

                //Validaciones
                if (string.IsNullOrEmpty(referenciarRecaudoInput.referencia1))
                {
                    referenciarRecaudoOutputDto.ErrorCodigo = "1";
                    referenciarRecaudoOutputDto.ErrorDescripcion = "Referencia 1 vacía";
                    return referenciarRecaudoOutputDto;
                }

                if (string.IsNullOrEmpty(referenciarRecaudoInput.usuario))
                {
                    referenciarRecaudoOutputDto.ErrorCodigo = "2";
                    referenciarRecaudoOutputDto.ErrorDescripcion = "Usuario invalido";
                    return referenciarRecaudoOutputDto;
                }

                if (string.IsNullOrEmpty(referenciarRecaudoInput.clave))
                {
                    referenciarRecaudoOutputDto.ErrorCodigo = "3";
                    referenciarRecaudoOutputDto.ErrorDescripcion = "Clave invalida";
                    return referenciarRecaudoOutputDto;
                }

                XElement parametros = new XElement("pvstrxmlParametros",
                    new XElement("Consulta",
                        new XElement("NombreConexion", conf.Nombreconexion),
                        new XElement("IdCia", conf.Compania),
                        new XElement("IdProveedor", "BCO"),
                        new XElement("IdConsulta", "CONSULTA_CLIENTE_BCO_OCCIDENTE"),
                        new XElement("Usuario", conf.Usuario),
                        new XElement("Clave", conf.ClaveUsuario),
                        new XElement("Parametros",
                            new XElement("id_cia", conf.Compania),
                            new XElement("nit", referenciarRecaudoInput.referencia1))));

                Consumo = new Consumo();

                LogBancoSiesa logBancoSiesa = new LogBancoSiesa()
                {
                    XmlBanco = ToXML(referenciarRecaudoInput),
                    XmlSiesa = parametros.ToString(),
                    TipoConsulta = "Referenciacion Cliente",
                    FechaConsumo = DateTime.Now,
                    Resultado = "Exitoso",
                    Referencia1 = referenciarRecaudoInput.referencia1
                };

                try
                {
                    DataSet arrayResult = await Consumo.EjecutarXmlAsync(parametros.ToString());

                    if (arrayResult.Tables[0].Rows.Count == 0) // No se obtuvieron datos
                    {
                        logBancoSiesa.Resultado = "Cliente no encontrado";
                        referenciarRecaudoOutputDto.ErrorCodigo = "10";
                        referenciarRecaudoOutputDto.ErrorDescripcion = "Cliente no encontrado";
                    }
                }
                catch (Exception e)
                {
                    logBancoSiesa.Resultado = "Error en el consumo del servicio de cliente SIESA --> " + e.Message;
                    referenciarRecaudoOutputDto.ErrorCodigo = "20";
                    referenciarRecaudoOutputDto.ErrorDescripcion = "Error en el consumo del servicio de cliente SIESA --> " + e.Message;
                }

                LogBancoSiesaDao = new LogBancoSiesaDao();
                await LogBancoSiesaDao.Add(logBancoSiesa);

                return referenciarRecaudoOutputDto;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Metodo que implementa la logica de confirmación de recaudo
        /// </summary>
        /// <param name="confirmarRecaudoInputDto"></param>
        /// <returns></returns>
        public async Task<ConfirmarRecaudoOutputDto> ConfirmarRecaudoAsync(ConfirmarRecaudoInputDto confirmarRecaudoInputDto)
        {
            try
            {
                //Leer el archivo de configuracion
                string file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"configImportar.xml");
                ConfiguracionImportar conf = ConfiguracionImportar.Deserialize(file);

                file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"configEjecutar.xml");
                ConfiguracionEjecutar confEjecutar = ConfiguracionEjecutar.Deserialize(file);

                Consumo = new Consumo();
                LogBancoSiesaDao = new LogBancoSiesaDao();
                LogBancoSiesa logBancoSiesa = null;
                XElement parametros = null;
                List<string> listCxC = new List<string>();
                double totalTransaccion = 0;

                string excepcion = "";

                //contador para las líneas de los conectores
                int cont = 1;

                //Conectores
                string inicial = "", final = "", RC = "", Caja = "", CxC = "", dec = "";

                string msg = "";

                //Información cuando se está pagando un credito y se necesita el conector CxC
                string tipoDocCruce = "", docCruce = "", centroCruce = "", unidadCruce = "", sucursalCruce = "", auxiliarCruce = "";
                int cuotasCruce = 0;
                double saldoPendiente = 0;

                ConfirmarRecaudoOutputDto confirmarRecaudoOutputDto = new ConfirmarRecaudoOutputDto
                {
                    ErrorCodigo = "0",
                    ErrorDescripcion = "",
                    TipoRegistro = "185",
                    NumeroTransaccionCliente = confirmarRecaudoInputDto.nro_autorizacion
                };

                //Validaciones

                if (string.IsNullOrEmpty(confirmarRecaudoInputDto.nro_autorizacion))
                {
                    confirmarRecaudoOutputDto.ErrorCodigo = "1";
                    confirmarRecaudoOutputDto.ErrorDescripcion = "Numero de autorización vacío";
                    return confirmarRecaudoOutputDto;
                }

                if (string.IsNullOrEmpty(confirmarRecaudoInputDto.usuario))
                {
                    confirmarRecaudoOutputDto.ErrorCodigo = "2";
                    confirmarRecaudoOutputDto.ErrorDescripcion = "Usuario invalido";
                    return confirmarRecaudoOutputDto;
                }

                if (string.IsNullOrEmpty(confirmarRecaudoInputDto.clave))
                {
                    confirmarRecaudoOutputDto.ErrorCodigo = "3";
                    confirmarRecaudoOutputDto.ErrorDescripcion = "Clave invalida";
                    return confirmarRecaudoOutputDto;
                }

                if (string.IsNullOrEmpty(confirmarRecaudoInputDto.efectivo))
                {
                    confirmarRecaudoOutputDto.ErrorCodigo = "4";
                    confirmarRecaudoOutputDto.ErrorDescripcion = "El valor en efectivo es invalido";
                    return confirmarRecaudoOutputDto;
                }

                if (string.IsNullOrEmpty(confirmarRecaudoInputDto.total_transaccion))
                {
                    confirmarRecaudoOutputDto.ErrorCodigo = "5";
                    confirmarRecaudoOutputDto.ErrorDescripcion = "El valor total de la transaccion es invalido";
                    return confirmarRecaudoOutputDto;
                }

                if (string.IsNullOrEmpty(confirmarRecaudoInputDto.referencia1))
                {
                    confirmarRecaudoOutputDto.ErrorCodigo = "6";
                    confirmarRecaudoOutputDto.ErrorDescripcion = "La referencia no puede ser nula o vacia";
                    return confirmarRecaudoOutputDto;
                }

                

                parametros = new XElement("pvstrxmlParametros",
                    new XElement("Consulta",
                        new XElement("NombreConexion", confEjecutar.Nombreconexion),
                        new XElement("IdCia", conf.Compania),
                        new XElement("IdProveedor", "BCO"),
                        new XElement("IdConsulta", "CONSULTA_CLIENTE_BCO_OCCIDENTE"),
                        new XElement("Usuario", confEjecutar.Usuario),
                        new XElement("Clave", confEjecutar.ClaveUsuario),
                        new XElement("Parametros",
                            new XElement("id_cia", conf.Compania),
                            new XElement("nit", confirmarRecaudoInputDto.referencia1))));

                logBancoSiesa = new LogBancoSiesa()
                {
                    XmlBanco = ToXML(confirmarRecaudoInputDto),
                    XmlSiesa = parametros.ToString(),
                    TipoConsulta = "Referenciacion Cliente",
                    FechaConsumo = DateTime.Now,
                    Resultado = "Exitoso",
                    Referencia1 = confirmarRecaudoInputDto.referencia1
                };

                try
                {
                    DataSet arrayResult = await Consumo.EjecutarXmlAsync(parametros.ToString());

                    if (arrayResult.Tables[0].Rows.Count == 0) // No se obtuvieron datos
                    {
                        logBancoSiesa.Resultado = "Cliente no encontrado";
                        confirmarRecaudoOutputDto.ErrorCodigo = "7";
                        confirmarRecaudoOutputDto.ErrorDescripcion = "Cliente no encontrado";

                        await LogBancoSiesaDao.Add(logBancoSiesa);

                        return confirmarRecaudoOutputDto;
                    }

                    foreach (DataRow dr in arrayResult.Tables[0].Rows)
                    {
                        excepcion = dr["Excepcion"].ToString();
                    }
                }
                catch (Exception e)
                {
                    logBancoSiesa.Resultado = "Error en el consumo del servicio de cliente SIESA --> " + e.Message;
                    excepcion = "01";
                }

                await LogBancoSiesaDao.Add(logBancoSiesa);

                //excepcion ="01           ";

                //Declaramos el conector inicial
                inicial = cont.ToString("D7") + "00000001" + conf.Compania.ToString("D3");
                cont++;

                //Obtengo los decimales del total de la transacción en el banco;
                dec = confirmarRecaudoInputDto.total_transaccion.Substring(confirmarRecaudoInputDto.total_transaccion.Length - 2);

                //Conector de RC y otros ingresos V3
                RC = cont.ToString("D7") + "03570003" + conf.Compania.ToString("D3") + "1" + conf.CentroOperacion.ToString("D3") + conf.TipoDocumento.PadRight(3) + "00000001" + DateTime.Now.ToString("yyyyMMdd") + conf.CodigoCaja.PadRight(3) +
                    confirmarRecaudoInputDto.fecha_transaccion.PadRight(8) + confirmarRecaudoInputDto.referencia1.PadRight(15) + conf.Moneda.PadRight(3) + "+" + (Int64.Parse(confirmarRecaudoInputDto.total_transaccion) / 100).ToString("D15") + "." + dec + "00" + conf.Moneda.PadRight(3) +
                    "+" + (Int64.Parse(confirmarRecaudoInputDto.total_transaccion) / 100).ToString("D15") + "." + dec + "00" + conf.CodigoCobrador.PadRight(4) + conf.UnidadNegocio.ToString().PadRight(20) + conf.CentroCostoRC.PadRight(15) + conf.ConceptoFlujo.ToString().PadRight(13) + "00013" + "1" +
                    "0" + ("REGISTRO CREADO DESDE SERVICIO CON BANCO OCCIDENTE NRO TRANSACCION: " + confirmarRecaudoInputDto.nro_autorizacion + " REFERENCIA1: " + confirmarRecaudoInputDto.referencia1 + " REFERENCIA2: " + confirmarRecaudoInputDto.referencia2).PadRight(255) + string.Empty.PadRight(20) +
                    string.Empty.PadRight(15) + string.Empty.PadRight(20) + string.Empty.PadRight(15) + "28050506".PadRight(20) + "900881543".PadRight(15) + "001".PadRight(3) + "001".PadRight(3) + "99".PadRight(20) + string.Empty.PadRight(15) + confirmarRecaudoInputDto.nro_autorizacion.PadRight(20) + conf.ValidaMedioPago.ToString("D1") + string.Empty.PadRight(3) +
                    string.Empty.PadRight(3) + 0.ToString("D8");

                cont++;

                //Conector de Caja V3
                Caja = cont.ToString("D7") + "03570103" + conf.Compania.ToString("D3") + conf.CentroOperacion.ToString("D3") + conf.TipoDocumento.PadRight(3) + "00000001" + conf.CodigoMedioPagoCaja.PadRight(3) + "+" +
                    (Int64.Parse(confirmarRecaudoInputDto.total_transaccion) / 100).ToString("D15") + "." + dec + "00" + "".PadRight(10) + 0.ToString("D8") + "".PadRight(25) + "".PadRight(3) + "".PadRight(10) + "".PadRight(8) +
                    "12345678".PadRight(30) + DateTime.Now.ToString("yyyyMMdd") + "".PadRight(3) + "".PadRight(15) +
                    ("REGISTRO CREADO DESDE SERVICIO CON BANCO OCCIDENTE NRO TRANSACCION: " + confirmarRecaudoInputDto.nro_autorizacion + " REFERENCIA1: " + confirmarRecaudoInputDto.referencia1 + " REFERENCIA2: " + confirmarRecaudoInputDto.referencia2).PadRight(255) +
                    conf.CentroCostoCaja.PadRight(15) + "".PadRight(30) + "CG" + conf.CuentaConsignacion.ToString().PadRight(3);

                cont++;

                
                parametros = new XElement("Consulta",
                    new XElement("NombreConexion", confEjecutar.Nombreconexion),
                    new XElement("IdCia", confEjecutar.Compania),
                    new XElement("IdProveedor", "BCO"),
                    new XElement("IdConsulta", "CONSULTA_CARTERA_BCO_OCCIDENTE"),
                    new XElement("Usuario", confEjecutar.Usuario),
                    new XElement("Clave", confEjecutar.ClaveUsuario),
                    new XElement("Parametros",
                        new XElement("id_cia", confEjecutar.Compania),
                        new XElement("nit", confirmarRecaudoInputDto.referencia1)));

                logBancoSiesa = new LogBancoSiesa()
                {
                    XmlBanco = ToXML(confirmarRecaudoInputDto),
                    XmlSiesa = parametros.ToString(),
                    TipoConsulta = "Referenciacion Cartera",
                    FechaConsumo = DateTime.Now,
                    Resultado = "Exitoso",
                    Referencia1 = confirmarRecaudoInputDto.referencia1,
                    Referencia2 = confirmarRecaudoInputDto.referencia2,
                    IdBanco = 1 // Id Asociado al banco de occidente
                };

                try
                {
                    DataSet arrayResult = await Consumo.EjecutarXmlAsync(parametros.ToString());

                    //Asigno el valor total recaudado a la variable de los conectores CxC
                    totalTransaccion = Int64.Parse(confirmarRecaudoInputDto.total_transaccion); //Obtengo el valor total que viene con los ultimos dos digitos como decimales
                    totalTransaccion = totalTransaccion / 100;//Lo divido entre 100 para obtener el valor real
                    long valorEntero = 0;
                    int decimales = 0;
                    string[] total;

                    if (!(arrayResult.Tables[0].Rows.Count == 0) && excepcion.Trim() != "01") // Trae datos y es un cliente sin excepción
                    {
                        foreach (DataRow dr in arrayResult.Tables[0].Rows)
                        {
                            if (totalTransaccion > 0)
                            {
                                //Se obtienen los datos para generar el conector
                                tipoDocCruce = dr["f350_id_tipo_docto"].ToString();
                                docCruce = dr["f350_consec_docto"].ToString();
                                centroCruce = dr["f353_id_co_cruce"].ToString();
                                unidadCruce = dr["f353_id_un_cruce"].ToString();
                                sucursalCruce = dr["f353_id_sucursal"].ToString();
                                cuotasCruce = Int32.Parse(dr["f353_nro_cuota_cruce"].ToString());
                                auxiliarCruce = dr["Auxiliar_Contable"].ToString();
                                saldoPendiente = Double.Parse(dr["Saldo Pendiente"].ToString());

                                //Si el valor de la factura es menor al valor total recaudado actual, entonces el valor con el que va el conector es el mismo de la factura.
                                if (saldoPendiente < totalTransaccion)
                                {
                                    total = saldoPendiente.ToString().Split('.');

                                    if (total.Length > 1)
                                    {
                                        valorEntero = Int64.Parse(total[0]);
                                        decimales = Int32.Parse(total[1].Substring(0, 2));

                                        if (total[1].Length == 1)
                                        {
                                            decimales = decimales * 10;
                                        }
                                    }
                                    else
                                    {
                                        valorEntero = Int64.Parse(total[0]);
                                        decimales = 0;
                                    }
                                }
                                else
                                {
                                    total = totalTransaccion.ToString().Split(',');

                                    if (total.Length > 1)
                                    {
                                        valorEntero = Int64.Parse(total[0]);
                                        decimales = Int32.Parse(total[1]);

                                        if (total[1].Length == 1)
                                        {
                                            decimales = decimales * 10;
                                        }
                                    }
                                    else
                                    {
                                        valorEntero = Int64.Parse(total[0]);
                                        decimales = 0;
                                    }
                                }

                                //conector de Credito V2
                                CxC = cont.ToString("D7") + "03570202" + conf.Compania.ToString("D3") + conf.CentroOperacion.ToString("D3") + conf.TipoDocumento.PadRight(3) + "00000001" + auxiliarCruce.PadRight(20) + centroCruce.PadRight(3) + unidadCruce.PadRight(20) + sucursalCruce.PadRight(3) +
                                tipoDocCruce.PadRight(3) + Int64.Parse(docCruce).ToString("D8") + cuotasCruce.ToString("D3") + "+" + valorEntero.ToString("D15") + "." + decimales.ToString("D2") + "00" + "+" + 0.ToString("D15") + "." + "0000" +
                                "+" + 0.ToString("D15") + "." + "0000" + "+" + 0.ToString("D15") + "." + "0000";

                                cont++;

                                //Añadimos el conector a la lista de conectores
                                listCxC.Add(CxC);

                                //Se resta el valor de la factura al total abonado para saber cuanto queda y cuanto se va a añadir a la siguiente factura
                                totalTransaccion -= saldoPendiente;

                            }
                            else
                            {
                                break;//si ya no hay saldo para ingresar ya no recorro la consulta
                            }
                        }
                    }
                    else
                    {
                        logBancoSiesa.Resultado = "No se encontró información de facturas para el cliente";
                    }
                }
                catch (Exception e)
                {
                    logBancoSiesa.Resultado = "Error en el consumo del servicio de facturas SIESA "+ e.Message;
                }

                await LogBancoSiesaDao.Add(logBancoSiesa);

                //Conector final
                final = cont.ToString("D7") + "99990001" + conf.Compania.ToString("D3");


                if (listCxC.Count <= 0)
                {
                    parametros = new XElement("Importar",
                        new XElement("NombreConexion", confEjecutar.Nombreconexion),
                        new XElement("IdCia", confEjecutar.Compania),
                        new XElement("Usuario", confEjecutar.Usuario),
                        new XElement("Clave", confEjecutar.ClaveUsuario),
                        new XElement("Datos",
                            new XElement("Linea", inicial),
                            new XElement("Linea", RC),
                            new XElement("Linea", Caja),
                            new XElement("Linea", final)));
                }
                else
                {

                    XElement datosCxC = new XElement("Datos");
                    datosCxC.Add(new XElement("Linea", inicial));
                    datosCxC.Add(new XElement("Linea", RC));
                    datosCxC.Add(new XElement("Linea", Caja));

                    //Agregamos todas las líneas del conector CxC
                    foreach (var item in listCxC)
                    {
                        datosCxC.Add(new XElement("Linea", item));
                    }

                    datosCxC.Add(new XElement("Linea", final));

                    parametros = new XElement("Importar",
                        new XElement("NombreConexion", confEjecutar.Nombreconexion),
                        new XElement("IdCia", confEjecutar.Compania),
                        new XElement("Usuario", confEjecutar.Usuario),
                        new XElement("Clave", confEjecutar.ClaveUsuario),
                        datosCxC);
                }

                logBancoSiesa = new LogBancoSiesa()
                {
                    XmlBanco = ToXML(confirmarRecaudoInputDto),
                    XmlSiesa = parametros.ToString(),
                    TipoConsulta = "Confirmacion",
                    FechaConsumo = DateTime.Now,
                    Resultado = "Exitoso",
                    Referencia1 = confirmarRecaudoInputDto.referencia1,
                    Referencia2 = confirmarRecaudoInputDto.referencia2,
                    NumeroAutorizacion = confirmarRecaudoInputDto.nro_autorizacion,
                    TotalTransaccion = (Int64.Parse(confirmarRecaudoInputDto.total_transaccion) / 100),
                    IdBanco = 1 // Id Asociado al banco de occidente
                };

                Consumo = new Consumo();
                try
                {
                    DataSet importarXMLResponse = Consumo.ImportarXml(parametros.ToString(), 0);

                    if (importarXMLResponse.Tables[0].Rows.Count > 0) // El servicio de Siesa respondió con errores
                    {
                        foreach (DataRow dr in importarXMLResponse.Tables[0].Rows)
                        {
                            msg += "Numero de Linea = " + dr["f_nro_linea"].ToString() + " Tipo Registro = " + dr["f_tipo_reg"].ToString() + " Descripción = " + dr["f_detalle"].ToString() + "\r\n";
                        }

                        logBancoSiesa.Resultado = "Error en el consumo del servicio importarXml SIESA ---> " + msg;
                        confirmarRecaudoOutputDto.ErrorCodigo = "10";
                        confirmarRecaudoOutputDto.ErrorDescripcion = "Error en al confirmar el pago ---> " + msg;
                    }
                }
                catch (Exception e)
                {
                    logBancoSiesa.Resultado = "Error en el consumo del servicio importarXml SIESA ---> " + e.Message;
                    confirmarRecaudoOutputDto.ErrorCodigo = "10";
                    confirmarRecaudoOutputDto.ErrorDescripcion = "Error en al confirmar el pago ---> " + e.Message;
                }

                await LogBancoSiesaDao.Add(logBancoSiesa);

                return confirmarRecaudoOutputDto;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Metodo que implementa la logica de reversión de recaudo
        /// </summary>
        /// <param name="reversarRecaudoInputDto"></param>
        /// <returns></returns>
        public async Task<ReversarRecaudoOutputDto> ReversarRecaudoAsync(ReversarRecaudoInputDto reversarRecaudoInputDto)
        {
            try
            {
                string file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"configReversar.xml");
                ConfiguracionReversar confReversar = ConfiguracionReversar.Deserialize(file);

                LogBancoSiesaDao = new LogBancoSiesaDao();
                ReversarRecaudoOutputDto reversarRecaudoOutputDto = new ReversarRecaudoOutputDto()
                {
                    ErrorCodigo = "0",
                    ErrorDescripcion = "",
                    TipoRegistro = "139"
                };


                LogBancoSiesa logBancoSiesa = new LogBancoSiesa()
                {
                    XmlBanco = ToXML(reversarRecaudoInputDto),
                    TipoConsulta = "Reversar Recaudo",
                    FechaConsumo = DateTime.Now,
                    Resultado = "Exitoso",
                    Referencia1 = reversarRecaudoInputDto.nro_transac_cli,
                    NumeroAutorizacion = reversarRecaudoInputDto.nro_autorizacion,
                    IdBanco = 1 // Id Asociado al banco de occidente
                };

                SmtpClient smtpClient = new SmtpClient(confReversar.SmtpClient, confReversar.Puerto);
                smtpClient.EnableSsl = true;
                smtpClient.Credentials = new NetworkCredential(confReversar.Usuario, confReversar.ClaveUsuario);

                try
                {
                    smtpClient.Send(confReversar.Sender, confReversar.To, confReversar.Asunto, ToXML(reversarRecaudoInputDto));
                }
                catch (Exception e)
                {
                    logBancoSiesa.Resultado = "Ocurrió un error en el envío del correo --> " + e.Message;
                    reversarRecaudoOutputDto.ErrorCodigo = "10";
                    reversarRecaudoOutputDto.ErrorDescripcion = "Ocurrió un error en el envío del correo --> " + e.Message;
                    reversarRecaudoOutputDto.TipoRegistro = "139";
                }

                await LogBancoSiesaDao.Add(logBancoSiesa);

                return reversarRecaudoOutputDto;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            

        }


        private string ToXML(object T)
        {
            using (var stringwriter = new StringWriter())
            {
                var serializer = new XmlSerializer(T.GetType());
                serializer.Serialize(stringwriter, T);
                return stringwriter.ToString();
            }
        }

        /// <summary>
        /// Metodo de consulta de recaudos
        /// </summary>
        /// <param name="consultarRecaudoInputDto"></param>
        /// <returns></returns>
        public async Task<ConsultarRecaudoOutputDto> ConsultarRecaudoAsync(ConsultarRecaudoInputDto consultarRecaudoInputDto)
        {
            try
            {
                return new ConsultarRecaudoOutputDto();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        
    }
}
