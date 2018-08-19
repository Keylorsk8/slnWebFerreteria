using Capa.Logica;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFerreteria
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if(Session["usuario"] != null)
                {
                    UsuarioLogica logica = new UsuarioLogica();
                    Usuario Usuario = logica.SeleccionarPorID(Session["usuario"].ToString());
                    lblUsuario.Text = Usuario.Nombre+"  <i class=\"fa fa-user-circle\"></i>";
                    if(Usuario.Rol == Rol.Administrador)
                    {
                        lblAdministrador.Text = "<a href=\"Direc\\Administrador.aspx\" style=\"text-decoration:none;margin-top:8px;\">Administrador</a>";
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        protected void lblUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                if(Session["usuario"].ToString() != "")
                {
                    Response.Redirect("Direc/Cuenta.aspx",false);
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