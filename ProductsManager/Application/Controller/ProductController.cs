using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsManager.Application.Interface;
using ProductsManager.Application.Model;

namespace ProductsManager.Application.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IProductService productService) : ControllerBase
    {
        private readonly IProductService productService = productService;

        [HttpGet]
        public ActionResult<List<Product>> Get()
        {
            return Ok(productService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetById(int id)
        {
            var product = productService.GetById(id);

            if (product is null)
            {
                return NotFound($"Product with Id {id} not found.");
            }

            return Ok(product);
        }

        [HttpPost]
        public ActionResult Post(Product request)
        {
            productService.Create(request);
            return Created();
        }

        [HttpPut]
        public ActionResult Put(int id, Product request)
        {
            var product = productService.Update(id, request);

            if (product is null)
            {
                return NotFound($"Product with Id {id} not found.");
            }

            return Ok(product);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var result = productService.Destroy(id);

            if (result)
            {
                return NotFound($"Product with Id {id} not found.");
            }

            return NoContent();
        }
    }
}