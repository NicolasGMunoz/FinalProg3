using Microsoft.AspNetCore.Mvc;
using UTN.Inc.Business;
using UTN.Inc.Entities;

namespace UTN.WebApplication.Controllers
{
    public class CompraController : Controller
    {
        private readonly ProductoLogica _productoLogica;

        public CompraController(ProductoLogica productoLogica)
        {
            _productoLogica = productoLogica;
        }

        public IActionResult Profile()
        {
            var newList = _productoLogica.ObtenerProductosWeb();
            return View(newList);
        }
    }
}
