using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class UsuarioDatos
    {
        public void Insertar(Usuario Usuario)
        {
            SqlConnection conexion = new SqlConnection(Conexion.Cadena);

            try
            {
                conexion.Open();

                string sql = "SP_InsertarUsuario";

                SqlCommand comando = new SqlCommand(sql, conexion);

                comando.Parameters.AddWithValue("@Rol", (int)Usuario.Rol);
                comando.Parameters.AddWithValue("@Nombre", Usuario.Nombre);
                comando.Parameters.AddWithValue("@Apellidos", Usuario.Apellidos);
                comando.Parameters.AddWithValue("@Email", Usuario.Email);
                comando.Parameters.AddWithValue("@Contraseña", Usuario.contraseña);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conexion.Close();
            }

        }

        public void Actualizar(Usuario Usuario)
        {
            SqlConnection conexion = new SqlConnection(Conexion.Cadena);

            try
            {
                conexion.Open();

                string sql = "PA_ActualizarUsuario";

                SqlCommand comando = new SqlCommand(sql, conexion);

                comando.Parameters.AddWithValue("@IdUsuario", Usuario.IdUsuario);
                comando.Parameters.AddWithValue("@IdRol", (int)Usuario.Rol);
                comando.Parameters.AddWithValue("@Nombre", Usuario.Nombre);
                comando.Parameters.AddWithValue("@Apellidos", Usuario.Apellidos);
                comando.Parameters.AddWithValue("@Email", Usuario.Email);
                comando.Parameters.AddWithValue("@Contraseña", Usuario.contraseña);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conexion.Close();
            }

        }

        public Usuario SeleccionarUsuarioPorId(string Email)
        {
            Usuario Usuario = null;
            SqlConnection conexion = new SqlConnection(Conexion.Cadena);
            try
            {
                conexion.Open();

                string sql = "SP_SeleccionarUsuarioPorId";

                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@Email", Email);

                comando.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Usuario = new Usuario()
                    {
                        IdUsuario = Convert.ToInt32(reader["IDUsuario"]),
                        Rol = Convert.ToInt32(reader["Rol"]) == 1 ? Rol.Administrador : Rol.Usuario,
                        Nombre = reader["Nombre"].ToString(),
                        Apellidos = reader["Apellidos"].ToString(),
                        Email = reader["Email"].ToString(),
                        contraseña = reader["Contraseña"].ToString()
                    };
                }
                return Usuario;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

                conexion.Close();
            }
        }
    }
}