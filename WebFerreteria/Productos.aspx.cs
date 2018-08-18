using Capa.Logica;
using Entidades;
using Entidades.clases;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFerreteria
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarCategorias();
                MostrarProductos();
            }
            try
            {
                if (Session["usuario"] != null)
                {
                    UsuarioLogica logica = new UsuarioLogica();
                    Usuario Usuario = logica.SeleccionarPorID(Session["usuario"].ToString());
                    lblUsuario3.Text = Usuario.Nombre + "  <i class=\"fa fa-user-circle\"></i>";
                    if (Usuario.Rol == Rol.Administrador)
                    {
                        lblAdministrador3.Text = "<a href=\"Direc\\Administrador.aspx\" style=\"text-decoration:none;margin-top:8px;\">Administrador</a>";
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        protected void lblUsuario3_Click(object sender, EventArgs e)
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
        protected void Borrar_Click(object sender, EventArgs e)
        {
            txtBusqueda.Value = "";
            ddlCategoria.SelectedIndex = -1;
            max.Value = "999999";
            MostrarProductos();
        }

        private void MostrarProductos()
        {
            ProductoLogica Logica = new ProductoLogica();
            List<Producto> Productos = Logica.SeleccionarConFiltro(txtBusqueda.Value,Convert.ToInt32(ddlCategoria.SelectedValue),Convert.ToDouble(max.Value));
            foreach(Producto pro in Productos)
            {
                string Imagen = "";
                if(pro.Imagen != null)
                {
                    Imagen = "data:image/jpg;base64," + Convert.ToBase64String(pro.Imagen);
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
            btnInfo.CssClass = "btn btn-outline-dark";
            btnInfo.Text = "Info";
            btnInfo.Attributes.Add("data-toggle", "modal");
            btnInfo.Attributes.Add("data-target", "#myModal");
            btnInfo.OnClientClick = "return false";

            Button btnAñadir = new Button();
            btnAñadir.CssClass = "btn btn-outline-success";
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

        public static System.Drawing.Image ByteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            return System.Drawing.Image.FromStream(ms);
        }

        private void LlenarCategorias()
        {
            CategoriaLogica logica = new CategoriaLogica();
            List<Categoria> Categorias = logica.SeleccionarTodos();
            Categorias.Insert(0, new Categoria() { Nombre = "Todas las Categorías", IdCategoria = -1 });
            ddlCategoria.DataSource = Categorias;
            ddlCategoria.DataTextField = "Nombre";
            ddlCategoria.DataValueField = "IdCategoria";
            ddlCategoria.DataBind();
        }

        protected void Filtrar_Click(object sender, EventArgs e)
        {
            MostrarProductos();
        }
        
        private bool MostrarProducto()
        {

            return false;
        }
    }
}