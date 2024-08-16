using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformacionCrud.Shared
{
    public  class PermisostipousuarioDTO
    {
        public int Idpermisostipousuario { get; set; }


        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El campo{0}es requerido")]
        public int? Usuarios { get; set; }


        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El campo{0}es requerido")]
        public int? Tipousuarios { get; set; }


        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El campo{0}es requerido")]
        public int? Permisos { get; set; }

        public ulong? Estado { get; set; }

        
        
        public UsuarioDTO? Usuario { get; set; }

        public TipousuariosDTO? Tiposusuarios { get; set; }

        public PermisosDTO? Permiso { get; set; }
    }
}
