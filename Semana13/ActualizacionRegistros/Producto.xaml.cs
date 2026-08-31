using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
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

namespace ActualizacionRegistros
{
    /// <summary>
    /// Lógica de interacción para Producto.xaml
    /// </summary>
    public partial class Producto : Window
    {
        string cn = ConfigurationManager.ConnectionStrings["ActualizacionRegistros.Properties.Settings.Northwind"].ConnectionString;
        public Producto()
        {
            InitializeComponent();
        }

        private void dgProductos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgProductos.SelectedItem != null){
                ProductoDTO producto = (ProductoDTO)dgProductos.SelectedItem;
                txtId.Text = producto.Id.ToString();
                txtNombre.Text = producto.Nombre;
                txtStock.Text = producto.Stock.ToString();
            }
        }

        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            txtId.Clear();
            txtNombre.Clear();
            txtStock.Clear();
            txtStock.Focus();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CargarProductos();
        }

        private void CargarProductos()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(cn))
                {
                    string query = "SELECT ProductID,ProductName,UnitPrice,UnitsInStock FROM Products ORDER BY ProductName";
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<ProductoDTO> lista = new List<ProductoDTO>();

                    while (reader.Read())
                    {
                        lista.Add(new ProductoDTO
                        {
                            Id = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Precio = reader.IsDBNull(2) ? null : reader.GetDecimal(2),
                            Stock = reader.IsDBNull(3) ? null : reader.GetInt16(3),
                        });
                    }
                    dgProductos.ItemsSource = lista;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error en sql {ex.Number}, {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error general {ex.Message}");
            }
        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string id = txtId.Text;

                using (SqlConnection conn = new SqlConnection(cn))
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();

                    if (string.IsNullOrEmpty(id))
                    {
                        return;
                    }
                    else
                    {
                        cmd.CommandText = "sp_UpdateProductStock";
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        
                        cmd.Parameters.Add("@ProductID", System.Data.SqlDbType.Int).Value = id;
                        cmd.Parameters.Add("@UnitsInStock", System.Data.SqlDbType.SmallInt).Value = string.IsNullOrEmpty(txtStock.Text) ? (Object)DBNull.Value : txtStock.Text;
                        
                        cmd.ExecuteNonQuery();

                        MessageBox.Show($"Producto actualizado");
                        this.CargarProductos();
                    }

                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error en sql {ex.Number}, {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error general {ex.Message}");
            }
        }
    }
}
