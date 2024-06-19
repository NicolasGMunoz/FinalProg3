using System;
using System.Collections.Generic;

namespace UTN.Inc.Entities;

public partial class Producto
{
    public int ProductoId { get; set; }

    public string? Nombre { get; set; }

    public int? CategoriaId { get; set; }

    public bool? Habilitado { get; set; }

    public virtual Categoria Categoria { get; set; }

    public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();

    public override string ToString()
    {
        return $"{Nombre} ({ProductoId}) {Categoria}";
    }
}
