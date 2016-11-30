using otlnal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace otlnal.Controllers
{
    [RoutePrefix("api/product")]
    public class ProductController : ApiController
    {
        private DbModel _dbModel = DbModel.Create();

        public HttpResponseMessage Get()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, _dbModel.Products.Include("Type"));
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        public HttpResponseMessage Post(ProductViewModel product)
        {
            try
            {
                var p = _dbModel.Products.Find(product.Id);
                p.Name = product.Name;
                p.Count = product.Count;
                var t = _dbModel.ProductTypes.Find(product.Type);
                p.Type = t;
                _dbModel.Entry(p).State = System.Data.Entity.EntityState.Modified;
                _dbModel.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        [Route("types")]
        [HttpGet]
        public HttpResponseMessage GetType()
        {
            try
            {                
                return Request.CreateResponse(HttpStatusCode.OK, _dbModel.ProductTypes);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }
    }
}