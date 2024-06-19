using System;
using System.Collections.Generic;

namespace UTN.Inc.Entities;

public partial class Venta
{
    public int VentaId { get; set; }

    public DateOnly? Fecha { get; set; }

    public int? ProductoId { get; set; }

    public int? Cantidad { get; set; }

    public int? UsuarioId { get; set; }

    public virtual Producto? Producto { get; set; }

    public virtual Usuario? Usuario { get; set; }
}
