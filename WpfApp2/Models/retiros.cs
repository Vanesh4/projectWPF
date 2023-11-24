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
            string consulta = "select COD_TER, fecha_para_calculo, liquidacion_2017PLUS, liquidacion_2018PLUS, liquidacion_2019PLUS, liquidacion_2020PLUS, liquidacion_2021PLUS, liquidacion_2022PLUS from BD$";
            //string consulta = "select COD_TER, fecha_para_calculo from BD$";
            //string consulta = "select * from BD$";
            return con.crearConexion(consulta);
        }

        public String postTblRetiros()
        {

            conexionbd con = new conexionbd();
            string peticion = "INSERT INTO BD$ (COD_TER, FECHAPARA_CALCULO)" +
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
                anio2017();
                anio2018();
                anio2019();
                anio2020();
                anio2021();
                anio2022();
                return "Inserción exitosa";
            }
            else
            {
                return "Error al insertar datos";
            }
        }

        private string agregarColumna(string anio)
        {
            string consulta = $"ALTER TABLE BD$ ADD liquidacion_{anio} BIGINT";
            return consulta;
        }
        private (int anio, int mes, int dia) retAnioMesDia(int cod_ter)
        {
            conexionbd con = new conexionbd();
            DataSet conAnio = con.crearConexion($"SELECT YEAR(fecha_para_calculo) as year FROM BD$ WHERE COD_TER = {cod_ter}");
            DataSet conMes = con.crearConexion($"SELECT MONTH(fecha_para_calculo) as mes FROM BD$ WHERE COD_TER = {cod_ter}");
            DataSet conDia = con.crearConexion($"SELECT DAY(fecha_para_calculo) as dia FROM BD$ WHERE COD_TER = {cod_ter}");

            int anio = Convert.ToInt32(conAnio.Tables[0].Rows[0]["year"]);
            int mes = Convert.ToInt32(conMes.Tables[0].Rows[0]["mes"]);
            int dia = Convert.ToInt32(conDia.Tables[0].Rows[0]["dia"]);

            return (anio, mes, dia);
        }

        public void anio2006()
        {
            conexionbd con = new conexionbd();
            con.conexionAltTabla(agregarColumna("2006"));

            DataSet res = con.crearConexion("SELECT COD_TER FROM BD$ where liquidacion_2006 iS NULL;");
            foreach (DataRow i in res.Tables[0].Rows)
            {
                int cod_ter = Convert.ToInt32(i["COD_TER"]);
                var r = retAnioMesDia(cod_ter);

                double calculo = 0;
                if (r.anio <= 2006)
                {
                    int valorFijo = 1000000;
                    int difAño = 2006 - r.anio;
                    int difMes = 12 - r.mes;
                    int difDia = 31 - r.dia;

                    calculo = (difAño * valorFijo) + ((difMes * valorFijo) / 12) + (((difDia * valorFijo) / 12) / 30);
                }
                string updateCon = $"UPDATE BD$ SET liquidacion_2006={calculo}  WHERE COD_TER = {cod_ter};";
                con.conexionAltTabla(updateCon);
                //string mensaje = "xd " + resptaaa;
                //MessageBox.Show(mensaje);
            }

        }

        public void anio2007()
        {
            conexionbd con = new conexionbd();
            con.conexionAltTabla(agregarColumna("2007"));

            DataSet res = con.crearConexion("SELECT COD_TER FROM BD$ where liquidacion_2007 iS NULL;");
            foreach (DataRow i in res.Tables[0].Rows)
            {
                int cod_ter = Convert.ToInt32(i["COD_TER"]);

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
                string updateCon = $"UPDATE BD$ SET liquidacion_2007={calculo}  WHERE COD_TER = {cod_ter};";
                con.conexionAltTabla(updateCon);
            }
        }
        public void anio2008()
        {
            conexionbd con = new conexionbd();
            con.conexionAltTabla(agregarColumna("2008"));

            DataSet res = con.crearConexion("SELECT COD_TER FROM BD$ where liquidacion_2008 iS NULL;");
            foreach (DataRow i in res.Tables[0].Rows)
            {
                int cod_ter = Convert.ToInt32(i["COD_TER"]);

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
                string updateCon = $"UPDATE BD$ SET liquidacion_2008={calculo}  WHERE COD_TER = {cod_ter};";
                con.conexionAltTabla(updateCon);
            }
        }
        public void anio2009()
        {
            conexionbd con = new conexionbd();
            con.conexionAltTabla(agregarColumna("2009"));

            DataSet res = con.crearConexion("SELECT COD_TER FROM BD$ where liquidacion_2009 iS NULL;");
            foreach (DataRow i in res.Tables[0].Rows)
            {
                int cod_ter = Convert.ToInt32(i["COD_TER"]);

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
                con.conexionAltTabla($"UPDATE BD$ SET liquidacion_2009={calculo}  WHERE COD_TER = {cod_ter};");
            }
        }
        public void anio2010()
        {
            conexionbd con = new conexionbd();
            con.conexionAltTabla(agregarColumna("2010"));

            DataSet res = con.crearConexion("SELECT COD_TER FROM BD$ where liquidacion_2010 iS NULL;");
            foreach (DataRow i in res.Tables[0].Rows)
            {
                int cod_ter = Convert.ToInt32(i["COD_TER"]);

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
                con.conexionAltTabla($"UPDATE BD$ SET liquidacion_2010={calculo}  WHERE COD_TER = {cod_ter};");
            }
        }
        public void anio2011()
        {
            conexionbd con = new conexionbd();
            con.conexionAltTabla(agregarColumna("2011"));

            DataSet res = con.crearConexion("SELECT COD_TER FROM BD$ where liquidacion_2011 iS NULL;");
            foreach (DataRow i in res.Tables[0].Rows)
            {
                int cod_ter = Convert.ToInt32(i["COD_TER"]);

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
                con.conexionAltTabla($"UPDATE BD$ SET liquidacion_2011={calculo}  WHERE COD_TER = {cod_ter};");
            }
        }
        public void anio2012()
        {
            conexionbd con = new conexionbd();
            con.conexionAltTabla(agregarColumna("2012"));

            DataSet res = con.crearConexion("SELECT COD_TER FROM BD$ where liquidacion_2012 iS NULL;");
            foreach (DataRow i in res.Tables[0].Rows)
            {
                int cod_ter = Convert.ToInt32(i["COD_TER"]);

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
                con.conexionAltTabla($"UPDATE BD$ SET liquidacion_2012={calculo}  WHERE COD_TER = {cod_ter};");
            }
        }
        public void anio2013()
        {
            conexionbd con = new conexionbd();
            con.conexionAltTabla(agregarColumna("2013"));

            DataSet res = con.crearConexion("SELECT COD_TER FROM BD$ where liquidacion_2013 iS NULL;");
            foreach (DataRow i in res.Tables[0].Rows)
            {
                int cod_ter = Convert.ToInt32(i["COD_TER"]);

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
                con.conexionAltTabla($"UPDATE BD$ SET liquidacion_2013={calculo}  WHERE COD_TER = {cod_ter};");
            }
        }
        public void anio2014()
        {
            conexionbd con = new conexionbd();
            con.conexionAltTabla(agregarColumna("2014"));

            DataSet res = con.crearConexion("SELECT COD_TER FROM BD$ where liquidacion_2014 iS NULL;");
            foreach (DataRow i in res.Tables[0].Rows)
            {
                int cod_ter = Convert.ToInt32(i["COD_TER"]);

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
                con.conexionAltTabla($"UPDATE BD$ SET liquidacion_2014={calculo}  WHERE COD_TER = {cod_ter};");
            }
        }
        public void anio2015()
        {
            conexionbd con = new conexionbd();
            con.conexionAltTabla(agregarColumna("2015"));

            DataSet res = con.crearConexion("SELECT COD_TER FROM BD$ where liquidacion_2015 iS NULL;");
            foreach (DataRow i in res.Tables[0].Rows)
            {
                int cod_ter = Convert.ToInt32(i["COD_TER"]);

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
                con.conexionAltTabla($"UPDATE BD$ SET liquidacion_2015={calculo}  WHERE COD_TER = {cod_ter};");
            }
        }
        public void anio2016()
        {
            conexionbd con = new conexionbd();
            con.conexionAltTabla(agregarColumna("2016"));

            DataSet res = con.crearConexion("SELECT COD_TER FROM BD$ where liquidacion_2016 iS NULL;");
            foreach (DataRow i in res.Tables[0].Rows)
            {
                int cod_ter = Convert.ToInt32(i["COD_TER"]);

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
                con.conexionAltTabla($"UPDATE BD$ SET liquidacion_2016={calculo}  WHERE COD_TER = {cod_ter};");
            }
        }

        //PLUS
        double divAnioDias = 365.0 / 12.0;
        public int calculoPlus(int cod_ter, int anioCal, double liquidacion, int plusVal)
        {
            conexionbd con = new conexionbd();
            DataTable tabla = con.crearConexion($"select fecha_para_calculo from BD$ where COD_TER = {cod_ter};").Tables[0];
            object valorFecha = tabla.Rows[0]["fecha_para_calculo"];
            DateTime fechaInicio = Convert.ToDateTime(valorFecha);
            DateTime fechaFin = new DateTime(anioCal, 12, 31);

            TimeSpan diferencia = fechaFin.Subtract(fechaInicio);
            int diferenciaEnDias = diferencia.Days;

            int plusValor = 0;
            var r = retAnioMesDia(cod_ter);
            if (DateTime.Now.Year - r.anio > 5)
            {
                plusValor = plusVal;
            }
            double plus = (diferenciaEnDias / divAnioDias) * plusValor;

            int calculo = (int)Math.Ceiling(liquidacion) + (int)Math.Ceiling(plus);
            //MessageBox.Show($"CODTER{cod_ter}\n PLUS {plus}\n Liquidacion {liquidacion} \nSuma Calculo {calculo}");
            return calculo;
        }
        public void anio2017()
        {
            conexionbd con = new conexionbd();
            con.conexionAltTabla(agregarColumna("2017PLUS"));

            DataSet res = con.crearConexion("SELECT COD_TER FROM BD$ where liquidacion_2017PLUS iS NULL;");
            foreach (DataRow i in res.Tables[0].Rows)
            {
                int cod_ter = Convert.ToInt32(i["COD_TER"]);
                var r = retAnioMesDia(cod_ter);
                int valorFijo = 2033763;
                double calculo = 0;
                if (r.anio < 2017)
                {
                    double liquidacion = valorFijo;
                    calculo = calculoPlus(cod_ter, 2017, liquidacion, 4891);
                }
                else if (r.anio == 2017)
                {
                    int difMes = 12 - r.mes;
                    int difDia = 31 - r.dia;

                    double liquidacion = ((difMes * valorFijo) / 12) + (((difDia * valorFijo) / 12) / 30);
                    calculo = calculoPlus(cod_ter, 2017, liquidacion, 4891);
                }
                con.conexionAltTabla($"UPDATE BD$ SET liquidacion_2017PLUS={calculo} WHERE COD_TER = {cod_ter};");
            }         

        }        

        public void anio2018()
        {
            conexionbd con = new conexionbd();
            con.conexionAltTabla(agregarColumna("2018PLUS"));

            DataSet res = con.crearConexion("SELECT COD_TER FROM BD$ where liquidacion_2018PLUS iS NULL;");
            foreach (DataRow i in res.Tables[0].Rows)
            {
                int cod_ter = Convert.ToInt32(i["COD_TER"]);
                var r = retAnioMesDia(cod_ter);
                int valorFijo = 2064174;                
                double calculo = 0;
                if (r.anio < 2018)
                {
                     double liq2018 = valorFijo;
                     calculo = calculoPlus(cod_ter, 2018,liq2018, 4898);
                }
                else if (r.anio == 2018)
                {
                    int difMes = 12 - r.mes;
                    int difDia = 31 - r.dia;

                    double liq2018 = ((difMes * valorFijo) / 12) + (((difDia * valorFijo) / 12) / 30);
                    calculo = calculoPlus(cod_ter, 2018, liq2018, 4898);
                }
                
                con.conexionAltTabla($"UPDATE BD$ SET liquidacion_2018PLUS={calculo} WHERE COD_TER = {cod_ter};");
            }
        }
        public void anio2019()
        {
            conexionbd con = new conexionbd();
            con.conexionAltTabla(agregarColumna("2019PLUS"));

            DataSet res = con.crearConexion("SELECT COD_TER FROM BD$ where liquidacion_2019PLUS iS NULL;");
            foreach (DataRow i in res.Tables[0].Rows)
            {
                int cod_ter = Convert.ToInt32(i["COD_TER"]);
                var r = retAnioMesDia(cod_ter);
                int valorFijo = 2209842;
                double calculo = 0;
                if (r.anio < 2019)
                {
                    double liquidacion = valorFijo;
                    calculo = calculoPlus(cod_ter, 2019, liquidacion, 4997);
                }
                else if (r.anio == 2019)
                {
                    int difMes = 12 - r.mes;
                    int difDia = 31 - r.dia;

                    double liquidacion = ((difMes * valorFijo) / 12) + (((difDia * valorFijo) / 12) / 30);
                    calculo = calculoPlus(cod_ter, 2019, liquidacion, 4997);
                }

                con.conexionAltTabla($"UPDATE BD$ SET liquidacion_2019PLUS={calculo} WHERE COD_TER = {cod_ter};");
            }
        }
        public void anio2020()
        {
            conexionbd con = new conexionbd();
            con.conexionAltTabla(agregarColumna("2020PLUS"));

            DataSet res = con.crearConexion("SELECT COD_TER FROM BD$ where liquidacion_2020PLUS iS NULL;");
            foreach (DataRow i in res.Tables[0].Rows)
            {
                int cod_ter = Convert.ToInt32(i["COD_TER"]);
                var r = retAnioMesDia(cod_ter);
                int valorFijo = 2103661;
                double calculo = 0;
                if (r.anio < 2020)
                {
                    double liquidacion = valorFijo;
                    calculo = calculoPlus(cod_ter, 2020, liquidacion, 4601);
                }
                else if (r.anio == 2020)
                {
                    int difMes = 12 - r.mes;
                    int difDia = 31 - r.dia;

                    double liquidacion = ((difMes * valorFijo) / 12) + (((difDia * valorFijo) / 12) / 30);
                    calculo = calculoPlus(cod_ter, 2020, liquidacion, 4601);
                }

                con.conexionAltTabla($"UPDATE BD$ SET liquidacion_2020PLUS={calculo} WHERE COD_TER = {cod_ter};");
            }
        }
        public void anio2021()
        {
            conexionbd con = new conexionbd();
            con.conexionAltTabla(agregarColumna("2021PLUS"));

            DataSet res = con.crearConexion("SELECT COD_TER FROM BD$ where liquidacion_2021PLUS iS NULL;");
            foreach (DataRow i in res.Tables[0].Rows)
            {
                int cod_ter = Convert.ToInt32(i["COD_TER"]);
                var r = retAnioMesDia(cod_ter);
                int valorFijo = 2462064;
                double calculo = 0;
                if (r.anio < 2021)
                {
                    double liquidacion = valorFijo;
                    calculo = calculoPlus(cod_ter, 2021, liquidacion, 5531);
                }
                else if (r.anio == 2021)
                {
                    int difMes = 12 - r.mes;
                    int difDia = 31 - r.dia;

                    double liquidacion = ((difMes * valorFijo) / 12) + (((difDia * valorFijo) / 12) / 30);
                    calculo = calculoPlus(cod_ter, 2021, liquidacion, 5531);
                }

                con.conexionAltTabla($"UPDATE BD$ SET liquidacion_2021PLUS={calculo} WHERE COD_TER = {cod_ter};");
            }
        }
        public void anio2022()
        {
            conexionbd con = new conexionbd();
            con.conexionAltTabla(agregarColumna("2022PLUS"));

            DataSet res = con.crearConexion("SELECT COD_TER FROM BD$ where liquidacion_2022PLUS iS NULL;");
            foreach (DataRow i in res.Tables[0].Rows)
            {
                int cod_ter = Convert.ToInt32(i["COD_TER"]);
                var r = retAnioMesDia(cod_ter);
                int valorFijo = 3243572;
                double calculo = 0;
                if (r.anio < 2022)
                {
                    double liquidacion = valorFijo;
                    calculo = calculoPlus(cod_ter, 2022, liquidacion, 7209);
                }
                else if (r.anio == 2022)
                {
                    int difMes = 12 - r.mes;
                    int difDia = 31 - r.dia;

                    double liquidacion = ((difMes * valorFijo) / 12) + (((difDia * valorFijo) / 12) / 30);
                    calculo = calculoPlus(cod_ter, 2022, liquidacion, 7209);
                }

                con.conexionAltTabla($"UPDATE BD$ SET liquidacion_2022PLUS={calculo} WHERE COD_TER = {cod_ter};");
            }
        }
        public void anio2023()
        {
            conexionbd con = new conexionbd();
            con.conexionAltTabla(agregarColumna("2023PLUS"));

            DataSet res = con.crearConexion("SELECT COD_TER FROM BD$ where liquidacion_2023PLUS iS NULL;");
            foreach (DataRow i in res.Tables[0].Rows)
            {
                int cod_ter = Convert.ToInt32(i["COD_TER"]);
                var r = retAnioMesDia(cod_ter);
                int valorFijo = 3243572;
                double calculo = 0;
                if (r.anio < 2023)
                {
                    double liquidacion = valorFijo;
                    calculo = calculoPlus(cod_ter, 2023, liquidacion, 7209);
                }
                else if (r.anio == 2023)
                {
                    int difMes = 12 - r.mes;
                    int difDia = 31 - r.dia;

                    double liquidacion = ((difMes * valorFijo) / 12) + (((difDia * valorFijo) / 12) / 30);
                    calculo = calculoPlus(cod_ter, 2023, liquidacion, 7209);
                }

                con.conexionAltTabla($"UPDATE BD$ SET liquidacion_2023PLUS={calculo} WHERE COD_TER = {cod_ter};");
            }
        }
    }
}
