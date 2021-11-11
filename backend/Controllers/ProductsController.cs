using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Data;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {

        private readonly BackendContext Context;

        public ProductsController(BackendContext context) {
            Context = context;
        }

        [HttpGet]
        public  ActionResult<IEnumerable<Products>> GetAll()
        {
            return Ok(Context.Products.ToList());
        }

        [HttpGet("{id}")]
        public ActionResult<Products> GetOne(int id)
        {
            var product =  Ok(Context.Products.FirstOrDefault( product => product.id == id));
            if(product != null) {
                return product;
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult CreateOne(Products product)
        {
            if (product == null) {
                throw new ArgumentNullException();
            }
            product.createdAt = DateTime.Now;

            Context.Add(product);
            Context.SaveChanges();

            return Ok(product);
        }

        [HttpPut("{id}")]
        public ActionResult<Products> ChangeOne(int id, Products product)
        { 
            Context.Products.Update(product);

            Context.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<Products> DeleteOne(int id, Products product)
        {
            if(product == null) {
                throw new ArgumentNullException(nameof(product));
            }
            Context.Products.Remove(product);
            
            Context.SaveChanges();

            return Ok();
        }
    }
}