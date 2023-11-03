using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp2.Models;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            data.Visibility = Visibility.Collapsed;
            dataFiltrada.Visibility = Visibility.Collapsed;
            msjEnvioDatos.Content = " ";
        }
        private void href(object sender, RoutedEventArgs e)
        {
            vistaTerceros segundaVentana = new vistaTerceros();
            this.Close();
            segundaVentana.Show();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Puestos dataPuestos = new Puestos();
            data.Visibility = Visibility.Visible;
            data.ItemsSource = dataPuestos.getPuestos().Tables[0].DefaultView;            
        }

        private void filtrar(object sender, RoutedEventArgs e)
        {
            Puestos dataPuestos = new Puestos();
            string textoIngresado = CuadroDeTexto.Text;
            //MessageBox.Show(dataPuestos.fitrarCargo(cargo);
            
            if (dataPuestos.fitrarCargo(textoIngresado).Tables.Count == 0 || dataPuestos.fitrarCargo(textoIngresado).Tables[0].Rows.Count == 0)
            {
                dataFiltrada.Visibility = Visibility.Collapsed;
                msjError.Content = "No se encontraron resultados";
            }
            else
            {
                dataFiltrada.Visibility = Visibility.Visible;     
                dataFiltrada.ItemsSource = dataPuestos.fitrarCargo(textoIngresado).Tables[0].DefaultView;
            }            
        }

        //validar datos:
        private bool validarRegistros()
        {
            if (txtCargo.Text == "" || txtCargo.Text == " ")
            {
                return false;
            }
            else if (txtCel.Text == "" || txtCel.Text == " ")
            {
                return false;
            }
            else if (txtCorreoCoo.Text == "" || txtCorreoCoo.Text == " ")
            {
                return false;
            }
            else if (txtObservacion.Text == "" || txtObservacion.Text == " ")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private void EnviarDatos(object sender, RoutedEventArgs e)
        {
            if (validarRegistros()) {
                Puestos dataPuestos = new Puestos(txtCargo.Text, txtArea.Text, txtCel.Text, txtCorreoCoo.Text, "gmail.com", "img", txtObservacion.Text);
                msjEnvioDatos.Content = dataPuestos.postPuestos();
            }
            else
            {
                msjEnvioDatos.Content = "llene todos los campos";
            }            
        }

        private bool IsNumeric(string text)
        {
            return int.TryParse(text, out _);
        }
        private void txt_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!IsNumeric(e.Text))
            {
                e.Handled = true;
            }
        }

        
        
    }
   }


