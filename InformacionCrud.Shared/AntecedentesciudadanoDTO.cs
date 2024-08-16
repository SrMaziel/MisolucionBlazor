using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformacionCrud.Shared
{
    public class AntecedentesciudadanoDTO
    {
        public int Idantecedentesciudadano { get; set; }

       
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El campo{0}es requerido")]
        public int? Ciudadanos { get; set; }


        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El campo{0}es requerido")]
        public int? Delitos { get; set; }


        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El campo{0}es requerido")]
        public int? Tiposdelitos { get; set; }


        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El campo{0}es requerido")]
        public int? Detenciones { get; set; }

       
        public DateOnly? Fechadelito { get; set; }


        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El campo{0}es requerido")]
        public int? Penaimpuesta { get; set; }

        public ulong? Estado { get; set; }
   
    
    
       
        public CiudadanosDTO?Ciudadano{ get; set;}

        public DelitosDTO? Delito { get; set; }

        public TiposdelitosDTO?Tiposdelito { get; set; }

        public DetencionesDTO? Detencione { get; set; }

        public PenaimpuestaDTO? Penaimpuestum { get; set; }

        public static implicit operator AntecedentesciudadanoDTO(List<AntecedentesciudadanoDTO> v)
        {
            throw new NotImplementedException();
        }
    }
}
