using Proyecto.Entities;
//using Proyecto.Entities.PersonPhone;

namespace Proyecto.Interface
{
    public interface IPersonPhoneOperation
    {
        public Task PutPersonPhones(List<PersonPhone> phones);
    }
}
