using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EjemploSQLCommandInsertar
{
    /// <summary>
    /// Lógica de interacción para AgregarProducto.xaml
    /// </summary>
    public partial class AgregarProducto : Window
    {
        public AgregarProducto()
        {
            InitializeComponent();
        }

        private async void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            btnRegistrar.IsEnabled = false;
            string cadena = ConfigurationManager.ConnectionStrings["EjemploSQLCommandInsertar.Properties.Settings.Northwind"].ConnectionString;
            try
            {
                using(SqlConnection conn = new SqlConnection(cadena))
                {
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "SP_AgregarProducto";
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add("@Nombre", System.Data.SqlDbType.NVarChar, 40).Value = txtNombre.Text;
                        cmd.Parameters.Add("@Precio", System.Data.SqlDbType.Money).Value = txtPrecio.Text;
                        cmd.CommandTimeout = 60;
                        await cmd.ExecuteNonQueryAsync();

                        MessageBox.Show("Producto agregado");
                        Limpiar();
                    }
                }
            }catch(SqlException ex)
            {
                MessageBox.Show($"Error SQL {ex.Number}, {ex.Message}");
            }
            btnRegistrar.IsEnabled = true;
        }

        private void Limpiar()
        {
            txtNombre.Clear();
            txtPrecio.Clear();
            txtNombre.Focus();
        }

        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }
    }
}
