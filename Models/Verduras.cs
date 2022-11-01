using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Parcial2_Frank.Models
{
    public class Verduras
    {
        [Key]
        public int VerduraId { get; set; }

        [Required(ErrorMessage = "Es obligatorio el nombre de la verdura")]
        public string? Nombre { get; set; }

        public DateTime FechaCreacion { get; set; }

       
        public string? Observaciones { get; set; }

        public double Total { get; set; }

        [ForeignKey("VerduraId")]
        public  List<VerdurasDetalle> Detalle { get; set; } = new List<VerdurasDetalle>();

    }

    public class VerdurasDetalle {

        [Key]
        public int id { get; set; }

        public int VerduraId { get; set; }

        public int VitaminaId { get; set; }
        
        public int Cantidad { get; set; }


    }
}
