using Capa.Logica;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFerreteria
{
    public partial class Contacto : System.Web.UI.Page
    {
        char[] delimitador_cc = { ',' };
        char[] delimitador_adjunto = { '|' };
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["usuario"] != null)
                {
                    UsuarioLogica logica = new UsuarioLogica();
                    Usuario Usuario = logica.SeleccionarPorID(Session["usuario"].ToString());
                    lblUsuario1.Text = Usuario.Nombre + "  <i class=\"fa fa-user-circle\"></i>";
                    if (Usuario.Rol == Rol.Administrador)
                    {
                        lblAdministrador1.Text = "<a href=\"Direc\\Administrador.aspx\" style=\"text-decoration:none;margin-top:8px;\">Administrador</a>";
                    }
                }
            }
            catch (Exception)
            {

            }
        }


        protected void lblUsuario1_Click(object sender, EventArgs e)
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

        public void enviar_correo(string host, int puerto, string remitente, string contraseña, string nombre, string nombrec, string apellidoc, string correoc, string telefonoc, string mensajec)
        {
            try
            {
                SmtpClient cliente = new SmtpClient(host, puerto);
                MailMessage correo = new MailMessage();

                correo.From = new MailAddress(remitente, nombre);
                correo.Body = nombrec + " " + apellidoc + " " + telefonoc + " " + mensajec;
                correo.To.Add(remitente);

                cliente.Credentials = new NetworkCredential(remitente, contraseña);
                cliente.EnableSsl = true;
                cliente.Send(correo);
                txtnombrec.Value = "";
                txtapellidoc.Value = "";
                txtcorreoc.Value = "";
                txttelefonoc.Value = "";
                txtmensajec.Value = "";
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void EnviarCorreo_Click(object sender, EventArgs e)
        {
            try
            {
                enviar_correo("smtp-mail.outlook.com", 587,
                    "pmora0813@hotmail.com",
                    "Pabl0m0ra0813", "Pablo",
                    txtnombrec.Value, txtapellidoc.Value,
                    txtcorreoc.Value, txttelefonoc.Value,
                    txtmensajec.Value);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}