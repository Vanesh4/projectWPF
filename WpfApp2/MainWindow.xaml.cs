using Microsoft.Win32;
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
            //terceros dataTer = new terceros();
            //listaTerceros.ItemsSource = dataTer.getTerceros().Tables[0].DefaultView;

            retiros dataTer = new retiros();

            dataTer.anio2020();
            dataTer.anio2021();
            dataTer.anio2022();
            RetirosData.ItemsSource = dataTer.getRetiros().Tables[0].DefaultView;

            dataPager.Source = (System.Collections.IEnumerable)RetirosData.ItemsSource;
        }

        private void EnviarData(object sender, RoutedEventArgs e)
        {

            if (txtCodter.Text == "")
            {
                msjEnvioDatos.Content = "llene todos los campos";
            }
            else
            {
                DateTime fechaCal = inputFecha.SelectedDate ?? DateTime.Today;
                int intCodTer = int.Parse(txtCodter.Text);
                retiros objRet = new retiros(intCodTer, fechaCal.ToString("yyyy-MM-dd"));
                msjEnvioDatos.Content = objRet.postTblRetiros();
                RetirosData.ItemsSource = objRet.getRetiros().Tables[0].DefaultView;
            }
        }

        //VALIDACION DE INPUT NUMERICO
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

        private void ButtonAdv_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog guardarArchivo = new SaveFileDialog();
            guardarArchivo.FileName = "Auxilio Retiro al pastor" + ".pdf";
            guardarArchivo.ShowDialog();
        } 
    }
}
   


