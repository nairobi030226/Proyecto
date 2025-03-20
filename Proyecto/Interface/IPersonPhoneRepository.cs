using Proyecto.Data;
using Proyecto.Entities;

namespace Proyecto.Interface
{
    public interface IPersonPhoneRepository
    {
        Task<IEnumerable<PersonPhone>> GetCustomersAsync();
    }
}