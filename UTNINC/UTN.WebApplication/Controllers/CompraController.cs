using Microsoft.AspNetCore.Mvc;
using UTN.Inc.Business;
using UTN.Inc.Entities;

namespace UTN.WebApplication.Controllers
{
    public class CompraController : Controller
    {
        private readonly ProductoLogica _productoLogica;
        private readonly CompraLogica _compraLogica;
        private readonly VentaLogica _ventaLogica;

        public CompraController(ProductoLogica productoLogica, CompraLogica compraLogica, VentaLogica ventaLogica)
        {
            _productoLogica = productoLogica;
            _compraLogica = compraLogica;
            _ventaLogica = ventaLogica;
        }

        public IActionResult Profile()
        {
            var newList = _productoLogica.ObtenerProductosWeb();
            return View(newList);
        }

        public IActionResult VentaDetail()
        {
            return RedirectToAction("VentaDetail", "Compra");
        }

        [HttpPost]
        public IActionResult CompraProducto(int productoID, int cantidad, int usuarioID)
        {
            int pid = productoID;
            int cant = cantidad;
            int uid = usuarioID;
            bool b = _compraLogica.ComprarProducto(pid, cant);
            //if(_compraLogica)
            return View();
        }
        
        [HttpPost]
        public IActionResult VentaProducto(int productoID, int cantidad, int usuarioID, DateTime fecha)
        {
            int pid = productoID;
            int cant = cantidad;
            int uid = usuarioID;
            //int stock = consultar en producto su stock;
            //if (stock >= cant )
            //{
            //    //generar venta
            //}
            //else
            //{
            //    //generar error
            //}

            return View();
        }
    }
}
