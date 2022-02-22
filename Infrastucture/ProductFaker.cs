using Bogus;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastucture
{
    // Install-Package Bogus
    public class ProductFaker : Faker<Product>
    {
        public ProductFaker()
        {
            RuleFor(p => p.Id, f => f.IndexFaker);
            RuleFor(p => p.Name, f => f.Commerce.ProductName());
            RuleFor(p => p.Color, f => f.Commerce.Color());
            RuleFor(p => p.UnitPrice, f => Math.Round( f.Random.Decimal(100, 1000), 2));
            RuleFor(p => p.Size, f => f.PickRandom<Size>());
            RuleFor(p => p.IsRemoved, f => f.Random.Bool(0.2f));
        }
    }
}
