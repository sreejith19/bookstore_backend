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
    public class CouponController : ApiController
    {
        private ICouponRepository repository;
        public CouponController()
        {
            repository = new CouponImplementation();
        }
        [System.Web.Http.HttpGet]
        public IHttpActionResult Get()
        {
            var data = repository.GetAll();
            return Ok(data);
        }
        public IHttpActionResult Get(int id)
        {
            var data = repository.GetCouponById(id);
            return Ok(data);
        }
        public IHttpActionResult Get(string value)
        {
            var data = repository.GetCouponByCode(value);
            return Ok(data);
        }
        [System.Web.Http.ActionName("Add")]
        [System.Web.Http.HttpPost]
        public IHttpActionResult Add([FromBody] Coupon coupon)
        {
            Debug.WriteLine("new add");
            Debug.WriteLine(coupon.couponId);
            int data = repository.Add(coupon);
            return Ok(data);
        }
        [System.Web.Http.ActionName("Edit")]
        [System.Web.Http.HttpPost]
        public IHttpActionResult Edit([FromBody] Coupon coupon)
        {
            Debug.WriteLine("new edit");
            int data = repository.Edit(coupon);
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
            int data = repository.Delete(id);
            return Ok(data);
        }
    }
}
