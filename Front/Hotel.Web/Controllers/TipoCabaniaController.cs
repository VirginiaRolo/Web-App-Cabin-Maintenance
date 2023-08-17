using Hotel.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Drawing;
using static System.Net.Mime.MediaTypeNames;
using System.Text;

namespace Hotel.Web.Controllers
{
    public class TipoCabaniaController : Controller
    {
        #region ATRIBUTOS
        private string localHost;
        private HttpClient cliente;
        #endregion

        #region CONSTRUCTOR
        public TipoCabaniaController()
        {
            localHost = "https://localhost:7100";
            cliente = new HttpClient();
        }
        #endregion

        //GET
        //Links con funcionalidades de Tipo Cabaña
        public ActionResult HomeTipoCabania()
        {
            return View();
        }

        //GET: Index
        //Listado de todos los tipos de cabañas
        public IActionResult Index()
        {
            Uri uri = new Uri(localHost + "/api/TipoCabanias");
            HttpRequestMessage solicitud = new HttpRequestMessage(HttpMethod.Get, uri);

            Task<HttpResponseMessage> respuesta = cliente.SendAsync(solicitud);
            respuesta.Wait();

            Task<string> response = respuesta.Result.Content.ReadAsStringAsync();

            TipoCabaniaModel[] listaTipoCabanias = JsonConvert.DeserializeObject<TipoCabaniaModel[]>(response.Result);

            return View(listaTipoCabanias);
        }


        //GET: Create
        //Muestra la vista para crear un tipo de cabaña
        public ActionResult Create()
        {
            return View();
        }

        //POST: Create
        //Permite crear un tipo de cabaña
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(TipoCabaniaModel tipoCabania)
        {
            try
            {
                // ------ LLAMADA A TIPO CABANIAS --------
                /******************* HEADERS *******************/
                //cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTUxMiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9lbWFpbGFkZHJlc3MiOiJ1bm9AZ21haWwuY29tIiwiZXhwIjoxNjg2MzE3Mjk2fQ.pb0jKJbRKxXDdWPnoQy-RcaIB2YAV-R_5sPPnmyyRnntKW6pIioU2A_IZgo9ELIX_demBsMX_LzMWhSySIsKMA");

                Uri uri = new Uri(localHost + "/api/TipoCabanias");
                HttpRequestMessage solicitud = new HttpRequestMessage(HttpMethod.Post, uri);

                /******************* CONTENIDO O BODY ********************/
                string json = JsonConvert.SerializeObject(tipoCabania);
                HttpContent contenido =
                new StringContent(json, Encoding.UTF8, "application/json");
                solicitud.Content = contenido;
                /*************** END CONTENIDO O BODY ********************/

                Task<HttpResponseMessage> respuesta = cliente.SendAsync(solicitud);
                respuesta.Wait();

                Console.WriteLine(respuesta.Result.StatusCode.ToString());

                Console.WriteLine(respuesta.Result.StatusCode.Equals(System.Net.HttpStatusCode.Unauthorized));
                Task<string> response = respuesta.Result.Content.ReadAsStringAsync();

                if (respuesta.Result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Message = response.Result;
                    return View();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return RedirectToAction("Create", new { error = e.Message });
            }
        }

        //GET: GetTipoCabaniasByNombre
        //Muestra la vista para buscar un tipo de cabaña por nombre
        public ActionResult GetTipoCabaniasByNombre()
        {
            return View();
        }

        //POST: GetTipoCabaniasByNombre
        //Listado de cabañas que coincidan con un nombre
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult GetTipoCabaniasByNombre(string nombre)
        {
            try
            {
                /******************* HEADERS *******************/
                //cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTUxMiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9lbWFpbGFkZHJlc3MiOiJ1bm9AZ21haWwuY29tIiwiZXhwIjoxNjg2MzE3Mjk2fQ.pb0jKJbRKxXDdWPnoQy-RcaIB2YAV-R_5sPPnmyyRnntKW6pIioU2A_IZgo9ELIX_demBsMX_LzMWhSySIsKMA");

                Uri uri = new Uri(localHost + "/api/TipoCabanias/Nombre/" + nombre);
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

                TipoCabaniaModel[] listaTipoCabanias = JsonConvert.DeserializeObject<TipoCabaniaModel[]>(response.Result);

                return View(listaTipoCabanias);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //GET: Delete
        //Muestra la vista para borrar un tipo de cabaña
        public ActionResult Delete(string nombre)
        {
            // ------ GET UN TIPO BY NOMBRE ------
            /******************* HEADERS *******************/
            //cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTUxMiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9lbWFpbGFkZHJlc3MiOiJ1bm9AZ21haWwuY29tIiwiZXhwIjoxNjg2MzE3Mjk2fQ.pb0jKJbRKxXDdWPnoQy-RcaIB2YAV-R_5sPPnmyyRnntKW6pIioU2A_IZgo9ELIX_demBsMX_LzMWhSySIsKMA");

            Uri uri = new Uri(localHost + "/api/TipoCabanias/UnNombre/" + nombre);
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

            TipoCabaniaModel tipoCabania = JsonConvert.DeserializeObject<TipoCabaniaModel>(response.Result);

            return View(tipoCabania);
        }

        //POST: Delete
        //Listado de cabañas que coincidan con un nombre
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Delete(string nombre, IFormCollection collection)
        {
            try
            {
                /******************* HEADERS *******************/
                //cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTUxMiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9lbWFpbGFkZHJlc3MiOiJ1bm9AZ21haWwuY29tIiwiZXhwIjoxNjg2MzE3Mjk2fQ.pb0jKJbRKxXDdWPnoQy-RcaIB2YAV-R_5sPPnmyyRnntKW6pIioU2A_IZgo9ELIX_demBsMX_LzMWhSySIsKMA");

                Uri uri = new Uri(localHost + "/api/TipoCabanias/" + nombre);
                HttpRequestMessage solicitud = new HttpRequestMessage(HttpMethod.Delete, uri);

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

                if (respuesta.Result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Message = response.Result;
                    return View();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //GET: Edit
        //Muestra la vista para editar un tipo de cabaña
        public ActionResult Edit(string nombre)
        {
            // ------ GET UN TIPO BY NOMBRE ------
            /******************* HEADERS *******************/
            //cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTUxMiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9lbWFpbGFkZHJlc3MiOiJ1bm9AZ21haWwuY29tIiwiZXhwIjoxNjg2MzE3Mjk2fQ.pb0jKJbRKxXDdWPnoQy-RcaIB2YAV-R_5sPPnmyyRnntKW6pIioU2A_IZgo9ELIX_demBsMX_LzMWhSySIsKMA");

            Uri uri = new Uri(localHost + "/api/TipoCabanias/UnNombre/" + nombre);
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

            TipoCabaniaModel tipoCabania = JsonConvert.DeserializeObject<TipoCabaniaModel>(response.Result);

            return View(tipoCabania);
        }

        //POST: Edit
        //Permite editar un tipo de cabaña
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit(TipoCabaniaModel tipoCabania, string nombre)
        {
            try
            {
                /******************* HEADERS *******************/
                //cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTUxMiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9lbWFpbGFkZHJlc3MiOiJ1bm9AZ21haWwuY29tIiwiZXhwIjoxNjg2MzE3Mjk2fQ.pb0jKJbRKxXDdWPnoQy-RcaIB2YAV-R_5sPPnmyyRnntKW6pIioU2A_IZgo9ELIX_demBsMX_LzMWhSySIsKMA");

                Uri uri = new Uri(localHost + "/api/TipoCabanias/" + nombre);
                HttpRequestMessage solicitud = new HttpRequestMessage(HttpMethod.Put, uri);

                /******************* CONTENIDO O BODY ********************/
                string json = JsonConvert.SerializeObject(tipoCabania);
                HttpContent contenido =
                new StringContent(json, Encoding.UTF8, "application/json");
                solicitud.Content = contenido;
                /*************** END CONTENIDO O BODY ********************/

                Task<HttpResponseMessage> respuesta = cliente.SendAsync(solicitud);
                respuesta.Wait();

                Console.WriteLine(respuesta.Result.StatusCode.ToString());

                Console.WriteLine(respuesta.Result.StatusCode.Equals(System.Net.HttpStatusCode.Unauthorized));
                Task<string> response = respuesta.Result.Content.ReadAsStringAsync();

                if (respuesta.Result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Message = response.Result;
                    return View();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
