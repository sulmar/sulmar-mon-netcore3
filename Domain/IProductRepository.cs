using System.Collections.Generic;

namespace Domain
{
    public interface IProductRepository : IEntityRepository<Product>
    {
        IEnumerable<Product> Get(string color);
    }



}
