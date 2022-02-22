using Bogus;
using Domain;
using System.Collections.Generic;
using System.Linq;

namespace Infrastucture
{
    public class FakeProductRepository : FakeEntityRepository<Product>, IProductRepository
    {
        public FakeProductRepository(Faker<Product> faker)
            : base()
        {
            entities = faker.Generate(100);
        }

        public IEnumerable<Product> Get(string color)
        {
            return entities.Where(p => p.Color == color);
        }

        public IEnumerable<Product> GetByCustomer(int customerId)
        {
            throw new System.NotImplementedException();
        }
    }
}
