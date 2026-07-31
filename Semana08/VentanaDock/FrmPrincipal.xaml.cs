using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Xceed.Wpf.AvalonDock.Layout;

namespace VentanaDock
{
    /// <summary>
    /// Lógica de interacción para FrmPrincipal.xaml
    /// </summary>
    public partial class FrmPrincipal : Window
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            abrirVentana("Clientes", new UcClientes());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            abrirVentana("Proveedores", new UcProveedores());
        }

        private void abrirVentana(string titulo, UserControl contenido)
        {
            LayoutDocument ventana = new LayoutDocument();
            ventana.Title = titulo;
            ventana.Content = contenido;
            ventana.IsActive = true;
            ldpVentanas.Children.Add(ventana);
        }
    }
}
