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
            var username = TempData["username"] as string;
            var newList = _productoLogica.ObtenerProductosWeb();

            var modeloAnonimo = new {Username = username, NewList = newList  };

            return View(modeloAnonimo);

        }

        public IActionResult VentaDetail()
        {   
            var newList = _ventaLogica.ListarVentasConDatos();
            return View(newList);
        }

        [HttpPost]
        public async Task<IActionResult> CompraProducto(int productoID, int cantidad, string fechaCompra)
        {
            int pid = productoID;
            int cant = cantidad;
            int userID = Int32.Parse(TempData["userID"].ToString());
            TempData.Keep("userID");
            DateTime fecha = DateTime.Parse(fechaCompra);
            
            
                bool b = await _compraLogica.SumarStock(fecha, pid, cant, userID);
                if (b)
                {
                    ViewBag.Message = "Compra Realizada";
                    return RedirectToAction("Profile", "Compra");
                }
                else
                {
                    ViewBag.Message = "Error en la compra, intente nuevamente";
                    return RedirectToAction("Profile", "Compra");
                }    
            
        }


        [HttpPost]
        public async Task<IActionResult> VentaProducto(int productoID, int cantidad)
        {
            int pid = productoID;
            int cant = cantidad;
            int userID = Int32.Parse(TempData["userID"].ToString());
            TempData.Keep("userID");
            bool b = await _ventaLogica.RestarStock(pid, cant, userID);
            if (b)
            {
                ViewBag.Message = "Venta Realizada";
                return RedirectToAction("Profile", "Compra");
            }
            else
            {
                return View();

            }
            
        }
    }
}
