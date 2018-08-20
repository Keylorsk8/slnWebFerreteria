using Datos;
using Entidades;
using Entidades.clases;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa.Logica
{
    public class UsuarioLogica
    {
        public void Insertar(Usuario Usuario)
        {
            if (string.IsNullOrEmpty(Usuario.IdUsuario.ToString()))
            {
                throw new ApplicationException("El número de cédula es requerido");
            }

            UsuarioDatos datos = new UsuarioDatos();

            if (datos.SeleccionarUsuarioPorId(Usuario.Email) == null)
            {
                datos.Insertar(Usuario);
            }
            else
            {
                datos.Actualizar(Usuario);
            }
        }

        public List<Telefono> SeleccionarTelefonosPorId(int IdUsuario)
        {
            UsuarioDatos datos = new UsuarioDatos();
            return datos.SeleccionarTelefonosPorId(IdUsuario);
        }

        public Usuario SeleccionarUsuariorId(int IdUsuario)
        {
            UsuarioDatos datos = new UsuarioDatos();
            return datos.SeleccionarUsuarioPorId(IdUsuario);
        }

        public Usuario SeleccionarPorID(string Email)
        {
            UsuarioDatos datos = new UsuarioDatos();
            return datos.SeleccionarUsuarioPorId(Email);
        }

        public List<Usuario> SeleccionarTodos()
        {
            UsuarioDatos datos = new UsuarioDatos();
            return datos.SeleccionarTodos();
        }

        public void Eliminar(int IdUsuario)
        {
            UsuarioDatos datos = new UsuarioDatos();
            datos.Eliminar(IdUsuario);
        }

        public void EliminarTelefono(int IdUsuario,string numero)
        {
            UsuarioDatos datos = new UsuarioDatos();
            datos.EliminarTelefono(IdUsuario,numero);
        }
    }
}
