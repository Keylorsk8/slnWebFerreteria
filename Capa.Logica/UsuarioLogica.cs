using Datos;
using Entidades;
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

        public Usuario SeleccionarPorID(string Email)
        {
            UsuarioDatos datos = new UsuarioDatos();
            return datos.SeleccionarUsuarioPorId(Email);
        }
    }
}
