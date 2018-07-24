using System.Configuration;

namespace Datos
{
    public class Conexion
    {
        public static string Cadena
        {
            get
            {
                string nombre = "Default";
                return System.Configuration.ConfigurationManager.ConnectionStrings[nombre].ConnectionString;
            }
        }
    }
}
