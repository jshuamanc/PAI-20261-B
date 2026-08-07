using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Northwind
{
    /// <summary>
    /// Lógica de interacción para FrmProductos.xaml
    /// </summary>
    public partial class FrmProductos : Window
    {
        string cadenaConexion = "Server=.;Database=Northwind;Integrated Security=True;TrustServerCertificate=True;Encrypt=True";
        SqlDataAdapter adapter;
        DataSet dataSet;
        public FrmProductos()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string query = "select ProductID,ProductName,UnitPrice,UnitsInStock,Discontinued from Products";

            SqlConnection con = new SqlConnection(cadenaConexion);
                adapter = new SqlDataAdapter(query, con);

                dataSet = new DataSet();

                adapter.Fill(dataSet,"Producto");

                dgProductos.ItemsSource = dataSet.Tables["Producto"].DefaultView;

            
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            int filas = adapter.Update(dataSet, "Producto");

            MessageBox.Show($"Sincronizacion completada, {filas} filas afectadas");


        }
    }
}
