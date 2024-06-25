using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTN.Inc.Data.Repository;
using UTN.Inc.Entities;

namespace UTN.Inc.Business
{
    public class VentaLogica
    {
        private readonly VentaRepository _venta;

        public VentaLogica(VentaRepository venta)
        {
            _venta = venta;
        }
    }
}
