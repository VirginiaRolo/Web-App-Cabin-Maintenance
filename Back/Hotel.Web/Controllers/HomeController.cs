using Hotel.LogicaNegocio.Entidades;
using Hotel.LogicaNegocio.Interfaces;
using Hotel.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Hotel.Web.Controllers
{
    public class HomeController : Controller
    {
        #region ATRIBUTOS
        private readonly ILogger<HomeController> _logger;

        private IRepositorioUsuario repositorio;
        #endregion

        #region CONSTRUCTOR
        public HomeController(ILogger<HomeController> logger, IRepositorioUsuario repositorio)
        {
            _logger = logger;

            this.repositorio = repositorio;
        }
        #endregion


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult AccesoDenegado()
        {
            return View();
        }

        //GET
        public ActionResult Login()
        {
            return View();
        }
        //POST
        [HttpPost]
        public ActionResult Login(string email, string pass)
        {

            Usuario logueado = repositorio.Login(email, pass);

            if (logueado != null)
            {
                HttpContext.Session.SetInt32("LogueadoId", logueado.Id);
                //HttpContext.Session.SetString("token", respuesta.token);
                //HttpContext.Session.SetString("LogueadoRol", logueado.GetRol());
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.msg = "Error en los datos";
            }

            return View();
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }



        //Esto ya viene en el home controller
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}