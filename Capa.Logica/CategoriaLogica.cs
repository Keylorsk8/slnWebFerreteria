using Datos;
using Entidades.clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa.Logica
{
    public class CategoriaLogica
    {
         public void Insertar(Categoria Categoria)
        {
            if (string.IsNullOrEmpty(Categoria.Nombre))
            {
                throw new ApplicationException("El Nombre es requerido");
            }

            CategoriaDatos datos = new CategoriaDatos();

            if (datos.SeleccionarUsuarioPorId(Categoria.IdCategoria) == null)
            {
                datos.Insertar(Categoria);
            }
            else
            {
                datos.Actualizar(Categoria);
            }
        }

        public Categoria SeleccionarPorID(int IdCategoria)
        {
            CategoriaDatos datos = new CategoriaDatos();
            return datos.SeleccionarUsuarioPorId(IdCategoria);
        }

        public List<Categoria> SeleccionarTodos()
        {
            CategoriaDatos datos = new CategoriaDatos();
            return datos.SeleccionarTodos();
        }

        public void Eliminar(int IdCategoria)
        {
            CategoriaDatos datos = new CategoriaDatos();
            datos.Eliminar(IdCategoria);
        }
    }
}
