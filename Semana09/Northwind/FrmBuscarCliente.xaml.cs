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
using Microsoft.Data.SqlClient;

namespace Northwind
{
    /// <summary>
    /// Lógica de interacción para FrmBuscarCliente.xaml
    /// </summary>
    public partial class FrmBuscarCliente : Window
    {

        string cadenaConexion = "Server=.;Database=Northwind;Integrated Security=True;TrustServerCertificate=True;Encrypt=True";
        public FrmBuscarCliente()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string query = "SELECT DISTINCT COUNTRY FROM CUSTOMERS ORDER BY COUNTRY";

            using(SqlConnection con = new SqlConnection(cadenaConexion))
            {
                try
                {
                    con.Open();
                    SqlCommand command = new SqlCommand(query, con);
                    using (SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        cbxPais.Items.Clear();
                        while (reader.Read())
                        {
                            cbxPais.Items.Add(reader.GetString(0));
                        }
                    }
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }
;        }

        private void cbxPais_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbxPais.SelectedItem == null) return;
            string pais = cbxPais.SelectedItem.ToString();

            string query = "SELECT CustomerID,CompanyName,ContactName,Country FROM CUSTOMERS WHERE COUNTRY=@Country";

            using (SqlConnection con = new SqlConnection(cadenaConexion))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Country", pais);

                    SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                    List<Cliente> lstClientes = new List<Cliente>();
                    while (reader.Read())
                    {
                        lstClientes.Add(new Cliente
                        {
                            CustomerID = reader.GetString(0),
                            CompanyName = reader.GetString(1),
                            ContactName = reader.GetString(2),
                            Country = reader.GetString(3)
                        });
                    }

                    lvClientes.ItemsSource = lstClientes;


                }
                catch(Exception ex)
                {
                    MessageBox.Show($"Error al cargar los clientes: {ex.Message}");
                }
            }
        }
    }
}
