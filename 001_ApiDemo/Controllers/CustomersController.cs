using _001_ApiDemo.Context;
using _001_ApiDemo.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace _001_ApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ApiContext _context;
        public CustomersController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult CustomerList()
        {
            var values = _context.Customers.ToList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return Ok("Ekleme İşlemi Gerçekleştirildi");
        }
        [HttpDelete]
        public IActionResult DeleteCustomer(int id)
        {
            var values = _context.Customers.Find(id);
            _context.Customers.Remove(values);
            _context.SaveChanges();
            return Ok("Başarı ile silindi");
        }

        [HttpGet("GetById")]
        public IActionResult GetCustomerById(int id)
        {
            var values = _context.Customers.Find(id);
            return Ok(values);
        }
        [HttpPut]
        public IActionResult UpdateCustomer(Customer customer)
        {
            _context.Customers.Update(customer);
            _context.SaveChanges();
            return Ok("Başarı ile Güncellendi");
        }
    }
}
