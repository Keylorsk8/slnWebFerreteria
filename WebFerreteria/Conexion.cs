using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFerreteria
{
    public class Conexion
    {
        public static string Cadena
        { 
            get
            {
                return "Data Source =.; Initial Catalog = FerreteriaJyR; Persist Security Info = True; User ID = sa";
            }
        }
    }
}