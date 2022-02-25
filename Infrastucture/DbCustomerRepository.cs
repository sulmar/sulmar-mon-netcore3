using Domain;
using Domain.SearchCriterias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastucture
{
    public class DbCustomerRepository : ICustomerRepository
    {
        private readonly ShopperContext context;

        public DbCustomerRepository(ShopperContext context)
        {
            this.context = context;
        }

        public void Add(Customer entity)
        {
            context.Customers.Add(entity);
            context.SaveChanges();
        }

        public bool Exists(int id)
        {
            return context.Customers.Any(c => c.Id == id);
        }

        public Customer Get(string pesel)
        {
            return context.Customers.SingleOrDefault(c => c.Pesel == pesel);
        }

        public IEnumerable<Customer> Get(CustomerSearchCriteria searchCriteria)
        {
            IQueryable<Customer> query = context.Customers.AsQueryable();

            if (!string.IsNullOrEmpty(searchCriteria.City))
            {
                query = query.Where(c => c.ShipAddress.City == searchCriteria.City);
            }

            if (!string.IsNullOrEmpty(searchCriteria.Street))
            {
                query = query.Where(c => c.ShipAddress.Street == searchCriteria.Street);
            }

            return query.ToList();
        }

        public IEnumerable<Customer> Get()
        {
            return context.Customers.ToList();
        }

        public Customer Get(int id)
        {
            return context.Customers.Find(id);
        }

        public void Remove(int id)
        {
            context.Customers.Remove(Get(id));
            context.SaveChanges();
        }

        public void Update(Customer entity)
        {
            context.Customers.Update(entity);
            context.SaveChanges();
        }
    }
}
