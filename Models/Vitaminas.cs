using System.ComponentModel.DataAnnotations;

namespace Parcial2_Frank.Models
{
    public class Vitaminas
    {
        [Key]
        public int VitaminasId { get; set; }

        [Required(ErrorMessage ="La descripcion es obligatoria")]
        public string? Descripcion { get; set; }

    }
}
