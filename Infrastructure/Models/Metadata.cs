using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Infrastructure.Models.Metadata;

namespace Infrastructure.Models
{
    [MetadataType(typeof(ResidenciaMTDT))] public partial class Residencia { }
    [MetadataType(typeof(PlanCobroMTDT))] public partial class PlanCobro { }
    [MetadataType(typeof(CobroMTDT))] public partial class Cobro { }
    [MetadataType(typeof(UsuarioMTDT))] public partial class Usuario { }
    [MetadataType(typeof(RubroMTDT))] public partial class Rubro { }
    [MetadataType(typeof(IncidenciaMTDT))] public partial class Incidencia { }
    [MetadataType(typeof(NoticiasMTDT))] public partial class Noticias { }
    [MetadataType(typeof(ReservaMTDT))] public partial class Reserva { }
    public static class Metadata
    {
        public class ResidenciaMTDT
        {
            [Display(Name = "No. De Residencia")]
            public int ID { get; set; }
            [Display(Name = "Monto mensual")]
            public decimal montoMensual { get; set; }
            [Display(Name = "Cantidad de inquilinos")]
            public byte cantInquilinos { get; set; }
            [Display(Name = "Espacios en el garaje")]
            public byte espacioGaraje { get; set; }
            [Display(Name = "Habitaciones")]
            public byte habitaciones { get; set; }
            [Display(Name = "Calle")]
            public string calle { get; set; }
            [Display(Name = "Avenida")]
            public string avenida { get; set; }
            [Display(Name = "Descripción")]
            public string descripcion { get; set; }
            [Display(Name = "Fecha de construcción")]
            public DateTime? fechaConst { get; set; }
            [Display(Name = "Estado de construcción")]
            public byte estado { get; set; }
        }
        
        public class PlanCobroMTDT
        {
            [Display(Name = "No. De Plan")]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int ID { get; set; }
            [Display(Name = "Nombre")]
            [Required(AllowEmptyStrings = false, ErrorMessage = "Se requiere un nombre")]
            [StringLength(40, ErrorMessage = "No se permiten más de 40 caracteres en el nombre")]
            public string nombre { get; set; }
            [DataType(DataType.MultilineText)]
            [StringLength(200, ErrorMessage = "No se permiten más de 200 caracteres en la descripción")]
            [Display(Name = "Descripción")]
            public string descripcion { get; set; }
            [Display(Name = "Es aplicado por defecto?")]
            public bool automatico { get; set; }
        }
        
        public class CobroMTDT
        {
            [Display(Name = "Mes de cobro")]
            public System.DateTime fecha { get; set; }
            [Display(Name = "Plan de cobro aplicado")]
            public int IDPlanCobro { get; set; }
            [Display(Name = "Residencia")]
            public int IDResidencia { get; set; }
            [Display(Name = "Monto Total")]
            public decimal total { get; set; }
            [Display(Name = "Está pago?")]
            public bool pagado { get; set; }
            [Display(Name = "Fecha de pago")]
            public DateTime? fechaPago { get; set; }
        }

        public class UsuarioMTDT
        {
            [Display(Name = "ID de Usuario")]
            public int ID { get; set; }
            [Display(Name = "Nombre")]
            public string nombre { get; set; }
            [Display(Name = "Primer apellido")]
            public string apellido1 { get; set; }
            [Display(Name = "Segundo apellido")]
            public string apellido2 { get; set; }
            [Display(Name = "Teléfono")]
            public string telefono { get; set; }
            [Display(Name = "Correo electrónico")]
            public string correo { get; set; }
            [Display(Name = "Cédula")]
            public string cedula { get; set; }
            [Display(Name = "Tipo de usuario")]
            public byte tipo { get; set; }
        }

        public class RubroMTDT
        {
            [Display(Name = "No. De Rubro")]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int ID { get; set; }
            [UIHint("Money")]
            [Display(Name = "Monto")]
            [Range(-922337203685477.5808, 922337203685477.5807, ErrorMessage = "No se permiten valores demasiado grandes")]
            public decimal monto { get; set; }
            [Display(Name = "Es porcentual?")]
            public bool porcentual { get; set; }
            [Display(Name = "Motivo de cobro")]
            [Required(AllowEmptyStrings = false, ErrorMessage = "Se recomienda un motivo")]
            [StringLength(100, ErrorMessage = "No se permiten más de 100 caracteres en el motivo")]
            public string motivo { get; set; }
        }

        public class IncidenciaMTDT
        {
            [Display(Name = "No. De Incidencia")]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int ID { get; set; }
            [Required(AllowEmptyStrings = false, ErrorMessage = "Se recomienda una descripción")]
            [StringLength(200, ErrorMessage = "No se permiten más de 200 caracteres en la descripción")]
            [Display(Name = "Descripción")]
            [DataType(DataType.MultilineText)]
            public string descripcion { get; set; }
            [Display(Name = "Fecha")]
            public DateTime fecha { get; set; }
            [Display(Name = "Estado")]
            public byte estado { get; set; }
        }

        public class NoticiasMTDT
        {
            [Display(Name = "Nombre")]
            [Required(AllowEmptyStrings = false, ErrorMessage = "Se requiere un nombre")]
            [StringLength(40, ErrorMessage = "No se permiten más de 40 caracteres en el nombre")]
            public string nombre { get; set; }
            [Display(Name = "Contenido")]
            [DataType(DataType.MultilineText)]
            [StringLength(65535, ErrorMessage = "No se permiten demasiados caracteres en el nombre")]
            public string contenido { get; set; }
            [Display(Name = "Fecha")]
            [Required(AllowEmptyStrings = false, ErrorMessage = "Se requiere una fecha con el formato dd-mm-yyyy")]
            public DateTime fecha { get; set; }
            [Display(Name = "Imagen")]
            public byte[] imagen { get; set; }
        }

        public class ReservaMTDT
        {
            [Display(Name = "No. De Edificio")]
            [Required]
            public int IDEdificio { get; set; }
            [Display(Name = "Hora de reserva")]
            [Required(AllowEmptyStrings = false, ErrorMessage = "Se requiere una fecha con el formato dd-mm-yyyy")]
            public DateTime fecha { get; set; }
            [Display(Name = "Motivo de reserva")]
            [StringLength(100, ErrorMessage = "No se permiten más de 100 caracteres en el nombre")]
            [Required(AllowEmptyStrings = false, ErrorMessage = "Se requiere un motivo")]
            public string motivo { get; set; }
            [Display(Name = "Estado")]
            public byte estado { get; set; }
            [Display(Name = "Usuario que reserva")]
            public int IDUsuario { get; set; }
            [Display(Name = "Cantidad de horas")]
            [Required]
            public byte horas { get; set; }
        }

    }
}
