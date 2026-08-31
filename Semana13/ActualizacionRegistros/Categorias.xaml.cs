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
    /// Lógica de interacción para Categorias.xaml
    /// </summary>
    public partial class Categorias : Window
    {
        string cn = ConfigurationManager.ConnectionStrings["ActualizacionRegistros.Properties.Settings.Northwind"].ConnectionString;
        public Categorias()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            this.Nuevo();
        }

        private void Nuevo()
        {
            txtId.Clear();
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtNombre.Focus();
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
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
                        cmd.CommandText = "INSERT INTO Categories(CategoryName,Description) VALUES(@Nombre,@Descripcion); select SCOPE_IDENTITY();";
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.Parameters.Add("@Nombre", System.Data.SqlDbType.NVarChar, 15).Value = txtNombre.Text;
                        cmd.Parameters.Add("@Descripcion", System.Data.SqlDbType.NVarChar, -1).Value = string.IsNullOrEmpty(txtDescripcion.Text) ? (Object)DBNull.Value : txtDescripcion.Text;
                        int idGenerado = Convert.ToInt32(cmd.ExecuteScalar());

                        MessageBox.Show($"Categoria agregada con Id {idGenerado}");
                        this.Nuevo();
                        this.CargarListaCategorias();
                    }
                    else
                    {
                        cmd.CommandText = @"UPDATE categories SET CategoryName=@Nombre,
                                            Description=@Descripcion 
                                            WHERE CategoryID=@Id";
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.Parameters.Add("@Nombre", System.Data.SqlDbType.NVarChar, 15).Value = txtNombre.Text;
                        cmd.Parameters.Add("@Descripcion", System.Data.SqlDbType.NVarChar, -1).Value = string.IsNullOrEmpty(txtDescripcion.Text)?(Object)DBNull.Value:txtDescripcion.Text;
                        cmd.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;

                        cmd.ExecuteNonQuery();

                        MessageBox.Show($"Categoria actualizada");
                        this.CargarListaCategorias();
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.CargarListaCategorias();
        }

        private void CargarListaCategorias()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(cn))
                {
                    string query = "SELECT CategoryID,CategoryName,Description FROM Categories ORDER BY CategoryID";
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<Categoria> lista = new List<Categoria>();

                    while (reader.Read())
                    {
                        lista.Add(new Categoria
                        {
                            Id = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Descripcion = reader.IsDBNull("Description") ? null : reader.GetString(2)
                        });
                    }
                    dgCategorias.ItemsSource = lista;
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

        private void dgCategorias_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgCategorias.SelectedItem != null)
            {
                Categoria categoria = (Categoria)dgCategorias.SelectedItem;

                txtId.Text = categoria.Id.ToString();
                txtNombre.Text = categoria.Nombre.ToString();
                txtDescripcion.Text = categoria?.Descripcion.ToString();
            }
        }
    }
}
