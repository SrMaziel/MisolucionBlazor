using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformacionCrud.Shared
{
    public class VictimaDTO
    {
        public int Idvictimas { get; set; }

        public int? Ciudadano { get; set; }

       
        [Required(ErrorMessage = "El campo {0} es obligatorio ")]
        public string? Accidente { get; set; }

       
        [Required(ErrorMessage = "El campo {0} es obligatorio ")]
        public string? Heridas { get; set; }

        public ulong? Estado { get; set; }
    
    public CiudadanosDTO? Ciudadanos { get; set; }

    }
}
