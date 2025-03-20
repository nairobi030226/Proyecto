using Microsoft.AspNetCore.Mvc;
using Proyecto.Data;
using Proyecto.Entities;
using Microsoft.EntityFrameworkCore;

namespace Proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonPhoneController: ControllerBase
    {
        private readonly AddDbContext _context;

        public PersonPhoneController(AddDbContext context)
        {
            _context = context;
        }

        // Obtener todos los productos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonPhone>>> GetProducts()
        {
            return await _context.PersonPhone.ToListAsync();
        }

        // Obtener un producto por ID
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonPhone>> GetProduct(int id)
        {
            var product = await _context.PersonPhone.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return product;
        }
    }
}
