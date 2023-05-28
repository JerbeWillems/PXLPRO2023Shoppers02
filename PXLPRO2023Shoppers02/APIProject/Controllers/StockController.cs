using APIProject.Services;
using Microsoft.AspNetCore.Mvc;
using PXLPRO2023Shoppers02.Models;

namespace APIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IProducts _productsrepo;
        // invoke products interface into constructor
        public StockController(IProducts productsrepo)
        {
            _productsrepo = productsrepo;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<Products> product = _productsrepo.GetAll();
            List<Products> models = product.ToList();
            return Ok(models);
        }
        /*
         * search by id using the GetById function
         * Use the FromProduct function to return only the necessary data in the JSON response
         * */
        [HttpGet("{id}")]
        public IActionResult GetDetails(long id)
        {
            Products product = _productsrepo.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        /*
         * Post: parameter model gets filled in with data from request body (what the user adds in postman/application)
         */
        [HttpPost]
        public IActionResult AddProduct(Products model)
        {
            Products product = new Products
            {
                ProductName = model.ProductName,
                ProductPrice = model.ProductPrice,
                ProductStock = model.ProductStock,
                Category = model.Category,
                ProductImage = model.ProductImage
            };
            _productsrepo.Add(product);
            //make sure we loaded the correct product
            product = _productsrepo.GetById(product.ProductId);
            var outputModel = product;
            return CreatedAtAction("GetDetails", new { id = product.ProductId }, outputModel);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, Products model)
        {
            Products product = _productsrepo.GetById(id); // get the product that we wanna change
            if (product == null)
            {
                return NotFound();
            }
            // give the new values to our product
            product.ProductName = model.ProductName;
            product.ProductPrice = model.ProductPrice;
            product.ProductStock = model.ProductStock;
            product.Category = model.Category;
            product.ProductImage = model.ProductImage;

            _productsrepo.Update(product);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            Products product = _productsrepo.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            _productsrepo.Delete(product);
            return Ok();
        }
    }
}
