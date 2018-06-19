using System;

public class Conexion
{
    public static string Cadena
    {
        get
        {
            //Para conectarse con el app.config se necesita la referencia 
            //system.Configuration (debe de agregarse como una referencia, en add references)
            //no es lo mismo el using a la referencia

            string nombre = "SQLServer";// usar el mismo nombre del app.config
                                        //en este caso paso de llamarse Capa.UI.Properties.Settings.SQLServer a SQLServer

            return System.Configuration.ConfigurationManager.ConnectionStrings[nombre].ConnectionString;
        }
    }
}
