using Capa.Logica;
using Entidades;
using Entidades.clases;
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
                    }else
                    {
                        Response.Redirect("Acceso No autorizado.aspx");
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

        protected void gridClientes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.ToolTip = "Click en Seleccionar para ver este Usuario";
            }
        }


        protected void lblUsuario5_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["usuario"] != null)
                {
                    Response.Redirect("Cuenta.aspx",false);
                }
                else
                {
                    Response.Redirect("../Inicio Sesion.aspx");
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("../Inicio Sesion.aspx");
            }
        }

        protected void gridClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            int IdCliente = Convert.ToInt32(gridClientes.SelectedRow.Cells[1].Text);
            Usuario us = new UsuarioLogica().SeleccionarUsuariorId(IdCliente);
            txtNombreCliente.Text = us.Nombre;
            txtApellidos.Text = us.Apellidos;
            txtEmail.Text = us.Email;
            CargarNumeros(us.IdUsuario);
        }

        private void CargarNumeros(int idUsuario)
        {
            List<Telefono> Telefonos = new UsuarioLogica().SeleccionarTelefonosPorId(idUsuario);
            DataTable table = new DataTable();
            table.Columns.Add("ID");
            table.Columns.Add("Número");
            foreach(Telefono te in Telefonos)
            {
                DataRow row = table.NewRow();
                row["ID"] = idUsuario;
                row["Número"] = te.Numero;
                table.Rows.Add(row);
            }
            gridTelefonos.DataSource =  table;
            gridTelefonos.DataBind();
        }

        protected void gridTelefonos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            return;
        }

        protected void gridTelefonos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            return;
        }

        protected void Buscar_ServerClick(object sender, EventArgs e)
        {
            Session["producto"] = txtBusqueda.Value;
            Response.Redirect("../Productos.aspx", false);
        }
    }
}