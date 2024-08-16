using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformacionCrud.Shared
{
    public class DetencionesDTO
    {
        public int Iddetenciones { get; set; }

        public string? Detencion { get; set; }

        public ulong? Estado { get; set; }
    }
}
