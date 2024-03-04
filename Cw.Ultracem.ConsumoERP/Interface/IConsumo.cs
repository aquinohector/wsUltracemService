using System.Data;
using System.Threading.Tasks;

namespace Cw.Ultracem.ConsumoERP.Interface
{
    public interface IConsumo
    {
        /// <summary>
        /// Metodo utilizado para consulta  del servicio SIESA 
        /// </summary>
        /// <param name="paramEjecutar"></param>
        /// <returns></returns>
        Task<DataSet> EjecutarXmlAsync(string paramEjecutar);

        /// <summary>
        /// Metodo utilziado para la inserción de un pago en el servicio SIESA
        /// </summary>
        /// <param name="pvstrDatos"></param>
        /// <param name="printTipoError"></param>
        /// <returns></returns>
        DataSet ImportarXml(string pvstrDatos, short printTipoError);

    }
}
