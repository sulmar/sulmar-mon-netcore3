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
                new Customer { Id = 1, FirstName = "John", LastName = "Smith", Salary = 1000, Pesel = "9434234234324" },
                new Customer { Id = 2, FirstName = "Ann", LastName = "Smith", Salary = 2000, Pesel = "54545454545", Gender = Gender.Female },
                new Customer { Id = 3, FirstName = "Bart", LastName = "Smith", Salary = 500, Pesel = "65657756756", IsRemoved = true },
            };
        }

        public void Add(Customer customer)
        {
            int id = customers.Max(c => c.Id);

            customer.Id = ++id;

            customers.Add(customer);
        }

        public bool Exists(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> Get()
        { 
            return customers;
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
            //Remove(customer.Id);

            //customers.Add(customer);

            Customer existingCustomer = Get(customer.Id);
            existingCustomer.FirstName = customer.FirstName;
            existingCustomer.LastName = customer.LastName;
            existingCustomer.Gender = customer.Gender;
            existingCustomer.Salary = customer.Salary;
            existingCustomer.Pesel = customer.Pesel;
        }
    }
}
