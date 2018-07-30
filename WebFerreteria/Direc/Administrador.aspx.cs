using Capa.Logica;
using Entidades;
using Entidades.clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Imaging;

namespace WebFerreteria.Direc
{
    public partial class Administrador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LLenarGridClientes();
                LLenarGridCategorias();
                LLenarGridProductos();
                lbl.Text = "0";
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

        public void LLenarGridClientes()
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

        public void LLenarGridCategorias()
        {
            CategoriaLogica logica = new CategoriaLogica();
            List<Categoria> categorias = logica.SeleccionarTodos();
            DataTable table = new DataTable();
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Nombre", typeof(string));
            table.Columns.Add("Descripción", typeof(string));
            foreach (Categoria ca in categorias)
            {
                DataRow row = table.NewRow();
                row["Id"] = ca.IdCategoria;
                row["Nombre"] = ca.Nombre;
                row["Descripción"] = ca.Descripcion;
                table.Rows.Add(row);
            }
            gridCategorias.DataSource = table;
            gridCategorias.DataBind();
        }

        public void LLenarGridProductos()
        {
            ProductoLogica logica = new ProductoLogica();
            List<Producto> productos = logica.SeleccionarTodos();
            DataTable table = new DataTable();
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Nombre", typeof(string));
            table.Columns.Add("Descripción", typeof(string));
            table.Columns.Add("Categoria", typeof(string));
            table.Columns.Add("Imagen", typeof(System.Drawing.Image));
            table.Columns.Add("Precio", typeof(double));
            foreach(Producto pro in productos)
            {
                DataRow row = table.NewRow();
                row["Id"] = pro.IdProducto;
                row["Nombre"] = pro.Nombre;
                row["Descripción"] = pro.Descripcion;
                row["Categoria"] = pro.Categoria.Nombre;
                row["Imagen"] = ByteArrayToImage(pro.Imagen);
                row["Precio"] = pro.Precio;
                table.Rows.Add(row);
            }
            gridProductos.DataSource = table;
            gridProductos.DataBind();
        }

        protected void gridClientes_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridClientes.EditIndex = e.NewEditIndex;
            this.LLenarGridClientes();
            lbl.Text = "0";
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
            LLenarGridClientes();
            lbl.Text = "0";
        }

        protected void gridClientes_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridClientes.EditIndex = -1;
            LLenarGridClientes();
            lbl.Text = "0";
        }

        protected void gridClientes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int IdUsuario = Convert.ToInt32(gridClientes.DataKeys[e.RowIndex].Values[0]);
            UsuarioLogica logica = new UsuarioLogica();
            logica.Eliminar(IdUsuario);
            LLenarGridClientes();
            lbl.Text = "0";
        }

        protected void gridClientes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != gridClientes.EditIndex)
            {
                (e.Row.Cells[1].Controls[0] as LinkButton).Attributes["onclick"] = "return confirm('¿Desea eliminar este Usuario?');";
            }
            lbl.Text = "0";
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

        protected void gridCategorias_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridCategorias.EditIndex = e.NewEditIndex;
            this.LLenarGridCategorias();
            lbl.Text = "2";
        }

        protected void gridCategorias_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gridCategorias.Rows[e.RowIndex];
            int Id = Convert.ToInt32(gridCategorias.DataKeys[e.RowIndex].Values[0]);
            string Nombre = (row.Cells[3].Controls[0] as TextBox).Text;
            string Descripcion = (row.Cells[4].Controls[0] as TextBox).Text;
            Categoria Categoria = new Categoria()
            {
                IdCategoria = Id,
                Nombre = Nombre,
                Descripcion = Descripcion
            };

            CategoriaLogica logica = new CategoriaLogica();
            logica.Insertar(Categoria);
            gridCategorias.EditIndex = -1;
            LLenarGridCategorias();
            lbl.Text = "2";
        }

        protected void gridCategorias_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridCategorias.EditIndex = -1;
            LLenarGridCategorias();
            lbl.Text = "2";
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
            lbl.Text = "2";
        }

        protected void gridCategorias_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != gridCategorias.EditIndex)
            {
                (e.Row.Cells[1].Controls[0] as LinkButton).Attributes["onclick"] = "return confirm('¿Desea eliminar esta Categoría?');";
            }
            lbl.Text = "2";
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
        }

        protected void gridProductos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridProductos.EditIndex = e.NewEditIndex;
            this.LLenarGridProductos();
            lbl.Text = "1";
        }

        protected void gridProductos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gridProductos.Rows[e.RowIndex];
            int Id = Convert.ToInt32(gridProductos.DataKeys[e.RowIndex].Values[0]);
            string Nombre = (row.Cells[3].Controls[0] as TextBox).Text;
            string Descripcion = (row.Cells[4].Controls[0] as TextBox).Text;
            //Image imagen = (row.Cells[5].Controls[0] as FileUpload).PostedFile;
            Categoria Categoria = new Categoria()
            {
                IdCategoria = Id,
                Nombre = Nombre,
                Descripcion = Descripcion
            };
        }

        protected void gridProductos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }

        protected void gridProductos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void gridProductos_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            ProductoLogica logica = new ProductoLogica();
            byte[] imagen = null;
            using (BinaryReader reader = new BinaryReader(fluImagen.PostedFile.InputStream))
            {
                byte[] image = reader.ReadBytes(fluImagen.PostedFile.ContentLength);
                imagen = image;
            }
            Producto producto = new Producto()
            {
                Nombre = txtNombreProducto.Text,
                Descripcion = txtDescripcionProducto.Text,
                Categoria = new Categoria() { IdCategoria = 5 },
                Imagen = imagen,
                Precio = Convert.ToDouble(NudPrecio.Text)
            };
            logica.Insertar(producto);
            LLenarGridProductos();
            lbl.Text = "1";
        }

        public static System.Drawing.Image ByteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            return System.Drawing.Image.FromStream(ms);
        }

        public static byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, ImageFormat.Jpeg);
            return ms.ToArray();
        }
    }
}