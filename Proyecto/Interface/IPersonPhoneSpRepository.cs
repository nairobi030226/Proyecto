using System.Data;

namespace Proyecto.Interface
{
    public interface IPersonPhoneSpRepository
    {
        Task PutPersonPhonesBySpAsync(DataTable personPhones);
    }
}