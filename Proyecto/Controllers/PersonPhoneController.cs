using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto.Data;
using Proyecto.Entities;
using Proyecto.Interface;

namespace Proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonPhoneController : ControllerBase
    {
        private readonly IPersonPhoneRepository _repository;

        public PersonPhoneController(IPersonPhoneRepository repository)
        {
            _repository = repository;
        }

        //[HttpGet("{id}")]
        //public async Task<ActionResult<Customer>> GetCustomerById(int id)
        //{
        //    var customer = await _repository.GetCustomerByIdAsync(id);
        //    if (customer == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(customer);
        //}

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonPhone>>> GetCustomers()
        {
            var customers = await _repository.GetCustomersAsync();
            return Ok(customers);
        }

        //[HttpPost]
        //public async Task<ActionResult<Customer>> CreateCustomer(Customer customer)
        //{
        //    var createdCustomer = await _repository.CreateCustomerAsync(customer);
        //    return CreatedAtAction(nameof(GetCustomerById), new { id = createdCustomer.CustomerID }, createdCustomer);
        //}

        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateCustomer(int id, Customer customer)
        //{
        //    if (id != customer.CustomerID)
        //    {
        //        return BadRequest();
        //    }

        //    var result = await _repository.UpdateCustomerAsync(customer);
        //    if (!result)
        //    {
        //        return NotFound();
        //    }

        //    return NoContent();
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteCustomer(int id)
        //{
        //    var result = await _repository.DeleteCustomerByIdAsync(id);
        //    if (!result)
        //    {
        //        return NotFound();
        //    }

        //    return NoContent();
        //}
    }
}
