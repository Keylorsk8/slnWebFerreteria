﻿using Capa.Logica;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFerreteria
{
    public partial class Contacto1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["usuario"] != null)
                {
                    UsuarioLogica logica = new UsuarioLogica();
                    Usuario Usuario = logica.SeleccionarPorID(Session["usuario"].ToString());
                    lblUsuario1.Text = Usuario.Nombre;
                    if (Usuario.Rol == Rol.Administrador)
                    {
                        lblAdministrador1.Text = "<a href=\"Direc\\Administrador.aspx\" style=\"text-decoration:none;\">Administrador</a>";
                    }
                }
            }
            catch (Exception)
            {

            }
        }
          

        protected void lblUsuario1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["usuario"] != null)
                {

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