
using Microsoft.AspNetCore.Mvc;
using UTN.Inc.Business;


namespace UTN.WebApplication.Controllers
{
    public class HomeController : Controller

    {
    
        private readonly UsuarioLogica _logica;

        public HomeController(UsuarioLogica logica)
        {

            _logica = logica;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Profile()
        {
            return View();
        }




        [HttpPost]

        public ActionResult Login(string username, string password)
        {
            string user = username;
            string pass = password;
            int userid = _logica.RetornarID(username);


            bool b = _logica.ValidarUsuarioWeb(user, pass);


             if (b)
             {
                TempData["userID"] = userid;
                TempData["username"] = user;
                return RedirectToAction("Profile", "Compra");
              }
               else { return RedirectToAction("Error"); }
        }

    }
}
