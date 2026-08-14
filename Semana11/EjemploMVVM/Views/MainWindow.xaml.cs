using Microsoft.Data.SqlClient;
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

namespace EjemploMVVM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string cn = "Server=.;Database=Northwind;Integrated Security=True;TrustServerCertificate=True";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCargar_Click(object sender, RoutedEventArgs e)
        {
            string query = "SELECT ProductID,ProductName,UnitPrice,Discontinued FROM Products";

            using (SqlConnection conex = new SqlConnection(cn))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conex);
                DataTable dtProductos = new DataTable();

                da.Fill(dtProductos);

                dgProductos.ItemsSource = dtProductos.DefaultView;
            }
        }
    }
}