using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaTecnica.Models
{
    public class Books
    {
       
        public int Id { get; set; }

        public String Titulo { get; set; }

        public String Autor { get; set; }

        public int CantEjemplares { get; set; }
    }
}