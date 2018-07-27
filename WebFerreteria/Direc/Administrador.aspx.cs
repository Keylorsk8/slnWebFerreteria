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
    public partial class Administrador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LLenarGrid();
            }
            try
            {
                if (Session["usuario"] != null)
                {
                    UsuarioLogica logica = new UsuarioLogica();
                    Usuario Usuario = logica.SeleccionarPorID(Session["usuario"].ToString());
                    lblUsuario7.Text = Usuario.Nombre;
                    if (Usuario.Rol == Rol.Administrador)
                    {
                        lblAdministrador2.Text = "<a href=\"Administrador.aspx\" style=\"text-decoration:none;\">Administrador</a>";
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        public void LLenarGrid()
        {
            UsuarioLogica logica = new UsuarioLogica();
            List<Usuario> usuarios = logica.SeleccionarTodos();
            DataTable table = new DataTable();
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Nombre", typeof(string));
            table.Columns.Add("Apellidos", typeof(string));
            table.Columns.Add("Email", typeof(string));
            table.Columns.Add("Rol", typeof(int));
            foreach (Usuario us in usuarios)
            {
                DataRow row = table.NewRow();
                row["Id"] = us.IdUsuario;
                row["Nombre"] = us.Nombre;
                row["Apellidos"] = us.Apellidos;
                row["Email"] = us.Email;
                row["Rol"] = (int)us.Rol;
                table.Rows.Add(row);
            }
            gridClientes.DataSource = table;
            gridClientes.DataBind();
        }

        protected void gridClientes_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridClientes.EditIndex = e.NewEditIndex;
            this.LLenarGrid();
        }

        protected void gridClientes_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gridClientes.Rows[e.RowIndex];
            int Id = Convert.ToInt32(gridClientes.DataKeys[e.RowIndex].Values[0]);
            string Nombre = (row.Cells[3].Controls[0] as TextBox).Text;
            string Apellidos = (row.Cells[4].Controls[0] as TextBox).Text;
            string Email = (row.Cells[5].Controls[0] as TextBox).Text;
            int Rol = Convert.ToInt32((row.Cells[6].Controls[0] as TextBox).Text);
            Usuario usuario = new Usuario()
            {
                IdUsuario = Id,
                Nombre = Nombre,
                Apellidos = Apellidos,
                Email = Email,
                Rol = Rol == 1 ? Entidades.Rol.Administrador : Entidades.Rol.Usuario
            };

            UsuarioLogica logica = new UsuarioLogica();
            logica.Insertar(usuario);
            gridClientes.EditIndex = -1;
            LLenarGrid();
        }

        protected void gridClientes_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridClientes.EditIndex = -1;
            LLenarGrid();
        }

        protected void gridClientes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int IdUsuario = Convert.ToInt32(gridClientes.DataKeys[e.RowIndex].Values[0]);
            UsuarioLogica logica = new UsuarioLogica();
            logica.Eliminar(IdUsuario);
            LLenarGrid();
        }

        protected void gridClientes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != gridClientes.EditIndex)
            {
                (e.Row.Cells[1].Controls[0] as LinkButton).Attributes["onclick"] = "return confirm('¿Desea eliminar este Usuario?');";
            }
        }

        protected void lblUsuario7_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["usuario"] != null)
                {

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