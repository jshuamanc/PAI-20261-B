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

namespace Fechas
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

        private void btnFinalizar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnCalcular_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCliente.Text))
            {
                MessageBox.Show("Ingrese un cliente válido");
                return;
            }
            if(!double.TryParse(txtMonto.Text, out double deuda)|| deuda <= 0)
            {
                MessageBox.Show("Ingrese un monto válido");
                return;
            }
            if (dpVencimiento.SelectedDate == null)
            {
                MessageBox.Show("Seleccione fecha de vencimiento");
                return;
            }
            if(dpPago.SelectedDate == null)
            {
                MessageBox.Show("Seleccione fecha de pago");
                return;
            }

            DateTime fechaVencimiento = dpVencimiento.SelectedDate.Value;
            DateTime fechaPago = dpPago.SelectedDate.Value;

            int diasMora = 0;

            if (fechaPago > fechaVencimiento)
            {
                TimeSpan diferencia = fechaPago.Subtract(fechaVencimiento);

                diasMora = (int)diferencia.TotalDays;
            }
            
            txtDiasMora.Text = diasMora.ToString();

            double porcMora = diasMora * 0.5;

            txtMoraPorc.Text = porcMora.ToString();

            double monto = double.Parse(txtMonto.Text);
            double moraSoles = porcMora * monto / 100;

            txtMoraSoles.Text = moraSoles.ToString();

            double totalPagar = monto + moraSoles;

            txtMontoPagar.Text = totalPagar.ToString();

        }

        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            txtCliente.Clear();
            txtMonto.Clear();
            txtMontoPagar.Clear();
            txtMoraSoles.Clear();
            txtMoraPorc.Clear();
            txtDiasMora.Clear();

            dpVencimiento.SelectedDate = null;
            dpPago.SelectedDate = null;
        }
    }
}