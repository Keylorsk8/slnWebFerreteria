using Entidades.clases;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class CategoriaDatos
    {
        public void Insertar(Categoria Categoria)
        {
            SqlConnection conexion = new SqlConnection(Conexion.Cadena);

            try
            {
                conexion.Open();

                string sql = "SP_InsertarCategoria";

                SqlCommand comando = new SqlCommand(sql, conexion);

                comando.Parameters.AddWithValue("@Nombre",  Categoria.Nombre);
                comando.Parameters.AddWithValue("@Descripcion", Categoria.Descripcion);
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

        public void Actualizar(Categoria Categoria)
        {
            SqlConnection conexion = new SqlConnection(Conexion.Cadena);

            try
            {
                conexion.Open();

                string sql = "SP_ActualizarCategoria";

                SqlCommand comando = new SqlCommand(sql, conexion);

                comando.Parameters.AddWithValue("@IdUCategoria", Categoria.IdCategoria);
                comando.Parameters.AddWithValue("@Nombre", Categoria.Nombre);
                comando.Parameters.AddWithValue("@Descripcion", Categoria.Descripcion);
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

        public Categoria SeleccionarUsuarioPorId(int IdCategoria)
        {
            Categoria Categoria = null;
            SqlConnection conexion = new SqlConnection(Conexion.Cadena);
            try
            {
                conexion.Open();

                string sql = "SP_SeleccionarCategoriaPorId";

                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@IdCategoria", IdCategoria);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Categoria = new Categoria()
                    {
                        IdCategoria = Convert.ToInt32(reader["IDCategoria"]),
                        Nombre = reader["Nombre"].ToString(),
                        Descripcion = reader["Descripcion"].ToString()
                    };
                }
                return Categoria;
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

        public List<Categoria> SeleccionarTodos()
        {
            List<Categoria> categorias = new List<Categoria>();
            SqlConnection conexion = new SqlConnection(Conexion.Cadena);
            try
            {
                conexion.Open();

                string sql = "SP_SeleccionarCategorias";

                SqlCommand comando = new SqlCommand(sql, conexion);

                comando.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Categoria Categoria = new Categoria()
                    {
                        IdCategoria = Convert.ToInt32(reader["IdCategoria"]),
                        Nombre = reader["Nombre"].ToString(),
                        Descripcion = reader["Descripcion"].ToString()
                    };
                    categorias.Add(Categoria);
                }
                return categorias;
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

        public void Eliminar(int IdCategoria)
        {
            SqlConnection conexion = new SqlConnection(Conexion.Cadena);
            try
            {
                conexion.Open();

                string sql = "SP_EliminarCategoria";

                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@IdCategoria", IdCategoria);
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
