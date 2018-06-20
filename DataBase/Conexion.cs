using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace DataBase
{
    public class Conexion
    {
        public SqlConnection getConexion()
        {
            try
            {
                string cadena = "Data Source=.;Initial Catalog=FerreteriaJyR;Persist Security Info=True;User ID=sa;Password=123456";
                SqlConnection cnn = new SqlConnection(cadena);
                cnn.Open();
                return cnn; 
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
