﻿using System;
using System.Collections.Generic;

namespace UTN.Inc.Entities;

public partial class Categoria
{
    public int CategoriaId { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
