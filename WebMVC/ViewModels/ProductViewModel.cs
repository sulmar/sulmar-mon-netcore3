using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMVC.ViewModels
{
    public abstract class BaseViewModel
    {

    }

    public class ProductViewModel : BaseViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
        public string BrandName { get; set; }
        public Size Size { get; set; }

        public string GetSize()
        {
            return new string('*', (int) Size);
        }
    }
}
