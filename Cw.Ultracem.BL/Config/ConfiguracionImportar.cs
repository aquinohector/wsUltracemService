using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Cw.Ultracem.BL.Config
{
    /// <summary>
    /// Clase utilizada para obtener los datos del archivo de configuracion ubicado en el proyecto Cw.Ultracem.Service//config.xml - Para agregar una propiedad se debe agregar la propiedad aquí y en el archivo de configuración para que se mapee correctamente.
    /// </summary>
    public class ConfiguracionImportar
    {
        public string Banco { set; get; }

        public int CuentaBanco { set; get; }

        public int CuentaAnticipo { set; get; }

        public int CuentaCartera { set; get; }

        public string TipoDocumento { set; get; }

        public int Compania { set; get; }

        public int CentroOperacion { set; get; }

        public int UnidadNegocio { set; get; }

        public int ConceptoFlujo { set; get; }

        public string Moneda { set; get; }

        public string CodigoCaja { set; get; }

        public string CodigoCobrador { set; get; }
        
        public string CentroCostoRC { set; get; }

        public int ValidaMedioPago { set; get; }

        public string CodigoMedioPagoCaja { set; get; }

        public string CentroCostoCaja { set; get; }

        public string CuentaConsignacion { set; get; }

        /// <summary>
        /// Metodo utilizado para deserializar el archivo config.xml y llenar las propiedades de la clase de Configuración
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static ConfiguracionImportar Deserialize(string file)
        {
            System.Xml.Serialization.XmlSerializer xs
               = new System.Xml.Serialization.XmlSerializer(
                  typeof(ConfiguracionImportar));
            StreamReader reader = File.OpenText(file);
            ConfiguracionImportar c = (ConfiguracionImportar)xs.Deserialize(reader);
            reader.Close();
            return c;
        }

    }
}
