using Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DTOs;
using WebApi.Mappers;

namespace WebApi.Controllers
{
    [Route("api/customers")]
    public class CustomersDTOController : ControllerBase
    {
        private readonly ICustomerRepository customerRepository;

        public CustomersDTOController(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        // GET api/customers
        [HttpGet]
        public IEnumerable<CustomerDTO> Get()
        {
            IEnumerable<Customer> customers = customerRepository.Get();

            var result = customers
                .Select(customer => CustomerMapper.Map(customer));

            //ICollection<CustomerDTO> result = new List<CustomerDTO>();

            //foreach (Customer customer in customers)
            //{
            //    CustomerDTO customerDTO = CustomerMapper.Map(customer);

            //    result.Add(customerDTO);
            //}

            return result;
        }

        // GET api/customers/{id}
        [HttpGet("{id}")]
        public CustomerDTO Get(int id)
        {
            Customer customer = customerRepository.Get(id);

            CustomerDTO customerDTO = CustomerMapper.Map(customer);

            return customerDTO;
        }
    }
}
