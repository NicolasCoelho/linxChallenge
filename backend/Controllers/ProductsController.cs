using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using backend.Data;
using backend.Mappers;
using backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {

        private readonly BackendContext Context;
        private readonly IMapper Mapper;

        public ProductsController(BackendContext context, IMapper mapper) {
            Context = context;
            Mapper = mapper;
        }

        [HttpGet]
        public  ActionResult<IEnumerable<ProductsReadMapper>> GetAll()
        {
            var list = Context.Products.ToList(); 

            return Ok( Mapper.Map<IEnumerable<ProductsReadMapper>>(list) );
        }

        [HttpGet("{id}")]
        public ActionResult<ProductsReadMapper> GetOne(int id)
        {
            var product =  Context.Products.FirstOrDefault( product => product.id == id);
            if(product != null) {
                return Ok( Mapper.Map<ProductsReadMapper>(product) );
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<ProductsCreateMapper> CreateOne(ProductsCreateMapper mapperProduct)
        {
            if (mapperProduct == null) {
                throw new ArgumentNullException();
            }

            var product = Mapper.Map<Products>(mapperProduct);

            Context.Products.Add(product);
            Context.SaveChanges();

            return Ok(product);
        }

        [HttpPut("{id}")]
        public ActionResult<ProductsUpdateMapper> ChangeOne(int id, ProductsUpdateMapper mapperProduct)
        { 

            var product = Mapper.Map<Products>(mapperProduct);

            Context.Products.Update(product);

            Context.SaveChanges();

            return Ok(product);
        }

        [HttpDelete("{id}")]
        public ActionResult<Products> DeleteOne(int id, Products product)
        {
            if(product == null) {
                throw new ArgumentNullException(nameof(product));
            }
            Context.Products.Remove(product);
            
            Context.SaveChanges();

            return NoContent();
        }
    }
}