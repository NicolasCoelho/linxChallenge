using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using backend.Data;
using backend.Interfaces;
using backend.Mappers;
using backend.Models;
using backend.Services;
using backend.Utilities;
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

        [HttpGet()]
        public  ActionResult<IProductsPagination> GetAll(int page = 1, string ?target = null, string ?type = "name", string ?priceOrder = null)
        {

            var query = (from Products in Context.Products select Products);

            if (!string.IsNullOrEmpty(target)) {
                if (type == "name") {
                    query = query.Where(p => p.name.Contains(target));
                } else if(type == "code"){
                    query = query.Where(p => p.code.Contains(target));
                } else {
                    query = query.Where(p => p.name.Contains(target));
                }
            }
            
            if (!string.IsNullOrEmpty(priceOrder)) {
                if (priceOrder == "asc") {
                    query = query.OrderBy(p => p.price);
                } else {
                    query = query.OrderByDescending(p => p.price);
                }
            } else {
                query = query.OrderBy(p => p.id);
            }

            var pageTarget = page == 0 ? 1 : (int)page; 

            double total = (double)Context.Products.Count();
            double itemsPerPage = (double)10;

            total = (int) Math.Ceiling( (double)(total / itemsPerPage) );
            total = total == 0 ? 1 : total;

            var items = query
            .Take((int)itemsPerPage)
            .Skip((pageTarget - 1) * (int)itemsPerPage)
            .ToList();

            var response = new { totalPages = total, items };

            return Ok(response);
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

            FilesUtilities myFiles = new FilesUtilities();

            string filename = myFiles.WriteImage(product.image);

            product.image = filename;

            Context.Products.Add(product);

            Context.SaveChanges();

            FakeStore fakeStore = new FakeStore();
            fakeStore.AddProduct(product);

            return Ok(product);
        }

        [HttpPut("{id}")]
        public ActionResult<ProductsUpdateMapper> ChangeOne(int id, ProductsUpdateMapper mapperProduct)
        { 

            var product = Context.Products.Find(id);

            if(product == null) {
                return NotFound();
            }
            
            if (mapperProduct.image.Length > 50) {
                FilesUtilities myFiles = new FilesUtilities();

                string filename = myFiles.WriteImage(mapperProduct.image, product.image);

                mapperProduct.image = filename;
            }

            Context.Entry(product).CurrentValues.SetValues(mapperProduct);

            Context.SaveChanges();

            product.image = mapperProduct.image;

            FakeStore fakeStore = new FakeStore();
            fakeStore.UpdateProduct(id, product);

            return Ok(mapperProduct);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteOne(int id)
        {
            var product = Context.Products.FirstOrDefault(p => p.id == id);
            if(product == null) {
                throw new ArgumentNullException(nameof(id));
            }
            
            FilesUtilities myFiles = new FilesUtilities();
            myFiles.DeleteImage(product.image);

            Context.Products.Remove(product);
            Context.SaveChanges();

            FakeStore fakeStore = new FakeStore();
            fakeStore.DeleteProduct(id);

            return NoContent();
        }
    }
}