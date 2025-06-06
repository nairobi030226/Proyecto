using Microsoft.AspNetCore.Mvc;
using Proyecto.Entities;
using Proyecto.Interface;

namespace Proyecto.Controllers
{
 /// <summary>
        #region PersonPhoneBulkController
        [Route("api/[controller]")]
        [ApiController]
        public class PersonPhoneBulkController : ControllerBase
        {
            private readonly IPersonPhoneOperation _personPhoneOperation;

            public PersonPhoneBulkController(IPersonPhoneOperation personPhoneOperation)
            {
                _personPhoneOperation = personPhoneOperation;
            }

            [HttpPut]
            public async Task<IActionResult> PutPersonPhones([FromBody] List<PersonPhone> phones)
            {
                if (phones == null || phones.Count == 0)
                {
                    return BadRequest("La lista de teléfonos está vacía.");
                }

                await _personPhoneOperation.PutPersonPhones(phones);
                return NoContent();
            }
        }
        #endregion
  }