using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformacionCrud.Shared
{
    public class UsuarioDTO
    {
        public int Idusuarios { get; set; }

        public string? Usuario1 { get; set; }

       
        [Required(ErrorMessage = "El campo {0} es obligatorio ")]
        public int? Tipousuarios { get; set; }

        public ulong? Estado { get; set; }
    
   
        public TipousuariosDTO? Tiposusuarios { get; set; }
    }
}
