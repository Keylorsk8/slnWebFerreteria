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
    public partial class Categorias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LLenarGridCategorias();
            }
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
                    else
                    {
                        Response.Redirect("Acceso No Autorizado.aspx");
                    }
                }else
                {
                    Response.Redirect("../Inicio Sesion.aspx");
                }
            }
            catch (Exception)
            {

            }
            btnActualizarCategoria.Visible = false;
            btnBorrarCategoria.Visible = false;
            divIdCategoria.Visible = false;
        }

        public void LLenarGridCategorias()
        {
            CategoriaLogica logica = new CategoriaLogica();
            List<Categoria> categorias = logica.SeleccionarTodos();
            DataTable table = new DataTable();
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Nombre", typeof(string));
            foreach (Categoria ca in categorias)
            {
                DataRow row = table.NewRow();
                row["Id"] = ca.IdCategoria;
                row["Nombre"] = ca.Nombre;
                table.Rows.Add(row);
            }
            gridCategorias.DataSource = table;
            gridCategorias.DataBind();
        }

        protected void lblUsuario8_Click(object sender, EventArgs e)
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
            catch (Exception)
            {
                Response.Redirect("../Inicio Sesion.aspx");
            }
        }

        protected void gridCategorias_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int IdCategoria = Convert.ToInt32(gridCategorias.DataKeys[e.RowIndex].Values[0]);
            CategoriaLogica logica = new CategoriaLogica();
            try
            {
                logica.Eliminar(IdCategoria);
                LLenarGridCategorias();
            }
            catch (Exception ex)
            {
                string script = @"<script type='text/javascript'>
                            alert('Esta Categoría no puede ser eliminada');
                        </script>";

                script = string.Format(script, ex.Message);

                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            }
        }

        protected void gridCategorias_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.ToolTip = "Click en Seleccionar para editar esta Categoría";
            }
        }

        protected void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            Categoria Categoria = new Categoria()
            {
                Nombre = txtNombre.Text,
                Descripcion = txtDescripcion.Text
            };
            CategoriaLogica logica = new CategoriaLogica();
            logica.Insertar(Categoria);
            LLenarGridCategorias();
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            gridCategorias.SelectedIndex = -1;
        }

        protected void gridCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            Categoria Categoria = new CategoriaLogica().SeleccionarPorID(Convert.ToInt32(gridCategorias.SelectedRow.Cells[2].Text));
            txtNombre.Text = Categoria.Nombre;
            txtDescripcion.Text = Categoria.Descripcion;
            divIdCategoria.Visible = true;
            txtIdCategoria.Text = Categoria.IdCategoria.ToString();
            btnActualizarCategoria.Visible = true;
            btnBorrarCategoria.Visible = true;
            btnAgregarCategoria.Visible = false;
        }

        protected void btnActualizarCategoria_Click(object sender, EventArgs e)
        {
            Categoria Categoria = new Categoria()
            {
                IdCategoria = Convert.ToInt32(txtIdCategoria.Text),
                Nombre = txtNombre.Text,
                Descripcion = txtDescripcion.Text
            };
            CategoriaLogica logica = new CategoriaLogica();
            logica.Insertar(Categoria);
            LLenarGridCategorias();
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            divIdCategoria.Visible = false;
            txtIdCategoria.Text = "";
            btnActualizarCategoria.Visible = false;
            btnBorrarCategoria.Visible = false;
            btnAgregarCategoria.Visible = true;
            gridCategorias.SelectedIndex = -1;
        }

        protected void BorrarCategoria_Click(object sender, EventArgs e)
        {
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            divIdCategoria.Visible = false;
            txtIdCategoria.Text = "";
            btnActualizarCategoria.Visible = false;
            btnBorrarCategoria.Visible = false;
            btnAgregarCategoria.Visible = true;
            gridCategorias.SelectedIndex = -1;
        }

        protected void Buscar_ServerClick(object sender, EventArgs e)
        {
            Session["producto"] = txtBusqueda.Value;
            Response.Redirect("../Productos.aspx", false);
        }
    }
}