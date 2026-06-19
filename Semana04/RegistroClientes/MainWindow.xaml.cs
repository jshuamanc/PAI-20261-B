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

namespace RegistroClientes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Cliente> clientes = new List<Cliente>();
        public MainWindow()
        {
            InitializeComponent();

            lvClientes.ItemsSource = clientes;
            
        }

        private void btnGrabar_Click(object sender, RoutedEventArgs e)
        {
            string nombres = txtNombres.Text;
            string apellidos = txtApellidos.Text;
            string dni = txtDNI.Text;
            string direccion = txtDireccion.Text;

            ComboBoxItem seleccionado = (ComboBoxItem)cbxEstadoCivil.SelectedItem;
            string estadoCivil = seleccionado.Content.ToString();

            Cliente nuevo = new Cliente();
            nuevo.Apellidos = apellidos;
            nuevo.Dni = dni;
            nuevo.Nombres = nombres;
            nuevo.Direccion = direccion;
            nuevo.EstadoCivil = estadoCivil;

            clientes.Add(nuevo);

            LimpiarFormulario();

            lvClientes.ItemsSource = null;
            lvClientes.ItemsSource = clientes;

        }

        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            txtNombres.Clear();
            txtApellidos.Clear();
            txtDNI.Clear();
            txtDireccion.Clear();
            cbxEstadoCivil.SelectedIndex = -1;
        }

        private void btnEstadistica_Click(object sender, RoutedEventArgs e)
        {
            /*int solteros = 0;
            int casados = 0;

            for(int i =0; i< clientes.Count; i++) { 
                if (clientes[i].EstadoCivil == "Soltero(a)") {
                    solteros++;
                }
                if (clientes[i].EstadoCivil == "Casado(a)")
                {
                    casados++;
                }
            }*/

            int solteros = clientes.Count(c => c.EstadoCivil == "Soltero(a)");
            int casados = clientes.Count(c => c.EstadoCivil == "Casado(a)");

            txtCasados.Text = casados.ToString();
            txtSolteros.Text = solteros.ToString();
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
    
}