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

        //public async Task<PersonPhone> GetCustomerByIdAsync(int id) => await _context.PersonPhone.FindAsync(id);


        public async Task<IEnumerable<PersonPhone>> GetCustomersAsync()
        {
            var result = new List<PersonPhone> ();
            try
            {
                result = await _context.PersonPhone.Take(100).ToListAsync();
            }
            catch (Exception ex) {
                //Console.WriteLine(ex.ToString());
                Console.WriteLine($"Error al obtener los datos: {ex.Message}");
                throw; // Esto permite ver el error en la respuesta HTTP
            }
            return result;
            
        }
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
