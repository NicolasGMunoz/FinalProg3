using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UTN.Inc.Business;
using UTN.WebApplication.Models;

namespace UTN.WebApplication.Controllers
{
    public class CompraController : Controller
    {
        private readonly ILogger<CompraController> _logger;
        private readonly ProductoLogica _productoLogica;

        public CompraController(ILogger<CompraController> logger)
        {
            _logger = logger;
            _productoLogica = new ProductoLogica();
        }

        public IActionResult Index()
        {
            _productoLogica.GetProductos;
            return View();
        }

        public IActionResult Profile()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
