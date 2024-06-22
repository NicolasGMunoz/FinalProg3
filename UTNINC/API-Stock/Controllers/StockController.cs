using APIStock.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;



namespace APIStock.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public string datetime { get; set; }

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


            DateTime fechaHora = await ObtenerHoraAsync();

            return Ok($"Producto: {producto.Nombre} \nStock: {compras - ventas} \nFecha y Hora: {fechaHora.ToString("dddd, dd MMMM yyyy HH:mm:ss")}");
        }

        public static async Task<DateTime> ObtenerHoraAsync()
        {
            using (HttpClient cliente = new HttpClient())
            {
                string url = "http://worldtimeapi.org/api/timezone/Etc/UTC";
                HttpResponseMessage resp = await cliente.GetAsync(url);
                resp.EnsureSuccessStatusCode();
                string responseBody = await resp.Content.ReadAsStringAsync();

                StockController tr = JsonConvert.DeserializeObject<StockController>(responseBody);
                return DateTime.Parse(tr.datetime);
            }
        }

    }
}

