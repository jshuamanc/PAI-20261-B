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

namespace Semana04
{
    /// <summary>
    /// Lógica de interacción para ListView.xaml
    /// </summary>
    public partial class ListView : Window
    {
        List<Alumno> alumnos = new List<Alumno>();
        public ListView()
        {
            InitializeComponent();

            alumnos.Add(new Alumno("Juan","Perez",30));
            alumnos.Add(new Alumno("Carlos","Diaz",40));
            alumnos.Add(new Alumno("Pedro","Aguilar",40));

            lvAlumnos.ItemsSource = alumnos;

        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            string nombre = txtNombres.Text;
            string apellidos = txtApellidos.Text;
            int edad = Int32.Parse(txtEdad.Text);

            Alumno nuevo = new Alumno(nombre, apellidos, edad);

            alumnos.Add(nuevo);

            lvAlumnos.ItemsSource = null;
            lvAlumnos.ItemsSource = alumnos;

            txtNombres.Text = "";
            txtApellidos.Text = "";
            txtEdad.Text = "";
        }

        private void btn_Seleccionado_Click(object sender, RoutedEventArgs e)
        {
            Alumno seleccionado = (Alumno)lvAlumnos.SelectedItem;
            MessageBox.Show($"Alumno seleccionado: {seleccionado.Nombre} {seleccionado.Apellidos} {seleccionado.Edad} años");
        }
    }
}
