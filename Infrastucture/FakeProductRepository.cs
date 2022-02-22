using Bogus;
using Domain;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;

namespace Infrastucture
{
    public class FakeProductRepositoryOptions
    {
        public int Count { get; set; }
    }

    public class FakeProductRepository : FakeEntityRepository<Product>, IProductRepository
    {
        public FakeProductRepository(Faker<Product> faker, IOptions<FakeProductRepositoryOptions> options)
            : base()
        {
            entities = faker.Generate(options.Value.Count);
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
