using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using StopAppAPI.DAL;
using StopAppAPI.Repository;

namespace StopAppAPI.Controllers
{
    public class ProductsController : ApiController
    {
        private StoreAppEntities db = new StoreAppEntities();

        public GenericUnitOfWork _unitOfWork = new GenericUnitOfWork();
        // GET: api/Products
        public IQueryable<Product> GetProducts()
        {
            return _unitOfWork.GetRepositoryInstance<Product>().GetProductIQueryalbe();
        }


      
        // GET: api/Products/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult GetProduct(int productId)
        {
            return (IHttpActionResult)_unitOfWork.GetRepositoryInstance<Product>().GetFirstofDefaultByParameter(productId);
          
        }

        // PUT: api/Products/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProduct(int id, Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.ProductId)
            {
                return BadRequest();
            }

            db.Entry(product).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Products
        [ResponseType(typeof(Product))]
        public IHttpActionResult PostProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
             

            product.ModifiedDate = DateTime.Now;
            product.Discription = DateTime.Now;
            product.isActive = true;
            product.isFeatured = true;
            product.isDeleted = false;
            _unitOfWork.GetRepositoryInstance<Product>().Add(product);
         
            return CreatedAtRoute("DefaultApi", new { id = product.ProductId }, product);
        }

        // DELETE: api/Products/5d  c  c 
        [ResponseType(typeof(Product))]
        public IHttpActionResult DeleteProduct(int id)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            db.Products.Remove(product);
            db.SaveChanges();

            return Ok(product);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductExists(int id)
        {
            return db.Products.Count(e => e.ProductId == id) > 0;
        }
    }
}