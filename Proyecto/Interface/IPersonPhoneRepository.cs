using Proyecto.Data;
using Proyecto.Entities;
using System.Data;
using Proyecto.Interface;

namespace Proyecto.Interface
{
    // Interfaz que define las operaciones para gestionar PersonPhone en la base de datos
    public interface IPersonPhoneRepository : IPersonPhoneSpRepository
    {
        // Método para obtener todos los registros de teléfonos
        Task<IEnumerable<PersonPhone>> GetPersonPhoneAsync();

        // Método para obtener un teléfono por su ID
        Task<PersonPhone> GetPersonPhoneByIdAsync(int id);
        // Método para crear un nuevo teléfono
        Task<PersonPhone> CreatePersonPhoneAsync(PersonPhone personPhone);
        // Método para actualizar un teléfono existente
        Task<bool> UpdatePersonPhoneAsync(PersonPhone personPhone);
        // Método para eliminar un teléfono por su ID
        Task<bool> DeletePersonPhoneByIdAsync(int id);

        //---------------------SE AGREGÓ--------------------
        // Método para actualizar múltiples teléfonos usando un DataTable
        Task PutPersonPhonesBySpAsync(DataTable personPhones);
    }
}