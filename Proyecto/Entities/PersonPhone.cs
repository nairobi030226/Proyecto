using System.ComponentModel.DataAnnotations;

namespace Proyecto.Entities
{
    public class PersonPhone
    {
        [Key] public int ProductID { get; set; }
        public int BusinessEntityID { get; set; }
        public string PhoneNumber { get; set; }
        public int PhoneNumberTypeID { get; set; }
        public DateTime modifiedDate { get; set; }
    }
}
