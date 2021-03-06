using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Domain;
using System;
using Domain.SearchCriterias;
using Microsoft.AspNetCore.Http;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/customers")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository customerRepository;

        public CustomersController(
            ICustomerRepository customerRepository
            )
        {
            this.customerRepository = customerRepository;
        }

        [HttpGet("/api/ping")]
        public ActionResult<string> Ping()
        {
            return "Pong";
        }


        // GET api/customers
        //[HttpGet]
        //public IEnumerable<Customer> Get()
        //{
        //    IEnumerable<Customer> customers = customerRepository.Get();

        //    return customers;
        //}


        // Route Constraints (reguły tras)
        // https://docs.microsoft.com/pl-pl/aspnet/core/fundamentals/routing?view=aspnetcore-6.0#route-constraints

        // GET api/customers/{pesel}
        [HttpGet("{pesel:length(11):required}", Name = "GetCustomerByPesel")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public ActionResult<Customer> Get(string pesel)
        {
            Customer customer = customerRepository.Get(pesel);

            if (customer == null)
                return new NotFoundResult();

            return new OkObjectResult(customer);
        }

        // GET api/customers/{id}
        [HttpGet("{id:int:maxlength(10)}", Name = "GetCustomerById")]
        [ProducesResponseType(typeof(Customer), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Customer> Get(int id)
        {
            Customer customer = customerRepository.Get(id);

            if (customer == null)
                return new NotFoundResult();

            return new OkObjectResult(customer);
        }

        // Query params
        // GET api/customers?City=Warsaw&Street=Dworcowa

        [HttpGet]
        public ActionResult<IEnumerable<Customer>> Get([FromQuery] CustomerSearchCriteria searchCriteria)
        {
            var customers = customerRepository.Get(searchCriteria);

            return new OkObjectResult(customers);
        }

        // GET api/customers/{country}/{city}

        // GET api/customers/{id}/orders

        // GET posts/net-core/fundamentals/hello-world


        // POST api/customers
        // {customer}
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesDefaultResponseType]
        public ActionResult<Customer> Post([FromServices] IMessageService messageService, [FromBody] Customer customer)
        {
            if (ModelState.IsValid)
            {
                customerRepository.Add(customer);

                // return new CreatedResult($"https://localhost:5001/api/customers/{customer.Id}", customer);

                messageService.Send($"Hello {customer.FirstName}!");

                return new CreatedAtRouteResult("GetCustomerById", new { id = customer.Id }, customer);

            }
            else
            {
                return new BadRequestObjectResult(ModelState);
            }
        }

        // PUT api/customers/{id}
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public ActionResult Put(int id, [FromBody] Customer customer)
        {
            if (id != customer.Id)
                return new BadRequestResult();

            customerRepository.Update(customer);

            return new NoContentResult();

           // return new OkObjectResult(customer);
        }

        // DELETE api/customers/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Customer customer = customerRepository.Get(id);

            if (customer == null)
                return new NotFoundResult();

            customerRepository.Remove(id);

            return new OkResult();
        }

        [HttpHead("{id}")]
        public ActionResult Head(int id)
        {
            if (customerRepository.Exists(id))
                return new OkResult();
            else
                return new NotFoundResult();
        }
      

    }
}
