using Cw.Ultracem.ConsumoERP.Interface;
using System.Data;
using System.Threading.Tasks;

namespace Cw.Ultracem.ConsumoERP.Implementacion
{
    public class Consumo : IConsumo
    {
        /// <summary>
        /// Metodo utilizado para consulta  del servicio SIESA 
        /// </summary>
        /// <param name="paramEjecutar"></param>
        /// <returns></returns>
        public async Task<DataSet> EjecutarXmlAsync(string paramEjecutar)
        {
            //Se instancia la clase cliente para hacer los consumos
            ServicioSiesa.WSUNOEESoapClient ws = new ServicioSiesa.WSUNOEESoapClient();

            //Ejecutamos la consulta
            DataSet resultArray = await ws.EjecutarConsultaXMLAsync(paramEjecutar);

            ws.Close();

            return resultArray;
        }

        /// <summary>
        /// Metodo utilizado para la inserción de un pago en el servicio SIESA
        /// </summary>
        /// <param name="pvstrDatos"></param>
        /// <param name="printTipoError"></param>
        /// <returns></returns>
        public DataSet ImportarXml(string pvstrDatos, short printTipoError)
        {
            //Se instancia la clase cliente para hacer los consumos
            ServicioSiesa.WSUNOEESoapClient ws = new ServicioSiesa.WSUNOEESoapClient();

            DataSet importarXMLResponse = ws.ImportarXML(pvstrDatos, ref printTipoError);

            ws.Close();

            return importarXMLResponse;
        }
        
    }
}
