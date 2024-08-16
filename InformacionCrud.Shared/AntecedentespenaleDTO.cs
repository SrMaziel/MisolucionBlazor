using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformacionCrud.Shared
{
    public class AntecedentespenalesDTO
    {
        public int Idantecedentespenales { get; set; }


        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El campo{0}es requerido")]
        public int? Ciudadano { get; set; }


        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El campo{0}es requerido")]
        public int? Delitos { get; set; }


        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El campo{0}es requerido")]
        public int? Tiposdelitos { get; set; }


        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El campo{0}es requerido")]
        public int? Penaimpuesta { get; set; }

        
        public ulong? Estado { get; set; }
   
     
        
        
        public CiudadanosDTO? Ciudadanos { get; set; }

        public DelitosDTO? Delito { get; set; }

        public TiposdelitosDTO? Tiposdelito { get; set; }
        
        public PenaimpuestaDTO? Penaimpuestum { get; set; }
    }
}
