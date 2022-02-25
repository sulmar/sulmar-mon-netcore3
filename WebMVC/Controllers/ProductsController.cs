using Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMVC.ViewModels;

namespace WebMVC.Controllers
{
    public class ProductsController : Controller
    {
        private IProductRepository productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public IActionResult Index()
        {
            var products = productRepository.Get();

            return View(products);
        }

        //public IActionResult Edit(int id)
        //{
        //    var product = productRepository.Get(id);

        //    ProductViewModel productViewModel = new ProductViewModel()
        //    {
                
        //    };
        //}
    }
}
