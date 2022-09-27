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
        public int Add([FromBody] Category category)
        {
            Debug.WriteLine("new add");
            var data = repository.addCategory(category);
            return data;
        }
        //[System.Web.Http.Route("Edit")]
        [System.Web.Http.ActionName("Edit")]
        [System.Web.Http.HttpPost]
        public int Edit([FromBody] Category category)
        {
            Debug.WriteLine("new edit");
            var data = repository.editCategory(category);
            return data;
        }
        [System.Web.Http.ActionName("Delete")]
        [System.Web.Http.HttpPost]
        public int Delete([FromBody] int id)
        {
            Debug.WriteLine("new delete");
            var data = repository.deleteCategoryById(id);
            return data;
        }
    }
}