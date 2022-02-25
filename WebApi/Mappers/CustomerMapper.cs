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
            //FirstName = customer.FirstName,
            //LastName = customer.LastName

            FullName = $"{customer.FirstName} {customer.LastName}"
        };

        // Tuple (krotki)
        public static (string firstName, string lastName) Extract(string fullName)
        {
            var names = fullName.Split(' ');

            return (names[0], names[1]);
        }

        public static Customer Map(CustomerDTO customerDTO)
        {
            var names = Extract(customerDTO.FullName);

            var customer = new Customer
            {
                Id = customerDTO.Id,
                FirstName = names.firstName,
                LastName = names.lastName,
            };

            return customer;
        }
    }
}
