using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UTN.WebApplication.Models;
using UTN.Inc.Business;


namespace UTN.WebApplication.Controllers
{
    public class CompraController : Controller
    {
        private readonly ILogger<CompraController> _logger;
        

        public CompraController(ILogger<CompraController> logger)
        {
           
            _logger = logger;
        }

        public IActionResult Index()
        {

            
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
