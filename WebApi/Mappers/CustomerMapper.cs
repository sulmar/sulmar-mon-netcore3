using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DTOs;

namespace WebApi.Mappers
{
    public class CustomerMapper
    {
        public static CustomerDTO Map(Customer customer) => new CustomerDTO
        {
            Id = customer.Id,
            FirstName = customer.FirstName,
            LastName = customer.LastName
        };

        public static Customer Map(CustomerDTO customerDTO) => new Customer
        {
            Id = customerDTO.Id,
            FirstName = customerDTO.FirstName,
            LastName = customerDTO.LastName,
        };
            

    }
}
