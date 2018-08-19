using Capa.Logica;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFerreteria.Direc
{
    public partial class Cuenta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["usuario"] != null)
                {
                    UsuarioLogica logica = new UsuarioLogica();
                    Usuario Usuario = logica.SeleccionarPorID(Session["usuario"].ToString());
                    lblUsuario8.Text = Usuario.Nombre + "  <i class=\"fa fa-user-circle\"></i>";
                    if (Usuario.Rol == Rol.Administrador)
                    {
                        lblAdministrador4.Text = "<a id=\"active\" href=\"Administrador.aspx\" style=\"text-decoration:none;margin-top:8px;\">Administrador</a>";
                    }
                }else
                {
                    Response.Redirect("../Inicio Sesion.aspx");
                }
            }
            catch (Exception)
            {

            }
        }

        protected void lblUsuario8_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["usuario"] != null)
                {
                    Response.Redirect("../Cuenta.aspx");
                }
                else
                {
                    Response.Redirect("../Inicio Sesion.aspx");
                }
            }
            catch (Exception)
            {
                Response.Redirect("../Inicio Sesion.aspx");
            }
        }

        protected void CerrarSesion_Click(object sender, EventArgs e)
        {
            Session["usuario"] = "";
            Response.Redirect("../Inicio Sesion.aspx");
        }
    }
}