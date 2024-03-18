using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PruebaTecnica.DTOs
{
    /// <summary>
    /// Uso del DTO como una clase para realizar las diferentes opraciones
    /// </summary>
    public class usuarioCreacionDTO
    {
        [JsonIgnore]
        public int Id { get; set; }

        [DefaultValue("")]
        public string PrimerNombre { get; set; }=string.Empty;

        [DefaultValue("")]
        public string SegundoNombre { get; set; } = string.Empty;

        [DefaultValue("")]
        public  string PrimerApellido { get; set; } = string.Empty;

        [DefaultValue("")]
        public  string SegundoApellido { get; set; } = string.Empty;

        [Required]
        [DefaultValue("")]
        public DateTime FechaNacimiento { get; set; }

       
        public double Sueldo { get; set; }

        public DateTime FechaCreacion { get; set; }

        public DateTime FechaModificacion { get; set; }
    }
}
