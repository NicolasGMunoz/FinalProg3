using APIStock.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UTN.Inc.Entities;


namespace APIStock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public StockController(ApiDbContext context)
        {
            _context = context;
        }

        [HttpGet("{productoId}")]
        public async Task<ActionResult<int>> GetStock(int productoId)
        {
            var producto = await _context.Producto.FindAsync(productoId);
            if (producto == null)
            {
                return NotFound();
            }

            var compras = await _context.Compra
                .Where(c => c.ProductoId == productoId)
                .SumAsync(c => c.Cantidad);

            var ventas = await _context.Venta
                .Where(v => v.ProductoId == productoId)
                .SumAsync(v => v.Cantidad);

            var stock = compras - ventas;

            return Ok(stock);
        }
    }
}