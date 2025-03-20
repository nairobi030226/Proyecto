/*using Proyecto.Entities;
//using Proyecto.Entities.PersonPhone;
using Proyecto.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace Proyecto.Data
{
    public class PersonPhoneRepository : IPersonPhoneRepository
    {
        private readonly AddDbContext _context;

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
        
            
        
    
    }
}¨*/
