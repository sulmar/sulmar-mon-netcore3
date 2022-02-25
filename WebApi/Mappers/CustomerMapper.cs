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
            FirstName = customer.FirstName,
            LastName = customer.LastName
        };
    }
}
