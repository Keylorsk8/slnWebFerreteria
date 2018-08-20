using Entidades;
using Entidades.clases;
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

                InsertarTelefonos(Usuario);

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

        private void InsertarTelefonos(Usuario us)
        {
            SqlConnection conexion = new SqlConnection(Conexion.Cadena);

            try
            {
                conexion.Open();

                string sql = "SP_InsertarTelefonos";

                SqlCommand comando = new SqlCommand(sql, conexion);

                EliminarTelefonos(us);
                foreach(Telefono tel in us.Telefonos) {
                    comando.Parameters.AddWithValue("@IdUsuario", us.IdUsuario);
                    comando.Parameters.AddWithValue("@Numero", tel.Numero);
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.ExecuteNonQuery();
                }
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

        public void EliminarTelefono(int idUsuario, string numero)
        {
            SqlConnection conexion = new SqlConnection(Conexion.Cadena);

            try
            {
                conexion.Open();

                string sql = "Delete from Telefono where IdUsuario = @IdUsuario and Numero = @Numero";

                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@IdUsuario",idUsuario);
                comando.Parameters.AddWithValue("@Numero", numero);
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

        private void EliminarTelefonos(Usuario us)
        {
            SqlConnection conexion = new SqlConnection(Conexion.Cadena);

            try
            {
                conexion.Open();

                string sql = "Delete from Telefono where IdUsuario = @IdUsuario";

                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@IdUsuario", us.IdUsuario);
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

        public List<Telefono> SeleccionarTelefonosPorId(int IdUsuario)
        {
            SqlConnection conexion = new SqlConnection(Conexion.Cadena);
            try
            {
                List<Telefono> Telefonos = new List<Telefono>();
                conexion.Open();

                string sql = "SP_SeleccionarTelefonos";

                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@IdUsuario", IdUsuario);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Telefono Tel = new Telefono()
                    {
                        IdUsuario = Convert.ToInt32(reader["IdUsuario"]),
                        Numero = reader["Numero"].ToString()
                    };
                    Telefonos.Add(Tel);
                }
                return Telefonos;
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

                string sql = "SP_ActualizarUsuario";

                SqlCommand comando = new SqlCommand(sql, conexion);

                comando.Parameters.AddWithValue("@IdUsuario", Usuario.IdUsuario);
                comando.Parameters.AddWithValue("@Rol", (int)Usuario.Rol);
                comando.Parameters.AddWithValue("@Nombre", Usuario.Nombre);
                comando.Parameters.AddWithValue("@Apellidos", Usuario.Apellidos);
                comando.Parameters.AddWithValue("@Email", Usuario.Email);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.ExecuteNonQuery();
                InsertarTelefonos(Usuario);
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

        public Usuario SeleccionarUsuarioPorId(int IdUsuario)
        {
            Usuario Usuario = null;
            SqlConnection conexion = new SqlConnection(Conexion.Cadena);
            try
            {
                conexion.Open();

                string sql = "Select * from Usuario where IdUsuario = @IdUsuario";

                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@IdUsuario", IdUsuario);

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

        public List<Usuario> SeleccionarTodos()
        {
            List<Usuario> usuarios = new List<Usuario>();
            SqlConnection conexion = new SqlConnection(Conexion.Cadena);
            try
            {
                conexion.Open();

                string sql = "SP_SeleccionarUsuarios";

                SqlCommand comando = new SqlCommand(sql, conexion);

                comando.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Usuario usuario = new Usuario()
                    {
                        IdUsuario = Convert.ToInt32(reader["IDUsuario"]),
                        Rol = Convert.ToInt32(reader["Rol"]) == 1 ? Rol.Administrador : Rol.Usuario,
                        Nombre = reader["Nombre"].ToString(),
                        Apellidos = reader["Apellidos"].ToString(),
                        Email = reader["Email"].ToString(),
                        contraseña = reader["Contraseña"].ToString()
                    };
                    usuarios.Add(usuario);
                }
                return usuarios;
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

        public void Eliminar(int IdUsuario)
        {
            SqlConnection conexion = new SqlConnection(Conexion.Cadena);
            try
            {
                conexion.Open();

                string sql = "SP_EliminarUsuario";

                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@IdUsuario", IdUsuario);
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
    
    }
}