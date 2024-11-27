using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App_ventas_ds500.Models
{
    [Table("tb_cliente")]
    public class Cliente
    {
        [Key]
        [Required(ErrorMessage = "Escriba codigo de cliente")]
        [MinLength(8, ErrorMessage = "Escriba 8 digitos")]
        [Display(Name = "Numero de codigo de cliente")]

        public String codigo_cliente {  get; set; }

        [Display(Name = "Tipo Cliente")]

        public String tipo_cliente { get; set; }

        [Required(ErrorMessage = "Escriba nombre del cliente")]
        [StringLength(25)]
        [Display(Name = "Nombre Cliente")]

        public String nombre_cliente { get; set; }

        [Display(Name = "Tipo Documento")]

        public String tipo_documento { get; set; }

        [Required(ErrorMessage = "Escriba el nro de documento")]
        [StringLength(25)]
        [Display(Name = "Numero Documento")]

        public String nro_documento { get; set; }


        [Required(ErrorMessage = "Escriba numero de telefono")]
        [MinLength(9, ErrorMessage = "Escriba 9 digitos")]
        [Display(Name = "Numero de telefono")]

        public String telefono { get; set; }

        [Required(ErrorMessage = "Escriba el e-mail")]
        [StringLength(25)]
        [Display(Name = "Correo Electronico")]

        public String email { get; set; }

        [Required(ErrorMessage = "Escriba la direccion")]
        [StringLength(25)]
        [Display(Name = "Direccion")]

        public String direccion { get; set; }
    }
}
