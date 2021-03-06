using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Http;
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
        private readonly IMapper mapper;

        public CustomersDTOController(ICustomerRepository customerRepository, IMapper mapper)
        {
            this.customerRepository = customerRepository;
            this.mapper = mapper;
        }

        // GET api/customers
        [HttpGet]
        public IEnumerable<CustomerDTO> Get()
        {
            IEnumerable<Customer> customers = customerRepository.Get();

            var result = mapper.Map<IEnumerable<CustomerDTO>>(customers);

            //var result = customers
            //    .Select(customer => CustomerMapper.Map(customer));

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

            // CustomerDTO customerDTO = CustomerMapper.Map(customer);

            CustomerDTO customerDTO = mapper.Map<CustomerDTO>(customer);

            return customerDTO;
        }

        // POST api/customers
        // {customer}
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesDefaultResponseType]
        public ActionResult<Customer> Post([FromBody] CustomerDTO customerDTO)
        {
            if (ModelState.IsValid)
            {
                customerRepository.Add(CustomerMapper.Map(customerDTO));                

                return new CreatedAtRouteResult("GetCustomerById", new { id = customerDTO.Id }, customerDTO);

            }
            else
            {
                return new BadRequestObjectResult(ModelState);
            }
        }
    }
}
