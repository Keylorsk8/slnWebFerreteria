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
    public partial class Herramientas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //    ProductoLogica logica = new ProductoLogica();
            //    List<Producto> Lista = logica.SeleccionarTodos();
            //    foreach (var item in Lista)
            //    {
            //        Nombre.Text = item.Nombre;
            //        Consulta.ImageUrl = item.Imagen;
            //    }
            MostrarProductos();
        }


        private void MostrarProductos()
        {
            ProductoLogica Logica = new ProductoLogica();
            //List<Producto> Productos = Logica.SeleccionarConFiltro(txtBusqueda.Value, Convert.ToInt32(ddlCategoria.SelectedValue), Convert.ToDouble(max.Value));
            List<Producto> Productos = Logica.SeleccionarProductoIDCategoira(18);
            foreach (Producto pro in Productos)
            {
                string Imagen = "";
                if (pro.Imagen != null)
                {
                    Imagen = pro.Imagen;
                }
                DivProductos.Controls.Add(ProductoToCard(pro, Imagen));
            }
        }
        private Panel ProductoToCard(Producto Producto, string Imagen)
        {
            string Img = Imagen != null ? Imagen : "Images/No%20disponible.png";

            Panel panel = new Panel();
            panel.CssClass = "card mb-1 Cp";
            panel.ID = Producto.IdProducto.ToString();

            Panel CardB = new Panel();
            CardB.CssClass = "card-title TituloC";

            Panel Cardimg = new Panel();
            Cardimg.CssClass = "card-title ImgC";

            Panel CardPrice = new Panel();
            CardPrice.CssClass = "card-title PriceC";

            Panel CardButtons = new Panel();
            CardButtons.CssClass = "card-title ButtonsC";

            Label h5 = new Label();
            h5.CssClass = "card-title";
            h5.Text = Producto.Nombre;

            Image img = new Image();
            img.CssClass = "CarImg";
            img.ImageUrl = Img;

            Label h3 = new Label();
            h3.Text = "₡" + Producto.Precio + ",00";

            Button btnInfo = new Button();
            btnInfo.CssClass = "btn btn-outline-dark1";
            btnInfo.Text = "Info";

            Button btnAñadir = new Button();
            btnAñadir.CssClass = "btn btn-outline-success1";
            btnAñadir.Text = "Añadir";


            CardB.Controls.Add(h5);
            Cardimg.Controls.Add(img);
            CardPrice.Controls.Add(h3);
            CardButtons.Controls.Add(btnInfo);
            CardButtons.Controls.Add(btnAñadir);
            panel.Controls.Add(CardB);
            panel.Controls.Add(Cardimg);
            panel.Controls.Add(CardPrice);
            panel.Controls.Add(CardButtons);

            return panel;
        }
    }
}