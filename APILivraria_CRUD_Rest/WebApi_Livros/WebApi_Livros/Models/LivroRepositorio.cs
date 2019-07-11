using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi_Livros.Models
{

    public class LivroRepositorio : ILivroRepositorio
    {
        private List<Livro> livros = new List<Livro>();

        private int _nextId = 1;
        public LivroRepositorio()
        {
            Add(new Livro { nome = "Fisica experimental", id = 1, autor = "Robson Crusoe", preco = 55, data = Convert.ToDateTime("01/01/2010"), imagem = "imagem/capa1.jpg" });
            Add(new Livro { nome = "Biologia marinha", id = 2, autor = "Ari Couto", preco = 24, data = Convert.ToDateTime("02/01/2010"), imagem = "imagem/capa2.jpg" });
            Add(new Livro { nome = "Matematica para Dummies", id = 3, autor = "Oswald de Souza", preco = 35, data = Convert.ToDateTime("03/01/2010"), imagem = "imagem/capa3.jpg" });
            Add(new Livro { nome = "Contos de Verão", id = 4, autor = "Rui Barbosa", preco = 21, data = Convert.ToDateTime("04/01/2010"), imagem = "imagem/capa4.jpg" });
            Add(new Livro { nome = "Phyton 3 com Django", id = 5, autor = "Bill Gates", preco = 25, data = Convert.ToDateTime("05/01/2010"), imagem = "imagem/capa5.jpg" });
        }
        public IEnumerable<Livro> GetAll()
        {
            return livros;
        }
        public Livro Get(int id)
        {
            return livros.Find(s => s.id == id);
        }
        public bool Add(Livro livro)
        {
            bool addResult = false;
            if (livro == null)
            {
                return addResult;
            }
            int index = livros.FindIndex(s => s.id == livro.id);
            if (index == -1)
            {
                livros.Add(livro);
                addResult = true;
                return addResult;
            }
            else
            {
                return addResult;
            }
        }

        public void Remove(int id)
        {
            livros.RemoveAll(s => s.id == id);
        }
        public bool Update(Livro livro)
        {
            if (livro == null)
            {
                throw new ArgumentNullException("livro");
            }
            int index = livros.FindIndex(s => s.id == livro.id);
            if (index == -1)
            {
                return false;
            }
            livros.RemoveAt(index);
            livros.Add(livro);
            return true;
        }
    }
}