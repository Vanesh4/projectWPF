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
            //terceros dataTer = new terceros();
            //listaTerceros.ItemsSource = dataTer.getTerceros().Tables[0].DefaultView;
            retiros dataTer = new retiros();
            dataTer.anio2006();
            //RetirosData.ItemsSource = dataTer.anio2006().Tables[0].DefaultView;
        }
        private void TraerData(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
