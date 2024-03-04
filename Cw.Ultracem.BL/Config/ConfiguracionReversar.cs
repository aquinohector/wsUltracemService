using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Cw.Ultracem.BL.Config
{
    /// <summary>
    /// Clase utilizada para obtener los datos del archivo de reversion ubicado en el proyecto Cw.Ultracem.Service//configReversar.xml - Para agregar una propiedad se debe agregar la propiedad aquí y en el archivo de configuración para que se mapee correctamente.
    /// </summary>
    public class ConfiguracionReversar
    {
        public string Sender { get; set; }

        public string To { get; set; }

        public string Asunto { get; set; }

        public string ClaveUsuario { get; set; }

        public string SmtpClient { get; set; }

        public string Usuario { get; set; }

        public int Puerto { get; set; }

        /// <summary>
        /// Metodo utilizado para deserializar el archivo configReversar.xml y llenar las propiedades de la clase de Configuración
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static ConfiguracionReversar Deserialize(string file)
        {
            System.Xml.Serialization.XmlSerializer xs
               = new System.Xml.Serialization.XmlSerializer(
                  typeof(ConfiguracionReversar));
            StreamReader reader = File.OpenText(file);
            ConfiguracionReversar c = (ConfiguracionReversar)xs.Deserialize(reader);
            reader.Close();
            return c;
        }

    }
}
