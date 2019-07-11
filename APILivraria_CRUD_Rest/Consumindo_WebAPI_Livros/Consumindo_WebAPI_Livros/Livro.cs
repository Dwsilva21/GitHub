using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consumindo_WebAPI_Livros
{
    class Livro
    {
        public string nome { get; set; }
        public int id { get; set; }
        public string autor { get; set; }
        public double preco { get; set; }
        public DateTime data { get; set; }
        public string imagem { get; set; }
    }
}
