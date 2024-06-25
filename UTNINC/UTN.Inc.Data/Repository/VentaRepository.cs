using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTN.Inc.Entities;
using UTN.Inc.Data.DBContext;

namespace UTN.Inc.Data.Repository
{
    public class VentaRepository
    {
        private readonly UtnincContext _ventaRepo;

        public VentaRepository(UtnincContext ventaRepo)
        {
            _ventaRepo = ventaRepo;
        }
    }

}
