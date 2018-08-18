using Capa.Logica;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFerreteria.Direc
{
    public partial class Usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LLenarGridClientes();
            }
            try
            {
                if (Session["usuario"] != null)
                {
                    UsuarioLogica logica = new UsuarioLogica();
                    Usuario Usuario = logica.SeleccionarPorID(Session["usuario"].ToString());
                    lblUsuario5.Text = Usuario.Nombre + "  <i class=\"fa fa-user-circle\"></i>";
                    if (Usuario.Rol == Rol.Administrador)
                    {
                        lblAdministrador4.Text = "<a id=\"active\" href=\"Administrador.aspx\" style=\"text-decoration:none;margin-top:8px;\">Administrador</a>";
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        public void LLenarGridClientes()
        {
            UsuarioLogica logica = new UsuarioLogica();
            List<Usuario> usuarios = logica.SeleccionarTodos();
            DataTable table = new DataTable();
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Nombre", typeof(string));
            table.Columns.Add("Apellidos", typeof(string));
            foreach (Usuario us in usuarios)
            {
                DataRow row = table.NewRow();
                row["Id"] = us.IdUsuario;
                row["Nombre"] = us.Nombre;
                row["Apellidos"] = us.Apellidos;
                table.Rows.Add(row);
            }
            gridClientes.DataSource = table;
            gridClientes.DataBind();
        }

        protected void gridClientes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            
        }

        protected void gridClientes_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }


        protected void lblUsuario5_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["usuario"] != null)
                {
                    Response.Redirect("Cuenta.aspx");
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
    }
}