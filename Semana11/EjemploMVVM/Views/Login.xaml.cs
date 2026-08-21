using EjemploMVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EjemploMVVM.Views
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            LoginViewModel loginVM = new LoginViewModel();
            this.DataContext = loginVM;

            loginVM.OnLoginValido = LoginValido;
            loginVM.OnLoginFallido = LoginIncorrecto;
        }

        private void LoginValido()
        {
            MainWindow ventana = new MainWindow();
            ventana.Show();
            this.Close();
        }

        private void LoginIncorrecto(string mensaje)
        {
            MessageBox.Show(mensaje);
        }
    }
}
