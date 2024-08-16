using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformacionCrud.Shared
{
    public class DocumentosciudadanoDTO
    {
        public int Iddocumentosciudadanos { get; set; }


        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El campo{0}es requerido")]
        public int? Ciudadano { get; set; }


        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El campo{0}es requerido")]
        public int? Tipodocumento { get; set; }

        public ulong? Estado { get; set; } 



        public CiudadanosDTO?Ciudadanos { get; set; }

        public TipodocumentosDTO?Tipodocumentos { get; set; }
    }
}
