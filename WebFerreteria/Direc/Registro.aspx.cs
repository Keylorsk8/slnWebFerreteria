using Capa.Logica;
using Entidades;
using Entidades.clases;
using System;
using System.Collections.Generic;

namespace WebFerreteria.Direc
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["usuario"] != null)
                {
                    UsuarioLogica logica = new UsuarioLogica();
                    Usuario Usuario = logica.SeleccionarPorID(Session["usuario"].ToString());
                    Response.Redirect("Cuenta.aspx", false);
                }
            }
            catch (Exception)
            {

            }
        }

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
            List<Telefono> Telefonos = new List<Telefono>();
            Telefonos.Add(new Telefono() { Numero = txtTelefono.Text });
            Usuario.SetTelefonos(Telefonos);
            UsuarioLogica logica = new UsuarioLogica();
            if(logica.SeleccionarPorID(Usuario.Email) != null)
            {
                lblError.Text = "Este Usuario ya se encuentra Registrado";
            }else
            {
                logica.Insertar(Usuario);
                Session["usuario"] = Usuario.Email;
                Response.Redirect("../default.aspx");
            }
        }

        protected void lblUsuario5_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["usuario"] != null)
                {
                    Response.Redirect("../Cuenta.aspx");
                }
                else
                {
                    Response.Redirect("Inicio Sesion.aspx");
                }
            }
            catch (Exception)
            {
                Response.Redirect("Inicio Sesion.aspx");
            }
        }
    }
}