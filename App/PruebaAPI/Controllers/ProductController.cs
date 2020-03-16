using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaAPI.Models;
using PruebaDB.Models;
using PruebaDB.Repositories.Product;

namespace PruebaAPI.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private IProductRepository _rep;
        public ProductController(IProductRepository rep)
        {
            _rep = rep;
        }

        [HttpPost("SaveProduct")]
        public IActionResult SaveProduct([FromBody]Product product)
        {
            try
            {
                return Ok(_rep.SaveProduct(new product
                {
                    code = product.Code,
                    description = product.Description,
                    name = product.Name,
                    price = product.Price,
                    units = product.Units

                }));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetProducts")]
        public IActionResult GetProducts()
        {
            try
            {
                return Ok(_rep.GetList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}