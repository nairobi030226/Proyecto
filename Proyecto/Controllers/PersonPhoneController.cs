using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto.Data;
using Proyecto.Entities;
using Proyecto.Interface;

namespace Proyecto.Controllers
{
    //Define la ruta base del controlador como "api/personphone"
    [Route("api/[controller]")]
    [ApiController]
    public class PersonPhoneController : ControllerBase
    {
        private readonly IPersonPhoneRepository _repository;

        // Inyección de dependencias para acceder al repositorio de teléfonos de personas
        public PersonPhoneController(IPersonPhoneRepository repository)
        {
            _repository = repository;
        }

        // MÉTODO PARA OBTENER UN TELÉFONO POR SU ID
        [HttpGet("{id}")] // Se accede con "GET api/personphone/{id}"
        public async Task<ActionResult<PersonPhone>> GetPersonPhoneById(int id)
        {
            var personPhone = await _repository.GetPersonPhoneByIdAsync(id);
            if (personPhone == null)
            {
                return NotFound(); //Retorna 404 si no se encuentra
            }
            return Ok(personPhone); // Retorna 200 con los datos
        }

        //MÉTODO PARA OBTENER TODOS LOS TELÉFONOS
        [HttpGet] // Se accede con "GET api/personphone"
        public async Task<ActionResult<IEnumerable<PersonPhone>>> GetPersonPhone()
        {
            var personPhones = await _repository.GetPersonPhoneAsync();
            return Ok(personPhones); //Retorna la lista de teléfonos
        }

        // MÉTODO PARA CREAR UN NUEVO TELÉFONO
        [HttpPost] // Se accede con "POST api/personphone"
        public async Task<ActionResult<PersonPhone>> CreatePersonPhone(PersonPhone personPhone)
        {
            var createdPersonPhone = await _repository.CreatePersonPhoneAsync(personPhone);
            return CreatedAtAction(nameof(GetPersonPhoneById), new { id = createdPersonPhone.PhoneNumberTypeID }, createdPersonPhone);
            // Retorna 201 con la URL del nuevo recurso creado
        }
        // MÉTODO PARA ACTUALIZAR UN TELÉFONO EXISTENTE
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, PersonPhone personPhone)
        {
            if (id != personPhone.PhoneNumberTypeID)
            {
                return BadRequest(); // Retorna 400 si los IDs no coinciden
            }

            var result = await _repository.UpdatePersonPhoneAsync(personPhone);
            if (!result)
            {
                return NotFound(); // Retorna 404 si no se encuentra el registro
            }

            return NoContent(); // Retorna 204 si la actualización fue exitosa
        }

    }

}