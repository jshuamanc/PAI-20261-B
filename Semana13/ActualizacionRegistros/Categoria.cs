using System;
using System.Collections.Generic;
using System.Text;

namespace ActualizacionRegistros
{
    internal class Categoria
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string? Descripcion { get; set; } = string.Empty;
    }
}
