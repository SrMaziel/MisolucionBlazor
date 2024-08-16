using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformacionCrud.Shared
{
    public class InfraccionesDTO
    {
        public int Idinfracciones { get; set; }

        public string? Infracciones { get; set; }

        public string? Tipoinfracciones { get; set; }

        public ulong? Estado { get; set; }
    }
}
