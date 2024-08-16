using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformacionCrud.Shared
{
    public class InfraccionesciudadanoDTO
    {
        public int Idinfraccionesciudadano { get; set; }


        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El campo{0}es requerido")]
        public int? Ciudadano { get; set; }


        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El campo{0}es requerido")]
        public int? Infracciones { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string? Costomulta { get; set; }

        public ulong? Estado { get; set; }


        public CiudadanosDTO? Ciudadanos { get; set; }

        public InfraccionesDTO? Infraccione { get; set; }

    }
}
