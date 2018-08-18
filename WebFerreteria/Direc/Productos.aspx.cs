using Capa.Logica;
using Entidades;
using Entidades.clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFerreteria.Direc
{
    public partial class Productos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LLenarGridProductos();
                LLenarComboCategorias();
            }
            try
            {
                if (Session["usuario"] != null)
                {
                    UsuarioLogica logica = new UsuarioLogica();
                    Usuario Usuario = logica.SeleccionarPorID(Session["usuario"].ToString());
                    lblUsuario6.Text = Usuario.Nombre + "  <i class=\"fa fa-user-circle\"></i>";
                    if (Usuario.Rol == Rol.Administrador)
                    {
                        lblAdministrador4.Text = "<a id=\"active\" href=\"Administrador.aspx\" style=\"text-decoration:none;margin-top:8px;\">Administrador</a>";
                    }
                }
            }
            catch (Exception)
            {

            }
            btnActualizarProducto.Visible = false;
            btnBorrarProducto.Visible = false;
            divIdProducto.Visible = false;
        }

        protected void lblUsuario6_Click(object sender, EventArgs e)
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

        public void LLenarGridProductos()
        {
            ProductoLogica logica = new ProductoLogica();
            List<Producto> productos = logica.SeleccionarTodos();
            DataTable table = new DataTable();
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Nombre", typeof(string));
            foreach (Producto pro in productos)
            {
                DataRow row = table.NewRow();
                row["Id"] = pro.IdProducto;
                row["Nombre"] = pro.Nombre;
                table.Rows.Add(row);
            }
            gridProductos.DataSource = table;
            gridProductos.DataBind();
            gridProductos.SelectedIndex = -1;
        }

        private void LLenarComboCategorias()
        {
            CategoriaLogica logica = new CategoriaLogica();
            List<Categoria> Categorias = logica.SeleccionarTodos();
            cmbCategoria.DataSource = Categorias;
            cmbCategoria.DataTextField = "Nombre";
            cmbCategoria.DataValueField = "IdCategoria";
            cmbCategoria.DataBind();
        }

        protected void gridProductos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int IdProducto = Convert.ToInt32(gridProductos.DataKeys[e.RowIndex].Values[0]);
            ProductoLogica logica = new ProductoLogica();
            try
            {
                logica.Eliminar(IdProducto);
                LLenarGridProductos();
            }
            catch (Exception ex)
            {
                string script = @"<script type='text/javascript'>
                            alert('Este producto no puede ser eliminado');
                        </script>";

                script = string.Format(script, ex.Message);

                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            }
            gridProductos.SelectedIndex = -1;
        }

        protected void gridProductos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.ToolTip = "Click en Seleccionar para editar este Producto";
            }
        }

        protected void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            ProductoLogica logica = new ProductoLogica();
            byte[] imagen = null;
            using (BinaryReader reader = new BinaryReader(fluImagen.PostedFile.InputStream))
            {
                if (fluImagen.PostedFile != null)
                {
                    byte[] image = reader.ReadBytes(fluImagen.PostedFile.ContentLength);
                    imagen = image;
                }
            }
            Producto producto = new Producto()
            {
                Nombre = txtNombreProducto.Text,
                Descripcion = txtDescripcionProducto.Text,
                Categoria = new CategoriaLogica().SeleccionarPorID(Convert.ToInt32(cmbCategoria.SelectedItem.Value)),
                Imagen = imagen,
                Precio = Convert.ToDouble(NudPrecio.Text)
            };
            logica.Insertar(producto);
            LLenarGridProductos();
            txtNombreProducto.Text = "";
            txtDescripcionProducto.Text = "";
            cmbCategoria.SelectedIndex = 0;
            NudPrecio.Text = "";
            gridProductos.SelectedIndex = -1;
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

        protected void btnActualizarProducto_Click(object sender, EventArgs e)
        {
            ProductoLogica logica = new ProductoLogica();
            byte[] imagen = null;
            using (BinaryReader reader = new BinaryReader(fluImagen.PostedFile.InputStream))
            {
                if (fluImagen.PostedFile != null)
                {
                    byte[] image = reader.ReadBytes(fluImagen.PostedFile.ContentLength);
                    imagen = image;
                }
            }
            Producto producto = new Producto()
            {
                IdProducto = Convert.ToInt32(txtIdProducto.Text),
                Nombre = txtNombreProducto.Text,
                Descripcion = txtDescripcionProducto.Text,
                Categoria = new CategoriaLogica().SeleccionarPorID(Convert.ToInt32(cmbCategoria.SelectedItem.Value.ToString())),
                Imagen = imagen,
                Precio = Convert.ToDouble(NudPrecio.Text)
            };
            logica.Insertar(producto);
            LLenarGridProductos();
            txtNombreProducto.Text = "";
            txtDescripcionProducto.Text = "";
            cmbCategoria.SelectedIndex = 0;
            NudPrecio.Text = "";
            divIdProducto.Visible = false;
            btnActualizarProducto.Visible = false;
            btnBorrarProducto.Visible = false;
            btnAgregarProducto.Visible = true;
            gridProductos.SelectedIndex = -1;
        }

        protected void btnBorrarProducto_Click(object sender, EventArgs e)
        {
            txtNombreProducto.Text = "";
            txtDescripcionProducto.Text = "";
            cmbCategoria.SelectedIndex = 0;
            NudPrecio.Text = "";
            divIdProducto.Visible = false;
            txtIdProducto.Text = "";
            btnActualizarProducto.Visible = false;
            btnBorrarProducto.Visible = false;
            btnAgregarProducto.Visible = true;
            gridProductos.SelectedIndex = -1;
        }

        protected void gridProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Producto Producto = new ProductoLogica().SeleccionarPorID(Convert.ToInt32(gridProductos.SelectedRow.Cells[2].Text));
            txtNombreProducto.Text = Producto.Nombre;
            txtDescripcionProducto.Text = Producto.Descripcion;
            for(int i = 0; i < cmbCategoria.Items.Count; i++)
            {
                if((new CategoriaLogica().SeleccionarPorID(Convert.ToInt32(cmbCategoria.Items[i].Value)).IdCategoria == Producto.Categoria.IdCategoria))
                {
                    cmbCategoria.SelectedIndex = i;
                    break;
                }
            }
            NudPrecio.Text = Producto.Precio.ToString();
            divIdProducto.Visible = true;
            txtIdProducto.Text = Producto.IdProducto.ToString();
            btnActualizarProducto.Visible = true;
            btnBorrarProducto.Visible = true;
            btnAgregarProducto.Visible = false;
        }
    }
}