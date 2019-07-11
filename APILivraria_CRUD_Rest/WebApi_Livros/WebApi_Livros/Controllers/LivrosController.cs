using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi_Livros.Models;

namespace WebApi_Livros.Controllers
{
    public class LivrosController : ApiController
    {

        static readonly ILivroRepositorio livroRepositorio = new LivroRepositorio();
        public HttpResponseMessage GetAllLivros()
        {
            List<Livro> listaLivros = livroRepositorio.GetAll().ToList();
            return Request.CreateResponse<List<Livro>>(HttpStatusCode.OK, listaLivros);
        }
        public HttpResponseMessage GetLivro(int id)
        {
            Livro livro = livroRepositorio.Get(id);
            if (livro == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Livro não localizado para o Id informado");
            }
            else
            {
                return Request.CreateResponse<Livro>(HttpStatusCode.OK, livro);
            }
        }

        public IEnumerable<Livro> GetLivrosPorNome(string nome)
        {
            return livroRepositorio.GetAll().Where(
                e => string.Equals(e.nome, nome, StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<Livro> GetLivrosPorAutor(string autor)
        {
            return livroRepositorio.GetAll().Where(
                e => string.Equals(e.autor, autor, StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<Livro> GetLivrosPorPreco(double preco)
        {
            return livroRepositorio.GetAll().Where(
                e => string.Equals(e.preco.ToString(), preco.ToString(), StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<Livro> GetLivrosPorData(DateTime data)
        {
            return livroRepositorio.GetAll().Where(
                e => string.Equals(e.data.ToString(), data.ToString(), StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<Livro> GetLivrosPorImagem(string imagem)
        {
            return livroRepositorio.GetAll().Where(
                e => string.Equals(e.imagem.ToString(), imagem.ToString(), StringComparison.OrdinalIgnoreCase));
        }

        public HttpResponseMessage PostLivro(Livro livro)
        {
            bool result = livroRepositorio.Add(livro);
            if (result)
            {
                var response = Request.CreateResponse<Livro>(HttpStatusCode.Created, livro);
                string uri = Url.Link("DefaultApi", new { id = livro.id });
                response.Headers.Location = new Uri(uri);
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Livro não foi incluído com sucesso");
            }
        }

        public HttpResponseMessage PutLivro(int id, Livro livro)
        {
            livro.id = id;
            if (!livroRepositorio.Update(livro))
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound,
 "Não foi possível atualizar o Livro para o id informado");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
        }
        public HttpResponseMessage DeleteLivro(int id)
        {
            livroRepositorio.Remove(id);
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }


    }
}
