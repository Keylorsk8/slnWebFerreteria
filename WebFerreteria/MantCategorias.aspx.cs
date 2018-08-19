using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFerreteria
{
    public partial class MantCategorias : System.Web.UI.Page
    {
      
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubirImagen_Click(object sender, EventArgs e)
        {
            //obtener los datos de la imagen
            int tamaño = fileUpload.PostedFile.ContentLength;
            string nombre = txtnombre.Text;

            byte[] ImagenOriginal = new byte[tamaño];

            fileUpload.PostedFile.InputStream.Read(ImagenOriginal, 0, tamaño);

            string ImagenBase64 = "data:image/jpg;base64," + Convert.ToBase64String(ImagenOriginal);

            imagen.ImageUrl = ImagenBase64;

            //insertar imagen de datos
            SqlConnection conexionSQL = new SqlConnection(Conexion.Cadena);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "insert into Categoria(Nombre,Descripcion) values(@Nombre,@Imagen)";
            cmd.Parameters.Add("@Imagen", SqlDbType.NVarChar).Value = ImagenBase64;
            cmd.Parameters.AddWithValue("@Nombre", nombre);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conexionSQL;
            conexionSQL.Open();
            cmd.ExecuteNonQuery();
        }

        
    }
}