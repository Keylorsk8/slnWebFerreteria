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
    public class Procedimientos
    {
        public bool AgregarUsuario(string Nombre, string Apellidos, string Email, string Contraseña,string Telefono)
        {
            Conexion cn = new Conexion();
            try
            {
                string sql = "SP_InsertarUsuario";
                SqlCommand cmd = new SqlCommand(sql, cn.getConexion());
                cmd.Parameters.AddWithValue("@Nombre", Nombre);
                cmd.Parameters.AddWithValue("@Apellidos", Apellidos);
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@Contraseña", Contraseña);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                String e = ex.Message;
                return false;
            }
            finally
            {
                cn.getConexion().Close();
            }
        }
    }
}
