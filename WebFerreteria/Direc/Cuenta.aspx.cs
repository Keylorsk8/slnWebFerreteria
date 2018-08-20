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
    public partial class Cuenta : System.Web.UI.Page
    {
        Usuario us = null;
        List<Telefono> Telefonos = new List<Telefono>();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["usuario"] != null)
                {
                    UsuarioLogica logica = new UsuarioLogica();
                    Usuario Usuario = logica.SeleccionarPorID(Session["usuario"].ToString());
                    this.us = Usuario;
                    lblUsuario10.Text = Usuario.Nombre + "  <i class=\"fa fa-user-circle\"></i>";
                    if (Usuario.Rol == Rol.Administrador)
                    {
                        lblAdministrador4.Text = "<a id=\"active\" href=\"Administrador.aspx\" style=\"text-decoration:none;margin-top:8px;\">Administrador</a>";
                    }
                }else
                {
                    Response.Redirect("../Inicio Sesion.aspx");
                }
            }
            catch (Exception)
            {

            }
            if (!IsPostBack)
            {
                CargarTelefonos();
                CargarDatos();
            }
        }

        private void CargarDatos()
        {
            UsuarioLogica logica = new UsuarioLogica();
            Usuario us = logica.SeleccionarPorID(Session["usuario"].ToString());
            txtNombreCliente.Text = us.Nombre;
            txtApellidos.Text = us.Apellidos;
            txtEmail.Text = us.Email;
        }

        private void CargarTelefonos()
        {
            UsuarioLogica logica = new UsuarioLogica();
            Usuario us = logica.SeleccionarPorID(Session["usuario"].ToString());
            List<Telefono> Telefonos = new List<Telefono>();
            Telefonos = logica.SeleccionarTelefonosPorId(us.IdUsuario);
            DataTable table = new DataTable();
            table.Columns.Add("Id");
            table.Columns.Add("Numero");
            foreach(Telefono tel in Telefonos)
            {
                DataRow row = table.NewRow();
                row["Id"] = us.IdUsuario;
                row["Numero"] = tel.Numero;
                table.Rows.Add(row);
            }
            gridTelefonos.DataSource = table;
            gridTelefonos.DataBind();
        }

        protected void lblUsuario8_Click(object sender, EventArgs e)
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

        protected void CerrarSesion_Click(object sender, EventArgs e)
        {
            Session["usuario"] = "";
            Response.Redirect("../Inicio Sesion.aspx");
        }

        protected void gridTelefonos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = e.RowIndex;
            gridTelefonos.SelectedIndex = index;
            string numero = gridTelefonos.SelectedRow.Cells[2].Text;
            UsuarioLogica logica = new UsuarioLogica();
            logica.EliminarTelefono((new UsuarioLogica().SeleccionarPorID(Session["usuario"].ToString())).IdUsuario,numero);
            CargarDatos();
            CargarTelefonos();
        }

        protected void txtNombreCliente_TextChanged(object sender, EventArgs e)
        { 
            us.Nombre = txtNombreCliente.Text;
        }

        protected void txtApellidos_TextChanged(object sender, EventArgs e)
        {
            us.Apellidos = txtApellidos.Text;
        }

        protected void GuardarCambios_Click(object sender, EventArgs e)
        {
            if (txtContraseña.Text.Equals(txtContraseña2.Text)) {
                us.contraseña = txtContraseña2.Text;
                new UsuarioLogica().Insertar(us);
                txtContraseña.Text = "";
                txtContraseña2.Text = "";
                CargarTelefonos();
                CargarDatos();
                UsuarioLogica logica = new UsuarioLogica();
                Usuario Usuario = logica.SeleccionarPorID(Session["usuario"].ToString());
                this.us = Usuario;
                lblUsuario10.Text = Usuario.Nombre + "  <i class=\"fa fa-user-circle\"></i>";
            }
            else
            {
                txtContraseña2.Focus();
                Response.Write("<script>alert('Las contraseñas no coinciden,Intelo de nuevo')</script>");
            }
        }

        protected void AgregarTelefono_Click(object sender, EventArgs e)
        {
            if(txtNuevoNumero.Text != "")
            {
                Usuario usuario = new UsuarioLogica().SeleccionarPorID(Session["usuario"].ToString());
                List<Telefono> Telefonos = usuario.GetTelefonos();
                Telefono tel = new Telefono() { IdUsuario = usuario.IdUsuario, Numero = txtNuevoNumero.Text };
                Telefonos.Add(tel);
                usuario.SetTelefonos(Telefonos);
                new UsuarioLogica().Insertar(usuario);
                CargarDatos();
                CargarTelefonos();
                txtNuevoNumero.Text = "";
            }else
            {
                Response.Write("<script>alert('Digite un número de teléfono'); document.getElementById('txtNuevoNumero').focus();</script>");
            }
        }

        protected void Buscar_ServerClick(object sender, EventArgs e)
        {
            Session["producto"] = txtBusqueda.Value;
            Response.Redirect("../Productos.aspx", false);
        }
    }
}