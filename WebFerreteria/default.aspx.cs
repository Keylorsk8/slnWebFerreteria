﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFerreteria
{
    public partial class defaultcopia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnCuenta_Click(object sender, EventArgs e)
        {
            Response.Redirect("Inicio Sesion.aspx");
        }
    }
}