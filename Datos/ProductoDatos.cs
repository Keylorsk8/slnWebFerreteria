﻿using Entidades.clases;
using System;
using System.Collections.Generic;
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
                comando.Parameters.AddWithValue("@Categoria", Producto.Categoria.IdCategoria);
                SqlParameter image = comando.Parameters.Add("@Imagen", System.Data.SqlDbType.Image);
                image.Value = Producto.Imagen;
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
                comando.Parameters.AddWithValue("@Categoria", Producto.Categoria.IdCategoria);
                SqlParameter image = comando.Parameters.Add("@Imagen", System.Data.SqlDbType.Image);
                image.Value = Producto.Imagen;
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
                        Imagen = (Byte[])reader["Imagen"],
                        Categoria = datos.SeleccionarUsuarioPorId((int)reader["Categoria"]),
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
                        Categoria = datos.SeleccionarUsuarioPorId((int)reader["Categoria"]),
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
    }
}