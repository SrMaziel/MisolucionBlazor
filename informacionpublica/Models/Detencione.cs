using System;
using System.Collections.Generic;

namespace InformacionPublica.Server.Models;

public partial class Detencione
{
    public int Iddetenciones { get; set; }

    public string? Detencion { get; set; }

    public ulong? Estado { get; set; }

    public virtual ICollection<Antecedentesciudadano> Antecedentesciudadanos { get; set; } = new List<Antecedentesciudadano>();

    public virtual ICollection<Arrestopolicial> Arrestopolicials { get; set; } = new List<Arrestopolicial>();
}
