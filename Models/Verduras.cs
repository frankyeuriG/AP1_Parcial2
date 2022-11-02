using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Parcial2_Frank.Models
{
    public class Verduras
    {
        [Key]
        public int VerduraId { get; set; }

        [Required(ErrorMessage = "El Nombre es Obligatorio")]
        public string? Nombre { get; set; }

        //La fecha la puse siempre al dia actual
        //para que el filtro de la consulta funcuione
        public DateTime Fecha { get; set; } = DateTime.Now;

        [Required(ErrorMessage ="la Observacion es obligatoria")]
        public string? Observaciones { get; set; }

        public double Total { get; set; }

        [ForeignKey("VerduraId")]
        public  List<VerdurasDetalle> Detalle { get; set; } = new List<VerdurasDetalle>();

    }

    public class VerdurasDetalle {

        [Key]
        public int id { get; set; }

        public int VerduraId { get; set; }

        [Required(ErrorMessage ="El id de vitamina es Obligatorio")]
        public int VitaminaId { get; set; }

        [Range(minimum:0.000001, maximum:100000000, ErrorMessage ="La Cantidad es Obligatoria")]
        public int Cantidad { get; set; }

        public string descripcion { get; set; }

    }
}
