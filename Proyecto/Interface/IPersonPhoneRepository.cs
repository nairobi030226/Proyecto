using Proyecto.Data;
using Proyecto.Entities;

namespace Proyecto.Interface
{
    // Interfaz que define las operaciones para gestionar PersonPhone en la base de datos
    public interface IPersonPhoneRepository
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
    }
}