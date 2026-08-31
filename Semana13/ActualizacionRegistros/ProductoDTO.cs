using System;
using System.Collections.Generic;
using System.Text;

namespace ActualizacionRegistros
{
    public class ProductoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public Decimal? Precio { get; set; }
        public int? Stock { get; set; }
    }
}
