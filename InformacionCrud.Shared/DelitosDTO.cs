using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformacionCrud.Shared
{
    public class DelitosDTO
    {
        public int Iddelitos { get; set; }



        public string? Delitos { get; set; }


        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El campo{0}es requerido")]

        public int? Tiposdelitos { get; set; }

        public ulong? Estado { get; set; }

        public TiposdelitosDTO? Tiposdelito {get; set;}

    }
}
