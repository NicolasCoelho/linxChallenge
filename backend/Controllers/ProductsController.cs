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
        public  ActionResult<IEnumerable<Products>> GetAll()
        {
            return Ok(Enumerable.Range(1, 5).Select(index => new Products
            {
                name = "Relogio",
                code = "12313212",
                price = 10000,
                image = "",
                createdAt = new DateTime()
            })
            .ToArray());
        }

        [HttpGet("{id}")]
        public ActionResult<Products> GetOne()
        {
            return Ok(new Products
            {
                name = "Relogio",
                code = "12313212",
                price = 10000,
                image = ""
            });
        }

        [HttpPut("{id}")]
        public ActionResult<Products> ChangeOne()
        {
            return Ok(new Products
            {
                name = "Relogio",
                code = "12313212",
                price = 10000,
                image = ""
            });
        }

        [HttpDelete("{id}")]
        public ActionResult<Products> DeleteOne()
        {
            return Ok(new Products
            {
                name = "Relogio",
                code = "12313212",
                price = 10000,
                image = ""
            });
        }
    }
}