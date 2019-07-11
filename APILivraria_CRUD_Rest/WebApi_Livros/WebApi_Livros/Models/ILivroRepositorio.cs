using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi_Livros.Models
{
    interface ILivroRepositorio
    {
        IEnumerable<Livro> GetAll();
        Livro Get(int id);
        bool Add(Livro livro);
        void Remove(int id);
        bool Update(Livro livro);
    }
}
 
