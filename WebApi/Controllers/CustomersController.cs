﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Domain;

namespace WebApi.Controllers
{
    [Route("api/customers")]
    public class CustomersController
    {
        private ICustomerRepository customerRepository;

        public CustomersController(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }


        // GET api/customers
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            IEnumerable<Customer> customers = customerRepository.Get();

            return customers;
        }

        // GET api/customers/{id}
        [HttpGet("{id}", Name = "GetCustomerById")]
        public ActionResult<Customer> Get(int id)
        {
            Customer customer = customerRepository.Get(id);

            if (customer == null)
                return new NotFoundResult();

            return new OkObjectResult(customer);

        }


        // GET api/customers?City=Warsaw

        // GET api/customers/{country}/{city}

        // GET api/customers/{id}/orders

        // GET posts/net-core/fundamentals/hello-world
        

        // POST api/customers
        // {customer}
        [HttpPost]
        public ActionResult<Customer> Post([FromBody] Customer customer)
        {
            customerRepository.Add(customer);

            // return new CreatedResult($"https://localhost:5001/api/customers/{customer.Id}", customer);

            return new CreatedAtRouteResult("GetCustomerById", new { id = customer.Id }, customer);

        }

        // PUT api/customers/{id}
        [HttpPut("{id}")]
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
    }
}
