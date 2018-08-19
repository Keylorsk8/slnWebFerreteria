using Entidades.clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;

namespace Datos
{
    public class ProductoDatos
    { 
        public void Insertar(Producto Producto)
        {
            SqlConnection conexion = new SqlConnection(Conexion.Cadena);

            try
            {
                conexion.Open();

                string sql = "SP_InsertarProducto";

                SqlCommand comando = new SqlCommand(sql, conexion);

                comando.Parameters.AddWithValue("@Nombre", Producto.Nombre);
                comando.Parameters.AddWithValue("@Descripcion", Producto.Descripcion);
                comando.Parameters.AddWithValue("@Categoria", Producto.Categoria);
                comando.Parameters.Add("@Imagen", SqlDbType.NVarChar).Value = Producto.Imagen;
                comando.Parameters.AddWithValue("@Precio", Producto.Precio);
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

        public void Actualizar(Producto Producto)
        {
            SqlConnection conexion = new SqlConnection(Conexion.Cadena);

            try
            {
                conexion.Open();

                string sql = "SP_ActualizarProducto";

                SqlCommand comando = new SqlCommand(sql, conexion);

                comando.Parameters.AddWithValue("@IdProducto", Producto.IdProducto);
                comando.Parameters.AddWithValue("@Nombre", Producto.Nombre);
                comando.Parameters.AddWithValue("@Descripcion", Producto.Descripcion);
                comando.Parameters.AddWithValue("@Categoria", Producto.Categoria);
                comando.Parameters.AddWithValue("@Imagen", Producto.Imagen);
                comando.Parameters.AddWithValue("@Precio", Producto.Precio);
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

        public Producto SeleccionarProductoPorId(int IdProducto)
        {
            Producto Producto = null;
            SqlConnection conexion = new SqlConnection(Conexion.Cadena);
            try
            {
                conexion.Open();

                string sql = "SP_SeleccionarProductoPorId";

                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@IdProducto", IdProducto);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    CategoriaDatos datos = new CategoriaDatos();
                    Producto = new Producto()
                    {
                        IdProducto = Convert.ToInt32(reader["IDProducto"]),
                        Nombre = reader["Nombre"].ToString(),
                        Descripcion = reader["Descripcion"].ToString(),
                        Imagen = (byte[])reader["Imagen"],
                        Categoria = new CategoriaDatos().SeleccionarUsuarioPorId(Convert.ToInt32(reader["Categoria"])),
                        Precio = Convert.ToDouble(reader["Precio"])
                    };
                }
                return Producto;
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

        public List<Producto> SeleccionarTodos()
        {
            List<Producto> Productos = new List<Producto>();
            SqlConnection conexion = new SqlConnection(Conexion.Cadena);
            try
            {
                conexion.Open();

                string sql = "SP_SeleccionarProductos";

                SqlCommand comando = new SqlCommand(sql, conexion);

                comando.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    CategoriaDatos datos = new CategoriaDatos();
                    Producto Producto = new Producto()
                    {
                        IdProducto = Convert.ToInt32(reader["IdProducto"]),
                        Nombre = reader["Nombre"].ToString(),
                        Descripcion = reader["Descripcion"].ToString(),
                        Imagen = (byte[])reader["Imagen"],
                        Categoria = new CategoriaDatos().SeleccionarUsuarioPorId(Convert.ToInt32(reader["Categoria"])),
                        Precio = Convert.ToDouble(reader["Precio"])
                    };
                    Productos.Add(Producto);
                }
                return Productos;
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

        public List<Producto> SeleccionarProductosConFiltro(string nombre,int IdCategoria,double PrecioMaximo)
        {
            List<Producto> lista = new List<Producto>();
            SqlConnection conexion = new SqlConnection(Conexion.Cadena);
            try
            {
                conexion.Open();

                string sql = "SP_SeleccionarProductosPorFiltro";

                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@Nombre", nombre);
                comando.Parameters.AddWithValue("@IdCategoria", IdCategoria);
                comando.Parameters.AddWithValue("@PrecioMaximo", PrecioMaximo);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Producto Producto = new Producto()
                    {
                        IdProducto = Convert.ToInt32(reader["IdProducto"]),
                        Nombre = reader["Nombre"].ToString(),
                        Descripcion = reader["Descripcion"].ToString(),
                        Imagen = (byte[])reader["Imagen"],
                        Categoria = new CategoriaDatos().SeleccionarUsuarioPorId(Convert.ToInt32(reader["Categoria"])),
                        Precio = Convert.ToDouble(reader["Precio"])
                    };
                    lista.Add(Producto);
                }
                return lista;
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

        public void Eliminar(int IdProducto)
        {
            SqlConnection conexion = new SqlConnection(Conexion.Cadena);
            try
            {
                conexion.Open();

                string sql = "SP_EliminarProducto";

                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@IdProducto", IdProducto);
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

        public List<Producto> SeleccionarProductoIdCategoria(int idcategoira)
        {
            List<Producto> Productos = new List<Producto>();
            SqlConnection conexion = new SqlConnection(Conexion.Cadena);
            try
            {
                conexion.Open();

                string sql = "SP_SeleccionarProductoPorIdCategoria";

                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@Idcategoria", idcategoira);

                comando.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    CategoriaDatos datos = new CategoriaDatos();
                    Producto Producto = new Producto()
                    {
                        IdProducto = Convert.ToInt32(reader["IdProducto"]),
                        Nombre = reader["Nombre"].ToString(),
                        Descripcion = reader["Descripcion"].ToString(),
                        Imagen = (byte[])reader["Imagen"],
                        Categoria = new CategoriaDatos().SeleccionarUsuarioPorId(Convert.ToInt32(reader["Categoria"])),
                        Precio = Convert.ToDouble(reader["Precio"])
                    };
                    Productos.Add(Producto);
                }
                return Productos;
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
