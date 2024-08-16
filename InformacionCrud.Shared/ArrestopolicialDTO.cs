using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformacionCrud.Shared
{
    public class ArrestopolicialDTO
    {
        public int Idarrestopolicial { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El campo{0}es requerido")]
        public int? Tipociudadano { get; set; }


        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El campo{0}es requerido")]
        public int? Ciudadano { get; set; }


        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El campo{0}es requerido")]
        public int? Delitos { get; set; }


        [Required(ErrorMessage = "El campo {0} es obligatorio ")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "POR FAVOR INGRESE SOLO LETRAS Y ESPACIOS.")]
        [StringLength(20, ErrorMessage = "La longitud debe estar entre 4 y 20 caracteres. ", MinimumLength = 4)]
        public string? Denunciantes { get; set; }


        [Required(ErrorMessage = "El campo {0} es obligatorio ")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "POR FAVOR INGRESE SOLO LETRAS Y ESPACIOS.")]
        [StringLength(20, ErrorMessage = "La longitud debe estar entre 4 y 20 caracteres. ", MinimumLength = 4)]
        public string? Denunciados { get; set; }


        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El campo{0}es requerido")]
        public int? Detenciones { get; set; }


        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El campo{0}es requerido")]
        public int? Denuncia { get; set; }

        public ulong? Estado { get; set; } 
    
    
        
        
        public CiudadanosDTO? Ciudadanos { get; set; }

        public TiposciudadanosDTO? Tiposciudadano { get; set; }

        public DelitosDTO? Delito  { get; set; }

        public DetencionesDTO? Detencione { get; set; }

        public DenunciaDTO? Denuncium { get; set; }
    }
}
