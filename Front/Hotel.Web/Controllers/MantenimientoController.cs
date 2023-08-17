using Hotel.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Hotel.Web.Controllers
{
    public class MantenimientoController : Controller
    {
        #region ATRIBUTOS
        private string localHost;
        private HttpClient cliente;
        #endregion

        #region CONSTRUCTOR
        public MantenimientoController()
        {
            localHost = "https://localhost:7100";
            cliente = new HttpClient();
        }
        #endregion

        //GET: GetMantenimientosByIdCabania
        public ActionResult GetMantenimientosByIdCabania(int idCabania)
        {
            try
            {
                /******************* HEADERS *******************/
                //cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTUxMiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9lbWFpbGFkZHJlc3MiOiJ1bm9AZ21haWwuY29tIiwiZXhwIjoxNjg2MzE3Mjk2fQ.pb0jKJbRKxXDdWPnoQy-RcaIB2YAV-R_5sPPnmyyRnntKW6pIioU2A_IZgo9ELIX_demBsMX_LzMWhSySIsKMA");

                Uri uri = new Uri(localHost + "/api/Mantenimientos/" + idCabania);
                HttpRequestMessage solicitud = new HttpRequestMessage(HttpMethod.Get, uri);

                /******************* CONTENIDO O BODY ********************/
                //string json = JsonConvert.SerializeObject(equipo);
                //HttpContent contenido =
                //new StringContent(json, Encoding.UTF8, "application/json");
                //solicitud.Content = contenido;
                /*************** END CONTENIDO O BODY ********************/

                Task<HttpResponseMessage> respuesta = cliente.SendAsync(solicitud);
                respuesta.Wait();

                Console.WriteLine(respuesta.Result.StatusCode.ToString());

                Console.WriteLine(respuesta.Result.StatusCode.Equals(System.Net.HttpStatusCode.Unauthorized));
                Task<string> response = respuesta.Result.Content.ReadAsStringAsync();

                MantenimientoModel[] listaMantenimientos = JsonConvert.DeserializeObject<MantenimientoModel[]>(response.Result);

                return View(listaMantenimientos);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //GET: Create
        //Muestra la vista para crear un mantenimiento a una cabaña
        public ActionResult Create(int idCabania)
        {
            // ------ LLAMADA A UNA CABANIA BY ID --------
            /******************* HEADERS *******************/
            //cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTUxMiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9lbWFpbGFkZHJlc3MiOiJ1bm9AZ21haWwuY29tIiwiZXhwIjoxNjg2MzE3Mjk2fQ.pb0jKJbRKxXDdWPnoQy-RcaIB2YAV-R_5sPPnmyyRnntKW6pIioU2A_IZgo9ELIX_demBsMX_LzMWhSySIsKMA");

            Uri uri = new Uri(localHost + "/api/Cabanias/Id/" + idCabania);
            HttpRequestMessage solicitud = new HttpRequestMessage(HttpMethod.Get, uri);

            /******************* CONTENIDO O BODY ********************/
            //string json = JsonConvert.SerializeObject(cabania);
            //HttpContent contenido =
            //new StringContent(json, Encoding.UTF8, "application/json");
            //solicitud.Content = contenido;
            /*************** END CONTENIDO O BODY ********************/

            Task<HttpResponseMessage> respuesta = cliente.SendAsync(solicitud);
            respuesta.Wait();

            Console.WriteLine(respuesta.Result.StatusCode.ToString());

            Console.WriteLine(respuesta.Result.StatusCode.Equals(System.Net.HttpStatusCode.Unauthorized));
            Task<string> response = respuesta.Result.Content.ReadAsStringAsync();

            CabaniaModel unaCabania = JsonConvert.DeserializeObject<CabaniaModel>(response.Result);

            ViewBag.unaCabania = unaCabania;
            return View("Create", new MantenimientoModel { Cabania = unaCabania});
        }

        //POST: Create
        //Permite crear un mantenimiento a una cabaña
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(MantenimientoModel mantenimiento)
        {
            try
            {
                /******************* HEADERS *******************/
                //cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTUxMiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9lbWFpbGFkZHJlc3MiOiJ1bm9AZ21haWwuY29tIiwiZXhwIjoxNjg2MzE3Mjk2fQ.pb0jKJbRKxXDdWPnoQy-RcaIB2YAV-R_5sPPnmyyRnntKW6pIioU2A_IZgo9ELIX_demBsMX_LzMWhSySIsKMA");

                Uri uri = new Uri(localHost + "/api/Mantenimientos");
                HttpRequestMessage solicitud = new HttpRequestMessage(HttpMethod.Post, uri);

                /******************* CONTENIDO O BODY ********************/
                string json = JsonConvert.SerializeObject(mantenimiento);
                HttpContent contenido =
                new StringContent(json, Encoding.UTF8, "application/json");
                solicitud.Content = contenido;
                /*************** END CONTENIDO O BODY ********************/

                Task<HttpResponseMessage> respuesta = cliente.SendAsync(solicitud);
                respuesta.Wait();

                Console.WriteLine(respuesta.Result.StatusCode.ToString());

                Console.WriteLine(respuesta.Result.StatusCode.Equals(System.Net.HttpStatusCode.Unauthorized));
                Task<string> response = respuesta.Result.Content.ReadAsStringAsync();


                // ------ LLAMADA A UNA CABANIA BY ID --------
                /******************* HEADERS *******************/
                //cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTUxMiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9lbWFpbGFkZHJlc3MiOiJ1bm9AZ21haWwuY29tIiwiZXhwIjoxNjg2MzE3Mjk2fQ.pb0jKJbRKxXDdWPnoQy-RcaIB2YAV-R_5sPPnmyyRnntKW6pIioU2A_IZgo9ELIX_demBsMX_LzMWhSySIsKMA");

                int idCabania = mantenimiento.IdCabania;

                Uri uri2 = new Uri(localHost + "/api/Cabanias/Id/" + idCabania);
                HttpRequestMessage solicitud2 = new HttpRequestMessage(HttpMethod.Get, uri2);

                /******************* CONTENIDO O BODY ********************/
                //string json = JsonConvert.SerializeObject(cabania);
                //HttpContent contenido =
                //new StringContent(json, Encoding.UTF8, "application/json");
                //solicitud.Content = contenido;
                /*************** END CONTENIDO O BODY ********************/

                Task<HttpResponseMessage> respuesta2 = cliente.SendAsync(solicitud2);
                respuesta2.Wait();

                Console.WriteLine(respuesta2.Result.StatusCode.ToString());

                Console.WriteLine(respuesta2.Result.StatusCode.Equals(System.Net.HttpStatusCode.Unauthorized));
                Task<string> response2 = respuesta2.Result.Content.ReadAsStringAsync();

                CabaniaModel unaCabania = JsonConvert.DeserializeObject<CabaniaModel>(response2.Result);

                if (respuesta.Result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Cabania");
                }
                else
                {
                    ViewBag.Message = response.Result;
                    ViewBag.unaCabania = unaCabania;
                    return View("Create", new MantenimientoModel { Cabania = unaCabania });
                    //return View();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return RedirectToAction("Create", new { error = e.Message });
            }
        }

        //GET: GetMantenimientosByFechas
        //Muestra la vista de busqueda de mantenimientos de una cabaña por dos fechas y el id de
        //la cabaña
        public ActionResult GetMantenimientosByFechas()
        {
            return View();
        }

        //POST: GetMantenimientosByFechas
        //Lista todos los mantenimientos de una cabaña dado un id y 2 fechas
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult GetMantenimientosByFechas(int idCabania, DateTime fecha1, DateTime fecha2)
        {
            try
            {
                //fecha1 = 2023 - 05 - 01T00: 33:45.294Z;
                /******************* HEADERS *******************/
                //cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTUxMiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9lbWFpbGFkZHJlc3MiOiJ1bm9AZ21haWwuY29tIiwiZXhwIjoxNjg2MzE3Mjk2fQ.pb0jKJbRKxXDdWPnoQy-RcaIB2YAV-R_5sPPnmyyRnntKW6pIioU2A_IZgo9ELIX_demBsMX_LzMWhSySIsKMA");

                //Uri uri = new Uri(localHost + "/api/Mantenimientos/" + idCabania + "/fecha1/" + fecha1 + "/fecha2/" + fecha2);
                Uri uri = new Uri(localHost + "/api/Mantenimientos/" + idCabania + "/" + fecha1 + "/" + fecha2);
                HttpRequestMessage solicitud = new HttpRequestMessage(HttpMethod.Get, uri);

                /******************* CONTENIDO O BODY ********************/
                //string json = JsonConvert.SerializeObject(equipo);
                //HttpContent contenido =
                //new StringContent(json, Encoding.UTF8, "application/json");
                //solicitud.Content = contenido;
                /*************** END CONTENIDO O BODY ********************/

                Task<HttpResponseMessage> respuesta = cliente.SendAsync(solicitud);
                respuesta.Wait();

                Console.WriteLine(respuesta.Result.StatusCode.ToString());

                Console.WriteLine(respuesta.Result.StatusCode.Equals(System.Net.HttpStatusCode.Unauthorized));
                Task<string> response = respuesta.Result.Content.ReadAsStringAsync();

                MantenimientoModel[] listaMantenimientos = JsonConvert.DeserializeObject<MantenimientoModel[]>(response.Result);

                return View(listaMantenimientos);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
