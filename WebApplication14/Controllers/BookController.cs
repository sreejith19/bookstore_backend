using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication14.Models;

namespace WebApplication14.Controllers
{
    public class BookController : ApiController
    {
        private IBookRepository repository;
        public BookController()
        {
            repository = new BookImplementation();
        }
        [System.Web.Http.HttpGet]
        public IHttpActionResult Get()
        {
            var data = repository.GetBooks();
            return Ok(data);
        }

        [System.Web.Http.HttpGet]
        public IHttpActionResult Get(int id)
        {
            var data = repository.GetBookById(id);
            return Ok(data);
        }

        [System.Web.Http.HttpGet]
        public IHttpActionResult Get(string value)
        {
            var data = repository.GetBooksByName(value);
            return Ok(data);
        }
        [System.Web.Http.ActionName("Category")]
        [System.Web.Http.HttpGet]
        public IHttpActionResult GetBooksByCategory(int id)
        {
            var data = repository.GetBooksByCatId(id);
            return Ok(data);
        }
        [System.Web.Http.ActionName("Author")]
        [System.Web.Http.HttpGet]
        public IHttpActionResult GetBooksByauthor(string value)
        {
            var data = repository.GetBooksByAuthor(value);
            return Ok(data);
        }

        [System.Web.Http.ActionName("Isbn")]
        [System.Web.Http.HttpGet]
        public IHttpActionResult Isbn(string value)
        {
            var data = repository.GetBooksByIsbn(value);
            return Ok(data);
        }
        [System.Web.Http.ActionName("Add")]
        [System.Web.Http.HttpPost]
        public int Add([FromBody] Book book)
        {
            Debug.WriteLine("new add");
            var data = repository.AddBook(book);
            return data;
        }

        [System.Web.Http.ActionName("Edit")]
        [System.Web.Http.HttpPost]
        public int Edit([FromBody] Book book)
        {
            Debug.WriteLine("new edit");
            var data = repository.EditBook(book);
            return data;
        }
        [System.Web.Http.ActionName("Enable")]
        [System.Web.Http.HttpPost]
        public bool Enable([FromBody] int id)
        {
            Debug.WriteLine("new enable");
            bool data = repository.Enable(id);
            return data;
        }
        [System.Web.Http.ActionName("Disable")]
        [System.Web.Http.HttpPost]
        public bool Disable([FromBody] int id)
        {
            Debug.WriteLine("new disable");
            bool data = repository.Disable(id);
            return data;
        }
        [System.Web.Http.ActionName("Delete")]
        [System.Web.Http.HttpPost]
        public int Delete([FromBody] int id)
        {
            Debug.WriteLine("new delete");
            var data = repository.DeleteBook(id);
            return data;
        }
    }
}
