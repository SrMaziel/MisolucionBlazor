using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformacionCrud.Shared
{
    public class HistoriallaboralDTO
    {
        public int Idhistoriallaboral { get; set; }



        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El campo{0}es requerido")]
        public int? Ciudadano { get; set; }


        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El campo{0}es requerido")]
        public int? Tiposciudadano { get; set; }



        [Required(ErrorMessage = "El campo {0} es obligatorio ")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "POR FAVOR INGRESE SOLO LETRAS Y ESPACIOS.")]
        [StringLength(100, ErrorMessage = "La longitud debe estar entre 4 y 100 caracteres. ", MinimumLength = 4)]
        public string? Empleoactual { get; set; }



        [Required(ErrorMessage = "El campo {0} es obligatorio ")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "POR FAVOR INGRESE SOLO LETRAS Y ESPACIOS.")]
        [StringLength(150, ErrorMessage = "La longitud debe estar entre 4 y 150 caracteres. ", MinimumLength = 4)]
        public string? Empleospasados { get; set; }

        public ulong? Estado { get; set; }

   
    public CiudadanosDTO? Ciudadanos { get; set; }
        public TiposciudadanosDTO? Tipociudadanos { get; set; }
    }
}
