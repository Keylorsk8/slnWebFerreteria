using Datos;
using Entidades.clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa.Logica
{
    public class ProductoLogica
    {
        public void Insertar(Producto Producto)
        {
            if (string.IsNullOrEmpty(Producto.Nombre))
            {
                throw new ApplicationException("El Nombre es requerido");
            }

            ProductoDatos datos = new ProductoDatos();

            if (datos.SeleccionarProductoPorId(Producto.IdProducto) == null)
            {
                datos.Insertar(Producto);
            }
            else
            {
                datos.Actualizar(Producto);
            }
        }

        public Producto SeleccionarPorID(int IdProducto)
        {
            ProductoDatos datos = new ProductoDatos();
            return datos.SeleccionarProductoPorId(IdProducto);
        }

        public List<Producto> SeleccionarTodos()
        {
            ProductoDatos datos = new ProductoDatos();
            return datos.SeleccionarTodos();
        }

        public void Eliminar(int IdProducto)
        {
            ProductoDatos datos = new ProductoDatos();
            datos.Eliminar(IdProducto);
        }
    }
}

