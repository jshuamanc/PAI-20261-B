using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace TragamonedasV2
{
    public partial class MainWindow : Window
    {
        private DispatcherTimer _temporizador;
        private int _segundosTranscurridos;
        private const int SegundosMaximos = 8;
        private int _puntaje;
        private Random _random = new Random();
        private List<string> _urisImagenes = new List<string>();

        public MainWindow()
        {
            InitializeComponent();

            _temporizador = new DispatcherTimer();
            _temporizador.Interval = TimeSpan.FromSeconds(1);
            _temporizador.Tick += Temporizador_Tick;

            CargarImagenes();
            ReiniciarUI();

            StartButton.Click += IniciarButton_Click;
        }

        private void CargarImagenes()
        {
            _urisImagenes.Clear();
            for (int i = 1; i <= 6; i++)
            {
                string uri = $"pack://application:,,,/Imagenes/{i}.png";
                _urisImagenes.Add(uri);
            }
        }

        private void ReiniciarUI()
        {
            _temporizador.Stop();
            _segundosTranscurridos = 0;
            _puntaje = 0;
            TimeTextBlock.Text = TimeSpan.FromSeconds(0).ToString(@"mm\:ss");
            ScoreTextBlock.Text = _puntaje.ToString();
            StatusTextBlock.Text = string.Empty;

            if (_urisImagenes.Count >= 3)
            {
                EstablecerImagen(Image1, _urisImagenes[0]);
                EstablecerImagen(Image2, _urisImagenes[1]);
                EstablecerImagen(Image3, _urisImagenes[2]);
            }
        }

        private void IniciarButton_Click(object sender, RoutedEventArgs e)
        {
            StartButton.IsEnabled = false;
            StatusTextBlock.Text = string.Empty;
            _segundosTranscurridos = 0;
            _puntaje = 0;
            ScoreTextBlock.Text = _puntaje.ToString();
            TimeTextBlock.Text = TimeSpan.FromSeconds(0).ToString(@"mm\:ss");
            _temporizador.Start();
            Girar();
        }

        private void Temporizador_Tick(object? sender, EventArgs e)
        {
            _segundosTranscurridos++;
            TimeTextBlock.Text = TimeSpan.FromSeconds(_segundosTranscurridos).ToString(@"mm\:ss");
            Girar();

            if (_puntaje >= 60)
            {
                TerminarJuego(true);
                return;
            }

            if (_segundosTranscurridos >= SegundosMaximos)
            {
                TerminarJuego(_puntaje >= 60);
                return;
            }
        }

        private void Girar()
        {
            if (_urisImagenes == null || _urisImagenes.Count < 6)
            {
                StatusTextBlock.Text = "No hay imágenes embebidas; asegúrate de incluir 1.png..6.png como Resource en la carpeta Imagenes.";
                _temporizador.Stop();
                StartButton.IsEnabled = true;
                return;
            }

            int i1 = _random.Next(1, 7) - 1; // 0..5
            int i2 = _random.Next(1, 7) - 1;
            int i3 = _random.Next(1, 7) - 1;

            EstablecerImagen(Image1, _urisImagenes[i1]);
            EstablecerImagen(Image2, _urisImagenes[i2]);
            EstablecerImagen(Image3, _urisImagenes[i3]);

            int ganado = 0;
            if (i1 == i2 && i2 == i3)
            {
                ganado = 20;
            }
            else if (i1 == i2 || i1 == i3 || i2 == i3)
            {
                ganado = 10;
            }

            _puntaje += ganado;
            ScoreTextBlock.Text = _puntaje.ToString();
        }

        private void TerminarJuego(bool gano)
        {
            _temporizador.Stop();
            StartButton.IsEnabled = true;

            if (gano)
                StatusTextBlock.Text = "GANASTE";
            else
                StatusTextBlock.Text = $"PERDISTE, puntaje obtenido: {_puntaje}";

            var res = MessageBox.Show("¿Desea seguir jugando?", gano ? "GANASTE" : "PERDISTE", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (res == MessageBoxResult.Yes)
            {
                ReiniciarUI();
                StartButton.IsEnabled = false;
                _temporizador.Start();
                Girar();
            }
            else
            {
                StartButton.IsEnabled = true;
            }
        }

        private void EstablecerImagen(Image controlImagen, string uriString)
        {
            try
            {
                var bmp = new BitmapImage();
                bmp.BeginInit();
                bmp.CacheOption = BitmapCacheOption.OnLoad;
                bmp.UriSource = new Uri(uriString, UriKind.Absolute);
                bmp.EndInit();
                bmp.Freeze();
                controlImagen.Source = bmp;
            }
            catch
            {
                // ignorar
            }
        }
    }
}
