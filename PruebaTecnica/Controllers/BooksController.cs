using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using PruebaTecnica.Models;


namespace PruebaTecnica.Controllers
{
    public class BooksController : ApiController
    {

        List<Books> listalibros = new List<Books>();

        public BooksController()
        {
            Books b = new Books { Id = 1, Titulo = "El principito", Autor = "Antoine de Saint", CantEjemplares = 50 };
            this.listalibros.Add(b);

            b = new Books { Id = 2, Titulo = "Padre rico padre pobre", Autor = "Robert Kiyosaki", CantEjemplares = 20 };
            this.listalibros.Add(b);

            b = new Books { Id = 3, Titulo = "El despertar de las musas", Autor = "Beatriz Luengo", CantEjemplares = 100 };
            this.listalibros.Add(b);


        }


        // GET: api/<controller>                                           //Permite obtener todos recursos
       
        public List<Books> GetBooks()

        {

            return this.listalibros;

        }


        // GET api/<controller>/5                                   //Permite obtener  recurso segun parametro

        public Books GetBook(int id)
        {


            Books b = this.listalibros.Find(z => z.Id == id);
            return b;
        }

        // POST api/<controller>
        public void AgregarBooks(Books book)
        {
            if (!listalibros.Contains(book))
            {
                listalibros.Add(book);
         
            }
         
          
        }

       
        // DELETE api/<controller>/5  
        public List<Books> DeleteBook(int id)
        {

            

                var b = this.listalibros.Find(z => z.Id == id);


                if (b != null)
                {
                    var ele = listalibros.Remove(b);
                    return this.listalibros;
                }
                else
                {
                    return listalibros;
                }
          






        }





    }
}