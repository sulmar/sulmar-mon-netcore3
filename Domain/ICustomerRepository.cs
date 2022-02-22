using Domain.SearchCriterias;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public interface ICustomerRepository : IEntityRepository<Customer>
    {
        Customer Get(string pesel);

        // IEnumerable<Customer> Get(string country, string city, string street);

        IEnumerable<Customer> Get(CustomerSearchCriteria searchCriteria);
    }



}
