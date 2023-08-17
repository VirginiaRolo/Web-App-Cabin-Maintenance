using Hotel.LogicaNegocio.Entidades;
using Hotel.LogicaNegocio.Excepciones;
using Hotel.LogicaNegocio.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Hotel.LogicaAplicacion.InterfacesCasosDeUso.ITipoCabaniaUC;
using Hotel.LogicaAplicacion.InterfacesCasosDeUso.ICabaniaUC;

namespace Hotel.Web.Controllers
{
    public class CabaniaController : Controller
    {
        #region ATRIBUTOS
        //Casos de uso
        /*private IRepositorioCabania repositorio;*/
        private IGetCabaniasUC getAllCabaniasUC;
        private ICreateCabaniaUC createCabaniaUC;
        private IGetCabaniasByCantMaxPersonasUC getAllCabaniasByCantMaxPersonasUC;
        private IGetCabaniasHabilitadasParaReservaUC getAllCabaniasHabilitadasParaReservaUC;
        private IGetCabaniasByNombreUC getAllCabaniasByNombreUC;
        private IGetCabaniasByTipoUC getAllCabaniasByTipoUC;
        /*private IRepositorioTipoCabania repositorioTipo;*/
        private IGetTiposDeCabaniaUC getAllTiposUC;

        private IWebHostEnvironment webHostEnvironment;
        private IRepositorioConfiguracion config;
        #endregion

        #region CONSTRUCTOR
        public CabaniaController(
            /*IRepositorioCabania repositorio,*/
            IGetCabaniasUC getAllCabaniasUC,
            ICreateCabaniaUC createCabaniaUC,
            IGetCabaniasByCantMaxPersonasUC getAllCabaniasByCantMaxPersonasUC,
            IGetCabaniasHabilitadasParaReservaUC getAllCabaniasHabilitadasParaReservaUC,
            IGetCabaniasByNombreUC getAllCabaniasByNombreUC,
            IGetCabaniasByTipoUC getAllCabaniasByTipoUC,
            /*IRepositorioTipoCabania repositorioTipo,*/
            IGetTiposDeCabaniaUC getAllTiposUC,

            IWebHostEnvironment webHostEnvironment,
            IRepositorioConfiguracion config)
        {
            /*this.repositorio = repositorio;*/
            this.getAllCabaniasUC = getAllCabaniasUC;
            this.createCabaniaUC = createCabaniaUC;
            this.getAllCabaniasByCantMaxPersonasUC = getAllCabaniasByCantMaxPersonasUC;
            this.getAllCabaniasHabilitadasParaReservaUC = getAllCabaniasHabilitadasParaReservaUC;
            this.getAllCabaniasByNombreUC = getAllCabaniasByNombreUC;
            this.getAllCabaniasByTipoUC = getAllCabaniasByTipoUC;
            /*this.repositorioTipo = repositorioTipo;*/
            this.getAllTiposUC = getAllTiposUC;

            this.webHostEnvironment = webHostEnvironment;
            this.config = config;
        }
        #endregion

        //GET
        //Links con funcionalidades de Cabaña
        public ActionResult HomeCabania()
        {
            if (HttpContext.Session.GetInt32("LogueadoId") != null)
            {
                return View();
            }
            return RedirectToAction("AccesoDenegado", "Home");

        }
      
        //GET: Index
        //Listado de todas las cabañas
        public ActionResult Index()
        {
            if (HttpContext.Session.GetInt32("LogueadoId") != null)
            {
                try
                {
                    IEnumerable<Cabania> ret = getAllCabaniasUC.GetCabanias();

                    if (ret.Count() == 0)
                    {
                        ViewBag.Message = "No existen cabañas registradas aún.";
                    }

                    return View(ret);
                }
                catch (Exception ex)
                {
                    ViewBag.Message = ex.Message;
                    return View();
                }
            }
            return RedirectToAction("AccesoDenegado", "Home");

        }

        //GET: GetByNombre
        //Muestra la vista para buscar una cabaña por nombre
        public ActionResult GetByNombre()
        {
            if (HttpContext.Session.GetInt32("LogueadoId") != null)
            {
                return View();
            }
            return RedirectToAction("AccesoDenegado", "Home");

        }
        //POST: GetByNombre
        //Listado de cabañas que coincidan con un nombre
        [HttpPost]
        public ActionResult GetByNombre(string nombre)
        {
            if (HttpContext.Session.GetInt32("LogueadoId") != null)
            {
                try
                {
                    IEnumerable<Cabania> ret = getAllCabaniasByNombreUC.GetCabaniasByNombre(nombre);

                    if (ret.Count() == 0)
                    {
                        ViewBag.Message = "No existe ninguna cabaña con ese nombre.";
                    }

                    return View(ret);
                }
                catch (Exception e)
                {
                    ViewBag.Message = "Error: " + e.Message;
                    return View();
                }
            }
            return RedirectToAction("AccesoDenegado", "Home");

        }

        //GET: GetByTipo
        //Muestra la vista para buscar una cabaña por tipo de cabaña
        public ActionResult GetByTipo()
        {
            if (HttpContext.Session.GetInt32("LogueadoId") != null)
            {
                return View();
            }
            return RedirectToAction("AccesoDenegado", "Home");

        }
        //POST: GetByTipo
        //Listado de cabañas que sean de un tipo
        [HttpPost]
        public ActionResult GetByTipo(string tipo)
        {
            if (HttpContext.Session.GetInt32("LogueadoId") != null)
            {
                try
                {
                    IEnumerable<Cabania> ret = getAllCabaniasByTipoUC.GetCabaniasByTipo(tipo);

                    if (ret.Count() == 0)
                    {
                        ViewBag.Message = "No existe ninguna cabaña con ese tipo.";
                    }

                    return View(ret);
                }
                catch (Exception e)
                {
                    ViewBag.Message = "Error: " + e.Message;
                    return View();
                }
            }
            return RedirectToAction("AccesoDenegado", "Home");

        }

        //GET: GetByCantMaxPersonas
        //Muestra la vista para buscar una cabaña por cantidad máxima de personas
        public ActionResult GetByCantMaxPersonas()
        {
            if (HttpContext.Session.GetInt32("LogueadoId") != null)
            {
                return View();
            }
            return RedirectToAction("AccesoDenegado", "Home");

        }
        //POST: GetByCantMaxPersonas
        //Listado de cabañas que acepten una cantidad máxima de personas
        [HttpPost]
        public ActionResult GetByCantMaxPersonas(int numero)
        {
            if (HttpContext.Session.GetInt32("LogueadoId") != null)
            {
                if (numero > 0)
                {
                    try
                    {
                        IEnumerable<Cabania> ret = getAllCabaniasByCantMaxPersonasUC.GetCabaniasByCantMaxPersonas(numero);

                        if (ret.Count() == 0)
                        {
                            ViewBag.Message = "No existe ninguna cabaña con esa cantidad máxima de personas.";
                        }

                        return View(ret);
                    }
                    catch (Exception e)
                    {
                        ViewBag.Message = "Error: " + e.Message;
                        return View();
                    }

                }
                else
                {
                    ViewBag.Message = "Error: Debe seleccionar una cantidad de personas";
                    return View();
                }

            }
            return RedirectToAction("AccesoDenegado", "Home");
        }

        //GET: GetByHabilitada
        //Muestra la vista para buscar una cabaña si está habilitada para reservas
        public ActionResult GetByHabilitada()
        {
            if (HttpContext.Session.GetInt32("LogueadoId") != null)
            {
                try
                {
                    IEnumerable<Cabania> ret = getAllCabaniasHabilitadasParaReservaUC.GetCabaniasHabilitadasParaReserva();

                    if (ret.Count() == 0)
                    {
                        ViewBag.Message = "No existe ninguna cabaña habilitada para reservas.";
                    }

                    return View(ret);
                }
                catch (Exception e)
                {
                    ViewBag.Message = "Error: " + e.Message;
                    return View();
                }
            }
            return RedirectToAction("AccesoDenegado", "Home");

        }

        // GET: Create
        //Muestra la vista para crear una cabaña
        public ActionResult Create()
        {
            if (HttpContext.Session.GetInt32("LogueadoId") != null)
            {
                IEnumerable<TipoCabania> ret = getAllTiposUC.GetTiposCabania();
                ViewBag.listaTipos = ret;
                return View();
            }
            return RedirectToAction("AccesoDenegado", "Home");

        }
        //POST: Create
        //Permite crear una cabaña
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(Cabania cabania, IFormFile imagen)
        //{
        //    if (HttpContext.Session.GetInt32("LogueadoId") != null)
        //    {
        //        try
        //        {
        //            GuardarImagen(imagen, cabania);
        //            createCabaniaUC.CreateCabania(cabania, config);
        //            return RedirectToAction(nameof(Index));
        //        }
        //        catch (CabaniaException e)
        //        {
        //            ViewBag.Message = e.Message;
        //            return View();
        //        }
        //        catch (Exception e)
        //        {
        //            ViewBag.Message = e.Message;
        //            return View();
        //        }

        //    }
        //    return RedirectToAction("AccesoDenegado", "Home");

        //}

        //Método para guardar la imágen
        private void GuardarImagen(IFormFile imagen, Cabania cabania)
        {
            if (imagen == null || cabania == null)
            {
                throw new Exception("Datos incorrectos");
            }

            string rutaFisicaWwwRoot = webHostEnvironment.WebRootPath;
            string extension = imagen.FileName.Split(".").Last();
            string nombreImagen = cabania.Nombre + "_001." + extension;

            string rutaFisicaImgsCabanias = Path.Combine(rutaFisicaWwwRoot, "imgs", "Cabanias", nombreImagen);

            try
            {
                //el método using libera los recursos del objeto FileStream al finalizar
                using (FileStream f = new FileStream(rutaFisicaImgsCabanias, FileMode.Create))
                {
                    //Para archivos grandes o varios archivos usar la versión
                    imagen.CopyTo(f);
                }

                //GUARDAR EL NOMBRE DE LA IMAGEN SUBIDA EN EL OBJETO
                cabania.Foto = nombreImagen;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region MÉTODOS QUE NO SE USAN
        // GET: CabaniaController/Details/5
        public ActionResult Details(int id)
        {
            if (HttpContext.Session.GetInt32("LogueadoId") != null)
            {
                return View();
            }
            return RedirectToAction("AccesoDenegado", "Home");

        }

        // GET: CabaniaController/Edit/5
        public ActionResult Edit(int id)
        {
            if (HttpContext.Session.GetInt32("LogueadoId") != null)
            {
                return View();
            }
            return RedirectToAction("AccesoDenegado", "Home");

        }

        // POST: CabaniaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            if (HttpContext.Session.GetInt32("LogueadoId") != null)
            {
                try
                {
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
            return RedirectToAction("AccesoDenegado", "Home");

        }

        // GET: CabaniaController/Delete/5
        public ActionResult Delete(int id)
        {
            if (HttpContext.Session.GetInt32("LogueadoId") != null)
            {
                return View();
            }
            return RedirectToAction("AccesoDenegado", "Home");

        }

        // POST: CabaniaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            if (HttpContext.Session.GetInt32("LogueadoId") != null)
            {
                try
                {
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
            return RedirectToAction("AccesoDenegado", "Home");

        }
        #endregion
    }
}
