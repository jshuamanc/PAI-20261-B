using System;
using System.Collections.Generic;
using System.Text;

namespace EjemploMVVM.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string nombre { get; set; } = string.Empty;
        public decimal precio { get; set; }
        public bool discontinuado { get; set; }
    }
}
