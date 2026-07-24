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

namespace Temperaturas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TextBox[] txtMeses;
        private string[] meses = new string[] { 
            "Enero","Febrero","Marzo","Abril","Mayo",
            "Junio","Julio","Agosto","Setiembre","Octubre",
            "Noviembre","Diciembre"
        };
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCalcular_Click(object sender, RoutedEventArgs e)
        {
            double[] temperaturas = new double[12];
            double sumaTemperaturas = 0;
            lbxMesesMayores.Items.Clear();
            for(int i = 0; i < temperaturas.Length; i++)
            {
                if(double.TryParse(txtMeses[i].Text, out double temperatura))
                {
                    temperaturas[i] = temperatura;
                    sumaTemperaturas += temperatura;
                }
                else
                {
                    MessageBox.Show("Ingrese temperatura válida");
                    txtMeses[i].Focus();
                    return;
                }                
            }
            double promedio = sumaTemperaturas / 12;
            tbPromedio.Text = promedio.ToString("N2");

            int mayores = 0;

            for(int i = 0;i < temperaturas.Length;i++)
            {
                if (temperaturas[i] > promedio)
                {
                    mayores++;
                    lbxMesesMayores.Items.Add(meses[i]);
                }
            }

            txtMayores.Text = mayores.ToString();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtMeses = new TextBox[] { 
                txtEnero,txtFebrero,txtMarzo,txtAbril,
                txtMayo,txtJunio,txtJulio,txtAgosto,
                txtSetiembre,txtOctubre,txtNoviembre,txtDiciembre
            };

            Random random = new Random();
            for(int i = 0;i<txtMeses.Length; i++)
            {
                txtMeses[i].Text = (random.NextDouble() * 100).ToString("N2");
            }
        }
    }
}