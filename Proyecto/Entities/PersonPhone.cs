using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto.Entities
{
    // Define que esta clase representa la tabla "PersonPhone" dentro del esquema
    // "Person" en la base de datos
    [Table("PersonPhone", Schema = "Person")]

    public class PersonPhone
    {
        // Llave primaria (identificador único) de la tabla
        [Key] //public int ProductID { get; set; }
        // ID de la entidad de negocio asociada (puede ser una persona o empresa)
        public int BusinessEntityID { get; set; }
        // Número de teléfono (se inicializa con un string vacío para evitar valores nulos)
        public string PhoneNumber { get; set; } = string.Empty;
        
        // Tipo de número de teléfono (ejemplo: móvil, casa, trabajo)
        public int PhoneNumberTypeID { get; set; }

        // Fecha de última modificación
        public DateTime modifiedDate { get; set; }
    }
}
