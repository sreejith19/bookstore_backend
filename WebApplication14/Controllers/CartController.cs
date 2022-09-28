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
    public class CartController : ApiController
    {
        private ICartRepository repository;
        public CartController()
        {
            repository = new CartImplementation();
        }


        [System.Web.Http.HttpGet]
        public IHttpActionResult Get(int id)
        {
            var data = repository.GetCart(id);
            return Ok(data);
        }
        [System.Web.Http.ActionName("Add")]
        [System.Web.Http.HttpGet]
        public bool Add(int id,int data)
        {
            Debug.WriteLine("new add");
            var resp = repository.AddToCart(id, data);
            return resp;
        }
        [System.Web.Http.ActionName("Delete")]
        [System.Web.Http.HttpGet]
        public bool Delete(int id, int data)
        {
            Debug.WriteLine("new delete");
            var resp = repository.RemoveFromCart(id, data);
            return resp;
        }
    }
}
