using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Models;

namespace ConsumeWEPAPI.Controllers
{
    public class BooksController1 : Controller
    {
        // GET: BooksController1
        public ActionResult Index()
        {
            var wc = new System.Net.WebClient();
            var url = "https://localhost:44315/api/Books";

            //INVOCAR AL WEB SERVICE REST.
            //Este metodo devuelve un string, en formato Json y para transformarlo en un array, utilizamos la libreria Newtonsoft
            var res = wc.DownloadString(url);

            //DESERIALIZAR EL JSON Y CONVERTIR EN ARRAY DE ARTICULOS
            Books[] datos = Newtonsoft.Json.JsonConvert.DeserializeObject<Books[]>(res);
            return View(datos);
        }

        // GET: BooksController1/Details/5
        public ActionResult Details(int id)
        {
            var wc = new System.Net.WebClient();
            var url = "https://localhost:44315/api/Books/" + id.ToString();

            //INVOCAR AL WEB SERVICE REST.
            //Este metodo devuelve un string, en formato Json y para transformarlo en un array, utilizamos la libreria Newtonsoft
            var res = wc.DownloadString(url);

            //DESERIALIZAR EL JSON Y CONVERTIR EN ARRAY DE Books
            Books datos = Newtonsoft.Json.JsonConvert.DeserializeObject<Books>(res);
            return View(datos);
        }

        // GET: BooksController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BooksController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Books datos)
        {
            try
            {
                var wc = new System.Net.WebClient();
                var url = "https://localhost:44315/api/Books/";

                //SERIALIZAR EN FORMATO JSON LOS DATOS DEL BOOKS/ CONVERTIR LOS DATOS A JSON
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(datos);

                //CONFIGURAR EL WEB CLIENT PARA ENVIAR EL JSON
                wc.Headers.Add("Content-type", "application/json");

                //ENVIAMOS EL JSON AL WEB SERVICE
                wc.UploadString(url, json);

                return View(datos);
            }
            catch
            {
                return View();
            }
        }

        // GET: BooksController1/Edit/5
        public ActionResult Edit(int id)
        {
            var wc = new System.Net.WebClient();
            var url = "https://localhost:44315/api/Books/" + id.ToString();

            //INVOCAR AL WEB SERVICE REST.
            //Este metodo devuelve un string, en formato Json y para transformarlo en un array, utilizamos la libreria Newtonsoft
            var res = wc.DownloadString(url);

            //DESERIALIZAR EL JSON Y CONVERTIR EN UN OBJETO DE BOOK
            Books datos = Newtonsoft.Json.JsonConvert.DeserializeObject<Books>(res);

            //PASO EL ARTICULO A LA VISTA
            return View(datos);
        }

        // POST: BooksController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Books datos)
        {
            try
            {
                var wc = new System.Net.WebClient();

                //Agregar al final el Id que se quiere modificar
                var url = "https://localhost:44315/api/Books/" + id.ToString();


                //SERIALIZAR EN FORMATO JSON LOS DATOS DEL BOOK/ CONVERTIR LOS DATOS A JSON
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(datos);

                //CONFIGURAR EL WEB CLIENT PARA ENVIAR EL JSON
                wc.Headers.Add("Content-type", "application/json");

                //ENVIAMOS EL JSON AL WEB SERVICE CON EL METODO PUT
                wc.UploadString(url, "PUT", json);

                return View(datos);
            }
            catch
            {
                return View();
            }
        }

        // GET: BooksController1/Delete/5
        public ActionResult Delete(int id)
        {
            var wc = new System.Net.WebClient();
            var url = "https://localhost:44315/api/Books/" + id.ToString();//url donde está publicado el servicio, o la de postman q utilizamos para probar la web API

            //INVOCAR AL WEB SERVICE REST.
            //Este metodo devuelve un string, en formato Json y para transformarlo en un array, utilizamos la libreria Newtonsoft
            var res = wc.DownloadString(url);

            //DESERIALIZAR EL JSON Y CONVERTIR EN UN OBJETO DE BOOK
            Books datos = Newtonsoft.Json.JsonConvert.DeserializeObject<Books>(res);

            //PASO EL ARTICULO A LA VISTA
            return View(datos);
        }

        // POST: BooksController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var wc = new System.Net.WebClient();

                //Agregar al final el Id que se quiere modificar
                var url = "https://localhost:44315/api/Books/" + id.ToString();


                //ENVIAMOS EL JSON AL WEB SERVICE CON EL METODO DELETE
                wc.UploadString(url, "DELETE", "");

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
