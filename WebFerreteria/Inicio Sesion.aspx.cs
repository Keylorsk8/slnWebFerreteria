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
    public partial class Inicio_Sesion1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIniciar_click(object sender, EventArgs e)
        {
            UsuarioLogica logica = new UsuarioLogica();
            Usuario Usuario = logica.SeleccionarPorID(txtCorreo.Text);
            if (Usuario == null)
            {
                lblError.Text = "Este Usuario no existe";
            }else
            {
                if(Usuario.contraseña != txtContraseña.Text)
                {
                    lblError.Text = "Contraseña Incorrecta";
                }else
                {
                    Session["Usuario"] = Usuario.Email;
                    Response.Redirect("default.aspx");
                }
            }
            
        }
    }
}