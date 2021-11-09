using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {

        public ProductsController() {
            
        }

        [HttpGet]
        public IEnumerable<Products> GetAll()
        {
            return Enumerable.Range(1, 5).Select(index => new Products
            {
                name = "Relogio",
                code = "12313212",
                price = 10000,
                image = ""
            })
            .ToArray();
        }

        [HttpGet("{id}")]
        public Products GetOne()
        {
            return new Products
            {
                name = "Relogio",
                code = "12313212",
                price = 10000,
                image = ""
            };
        }

        [HttpPut("{id}")]
        public Products ChangeOne()
        {
            return new Products
            {
                name = "Relogio",
                code = "12313212",
                price = 10000,
                image = ""
            };
        }

        [HttpDelete("{id}")]
        public Products DeleteOne()
        {
            return new Products
            {
                name = "Relogio",
                code = "12313212",
                price = 10000,
                image = ""
            };
        }
    }
}