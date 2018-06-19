using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data;

namespace WebFerreteria
{
    public partial class Inicio_Sesion_copia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIniciar_Click(object sender, EventArgs e)
        {
            Response.Redirect("www.google.com");
        }

        protected void btnIniciar_Click1(object sender, EventArgs e)
        {
            Session["username"] = "Keylor";
        }
    }
}