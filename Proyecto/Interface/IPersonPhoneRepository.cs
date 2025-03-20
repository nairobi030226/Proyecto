/*using Proyecto.Data;
using Proyecto.Entities;

namespace Proyecto.Interface
{
    public interface IPersonPhoneRepository
    {
        private readonly AddDbContext _context;

        public PersonPhoneRepository(AddDbContext context)
        {
            _context = context;
        }

        public async Task<PersonPhone> GetPersonPhoneByIdAsync(int id)
        {
            return await _context.PersonPhone.FindAsync(id);
        }
        Task<PersonPhone> GetCustomerByIdAsync(int id);
        Task<IEnumerable<PersonPhone>> GetCustomerAsync();
        Task<PersonPhone> GetCustomerCountAsync(PersonPhone PersonPhone);

        Task<bool> UpdateCustomerAsync(PersonPhone PersonPhone);

        Task<bool> DeleteCustomerByIdAsync(int id);
    }
}*/