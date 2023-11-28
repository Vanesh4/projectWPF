using System;
using System.Data;
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
                else if (r.anio == 2007)
                {

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
        public (int calculo, double plus) calculoPlus(int cod_ter, DateTime fechaFin, double liquidacion, int plusVal)
        {
            conexionbd con = new conexionbd();
            DataTable tabla = con.crearConexion($"select fecha_para_calculo from BD$ where COD_TER = {cod_ter};").Tables[0];
            DateTime fechaInicio = Convert.ToDateTime(tabla.Rows[0]["fecha_para_calculo"]);

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

            //MessageBox.Show($"calculoPlussssssssss: CODTER{cod_ter}\n PLUS {plus}\n Liquidacion {liquidacion} \nSuma Calculo {calculo}");
            return (calculo, plus);
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
                    calculo = calculoPlus(cod_ter, new DateTime(2017, 12, 31), liquidacion, 4891).calculo;
                }
                else if (r.anio == 2017)
                {
                    int difMes = 12 - r.mes;
                    int difDia = 31 - r.dia;

                    double liquidacion = ((difMes * valorFijo) / 12) + (((difDia * valorFijo) / 12) / 30);
                    calculo = calculoPlus(cod_ter, new DateTime(2017, 12, 31), liquidacion, 4891).calculo;
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
                    calculo = calculoPlus(cod_ter, new DateTime(2018, 12, 31), liq2018, 4898).calculo;
                }
                else if (r.anio == 2018)
                {
                    int difMes = 12 - r.mes;
                    int difDia = 31 - r.dia;

                    double liq2018 = ((difMes * valorFijo) / 12) + (((difDia * valorFijo) / 12) / 30);
                    calculo = calculoPlus(cod_ter, new DateTime(2018, 12, 31), liq2018, 4898).calculo;
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
                    calculo = calculoPlus(cod_ter, new DateTime(2019, 12, 31), liquidacion, 4997).calculo;
                }
                else if (r.anio == 2019)
                {
                    int difMes = 12 - r.mes;
                    int difDia = 31 - r.dia;

                    double liquidacion = ((difMes * valorFijo) / 12) + (((difDia * valorFijo) / 12) / 30);
                    calculo = calculoPlus(cod_ter, new DateTime(2019, 12, 31), liquidacion, 4997).calculo;
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
                    calculo = calculoPlus(cod_ter, new DateTime(2020, 12, 31), liquidacion, 4601).calculo;
                }
                else if (r.anio == 2020)
                {
                    int difMes = 12 - r.mes;
                    int difDia = 31 - r.dia;

                    double liquidacion = ((difMes * valorFijo) / 12) + (((difDia * valorFijo) / 12) / 30);
                    calculo = calculoPlus(cod_ter, new DateTime(2020, 12, 31), liquidacion, 4601).calculo;
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
                    calculo = calculoPlus(cod_ter, new DateTime(2021, 12, 31), liquidacion, 5531).calculo;
                }
                else if (r.anio == 2021)
                {
                    int difMes = 12 - r.mes;
                    int difDia = 31 - r.dia;

                    double liquidacion = ((difMes * valorFijo) / 12) + (((difDia * valorFijo) / 12) / 30);
                    calculo = calculoPlus(cod_ter, new DateTime(2021, 12, 31), liquidacion, 5531).calculo;
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
                    calculo = calculoPlus(cod_ter, new DateTime(2022, 12, 31), liquidacion, 7209).calculo;
                }
                else if (r.anio == 2022)
                {
                    int difMes = 12 - r.mes;
                    int difDia = 31 - r.dia;

                    double liquidacion = ((difMes * valorFijo) / 12) + (((difDia * valorFijo) / 12) / 30);
                    calculo = calculoPlus(cod_ter, new DateTime(2022, 12, 31), liquidacion, 7209).calculo;
                }

                con.conexionAltTabla($"UPDATE BD$ SET liquidacion_2022PLUS={calculo} WHERE COD_TER = {cod_ter};");
            }
        }

        public void anio2023()
        {
            conexionbd con = new conexionbd();
            //con.conexionAltTabla(agregarColumna("2023PLUS"));

            //DataSet res = con.crearConexion("SELECT COD_TER FROM BD$ where liquidacion_2023PLUS iS NULL;");
            DataSet res = con.crearConexion("SELECT COD_TER FROM BD$ where fecha_para_calculo = '2010-12-31';");
            foreach (DataRow i in res.Tables[0].Rows)
            {
                int cod_ter = Convert.ToInt32(i["COD_TER"]);
                var r = retAnioMesDia(cod_ter);
                double valorFijo = 3243572.0;
                double calculo = 0;
                double liquidacion = 0;
                if (DateTime.Now.Year == 2023)
                {
                    int difMes = DateTime.Now.Month - 1;
                    int difDia = DateTime.Now.Day;

                    liquidacion = ((difMes * valorFijo) / 12) + ((difDia * valorFijo) / 12) / 30;

                    double cal1 = calculoPlus(cod_ter, DateTime.Now, (int)Math.Ceiling(liquidacion), 7209).plus / 365.0;
                    MessageBox.Show($"calculo {calculoPlus(cod_ter, DateTime.Now, (int)Math.Ceiling(liquidacion), 7209).plus}");
                    MessageBox.Show($"/365\n{calculoPlus(cod_ter, DateTime.Now, (int)Math.Ceiling(liquidacion), 7209).plus / 365}");

                    double cal2 = DateTime.Now.Month * 30.0 + DateTime.Now.Day;
                    double plus = cal1 * cal2;
                    calculo = (int)Math.Ceiling(liquidacion) + plus;
                    MessageBox.Show($"cal1{cal1}\ncal2{cal2}\nplus{plus}");
                }
                else if (r.anio < 2023)
                {
                    liquidacion = valorFijo;
                    //calculo = calculoPlus(cod_ter, 2023, liquidacion, 7209);
                }
                else if (r.anio == 2023)
                {
                    int difMes = 12 - r.mes;
                    int difDia = 31 - r.dia;

                    liquidacion = ((difMes * valorFijo) / 12) + (((difDia * valorFijo) / 12) / 30);
                    calculo = calculoPlus(cod_ter, new DateTime(2023, 12, 31), liquidacion, 7209).calculo;
                }
                //MessageBox.Show($"cod_ter:{cod_ter}\nliquidacion:{(int)Math.Ceiling(liquidacion)}\nCALCULOOOOOOO:{calculo}");
                //con.conexionAltTabla($"UPDATE BD$ SET liquidacion_2023PLUS={calculo} WHERE COD_TER = {cod_ter};");
            }
        }
    }
}
