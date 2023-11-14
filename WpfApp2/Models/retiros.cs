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
        private String FECHAPARA_CALCULO { get; set; }

        public retiros() { }

        public retiros(int cOD_TER, String fECHAPARA_CALCULO)
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
            
            conexionbd con = new conexionbd();
            string peticion = "INSERT INTO tbl_retiros (COD_TER, FECHAPARA_CALCULO)" +
                $"VALUES ({COD_TER}, '{FECHAPARA_CALCULO}')";
            int res = con.conexionAltTabla(peticion);
            if (res >= 1)
            {
                anio2006();
                anio2007();
                anio2008();
                anio2009();
                anio2010();
                anio2011();
                anio2012();
                anio2013();
                anio2014();
                anio2015();
                anio2016();
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
        private (int anio, int mes, int dia) retAnioMesDia(int cod_ter)
        {
            conexionbd con = new conexionbd();
            DataSet conAnio = con.crearConexion($"SELECT YEAR(FECHAPARA_CALCULO) as year FROM tbl_retiros WHERE COD_TER = {cod_ter}");
            DataSet conMes = con.crearConexion($"SELECT MONTH(FECHAPARA_CALCULO) as mes FROM tbl_retiros WHERE COD_TER = {cod_ter}");
            DataSet conDia = con.crearConexion($"SELECT DAY(FECHAPARA_CALCULO) as dia FROM tbl_retiros WHERE COD_TER = {cod_ter}");

            int anio = Convert.ToInt32(conAnio.Tables[0].Rows[0]["year"]);
            int mes = Convert.ToInt32(conMes.Tables[0].Rows[0]["mes"]);
            int dia = Convert.ToInt32(conDia.Tables[0].Rows[0]["dia"]);

            return (anio, mes, dia);
        }

        public void anio2006()
        {            
            conexionbd con = new conexionbd();            
            con.conexionAltTabla(agregarColumna("2006"));

            DataSet res = con.crearConexion("SELECT COD_TER FROM tbl_retiros where liquidacion_2006 iS NULL;");
            foreach (DataRow i in res.Tables[0].Rows)
            {
                int cod_ter = (int)i["COD_TER"];
                var r = retAnioMesDia(cod_ter);              

                double calculo = 0;
                if (r.anio <= 2006)
                {
                    int valorFijo = 1000000;
                    int difAño = 2006 - r.anio;
                    int difMes = 12 -  r.mes;
                    int difDia = 31 - r.dia;

                    calculo = (difAño * valorFijo) + ((difMes* valorFijo)/12) + (((difDia * valorFijo) /12)/30);                               
                }
                string updateCon = $"UPDATE tbl_retiros SET liquidacion_2006={calculo}  WHERE COD_TER = {cod_ter};";
                int resptaaa = con.conexionAltTabla(updateCon);
                //string mensaje = "xd " + resptaaa;
                //MessageBox.Show(mensaje);
            }

        }       

        public void anio2007()
        {
            conexionbd con = new conexionbd();
            con.conexionAltTabla(agregarColumna("2007"));

            DataSet res = con.crearConexion("SELECT COD_TER FROM tbl_retiros where liquidacion_2007 iS NULL;");
            foreach (DataRow i in res.Tables[0].Rows)
            {
                int cod_ter = (int)i["COD_TER"];

                var r = retAnioMesDia(cod_ter);
                int valorFijo = 576000;
                double calculo = 0;
                if (r.anio <= 2006)
                {
                    calculo = valorFijo;
                }
                else if (r.anio == 2007) {
                                        
                    int difMes = 12 - r.mes;
                    int difDia = 31 - r.dia;

                    calculo = ((difMes * valorFijo) / 12) + (((difDia * valorFijo) / 12) / 30);
                }
                string updateCon = $"UPDATE tbl_retiros SET liquidacion_2007={calculo}  WHERE COD_TER = {cod_ter};";
                con.conexionAltTabla(updateCon);                
            }
        }
        public void anio2008()
        {
            conexionbd con = new conexionbd();
            con.conexionAltTabla(agregarColumna("2008"));

            DataSet res = con.crearConexion("SELECT COD_TER FROM tbl_retiros where liquidacion_2008 iS NULL;");
            foreach (DataRow i in res.Tables[0].Rows)
            {
                int cod_ter = (int)i["COD_TER"];

                var r = retAnioMesDia(cod_ter);

                int valorFijo = 670472;
                double calculo = 0;
                if (r.anio <= 2007)
                {
                    calculo = valorFijo;
                }
                else if (r.anio == 2008)
                {                    
                    int difMes = 12 - r.mes;
                    int difDia = 31 - r.dia;

                    calculo = ((difMes * valorFijo) / 12) + (((difDia * valorFijo) / 12) / 30);
                }
                string updateCon = $"UPDATE tbl_retiros SET liquidacion_2008={calculo}  WHERE COD_TER = {cod_ter};";
                con.conexionAltTabla(updateCon);
            }
        }
        public void anio2009()
        {
            conexionbd con = new conexionbd();
            con.conexionAltTabla(agregarColumna("2009"));

            DataSet res = con.crearConexion("SELECT COD_TER FROM tbl_retiros where liquidacion_2009 iS NULL;");
            foreach (DataRow i in res.Tables[0].Rows)
            {
                int cod_ter = (int)i["COD_TER"];

                var r = retAnioMesDia(cod_ter);

                int valorFijo = 780350;
                double calculo = 0;
                if (r.anio < 2009)
                {
                    calculo = valorFijo;
                }
                else if (r.anio == 2009)
                {
                    int difMes = 12 - r.mes;
                    int difDia = 31 - r.dia;
                    calculo = ((difMes * valorFijo) / 12) + (((difDia * valorFijo) / 12) / 30);
                }                
                con.conexionAltTabla($"UPDATE tbl_retiros SET liquidacion_2009={calculo}  WHERE COD_TER = {cod_ter};");
            }
        }
        public void anio2010()
        {
            conexionbd con = new conexionbd();
            con.conexionAltTabla(agregarColumna("2010"));

            DataSet res = con.crearConexion("SELECT COD_TER FROM tbl_retiros where liquidacion_2010 iS NULL;");
            foreach (DataRow i in res.Tables[0].Rows)
            {
                int cod_ter = (int)i["COD_TER"];

                var r = retAnioMesDia(cod_ter);

                int valorFijo = 823000;
                double calculo = 0;
                if (r.anio < 2010)
                {
                    calculo = valorFijo;
                }
                else if (r.anio == 2010)
                {
                    int difMes = 12 - r.mes;
                    int difDia = 31 - r.dia;
                    calculo = ((difMes * valorFijo) / 12) + (((difDia * valorFijo) / 12) / 30);
                }
                con.conexionAltTabla($"UPDATE tbl_retiros SET liquidacion_2010={calculo}  WHERE COD_TER = {cod_ter};");
            }
        }
        public void anio2011()
        {
            conexionbd con = new conexionbd();
            con.conexionAltTabla(agregarColumna("2011"));

            DataSet res = con.crearConexion("SELECT COD_TER FROM tbl_retiros where liquidacion_2011 iS NULL;");
            foreach (DataRow i in res.Tables[0].Rows)
            {
                int cod_ter = (int)i["COD_TER"];

                var r = retAnioMesDia(cod_ter);

                int valorFijo = 945000;
                double calculo = 0;
                if (r.anio < 2011)
                {
                    calculo = valorFijo;
                }
                else if (r.anio == 2011)
                {
                    int difMes = 12 - r.mes;
                    int difDia = 31 - r.dia;
                    calculo = ((difMes * valorFijo) / 12) + (((difDia * valorFijo) / 12) / 30);
                }
                con.conexionAltTabla($"UPDATE tbl_retiros SET liquidacion_2011={calculo}  WHERE COD_TER = {cod_ter};");
            }
        }
        public void anio2012()
        {
            conexionbd con = new conexionbd();
            con.conexionAltTabla(agregarColumna("2012"));

            DataSet res = con.crearConexion("SELECT COD_TER FROM tbl_retiros where liquidacion_2012 iS NULL;");
            foreach (DataRow i in res.Tables[0].Rows)
            {
                int cod_ter = (int)i["COD_TER"];

                var r = retAnioMesDia(cod_ter);

                int valorFijo = 1000000;
                double calculo = 0;
                if (r.anio < 2012)
                {
                    calculo = valorFijo;
                }
                else if (r.anio == 2012)
                {
                    int difMes = 12 - r.mes;
                    int difDia = 31 - r.dia;
                    calculo = ((difMes * valorFijo) / 12) + (((difDia * valorFijo) / 12) / 30);
                }
                con.conexionAltTabla($"UPDATE tbl_retiros SET liquidacion_2012={calculo}  WHERE COD_TER = {cod_ter};");
            }
        }
        public void anio2013()
        {
            conexionbd con = new conexionbd();
            con.conexionAltTabla(agregarColumna("2013"));

            DataSet res = con.crearConexion("SELECT COD_TER FROM tbl_retiros where liquidacion_2013 iS NULL;");
            foreach (DataRow i in res.Tables[0].Rows)
            {
                int cod_ter = (int)i["COD_TER"];

                var r = retAnioMesDia(cod_ter);

                int valorFijo = 1090000;
                double calculo = 0;
                if (r.anio < 2013)
                {
                    calculo = valorFijo;
                }
                else if (r.anio == 2013)
                {
                    int difMes = 12 - r.mes;
                    int difDia = 31 - r.dia;
                    calculo = ((difMes * valorFijo) / 12) + (((difDia * valorFijo) / 12) / 30);
                }
                con.conexionAltTabla($"UPDATE tbl_retiros SET liquidacion_2013={calculo}  WHERE COD_TER = {cod_ter};");
            }
        }
        public void anio2014()
        {
            conexionbd con = new conexionbd();
            con.conexionAltTabla(agregarColumna("2014"));

            DataSet res = con.crearConexion("SELECT COD_TER FROM tbl_retiros where liquidacion_2014 iS NULL;");
            foreach (DataRow i in res.Tables[0].Rows)
            {
                int cod_ter = (int)i["COD_TER"];

                var r = retAnioMesDia(cod_ter);

                int valorFijo = 1263000;
                double calculo = 0;
                if (r.anio < 2014)
                {
                    calculo = valorFijo;
                }
                else if (r.anio == 2014)
                {
                    int difMes = 12 - r.mes;
                    int difDia = 31 - r.dia;
                    calculo = ((difMes * valorFijo) / 12) + (((difDia * valorFijo) / 12) / 30);
                }
                con.conexionAltTabla($"UPDATE tbl_retiros SET liquidacion_2014={calculo}  WHERE COD_TER = {cod_ter};");
            }
        }
        public void anio2015()
        {
            conexionbd con = new conexionbd();
            con.conexionAltTabla(agregarColumna("2015"));

            DataSet res = con.crearConexion("SELECT COD_TER FROM tbl_retiros where liquidacion_2015 iS NULL;");
            foreach (DataRow i in res.Tables[0].Rows)
            {
                int cod_ter = (int)i["COD_TER"];

                var r = retAnioMesDia(cod_ter);

                int valorFijo = 1336600;
                double calculo = 0;
                if (r.anio < 2015)
                {
                    calculo = valorFijo;
                }
                else if (r.anio == 2015)
                {
                    int difMes = 12 - r.mes;
                    int difDia = 31 - r.dia;
                    calculo = ((difMes * valorFijo) / 12) + (((difDia * valorFijo) / 12) / 30);
                }
                con.conexionAltTabla($"UPDATE tbl_retiros SET liquidacion_2015={calculo}  WHERE COD_TER = {cod_ter};");
            }
        }
        public void anio2016()
        {
            conexionbd con = new conexionbd();
            con.conexionAltTabla(agregarColumna("2016"));

            DataSet res = con.crearConexion("SELECT COD_TER FROM tbl_retiros where liquidacion_2016 iS NULL;");
            foreach (DataRow i in res.Tables[0].Rows)
            {
                int cod_ter = (int)i["COD_TER"];

                var r = retAnioMesDia(cod_ter);

                int valorFijo = 2527574;
                double calculo = 0;
                if (r.anio < 2016)
                {
                    calculo = valorFijo;
                }
                else if (r.anio == 2016)
                {
                    int difMes = 12 - r.mes;
                    int difDia = 31 - r.dia;
                    calculo = ((difMes * valorFijo) / 12) + (((difDia * valorFijo) / 12) / 30);
                }
                con.conexionAltTabla($"UPDATE tbl_retiros SET liquidacion_2016={calculo}  WHERE COD_TER = {cod_ter};");
            }
        }
    }
}
