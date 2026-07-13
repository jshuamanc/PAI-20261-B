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
using System.Windows.Threading;

namespace Tragamonedas
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer timerReloj;
        private DispatcherTimer timerJuego;
        private Random random = new Random();

        private const int TIEMPO_TOTAL_TICKS = 60;
        private int contadorTicks = 0;

        public MainWindow()
        {
            InitializeComponent();

            
        }

        private void btnIniciarJuego_Click(object sender, RoutedEventArgs e)
        {
            timerJuego.Start();
            contadorTicks = 0;
            lbResultado.Visibility = Visibility.Hidden;
            btnIniciarJuego.IsEnabled = false;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            timerReloj = new DispatcherTimer();
            timerReloj.Interval = TimeSpan.FromMilliseconds(1);
            timerReloj.Tick += TimerReloj_Tick;
            timerReloj.Start();

            timerJuego = new DispatcherTimer();
            timerJuego.Interval = TimeSpan.FromMilliseconds(100);
            timerJuego.Tick += TimerJuego_Tick;
        }

        private void TimerJuego_Tick(object sender, EventArgs e)
        {
            int n1 = random.Next(10,30);
            int n2 = random.Next(10,30);
            int n3 = random.Next(10, 30);

            txtJugada1.Text = n1.ToString();
            txtJugada2.Text = n2.ToString();
            txtJugada3.Text = n3.ToString();

            contadorTicks++;

            if (contadorTicks >= TIEMPO_TOTAL_TICKS)
            {
                timerJuego.Stop();
                Validar_Jugada(n1,n2,n3);
            }

        }

        private void TimerReloj_Tick(object sender, EventArgs e)
        {
            lbReloj.Content = DateTime.Now.ToString("HH:mm:ss");
        }

        private void Validar_Jugada(int n1, int n2, int n3)
        {
            if(n1==n2 && n2==n3)
            {
                lbResultado.Content = "¡Ganaste!";
                lbResultado.Background = Brushes.Green;
            }
            else
            {
                lbResultado.Content = "¡Perdiste!";
                lbResultado.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF86DBE6"));
            }

            lbResultado.Visibility = Visibility.Visible;
            btnIniciarJuego.IsEnabled = true;
        }
    }
}
