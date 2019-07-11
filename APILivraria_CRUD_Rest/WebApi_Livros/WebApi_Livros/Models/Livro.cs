using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi_Livros.Models
{
    public class Livro
    {
        public string nome { get; set; }
        public int id { get; set; }
        public string autor { get; set; }
        public double preco { get; set; }
        public DateTime data { get; set; }
        public string imagem { get; set; }

    }
}