﻿using System;
using System.Collections.Generic;
using System.Data;
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
            dataTer.anio2007();
            dataTer.anio2008();
            dataTer.anio2009();
            dataTer.anio2010();
            dataTer.anio2011();
            dataTer.anio2012();
            dataTer.anio2013();
            dataTer.anio2014();
            dataTer.anio2015();
            dataTer.anio2016();

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
    }
}
