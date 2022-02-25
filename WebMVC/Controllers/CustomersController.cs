using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMVC.Controllers
{

    // GET localhost:5001/customers/index
    [Authorize(Roles = "Developer, Trainer")]
    public class CustomersController : Controller
    {
        private readonly ICustomerRepository customerRepository;

        public CustomersController(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public IActionResult Index()
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                return Unauthorized();
            }

            var customers = customerRepository.Get();

            return View(customers);
        }

        [AllowAnonymous]
        public IActionResult About()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            var customer = customerRepository.Get(id);

            return View(customer);
        }

        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                customerRepository.Update(customer);

                return RedirectToAction("Index", new { id = customer.Id });
            }
            else
            {
                return View(customer);
            }
        }

        // GET Customers/Delete/{id}
        public IActionResult Delete(int id)
        {
            var customer = customerRepository.Get(id);

            return View(customer);
        }

        // POST Customers/Delete/{id}
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            customerRepository.Remove(id);

            return RedirectToAction("Index");
        }

        

    }
}
