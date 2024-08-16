using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformacionCrud.Shared
{
    public class DenunciaDTO
    {
        public int Iddenuncia { get; set; }



        [Required(ErrorMessage = "El campo denuncia {0} es requerido.")]
        public string? Denuncia { get; set; }



        [Required(ErrorMessage = "El campo{0} es obligatorio.")]
        public int? Tipodenuncia { get; set; }


        [Required(ErrorMessage = "El campo{0} es obligatorio.")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "POR FAVOR INGRESE SOLO LETRAS Y ESPACIOS.")]
        [StringLength(35, ErrorMessage = "La longitud debe estar entre 4 y 35 caracteres. ", MinimumLength = 4)]
        public string? Denunciante { get; set; }


        [Required(ErrorMessage = "El campo{0} es obligatorio.")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "POR FAVOR INGRESE SOLO LETRAS Y ESPACIOS.")]
        [StringLength(35, ErrorMessage = "La longitud debe estar entre 4 y 35 caracteres. ", MinimumLength = 4)]


        public string? Denunciado { get; set; }

        public ulong? Estado { get; set; } 
   
    
    
    
    
    
    
    
    
    
    }

}
