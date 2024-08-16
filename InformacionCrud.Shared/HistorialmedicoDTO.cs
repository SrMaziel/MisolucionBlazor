using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformacionCrud.Shared
{
    public class HistorialmedicoDTO
    {
        public int Idhistorialmedico { get; set; }



        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El campo{0}es requerido")]
        public int? Ciudadano { get; set; }


        [Required(ErrorMessage = "El campo{0} es obligatorio.")]
        [RegularExpression(@"^\d{4}-\{4}$", ErrorMessage = "Por Favor ingresar el contacto de emergencia correctamente")]
        public string? Contactoemergencia { get; set; }



        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "POR FAVOR INGRESE SOLO LETRAS Y ESPACIOS.")]
        [StringLength(150, ErrorMessage = "La longitud debe estar entre 4 y 150 caracteres. ", MinimumLength = 4)]
        public string? Intervencionesquirurjicas { get; set; }



        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "POR FAVOR INGRESE SOLO LETRAS Y ESPACIOS.")]
        [StringLength(150, ErrorMessage = "La longitud debe estar entre 4 y 150 caracteres. ", MinimumLength = 4)]
        public string? Padecimientos { get; set; }


        public ulong? Estado { get; set; }
    
        public CiudadanosDTO? Ciudadanos { get; set; }
       
    }
}
