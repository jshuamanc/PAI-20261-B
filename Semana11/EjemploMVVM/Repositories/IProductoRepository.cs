using EjemploMVVM.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EjemploMVVM.Repositories
{
    public interface IProductoRepository
    {
        public List<Producto> ListarTodos();
        public List<Producto> BuscarPorNombre(string nombre);
    }
}
