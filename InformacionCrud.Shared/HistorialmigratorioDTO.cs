using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformacionCrud.Shared
{
    public class HistorialmigratorioDTO
    {
        public int Idhistorialmigratorio { get; set; }


        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El campo{0}es requerido")]
        public int? Ciudadano { get; set; }



        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El campo{0}es requerido")]
        public int? Tiposdocumentos { get; set; }


        [Required(ErrorMessage = "El campo {0} es obligatorio ")]

        public string? Fronteraentrada { get; set; }


        [Required(ErrorMessage = "El campo {0} es obligatorio ")]
        public string? Fronterasalida { get; set; }


        public DateTime? Fechaentrada { get; set; }

        public DateTime? Fechasalida { get; set; }


        [Required(ErrorMessage = "El campo {0} es obligatorio ")]
        public string? Procedencia { get; set; }


        [Required(ErrorMessage = "El campo {0} es obligatorio ")]
        public string? Destino { get; set; }


        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El campo{0}es requerido")]
        public int? Fronterasalvadoreña { get; set; }

        public ulong? Estado { get; set; }


        public CiudadanosDTO? Ciudadanos { get; set; }

        public TipodocumentosDTO? Tipodocumento { get; set; }

        public FronterasalvadoreñaDTO? Fronterasalvadoreñas { get; set; }


    }
}
