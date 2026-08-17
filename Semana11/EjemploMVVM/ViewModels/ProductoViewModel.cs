using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using EjemploMVVM.Commands;
using EjemploMVVM.Models;
using EjemploMVVM.Repositories;

namespace EjemploMVVM.ViewModels
{
    public class ProductoViewModel
    {
        public ObservableCollection<Producto> productos { get; set; } = new ObservableCollection<Producto>();

        public RelayCommand ComandoCargarProductos { get; set; }

        public string textoBuscar { get; set; } = string.Empty;

        private IProductoRepository _repository;

        public ProductoViewModel()
        {
            _repository = new ProductoRepositoryImpl();
            ComandoCargarProductos = new RelayCommand(BuscarProductos);

            CargarProductos();
        }

        private void BuscarProductos()
        {
            List<Producto> lista = _repository.BuscarPorNombre(textoBuscar);
            productos.Clear();
            foreach (Producto producto in lista)
            {
                productos.Add(producto);
            }
        }

        public void CargarProductos()
        {
            List<Producto> lista = _repository.ListarTodos();
            productos.Clear();
            foreach (Producto producto in lista)
            {
                productos.Add(producto);
            }
            int cantidad = productos.Count;
        }


        

    }
}
