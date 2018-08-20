using Entidades.clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuario
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public string contraseña { get; set; }
        public int IdUsuario { get; set; }
        public Rol Rol { get; set; }
        public List<Telefono> Telefonos = new List<Telefono>();

        public List<Telefono> GetTelefonos()
        {
            return Telefonos;
        }

        public void SetTelefonos(List<Telefono> li)
        {
            Telefonos = li;
         }
    }
}

    
