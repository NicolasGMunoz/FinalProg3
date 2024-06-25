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
            int? userID = TempData["userID"] as int?;
            var username = TempData["username"] as string;
            var newList = _productoLogica.ObtenerProductosWeb();

            var modeloAnonimo = new { UserID = userID, Username = username, NewList = newList  };

            return View(modeloAnonimo);

        }

        public IActionResult VentaDetail()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CompraProducto(int productoID, int cantidad, int usuarioID, string fechaCompra)
        {
            int pid = productoID;
            int cant = cantidad;
            int? uid = TempData["userID"] as int?;
            TempData.Keep("userID");
            DateTime fecha = DateTime.Parse(fechaCompra);
            bool b = await _compraLogica.SumarStock(fecha, pid, cant, usuarioID);
            if (b)
            {
                ViewBag.Message = "Compra Realizada";
                return RedirectToAction("Profile", "Compra");
            }
            else
            {
                ViewBag.Message = "Error en la compra, intente nuevamente";
                return View();
            }
            
        }


        [HttpPost]
        public IActionResult VentaProducto(int productoID, int cantidad, int usuarioID, string fechaVenta)
        {
            int pid = productoID;
            int cant = cantidad;
            int uid = usuarioID;
            string fecha = fechaVenta;
            TempData.Keep();
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
