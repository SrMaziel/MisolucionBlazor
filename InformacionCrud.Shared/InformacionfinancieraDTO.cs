using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformacionCrud.Shared
{
    public class InformacionfinancieraDTO
    {
        public int Idinformacionfinanciera { get; set; }


        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El campo{0}es requerido")]
        public int? Ciudadano { get; set; }


        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "POR FAVOR INGRESE SOLO LETRAS Y ESPACIOS.")]
        [StringLength(50, ErrorMessage = "La longitud debe estar entre 4 y 50 caracteres. ", MinimumLength = 4)]
        public string? Profesion { get; set; }


        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "POR FAVOR INGRESE SOLO LETRAS Y ESPACIOS.")]
        [StringLength(50, ErrorMessage = "La longitud debe estar entre 4 y 50 caracteres. ", MinimumLength = 4)]
        public string? Oficio { get; set; }


        [Required(ErrorMessage = "El campo {0} es obligatorio ")]
        public string? Salariomensual { get; set; }


        [Required(ErrorMessage = "El campo {0} es obligatorio ")]
        public string? Salarioanual { get; set; }


        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El campo{0}es requerido")]
        public int? Tipoingresos { get; set; }


        [Required(ErrorMessage = "El campo {0} es obligatorio ")]
        public string? Procedenciaingresos { get; set; }


        public string? Declaracionimpuestos { get; set; }

        public ulong? Estado { get; set; }


        public CiudadanosDTO? Ciudadanos { get; set; }

        public TiposingresosDTO? Tiposingresos { get; set; }


    }
}
