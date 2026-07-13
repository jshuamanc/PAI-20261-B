using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AdivinaEdad
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private int edadMinima;
        private int edadMaxima;
        private int edadPropuesta;
        private int contadorIntentos;

        private Random random = new Random();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnPrimerIntento_Click(object sender, RoutedEventArgs e)
        {
            if(!int.TryParse(txtEdadMinima.Text, out edadMinima))
            {
                MessageBox.Show("Ingrese una edad mínima válida", "Validación!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!int.TryParse(txtEdadMaxima.Text, out edadMaxima))
            {
                MessageBox.Show("Ingrese una edad máxima válida", "Validación!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if(edadMinima >= edadMaxima)
            {
                MessageBox.Show("Ingrese un rango de edades válida, edad maxima mayor que minima");
                return;
            }

            edadPropuesta = random.Next(edadMinima, edadMaxima + 1);

            contadorIntentos++;

            txtEdadPropuesta.Text = edadPropuesta.ToString();
        }

        private void btnIncorrecto_Click(object sender, RoutedEventArgs e)
        {
            if (contadorIntentos == 0){
                MessageBox.Show("Debe hacer click en el boton primer intento");
                return;
            }
            edadPropuesta = random.Next(edadMinima, edadMaxima + 1);
            contadorIntentos++;
            txtEdadPropuesta.Text = edadPropuesta.ToString();
        }

        private void btnCorrecto_Click(object sender, RoutedEventArgs e)
        {
            if (contadorIntentos == 0)
            {
                MessageBox.Show("Debe hacer click en el boton primer intento");
                return;
            }

            MessageBox.Show($"Edad correcta: {contadorIntentos} inetentos");
        }
    }
}
