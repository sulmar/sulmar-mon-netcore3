using Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/products")]
    public class ProductsController
    {
        private IProductRepository productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        // GET api/products
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            IEnumerable<Product> products = productRepository.Get();

            return products;
        }



        // GET api/products/{id}
        [HttpGet("{id}", Name = "GetProductById")]
        public ActionResult<Product> Get(int id)
        {
            var product = productRepository.Get(id);

            if (product == null)
                return new NotFoundResult();

            return new OkObjectResult(product);

        }


        // GET api/customers?City=Warsaw&Street=Dworcowa

        // GET api/customers/{country}/{city}

        // GET api/customers/{id}/orders

        // GET posts/net-core/fundamentals/hello-world


        // POST api/customers
        // {customer}
        [HttpPost]
        public ActionResult<Product> Post([FromBody] Product product)
        {
            productRepository.Add(product);

            return new CreatedAtRouteResult("GetProductById", new { id = product.Id }, product);

        }

        // PUT api/products/{id}
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Product product)
        {
            if (id != product.Id)
                return new BadRequestResult();

            productRepository.Update(product);

            return new NoContentResult();

            // return new OkObjectResult(customer);
        }

        // DELETE api/products/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var product = productRepository.Get(id);

            if (product == null)
                return new NotFoundResult();

            productRepository.Remove(id);

            return new OkResult();
        }

        // GET api/customers/{id}/products
        [HttpGet("/api/customers/{id}/products")]
        public ActionResult<IEnumerable<Product>> GetByCustomer(int id)
        {
            var products = productRepository.GetByCustomer(id);

            return new OkObjectResult(products);

        }
    }
}
