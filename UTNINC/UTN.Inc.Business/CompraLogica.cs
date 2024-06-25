using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTN.Inc.Data.Repository;
using UTN.Inc.Entities;

namespace UTN.Inc.Business
{
    public class CompraLogica
    {
        private readonly CompraRepository _compra;

        public CompraLogica(CompraRepository compra)
        {
            _compra = compra;
        }

        public bool ComprarProducto(int id, int cantidad)
        {
            return true;
        }
    }
}
