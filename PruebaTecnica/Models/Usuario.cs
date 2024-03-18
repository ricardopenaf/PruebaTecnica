using System.ComponentModel.DataAnnotations;

namespace PruebaTecnica.Models
{
    /// <summary>
    /// Tbl de usuario
    /// </summary>
    public class Usuario
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "El primer nombre es obligatorio")]
        [StringLength(50, ErrorMessage = "El primer nombre no puede tener más de 50 caracteres")]
        [RegularExpression("^[a-zA-ZáéíóúñÑ ]+$", ErrorMessage = "El primer nombre no puede contener números")]
        public string PrimerNombre { get; set; }

        [StringLength(50, ErrorMessage = "El segundo nombre no puede tener más de 50 caracteres")]
        [RegularExpression("^[a-zA-ZáéíóúñÑ ]+$", ErrorMessage = "El primer nombre no puede contener números")]
        public string SegundoNombre { get; set; }

        [Required(ErrorMessage = "El primer apellido es obligatorio")]
        [StringLength(50, ErrorMessage = "El primer nombre no puede tener más de 50 caracteres")]
        [RegularExpression("^[a-zA-ZáéíóúñÑ ]+$", ErrorMessage = "El primer nombre no puede contener números")]
        public string PrimerApellido { get; set; }

        [StringLength(50, ErrorMessage = "El segundo apellido no puede tener más de 50 caracteres")]
        [RegularExpression("^[a-zA-ZáéíóúñÑ ]+$", ErrorMessage = "El primer nombre no puede contener números")]
        public string SegundoApellido { get; set; }

        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "El sueldo es obligatorio y no puede ser 0")]
        [Range(0, double.MaxValue, ErrorMessage = "El sueldo no puede ser negativo.")]
        public double Sueldo { get; set; }

        public DateTime FechaCreacion { get; set; }

        public DateTime FechaModificacion { get; set; }
    }

}
