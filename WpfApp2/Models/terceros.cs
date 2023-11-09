using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Models
{
    internal class terceros
    {

        public DataSet getTerceros()
        {
            conexionbd con = new conexionbd();
            string consulta = "select * from tbl_terceros";
            return con.crearConexion(consulta);
        }
        
    }
}
