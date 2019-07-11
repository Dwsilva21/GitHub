using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApi_Livros.Controllers;
using WebApi_Livros.Models;
using System.Net.Http;
using System.Web.Http.Results;

namespace StoreApp.Tests
{
    [TestClass]
    public class TestSimpleProductController
    {
        [TestMethod]
        public void GetAllProducts_ShouldReturnAllProducts()
        {
            var testProducts = GetTestProducts();
            var controller = new LivrosController();

            HttpResponseMessage result = controller.GetAllLivros() ;

            Assert.AreEqual(testProducts.Count, 4);
        }

        [TestMethod]
        public async Task GetAllProductsAsync_ShouldReturnAllProducts()
        {
            var testProducts = GetTestProducts();
            var controller = new LivrosController();

            HttpResponseMessage result = controller.GetAllLivros() ;

            var livros = result.Content.ReadAsAsync<Livro>();

            Assert.AreEqual(testProducts.Count, result.Content);
        }

        [TestMethod]
        public void xGetProduct_ShouldReturnCorrectProduct()
        {
            var testProducts = GetTestProducts();
            var controller = new LivrosController();

            HttpResponseMessage result = controller.GetLivro(4)  ;
            var livros = result.Content.ReadAsAsync<Livro>();

            Assert.IsNotNull(result);
            Assert.AreEqual(testProducts[3].nome, result);
        }

        [TestMethod]
        public async Task GetProductAsync_ShouldReturnCorrectProduct()
        {
            var testProducts = GetTestProducts();
            var controller = new LivrosController();

            var result = controller.GetLivro(3)  ;

            Assert.IsNotNull(result);
            Assert.AreEqual(testProducts[3].nome, result);
        }

        [TestMethod]
        public void GetProduct_ShouldNotFindProduct()
        {
            var controller = new LivrosController();

            var result = controller.GetLivro(999);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        private List<Livro> GetTestProducts()
        {
            var testProducts = new List<Livro>();
            testProducts.Add(new Livro { nome = "Matematica para Dummies", id = 1, autor = "Oswald de Souza", preco = 35, data = Convert.ToDateTime("03/01/2010"), imagem = "imagem/capa3.jpg" });
            testProducts.Add(new Livro { nome = "Matematica para Dummies", id = 2, autor = "Oswald de Souza", preco = 35, data = Convert.ToDateTime("03/01/2010"), imagem = "imagem/capa3.jpg" });
            testProducts.Add(new Livro { nome = "Matematica para Dummies", id = 3, autor = "Oswald de Souza", preco = 35, data = Convert.ToDateTime("03/01/2010"), imagem = "imagem/capa3.jpg" });
            testProducts.Add(new Livro { nome = "Matematica para Dummies", id = 4, autor = "Oswald de Souza", preco = 35, data = Convert.ToDateTime("03/01/2010"), imagem = "imagem/capa3.jpg" });
            return testProducts;
        }
    }
}