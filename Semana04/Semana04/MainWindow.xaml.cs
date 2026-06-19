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

namespace Semana04
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

        private void btnCombo_Click(object sender, RoutedEventArgs e)
        {
            ComboBox ventana = new ComboBox();
            ventana.ShowDialog();
        }

        private void btnListBox_Click(object sender, RoutedEventArgs e)
        {
            ListBox ventana = new ListBox();
            ventana.Show();
        }

        private void btnListView_Click(object sender, RoutedEventArgs e)
        {
            ListView ventana = new ListView();
            ventana.ShowDialog();
        }
    }
}