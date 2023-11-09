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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp2.Models
{
    /// <summary>
    /// Lógica de interacción para vistaTerceros.xaml
    /// </summary>
    public partial class vistaTerceros : Window
    {
        public vistaTerceros()
        {
            InitializeComponent();
            //inputFecha.DisplayDateEnd = DateTime.Today;

            //terceros dataTer = new terceros();
            //listaTerceros.ItemsSource = dataTer.getTerceros().Tables[0].DefaultView;

            retiros dataTer = new retiros();
            dataTer.anio2006();
            RetirosData.ItemsSource = dataTer.getRetiros().Tables[0].DefaultView;
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
                retiros objRet = new retiros(intCodTer, fechaCal);
                msjEnvioDatos.Content = objRet.postTblRetiros();
            }

            //retiros dataTer = new retiros();
            //dataTer.postTblRetiros();
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
    }
}
