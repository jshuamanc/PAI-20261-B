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

namespace Semana04
{
    /// <summary>
    /// Lógica de interacción para ListBox.xaml
    /// </summary>
    public partial class ListBox : Window
    {
        public ListBox()
        {
            InitializeComponent();
        }

        private void btnMostrar_Click(object sender, RoutedEventArgs e)
        {
            if(lbxFrutas.SelectedItem == null){
                MessageBox.Show("Seleccione un elemento");
                return;
            }
            ListBoxItem itemSeleccionado = (ListBoxItem)lbxFrutas.SelectedItem;
            string valorSeleccionado = itemSeleccionado.Content.ToString();
            MessageBox.Show($"Fruta Seleccionada: {valorSeleccionado}");
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            ListBoxItem nuevoItem = new ListBoxItem();
            nuevoItem.Content = txtNuevaFruta.Text.ToUpper();

            lbxFrutas.Items.Add( nuevoItem );

            txtNuevaFruta.Text = "";
        }
    }
}
