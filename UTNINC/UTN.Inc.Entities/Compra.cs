using System;
using System.Collections.Generic;

namespace UTN.Inc.Entities;

public partial class Compra
{
    public int CompraId { get; set; }

    public DateOnly? Fecha { get; set; }

    public int? ProductoId { get; set; }

    public int? Cantidad { get; set; }

    public int? UsuarioId { get; set; }

    public virtual Producto? Producto { get; set; }
}
