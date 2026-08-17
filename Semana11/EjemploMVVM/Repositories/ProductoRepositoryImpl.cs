using EjemploMVVM.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EjemploMVVM.Repositories
{
    public class ProductoRepositoryImpl : IProductoRepository
    {
        string cn;
        public ProductoRepositoryImpl()
        {
            cn = ConfigurationManager.ConnectionStrings["EjemploMVVM.Properties.Settings.NorthwindDB"].ConnectionString;
        }

        public List<Producto> BuscarPorNombre(string nombre)
        {
            string query = "SELECT ProductID,ProductName,UnitPrice,Discontinued FROM Products WHERE (@Nombre IS NULL OR ProductName LIKE @Nombre)";
            List<Producto> listaProductos = new List<Producto>();
            using (SqlConnection conex = new SqlConnection(cn))
            {
                conex.Open();
                string? nombreParametro = string.IsNullOrEmpty(nombre)?null:"%" + nombre + "%";
                SqlCommand sqlCommand = new SqlCommand(query, conex);
                sqlCommand.Parameters.Add("@Nombre",SqlDbType.NVarChar,40).Value = nombreParametro;
                SqlDataReader reader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    Producto producto = new Producto
                    {
                        Id = reader.GetInt32(0),
                        nombre = reader.GetString(1),
                        precio = reader.GetDecimal(2),
                        discontinuado = reader.GetBoolean(3)
                    };
                    listaProductos.Add(producto);
                }
                return listaProductos;

            }
        }

        public List<Producto> ListarTodos()
        {
            string query = "SELECT ProductID,ProductName,UnitPrice,Discontinued FROM Products";
            List<Producto> listaProductos = new List<Producto>();
            using (SqlConnection conex = new SqlConnection(cn))
            {
                conex.Open();
                SqlCommand sqlCommand = new SqlCommand(query, conex);
                SqlDataReader reader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while(reader.Read())
                {
                    Producto producto = new Producto
                    {
                        Id = reader.GetInt32(0),
                        nombre = reader.GetString(1),
                        precio = reader.GetDecimal(2),
                        discontinuado = reader.GetBoolean(3)
                    };
                    listaProductos.Add(producto);
                }
                return listaProductos;
            }
        }
    }
}
