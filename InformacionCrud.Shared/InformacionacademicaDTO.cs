using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformacionCrud.Shared
{
    public class InformacionacademicaDTO
    {
        public int Idinformacionacademica { get; set; }


        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El campo{0}es requerido")]
        public int? Ciudadano { get; set; }

        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "POR FAVOR INGRESE SOLO LETRAS Y ESPACIOS.")]
        [StringLength(100, ErrorMessage = "Agregar escuela educativa correctamente.", MinimumLength = 5)]
        public string? Escuela { get; set; }


        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "POR FAVOR INGRESE SOLO LETRAS Y ESPACIOS.")]
        [StringLength(100, ErrorMessage = "Agregar educacion media correctamente.", MinimumLength = 5)]
        public string? Educacionmedia { get; set; }


        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "POR FAVOR INGRESE SOLO LETRAS Y ESPACIOS.")]
        [StringLength(100, ErrorMessage = "Agregar universidad correctamente.", MinimumLength = 5)]
        public string? Universidades { get; set; }


        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "POR FAVOR INGRESE SOLO LETRAS Y ESPACIOS.")]
        [StringLength(100, ErrorMessage = "Agregar entre 5 y 100 caracteres.", MinimumLength = 5)]
        public string? Estudiaactualmente { get; set; }

        public ulong? Estado { get; set; }
   
    
        public CiudadanosDTO?Ciudadanos { get; set; }
    
    }
}
