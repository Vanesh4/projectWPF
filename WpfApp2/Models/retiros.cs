using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp2.Models
{
    class retiros
    {
        private int COD_TER { get; set; }
        private DateTime FECHAPARA_CALCULO { get; set; }

        public retiros() { }

        public retiros(int cOD_TER, DateTime fECHAPARA_CALCULO)
        {
            COD_TER = cOD_TER;
            FECHAPARA_CALCULO = fECHAPARA_CALCULO;
        }

        private string agregarColumna(string anio)
        {
            string consulta = $"ALTER TABLE tbl_retiros ADD liquidacion_{anio} BIGINT;";
            return consulta;
        }

        public void anio2006()
        {

            conexionbd con = new conexionbd();
            DataSet res = con.crearConexion("SELECT COD_TER FROM tbl_retiros");
            foreach (DataRow i in res.Tables[0].Rows)
            {
                int cod_ter = (int)i["COD_TER"];
                string anio = $"SELECT YEAR(FECHAPARA_CALCULO) FROM tbl_retiros WHERE COD_TER = {cod_ter}";
                string mes = $"SELECT MONTH(FECHAPARA_CALCULO) FROM tbl_retiros WHERE COD_TER = {cod_ter}";
                string dia = $"SELECT DAY(FECHAPARA_CALCULO) FROM tbl_retiros WHERE COD_TER = {cod_ter}";
                string mensaje = "cada reg" + con.crearConexion(anio);
                MessageBox.Show(mensaje);
            }

            

        }
    }
}
