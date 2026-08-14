using System;
using System.Collections.Generic;
using System.Text;

namespace EjemploMVVM.Models
{
    internal class Producto
    {
        public int Id { get; set; }
        public string nombre { get; set; }
        public decimal precio { get; set; }
        public bool discontinuado { get; set; }
    }
}
