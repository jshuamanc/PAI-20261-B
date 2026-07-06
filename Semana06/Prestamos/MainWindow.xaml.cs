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

namespace Prestamos
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

        private void btnCalcular_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCliente.Text))
            {
                MessageBox.Show("Ingrese el nombre del cliente","Cliente Invàlido",MessageBoxButton.OK,MessageBoxImage.Warning);
                return;
            }
            string cliente = txtCliente.Text;

            if(!double.TryParse(txtMontoPagar.Text, out double montoPagar) || montoPagar<=0)
            {
                MessageBox.Show("Ingrese el monto", "Monto Invàlido", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            DateTime fechaVencimiento = dpFechaVencimiento.SelectedDate.Value;
            DateTime fechaPago = dpFechaPago.SelectedDate.Value;

            int diasMora = 0;

            if(fechaPago >  fechaVencimiento)
            {
                TimeSpan diferencia = fechaPago.Subtract(fechaVencimiento);
                diasMora = (int)diferencia.TotalDays;
            }

            double moraPorcentaje = diasMora * 0.5;

            double moraSoles = montoPagar * moraPorcentaje / 100;

            double totalPagar = montoPagar + moraSoles;

            txtDias.Text = diasMora.ToString();
            txtMoraProc.Text = moraPorcentaje.ToString();
            txtMora.Text = moraSoles.ToString();
            txtMontoTotal.Text = totalPagar.ToString();
        }

        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            txtCliente.Clear();
            txtDias.Clear();
            txtMontoPagar.Clear();
            txtMontoTotal.Clear();
            txtMora.Clear();
            txtMoraProc.Clear();
            dpFechaPago.SelectedDate = null;
            dpFechaVencimiento.SelectedDate = null;
        }

        private void btnFinalizar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}