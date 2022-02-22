using Domain;
using Domain.SearchCriterias;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastucture
{

    public class FakeCustomerRepository : ICustomerRepository
    {
        private ICollection<Customer> customers;

        public FakeCustomerRepository()
        {
            customers = new List<Customer>()
            {
                new Customer { Id = 1, FirstName = "John", LastName = "Smith"},
                new Customer { Id = 2, FirstName = "Ann", LastName = "Smith"},
                new Customer { Id = 3, FirstName = "Bart", LastName = "Smith"},
            };
        }

        public void Add(Customer customer)
        {
            int id = customers.Max(c => c.Id);

            customer.Id = ++id;

            customers.Add(customer);
        }

        public IEnumerable<Customer> Get()
        { 
            return customers
                .Where(c => c.Gender == Gender.Man)
                .OrderBy(c => c.FirstName)
                .ThenBy(c => c.LastName);
        }

        public Customer Get(int id)
        {
            Customer customer = customers.SingleOrDefault(c => c.Id == id);

            //Customer customer = null;

            //foreach (Customer c in customers)
            //{
            //    if (c.Id == id)
            //    {
            //        customer = c;

            //        break;
            //    }
            //}

            return customer;

        }

        public Customer Get(string pesel)
        {
            return customers.SingleOrDefault(c => c.Pesel == pesel);
        }

        //public IEnumerable<Customer> Get(string city, string street)
        //{
        //    return customers
        //        .Where(c => c.ShipAddress.City == city)
        //        .Where(c => c.ShipAddress.Street == street);

        //}

        public IEnumerable<Customer> Get(CustomerSearchCriteria searchCriteria)
        {
            IQueryable<Customer> query = customers.AsQueryable();

            if (!string.IsNullOrEmpty(searchCriteria.City))
            {
                query = query.Where(c => c.ShipAddress.City == searchCriteria.City);
            }

            if (!string.IsNullOrEmpty(searchCriteria.Street))
            {
                query = query.Where(c => c.ShipAddress.Street == searchCriteria.Street);
            }

            return customers.ToList();
                
                
        }

        public void Remove(int id)
        {
            customers.Remove(Get(id));
        }

        public void Update(Customer customer)
        {
            Remove(customer.Id);

            customers.Add(customer);
        }
    }
}
