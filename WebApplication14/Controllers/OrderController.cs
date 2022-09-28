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
    public class OrderController : ApiController
    {
        private IOrderRepository repository;
        public OrderController()
        {
            repository = new OrderImplementation();
        }

        [System.Web.Http.HttpGet]
        public IHttpActionResult Get()
        {
            var data = repository.GetAll();
            return Ok(data);
        }

        [System.Web.Http.HttpGet]
        public IHttpActionResult Get(int id)
        {
            var data = repository.GetOrderById(id);
            return Ok(data);
        }

        [System.Web.Http.ActionName("User")]
        [System.Web.Http.HttpGet]
        public IHttpActionResult GetUserId(int id)
        {
            var data = repository.GetOrderByUserId(id);
            return Ok(data);
        }

        [System.Web.Http.ActionName("Place")]
        [System.Web.Http.HttpPost]
        public int Add([FromBody] Order order)
        {
            Debug.WriteLine("new add");
            int data = repository.Place(order);
            return data;
        }
        [System.Web.Http.ActionName("Edit")]
        [System.Web.Http.HttpPost]
        public int Edit([FromBody] Order order)
        {
            Debug.WriteLine("new edit");
            int data = repository.Edit(order);
            return data;
        }
        [System.Web.Http.ActionName("Delete")]
        [System.Web.Http.HttpPost]
        public int Delete([FromBody] Order order)
        {
            Debug.WriteLine("new delete");
            var data = repository.Delete(order);
            return data;
        }
        [System.Web.Http.ActionName("GetId")]
        [System.Web.Http.HttpPost]
        public int GetOrderId([FromBody]Order order)
        {
            var data = repository.GetOrderId(order);
            return data;
        }

        [System.Web.Http.ActionName("Enable")]
        [System.Web.Http.HttpPost]
        public bool Enable([FromBody]int id)
        {
            var data = repository.Enable(id);
            return data;
        }
        [System.Web.Http.ActionName("Disable")]
        [System.Web.Http.HttpPost]
        public bool Disable([FromBody]int id)
        {
            var data = repository.Disable(id);
            return data;
        }
    }
}
