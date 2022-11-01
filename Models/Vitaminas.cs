using System.ComponentModel.DataAnnotations;

namespace Parcial2_Frank.Models
{
    public class Vitaminas
    {
        [Key]
        public int VitaminaId { get; set; }

        public string? Descripcion { get; set; }

    }
}
