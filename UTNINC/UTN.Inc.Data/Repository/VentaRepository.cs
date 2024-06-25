
using Microsoft.EntityFrameworkCore;
using UTN.Inc.Data.DBContext;
using UTN.Inc.Entities;

namespace UTN.Inc.Data.Repository
{
    public class VentaRepository
    {
        private readonly UtnincContext _ventaRepo;

        public VentaRepository(UtnincContext context)
        {
            _ventaRepo = context;
        }

        //MODIFICAR STOCK

        public void ModificarStock(Venta venta)
        {
            _ventaRepo.Venta.Add(venta);
            _ventaRepo.SaveChanges();
        }

        //CHEQUEAR STOCK
        public async Task<int> ChequearStock(int productoID)
        {


            var compras = await _ventaRepo.Compras
                .Where(c => c.ProductoId == productoID)
                .SumAsync(c => c.Cantidad);

            var ventas = await _ventaRepo.Venta
                .Where(v => v.ProductoId == productoID)
                .SumAsync(v => v.Cantidad);

            return ((int)compras - (int)ventas);

        }
        //OBTENER TODAS LAS VENTAS
        public List<Venta> ObtenerVentas()
        {
            return _ventaRepo.Venta.ToList();
        }

        //OBTENER TODAS LAS VENTAS CON NOMBRE DE PRODUCTO Y NOMBRE DE USUARIO
        public IQueryable<VentaDTO> ObtenerVentasFull()
        {
            return (from Usuario in _ventaRepo.Usuarios
                    join Venta in _ventaRepo.Venta on Usuario.UsuarioId equals Venta.UsuarioId
                    join Producto in _ventaRepo.Producto on Venta.ProductoId equals Producto.ProductoId
                    select new VentaDTO
                    {
                        VentaID = Venta.VentaId,
                        Fecha = Venta.Fecha,
                        NombreProducto = Producto.Nombre,
                        ProductoID = Producto.ProductoId,
                        Cantidad = Venta.Cantidad,
                        NombreUsuario = Usuario.Nombre,
                        UsuarioID = Usuario.UsuarioId,

                    });
        }

    }
}