using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Parcial2_Frank.Models
{
    public class Verduras
    {
        [Key]
        public int VerdurasId { get; set; }

        [Required(ErrorMessage = "Es obligatorio el nombre de la verdura")]
        public string? Nombre { get; set; }

        public DateTime FechaCreacion { get; set; }

        [Required(ErrorMessage = "Es obligatoria la Observacion")]
        public string? Observaciones { get; set; }

        public int Cantidad { get; set; }

        [ForeignKey("VerdurasId")]
        public virtual List<VerdurasDetalle> detalle { get; set; } = new List<VerdurasDetalle>();

    }

    public class VerdurasDetalle {

        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "El verdurasId es obligatorio")]
        public int VerdurasId { get; set; }

        [Required(ErrorMessage ="El vitaminaId es obligatorio")]
        public int VitaminaId { get; set; }

        public int Cantidad { get; set; }


    }
}
