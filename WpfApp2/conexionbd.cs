using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
//using MySql.Data.MySqlClient;


namespace WpfApp2
{
    internal class conexionbd
    {
        private string conexion = "Data Source=192.168.10.8,1433; Initial Catalog=app;Persist Security Info=True; User Id=Corpen01SQL; Password=Prueba*123";
        //private string conexion = "server=192.168.10.13;port=3306;user=Gordillov;password=Hola2020*;database=app";
        public DataSet crearConexion(String consulta)
        {            
            DataSet ds = new DataSet();
            SqlConnection con1 = new SqlConnection(conexion);
            //MySqlConnection con1 = new MySqlConnection(conexion);

            try
            {
                con1.Open(); 
                SqlCommand cmd = new SqlCommand(consulta, con1);
                //MySqlCommand cmd = new MySqlCommand(consulta, con1);
                
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                //MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.SelectCommand.CommandTimeout = 0;
                da.Fill(ds);                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);                
            }
            finally
            {
                con1.Close();
            }

            return ds;
        }

        public int conexionAltTabla(String consulta)
        {
            //MySqlConnection con1 = new MySqlConnection(conexion);
            SqlConnection con1 = new SqlConnection(conexion);
            int filasAfectadas = 0;
            try
            {
                con1.Open(); 
                SqlCommand cmd = new SqlCommand(consulta, con1);
                //MySqlCommand cmd = new MySqlCommand(consulta, con1);

                SqlDataAdapter da = new SqlDataAdapter(cmd);  
                
                //MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.SelectCommand.CommandTimeout = 0;
                
                filasAfectadas = cmd.ExecuteNonQuery();
                //string mensaje = "El valor del número es: " + filasAfectadas;
                //MessageBox.Show(mensaje);
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                con1.Close();
            }
            return filasAfectadas;
        }
    }
}
