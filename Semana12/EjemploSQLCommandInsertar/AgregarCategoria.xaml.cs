using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EjemploSQLCommandInsertar
{
    /// <summary>
    /// Lógica de interacción para AgregarCategoria.xaml
    /// </summary>
    public partial class AgregarCategoria : Window
    {
        public AgregarCategoria()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            string cn = ConfigurationManager.ConnectionStrings["EjemploSQLCommandInsertar.Properties.Settings.Northwind"].ConnectionString;
            try
            {
                using(SqlConnection conex = new SqlConnection(cn))
                {
                    SqlCommand cmd = conex.CreateCommand();
                    cmd.CommandText = "INSERT INTO categories(CategoryName, Description) values(@Nombre,@Descripcion); select SCOPE_IDENTITY();";
                    cmd.Parameters.Add("@Nombre", System.Data.SqlDbType.NVarChar, 15).Value = txtNombre.Text;
                    cmd.Parameters.Add("@Descripcion", System.Data.SqlDbType.NVarChar, 200).Value = txtDescripcion.Text;
                    conex.Open();
                    int idGenerado = Convert.ToInt32(cmd.ExecuteScalar());

                    MessageBox.Show($"Categia agregada con id {idGenerado}");
                }
            }catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar categoria {ex.Message}");
            }
        }
    }
}
