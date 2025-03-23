using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto.Entities
{
    [Table("PersonPhone", Schema = "Person")]

    public class PersonPhone
    {
        [Key] //public int ProductID { get; set; }
        public int BusinessEntityID { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;

        public int PhoneNumberTypeID { get; set; }
        public DateTime modifiedDate { get; set; }
    }
}
