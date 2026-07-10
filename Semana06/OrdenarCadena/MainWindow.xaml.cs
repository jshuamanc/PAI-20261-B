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

namespace OrdenarCadena
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string[] listaNombres;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnDividir_Click(object sender, RoutedEventArgs e)
        {
            string nombres = txtListaNombres.Text;
            if( string.IsNullOrEmpty(nombres) )
            {
                MessageBox.Show("Ingrese la cadena de nombres",
                    "Validación",MessageBoxButton.OK, MessageBoxImage.Error );
                return;
            }

            listaNombres = nombres.Split(' ');
            lbNombres.Items.Clear();
            foreach ( string nombre in listaNombres )
            {
                lbNombres.Items.Add( nombre );
            }

            txtTotalNombres.Text = lbNombres.Items.Count.ToString();
        }

        private void btnFiltrar_Click(object sender, RoutedEventArgs e)
        {
            string filtro = txtFiltrar.Text;
            if(string.IsNullOrWhiteSpace(filtro) )
            {
                MessageBox.Show("Ingrese letra a filtrar","Validación!",MessageBoxButton.OK,MessageBoxImage.Error);
                return;
            }
            lbNombresFiltrados.Items.Clear();
            foreach (string nombre in listaNombres )
            {
                if (nombre.StartsWith(filtro,StringComparison.OrdinalIgnoreCase))
                {
                    lbNombresFiltrados.Items.Add( nombre );
                }
            }

            txtTotalFiltrados.Text = lbNombresFiltrados.Items.Count.ToString();
        }
    }
}