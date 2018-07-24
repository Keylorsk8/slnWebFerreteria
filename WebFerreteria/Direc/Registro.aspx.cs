using Capa.Logica;
using Entidades;
using System;

namespace WebFerreteria.Direc
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void btnregistrarse_Click(object sender, EventArgs e)
        {
            Usuario Usuario = new Usuario()
            {
                Nombre = txtNombre.Text,
                Apellidos = txtApellidos.Text,
                Email = txtEmail.Text,
                contraseña = txtContraseña.Text,
                Rol = Rol.Usuario
            };
            UsuarioLogica logica = new UsuarioLogica();
            if(logica.SeleccionarPorID(Usuario.Email) != null)
            {
                lblError.Text = "Este Usuario ya se encuentra Registrado";
            }else
            {
                logica.Insertar(Usuario);
                Response.Redirect("../default.aspx");
            }
        }
    }
}