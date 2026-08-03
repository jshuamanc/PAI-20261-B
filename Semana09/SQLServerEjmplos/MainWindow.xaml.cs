using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Data.SqlClient;

namespace SQLServerEjmplos
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string connectionString = "Server=.;Database=Northwind;Integrated Security=True;TrustServerCertificate=True;Encrypt=True";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnConectar_Click(object sender, RoutedEventArgs e)
        {
            
            using(SqlConnection con = new SqlConnection(connectionString)){
                try
                {
                    con.Open();
                    MessageBox.Show($"Conexion exitosa: {con.Database}");
                }catch(Exception ex)
                {
                    MessageBox.Show($"Error de conexion: {ex.Message}");
                }
            }
        }

        private void btnCargar_Click(object sender, RoutedEventArgs e)
        {
            string query = "Select CategoryID,CategoryName from Categories";
            using(SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();

                    using (SqlDataReader dataReader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        cbxCategorias.Items.Clear();
                        while (dataReader.Read())
                        {
                            cbxCategorias.Items.Add(
                                new
                                {
                                    Id = dataReader.GetInt32(0),
                                    Nombre = dataReader.GetString(1)
                                }
                            );
                        }
                    }
                    
                }catch( SqlException ex)
                {
                    MessageBox.Show($"Error en sql: {ex.Message}");
                }
            }
        }

        private void btnSeleccionado_Click(object sender, RoutedEventArgs e)
        {
            if (cbxCategorias.SelectedItem != null){
                dynamic categoriaSeleccionada = cbxCategorias.SelectedItem;
                int id = categoriaSeleccionada.Id;
                string nombre = categoriaSeleccionada.Nombre;

                MessageBox.Show($"Seleccionado: ID={id}, Nombre={nombre}");
            }
        }

        private void btnMostrarProductos_Click(object sender, RoutedEventArgs e)
        {
            string query = "SELECT ProductID, ProductName, UnitPrice, UnitsInStock FROM Products WHERE Discontinued = 0";
            using(SqlConnection con = new SqlConnection(connectionString))
            {
                SqlDataAdapter sqlData = new SqlDataAdapter(query, con);
                DataSet ds = new DataSet();

                sqlData.Fill(ds, "Producto");
                dgProductos.ItemsSource = ds.Tables["Producto"].DefaultView;


            }
        }
    }
}