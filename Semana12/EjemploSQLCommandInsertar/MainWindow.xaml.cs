using System.Configuration;
using System.Data;
using System.Windows;
using Microsoft.Data.SqlClient;

namespace EjemploSQLCommandInsertar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            string cn = ConfigurationManager.ConnectionStrings["EjemploSQLCommandInsertar.Properties.Settings.Northwind"].ConnectionString;
            try
            {
                using (SqlConnection conex = new SqlConnection(cn))
                {
                    string query = "INSERT INTO CUSTOMERS(CustomerID,CompanyName) VALUES( @Id,@Nombre)";
                    SqlCommand cmd = new SqlCommand(query, conex);
                    //cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("@Id", SqlDbType.NChar, 5).Value = txtId.Text;
                    cmd.Parameters.Add("@Nombre", SqlDbType.NVarChar, 40).Value = txtNombre.Text;
                    conex.Open();
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    if (filasAfectadas > 0)
                    {
                        MessageBox.Show("Cliente agregado");
                        this.Nuevo();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo registrar");
                    }
                }
            }catch (SqlException ex)
            {
                MessageBox.Show($"Error al insertar codigo: {ex.Number}, Descripcion: {ex.Message}");
            }catch(Exception ex)
            {
                MessageBox.Show($"Error inesperado, Descripcion: {ex.Message}");
            }
            
        }

        private void Nuevo()
        {
            txtId.Clear();
            txtNombre.Clear();
        }
    }
}