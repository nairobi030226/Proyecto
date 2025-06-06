using Proyecto.Entities;
using Proyecto.Interface;
using System.Data;

namespace Proyecto.Application
{
    public class PersonPhoneOperation : IPersonPhoneOperation
    {
        // Repositorio para realizar operaciones sobre la entidad PersonPhone
        #region REPOSITORIO
        private readonly IPersonPhoneRepository _repository;
        public PersonPhoneOperation(IPersonPhoneRepository repository)
        {
            _repository = repository;
        }
        public async Task PutPersonPhones(List<PersonPhone> phones)
        {
            var dtPhones = await TransformDTPersonPhone(phones);
            await _repository.PutPersonPhonesBySpAsync(dtPhones);
        }

        private Task<DataTable> TransformDTPersonPhone(List<PersonPhone> phones)
        {
            var table = new DataTable();

            table.Columns.Add("BusinessEntityID", typeof(int));
            table.Columns.Add("PhoneNumber", typeof(string));
            table.Columns.Add("PhoneNumberTypeID", typeof(int));
            table.Columns.Add("ModifiedDate", typeof(DateTime));

            foreach (var phone in phones)
            {
                table.Rows.Add(
                    phone.BusinessEntityID,
                    phone.PhoneNumber,
                    phone.PhoneNumberTypeID,
                    phone.modifiedDate
                );
            }

            return Task.FromResult(table);
        }
        #endregion
    }
}
