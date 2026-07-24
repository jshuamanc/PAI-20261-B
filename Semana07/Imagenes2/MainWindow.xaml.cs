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

namespace Imagenes2
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            /*BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.UriSource = new Uri(@"C:\PA_I\Imagenes\plaza_armas.jpg");
            bitmapImage.EndInit();
            imagen1.Source = bitmapImage;*/

            imagen1.Source = new BitmapImage(new Uri(@"C:\PA_I\Imagenes\plaza_armas.jpg"));


            imagen2.Source = new BitmapImage(new Uri("pack://application:,,,/Imagenes/Google.png"));
        }
    }
}