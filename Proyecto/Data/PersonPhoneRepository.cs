using Proyecto.Entities;
using Proyecto.Interface;
using Microsoft.EntityFrameworkCore;

namespace Proyecto.Data
{
    // Repositorio para manejar operaciones en la base de datos relacionadas con PersonPhone
    public class PersonPhoneRepository : IPersonPhoneRepository
    {
        private readonly AddDbContext _context;

        // Constructor que recibe el contexto de la base de datos para operar sobre ella
        public PersonPhoneRepository(AddDbContext context) //AppDbContext?
        {
            _context = context;
        }

        //public async Task<PersonPhone> GetCustomerByIdAsync(int id) => await _context.PersonPhone.FindAsync(id);

        // MÉTODO PARA OBTENER UNA LISTA DE HASTA 100 REGISTROS DE TELÉFONOS
        public async Task<IEnumerable<PersonPhone>> GetPersonPhone()
        {
            var result = new List<PersonPhone> ();
            try
            {
                result = await _context.PersonPhone.Take(100).ToListAsync();
            }
            catch (Exception ex) {
                // Muestra el error en la consola
                //Console.WriteLine(ex.ToString());
                Console.WriteLine($"Error al obtener los datos: {ex.Message}");
                throw; // Esto permite ver el error en la respuesta HTTP para que el cliente la vizualice
            }
            return result;
            
        }

        // MÉTODO PARA OBTENER TODOS LOS TELÉFONOS (MISMO QUE EL ANTERIOR PERO SIN VARIABLE INTERMEDIA)
        public async Task<IEnumerable<PersonPhone>> GetPersonPhoneAsync()
        {
            try
            {
                return await _context.PersonPhone.Take(100).ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener los datos: {ex.Message}");
                throw;
            }
        }

        // MÉTODO PARA OBTENER UN TELÉFONO POR SU ID
        public async Task<PersonPhone> GetPersonPhoneByIdAsync(int id)
        {
            var personPhone = await _context.PersonPhone.FindAsync(id);
            return personPhone ?? throw new KeyNotFoundException("No se encontró el teléfono de la persona.");
        }

        // MÉTODO PARA CREAR UN NUEVO TELÉFONO EN LA BASE DE DATOS
        public async Task<PersonPhone> CreatePersonPhoneAsync(PersonPhone personPhone)
        {
            // Asegurar que ModifiedDate tenga un valor válido antes de guardar
            if (personPhone.modifiedDate == DateTime.MinValue || personPhone.modifiedDate < new DateTime(1753, 1, 1))
            {
                personPhone.modifiedDate = DateTime.UtcNow;
            }
            _context.PersonPhone.Add(personPhone);
            await _context.SaveChangesAsync(); // Guarda los cambios en la base de datos
            return personPhone;
        }

        // MÉTODO PARA ACTUALIZAR UN TELÉFONO EXISTENTE
        public async Task<bool> UpdatePersonPhoneAsync(PersonPhone personPhone)
        {
            _context.Entry(personPhone).State = EntityState.Modified; // Marca el objeto como modificado
            return await _context.SaveChangesAsync() > 0; // Retorna true si la actualización fue exitosa
        }

        // MÉTODO PARA ELIMINAR UN TELÉFONO POR SU ID
        public async Task<bool> DeletePersonPhoneByIdAsync(int id)
        {
            var personPhone = await _context.PersonPhone.FindAsync(id);
            if (personPhone == null) return false; // Retorna false si el teléfono no existe

            _context.PersonPhone.Remove(personPhone);
            return await _context.SaveChangesAsync() > 0;  // Retorna true si se eliminó correctamente
        }
    }
}