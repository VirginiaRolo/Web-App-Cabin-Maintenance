using Hotel.LogicaAplicacion.InterfacesCasosDeUso.ICabaniaUC;
using Hotel.LogicaAplicacion.InterfacesCasosDeUso.IMantenimientoUC;
using Hotel.LogicaNegocio.Entidades;
using Hotel.LogicaNegocio.Excepciones;
using Hotel.LogicaNegocio.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;

namespace Hotel.Web.Controllers
{
    public class MantenimientoController : Controller
    {
        #region ATRIBUTOS
        //Casos de uso
        /*private IRepositorioMantenimiento repositorio;*/
        private ICreateMantenimientoUC createMantenimientoUC;
        private IGetMantenimientosByCabaniaIdUC getAllMantenimientosByCabaniaIdUC;
        private IGetMantenimientosByCabaniaIdYDosFechasUC getAllMantenimientosByCabaniaIdYDosFechasUC;
        /*private IRepositorioCabania repositorioCab;*/
        private IGetUnaCabaniaByIdUC getUnaCabaniaByIdUC;

        private IRepositorioConfiguracion config;
        #endregion

        #region CONSTRUCTOR
        public MantenimientoController(
            /*IRepositorioMantenimiento repositorio,*/
            ICreateMantenimientoUC createMantenimientoUC,
            IGetMantenimientosByCabaniaIdUC getAllMantenimientosByCabaniaIdUC,
            IGetMantenimientosByCabaniaIdYDosFechasUC getAllMantenimientosByCabaniaIdYDosFechasUC,
            /*IRepositorioCabania repositorioCab,*/
            IGetUnaCabaniaByIdUC getUnaCabaniaByIdUC,

            IRepositorioConfiguracion config)
        {
            /*this.repositorio = repositorio;*/
            this.createMantenimientoUC = createMantenimientoUC;
            this.getAllMantenimientosByCabaniaIdUC = getAllMantenimientosByCabaniaIdUC;
            this.getAllMantenimientosByCabaniaIdYDosFechasUC = getAllMantenimientosByCabaniaIdYDosFechasUC;
            /*this.repositorioCab = repositorioCab;*/
            this.getUnaCabaniaByIdUC = getUnaCabaniaByIdUC;

            this.config = config;
        }
        #endregion

        //GET: GetByIdCabania
        //Listado de todos los mantenimientos de una cabaña
        public ActionResult GetByIdCabania(int idCabania)
        {
            if (HttpContext.Session.GetInt32("LogueadoId") != null)
            {
                try
                {
                    IEnumerable<Mantenimiento> ret = getAllMantenimientosByCabaniaIdUC.GetMantenimientosByCabaniaId(idCabania);

                    if (ret.Count() == 0)
                    {
                        ViewBag.Message = "No existen mantenimientos registradas aún para esta cabaña.";
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

        //GET: GetByFechas
        //Muestra la vista de busqueda de mantenimientos de una cabaña por dos fechas y el id de
        //la cabaña
        public ActionResult GetByFechas()
        {
            if (HttpContext.Session.GetInt32("LogueadoId") != null)
            {
                return View();
            }
            return RedirectToAction("AccesoDenegado", "Home");

        }
        //POST: GetByFechas
        //Lista todos los mantenimientos de una cabaña dado un id y 2 fechas
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetByFechas(int idCabania, DateTime fecha1, DateTime fecha2)
        {
            if (HttpContext.Session.GetInt32("LogueadoId") != null)
            {
                if (fecha1 != default(DateTime) || fecha2 != default(DateTime))
                {
                    try
                    {
                        return View(getAllMantenimientosByCabaniaIdYDosFechasUC.GetMantenimientosByCabaniaIdYDosFechas(idCabania, fecha1, fecha2));
                    }
                    catch (MantenimientoException ex)
                    {
                        ViewBag.Message = ex.Message;
                        return View();
                    }
                    catch (Exception e)
                    {
                        ViewBag.Message = e.Message;
                        return View();
                    }
                }
                else
                {
                    ViewBag.Message = "Error: Debe seleccionar 2 fechas válidas";
                    return View();
                }

            }
            return RedirectToAction("AccesoDenegado", "Home");

        }

        //GET: Create
        //Muestra la vista para crear un mantenimiento a una cabaña
        public ActionResult Create(int idCabania, string mensaje)
        {
            if (HttpContext.Session.GetInt32("LogueadoId") != null)
            {
                Cabania ret = getUnaCabaniaByIdUC.GetUnaCabaniaById(idCabania);
                ViewBag.unaCabania = ret;
                ViewBag.Message = mensaje;
                TempData["cabaniaId"] = idCabania;
                return View();
            }
            return RedirectToAction("AccesoDenegado", "Home");
        }
        //POST: Create
        //Permite crear un mantenimiento a una cabaña
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int idCabania, Mantenimiento mantenimiento)
        {
            if (HttpContext.Session.GetInt32("LogueadoId") != null)
            {
                int cabaniaIdRecuperado = Int32.Parse(TempData["cabaniaId"].ToString());

                try
                {
                    createMantenimientoUC.CreateMantenimiento(cabaniaIdRecuperado, mantenimiento, config);
                    //return RedirectToAction(nameof(Index));
                    return RedirectToAction("Index", "Cabania");
                }
                catch (MantenimientoException ex)
                {
                    ViewBag.Message = ex.Message;
                    return RedirectToAction("Create", new { idCabania = cabaniaIdRecuperado, mensaje = ex.Message });
                }
                catch (Exception e)
                {
                    ViewBag.Message = e.Message;
                    return RedirectToAction("Create", new { idCabania = cabaniaIdRecuperado, mensaje = e.Message });
                }
            }
            return RedirectToAction("AccesoDenegado", "Home");

        }

        #region MÉTODOS QUE NO SE USAN
        // GET: MantenimientoController
        //no hay vista de esto, no se usa
        /*public ActionResult Index()
        {
            if (HttpContext.Session.GetInt32("LogueadoId") != null)
            {
                try
                {
                    IEnumerable<Mantenimiento> ret = getAllMantenimientosUC.GetMantenimientos();

                    if (ret.Count() == 0)
                    {
                        ViewBag.Message = "No existen mantenimientos registradas aún.";
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

        }*/

        // GET: MantenimientoController/Details/5
        public ActionResult Details(int id)
        {
            if (HttpContext.Session.GetInt32("LogueadoId") != null)
            {
                return View();
            }
            return RedirectToAction("AccesoDenegado", "Home");

        }

        // GET: MantenimientoController/Edit/5
        public ActionResult Edit(int id)
        {
            if (HttpContext.Session.GetInt32("LogueadoId") != null)
            {
                return View();
            }
            return RedirectToAction("AccesoDenegado", "Home");

        }

        // POST: MantenimientoController/Edit/5
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

        // GET: MantenimientoController/Delete/5
        public ActionResult Delete(int id)
        {
            if (HttpContext.Session.GetInt32("LogueadoId") != null)
            {
                return View();
            }
            return RedirectToAction("AccesoDenegado", "Home");

        }

        // POST: MantenimientoController/Delete/5
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
