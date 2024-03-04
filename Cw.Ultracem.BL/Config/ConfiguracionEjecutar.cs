using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Cw.Ultracem.BL.Config
{
    /// <summary>
    /// Clase utilizada para obtener los parametros de configuración del metodo ejecutarXML del servicio de SIESA
    /// </summary>
    public class ConfiguracionEjecutar
    {
        public string Nombreconexion { set; get; }

        public int Compania { set; get; }

        public string Usuario { set; get; }

        public string ClaveUsuario { set; get; }

        public string Nit { set; get; }

        /// <summary>
        /// Metodo utilizado para deserializar el archivo configEjecutar.xml y llenar las propiedades de la clase de ConfiguracionEjecutar
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static ConfiguracionEjecutar Deserialize(string file)
        {
            System.Xml.Serialization.XmlSerializer xs
               = new System.Xml.Serialization.XmlSerializer(
                  typeof(ConfiguracionEjecutar));
            StreamReader reader = File.OpenText(file);
            ConfiguracionEjecutar c = (ConfiguracionEjecutar)xs.Deserialize(reader);
            reader.Close();
            return c;
        }
    }
}
