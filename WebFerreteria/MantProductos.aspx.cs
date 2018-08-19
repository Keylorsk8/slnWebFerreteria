using Capa.Logica;
using Entidades.clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFerreteria
{
    public partial class MantProductos : System.Web.UI.Page
    {
        ProductoLogica logica = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            logica = new ProductoLogica();

            ddlCate.DataSource = new CategoriaLogica().SeleccionarTodos();
            ddlCate.DataTextField = "Nombre";
            ddlCate.DataValueField = "idCategoria";
            ddlCate.DataBind();



        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            int tamaño = fileUpload.PostedFile.ContentLength;

            Producto producto = new Producto();
            {
                producto.Nombre = txtnombre.Value;
                producto.Descripcion = txtDescripcion.Value;
                producto.Categoria = Convert.ToInt32(ddlCate.SelectedValue);
                producto.Precio = Convert.ToInt32(txtPrecio.Value);
               

            };

            byte[] ImagenOriginal = new byte[tamaño];

            fileUpload.PostedFile.InputStream.Read(ImagenOriginal, 0, tamaño);

            string ImagenBase64 = "data:image/jpg;base64," + Convert.ToBase64String(ImagenOriginal);

            producto.Imagen = ImagenBase64;

            imagen.ImageUrl = ImagenBase64;

            logica.Insertar(producto);

            Response.Redirect("MantProductos.aspx");
           
                
        }

        protected void MostrarIMG(object sender, EventArgs e)
        {
            int tamaño = fileUpload.PostedFile.ContentLength;
            byte[] ImagenOriginal = new byte[tamaño];
            fileUpload.PostedFile.InputStream.Read(ImagenOriginal, 0, tamaño);

            string ImagenBase64 = "data:image/jpg;base64," + Convert.ToBase64String(ImagenOriginal);
            imagen.ImageUrl = ImagenBase64;
        }
    }
}