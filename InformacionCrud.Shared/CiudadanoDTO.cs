using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace InformacionCrud.Shared
{
    public class CiudadanosDTO
    {
        public int Idciudadanos { get; set; }



        [Required(ErrorMessage = "El campo {0} es obligatorio ")]
        [RegularExpression("^[a-zA-Z ]*$",ErrorMessage = "POR FAVOR INGRESE SOLO LETRAS Y ESPACIOS.") ]
        [StringLength(20, ErrorMessage = "La longitud debe estar entre 4 y 20 caracteres. ", MinimumLength = 4)]
        public string? Nombre { get; set; }


        [Required(ErrorMessage = "El campo {0} es obligatorio ")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "POR FAVOR INGRESE SOLO LETRAS Y ESPACIOS.")]
        [StringLength(20, ErrorMessage = "La longitud debe estar entre 4 y 20 caracteres. ", MinimumLength = 4)]
        public string? Apellido { get; set; }

       
        public DateOnly? Fechanacimiento { get; set; }



        [Required(ErrorMessage = "Numero DUI obligatorio")]
        [RegularExpression(@"^\d{8}-\d{1}$", ErrorMessage = "Ingresar el numero de DUI correctamente. Debe ser 8 digitos seguidos de un guion y un digito.")]
         public string? Dui { get; set; }



        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El campo{0}es requerido")]
        public int? Tiposciudadanos { get; set; }


        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El campo{0}es requerido")]
        public int? Nacionalidad { get; set; }


        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El campo{0}es requerido")]
        public int? Tipodedocumento { get; set; }



        [Required(ErrorMessage = "El campo{0} es obligatorio.")]
        [RegularExpression(@"^\d{4}-\{4}$", ErrorMessage = "Por Favor ingresar el numero telefonico correctamente")]
        public string? Telefonofijio { get; set; }



        [Required(ErrorMessage = "El campo{0} es obligatorio.")]
        [RegularExpression(@"^\d{4}-\{4}$", ErrorMessage = "Por Favor ingresar el numero telefonico correctamente")]
        public string? Telefonomovil { get; set; }



        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [RegularExpression(@"^[^\s]+$", ErrorMessage = "Los espacios no estan permitidos.")]
        [StringLength(150, ErrorMessage = "La longitud debe ser entre 5 y 150 caracteres.", MinimumLength = 5)]
        public string? Correoelectronico { get; set; }



        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        
        public String? Direccionciudadano { get; set; }


        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El campo{0}es requerido")]
        public int? Bienes { get; set; }

        public ulong? Estado { get; set; }

        

        public TiposciudadanosDTO? Tiposciudadano {get; set;}

        public NacionalidadDTO? Nacional {get; set;}

        public TipodocumentosDTO? Tipodocumento{get; set;}

        public CiudadanosDTO? Ciudadanos { get; set; }

        public BienesDTO? Biene{ get; set; }

    }
}
