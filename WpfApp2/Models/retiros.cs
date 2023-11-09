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
        public DataSet getRetiros()
        {
            conexionbd con = new conexionbd();
            string consulta = "select * from tbl_retiros";
            return con.crearConexion(consulta);
        }

        public String postTblRetiros()
        {
            string msj = "hola c: " + COD_TER + "\nxd " + FECHAPARA_CALCULO;
            MessageBox.Show(msj);
            conexionbd con = new conexionbd();
            string peticion = "INSERT INTO tbl_retiros (COD_TER, FECHAPARA_CALCULO)" +
                $"VALUES ({COD_TER}, '{FECHAPARA_CALCULO}')";
            int res = con.conexionAltTabla(peticion);
            if (res >= 1)
            {
                return "Inserción exitosa";
            }
            else
            {
                return "Error al insertar datos";
            }
        }

        private string agregarColumna(string anio)
        {
            string consulta = $"ALTER TABLE tbl_retiros ADD liquidacion_{anio} BIGINT";
            return consulta;
        }

        public void anio2006()
        {
            conexionbd con = new conexionbd();
            DataSet res = con.crearConexion("SELECT COD_TER FROM tbl_retiros");
            foreach (DataRow i in res.Tables[0].Rows)
            {
                int cod_ter = (int)i["COD_TER"];

                DataSet conAnio = con.crearConexion($"SELECT YEAR(FECHAPARA_CALCULO) as year FROM tbl_retiros WHERE COD_TER = {cod_ter}");
                DataSet conMes = con.crearConexion($"SELECT MONTH(FECHAPARA_CALCULO) as mes FROM tbl_retiros WHERE COD_TER = {cod_ter}");
                DataSet conDia = con.crearConexion($"SELECT DAY(FECHAPARA_CALCULO) as dia FROM tbl_retiros WHERE COD_TER = {cod_ter}");

                int anio = Convert.ToInt32(conAnio.Tables[0].Rows[0]["year"]);
                int mes = Convert.ToInt32(conMes.Tables[0].Rows[0]["mes"]);
                int dia = Convert.ToInt32(conDia.Tables[0].Rows[0]["dia"]);


                double calculo = 0;
                if (anio <= 2006)
                {
                    int valorFijo = 1000000;
                    int difAño = 2006 - anio;
                    int difMes = 12 - mes;
                    int difDia = 31 - dia;

                    calculo = (difAño * valorFijo) + ((difMes* valorFijo)/12) + (((difDia * valorFijo) /12)/30);                               
                }
                string updateCon = $"UPDATE tbl_retiros SET liquidacion_2006 ={calculo}  WHERE COD_TER = {cod_ter};";
                int resptaaa = con.conexionAltTabla(updateCon);
                //string mensaje = "xd " + resptaaa;
                //MessageBox.Show(mensaje);
            }

        }
    }
}
