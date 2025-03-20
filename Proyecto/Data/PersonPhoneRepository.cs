using Proyecto.Entities;
using Proyecto.Interface;
using Microsoft.EntityFrameworkCore;

namespace Proyecto.Data
{
    public class PersonPhoneRepository : IPersonPhoneRepository
    {
        private readonly AddDbContext _context;

        public PersonPhoneRepository(AddDbContext context) //AppDbContext?
        {
            _context = context;
        }

        //public async Task<Customer> GetCustomerByIdAsync(int id) => await _context.Customer.FindAsync(id);


        public async Task<IEnumerable<PersonPhone>> GetCustomersAsync() => await _context.PersonPhone.Take(100).ToListAsync();
        /*private readonly AddDbContext _context;

        public PersonPhoneRepository(AddDbContext context) { 
            _context = context;
        }
        public async Task<PersonPhone> GetPersonPhoneByIdAsync(int id) => 
            await _context.PersonPhone.FindAsync(id);

        public async Task<PersonPhone>
        {
            //_context.PerosnPhone.FindAsync(id);
            await _context.SaveChangesAsync ();

           return PersonPhone;
        }
    }*/
    }
}
