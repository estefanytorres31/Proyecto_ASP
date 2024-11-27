using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace App_ventas_ds500.Models
{
    [Table("tb_proyecto")]
    public class Proyecto
    {
        [Key]
        [Required(ErrorMessage = "Escriba el código")]
        [MinLength(1, ErrorMessage = "Escriba 5 dígitos")]
        [Display(Name = "Código")]
        public String codigo_proyecto { get; set; }

        [Required(ErrorMessage = "Escriba el nombre del proyecto")]
        [StringLength(100)]
        [Display(Name = "Proyecto")]
        public String proyecto { get; set; }

        [Required(ErrorMessage = "Escriba la descripción")]
        [StringLength(100)]
        [Display(Name = "Descripción")]
        public String descripcion { get; set; }

        [Required(ErrorMessage = "Elija la fecha de inicio")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de inicio")]
        public DateTime fecha_inicio { get; set; }

        [Required(ErrorMessage = "Elija la fecha final")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha final")]
        public DateTime fecha_fin { get; set; }

        [Required(ErrorMessage = "Indique el estado del proyecto")]
        [StringLength(100)]
        [Display(Name = "Estado")]
        public String estado_proyecto { get; set; }

        [Required(ErrorMessage = "Escriba el precio")]
        [Display(Name = "Precio")]
        public double precio { get; set; }

        [Required(ErrorMessage = "Escriba el código de cliente")]
        [MinLength(1, ErrorMessage = "Escriba 5 dígitos")]
        [Display(Name = "Cliente")]
        public String proyecto_codigo_cliente { get; set; }

    }
}
