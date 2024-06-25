using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTN.Inc.Entities;
using UTN.Inc.Data.DBContext;

namespace UTN.Inc.Data.Repository
{
    public class CompraRepository
    {
        private readonly UtnincContext _compraRepo;

        public CompraRepository(UtnincContext compraRepo)
        {
            _compraRepo = compraRepo;
        }
    }
}
