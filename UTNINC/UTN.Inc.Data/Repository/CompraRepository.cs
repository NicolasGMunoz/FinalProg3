
using Microsoft.EntityFrameworkCore;
using UTN.Inc.Data.DBContext;
using UTN.Inc.Entities;

namespace UTN.Inc.Data.Repository
{
    public class CompraRepository
    {
        private readonly UtnincContext _compraRepo;

        public CompraRepository(UtnincContext context)
        {
            _compraRepo = context;
        }


        //MODIFICAR STOCK

        public void ModificarStock(Compra compra)
        {
            _compraRepo.Compras.Add(compra);
            _compraRepo.SaveChanges();
        }

        //CHEQUEAR STOCK
        public async Task<int> ChequearStock(int productoID)
        {


            var compras = await _compraRepo.Compras
                .Where(c => c.ProductoId == productoID)
                .SumAsync(c => c.Cantidad);



            return ((int)compras);

        }
    }
}