using EjemploMVVM.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace EjemploMVVM.Repositories
{
    public class ProductoRepositoryImpl : IProductoRepository
    {
        string cn = "Server=.;Database=Northwind;Integrated Security=True;TrustServerCertificate=True";
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
