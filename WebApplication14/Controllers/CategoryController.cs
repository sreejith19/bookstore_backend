using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

using WebApplication14.Models;

namespace WebApplication14.Controllers
{
    public class CategoryController : ApiController
    {
        // GET: Category
        private ICategoryrepository repository;

        public CategoryController()
        {
            repository = new CategoryImplementation();
        }
        [System.Web.Http.HttpGet]
        public IHttpActionResult Get()
        {
            var data = repository.getAll();
            return Ok(data); 
        }
        public IHttpActionResult Get(int id)
        {
            var data = repository.getCategoryById(id);
            return Ok(data);
        }
        //[System.Web.Http.Route("Add")]
        [System.Web.Http.ActionName("Add")]
        [System.Web.Http.HttpPost]
        public IHttpActionResult Add([FromBody] Category category)
        {
            Debug.WriteLine("new add");
            int data = repository.addCategory(category);
            return Ok(data);
        }
        //[System.Web.Http.Route("Edit")]
        [System.Web.Http.ActionName("Edit")]
        [System.Web.Http.HttpPost]
        public IHttpActionResult Edit([FromBody] Category category)
        {
            Debug.WriteLine("new edit");
            int data = repository.editCategory(category);
            return Ok(data);
        }
        [System.Web.Http.ActionName("Enable")]
        [System.Web.Http.HttpPost]
        public IHttpActionResult Enable([FromBody] int id)
        {
            Debug.WriteLine("new enable");
            bool data = repository.Enable(id);
            return Ok(data);
        }
        [System.Web.Http.ActionName("Disable")]
        [System.Web.Http.HttpPost]
        public IHttpActionResult Disable([FromBody] int id)
        {
            Debug.WriteLine("new disable");
            bool data = repository.Disable(id);
            return Ok(data);
        }
        [System.Web.Http.ActionName("Delete")]
        [System.Web.Http.HttpPost]
        public IHttpActionResult Delete([FromBody] int id)
        {
            Debug.WriteLine("new delete");
            int data = repository.deleteCategoryById(id);
            return Ok(data);
        }
    }
}