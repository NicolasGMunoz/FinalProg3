using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTN.Inc.Entities
{
    public class VentaDTO
    {
        public int VentaID { get; set; }
        public DateOnly? Fecha { get; set; }
        public string NombreProducto { get; set; }
        public int ProductoID { get; set; }
        public int? Cantidad { get; set; }

        public string NombreUsuario { get; set; }

        public int UsuarioID { get; set; }
    }
}
