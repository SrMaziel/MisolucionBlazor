using System;
using System.Collections.Generic;

namespace InformacionPublica.Server.Models;

public partial class Nacionalidad
{
    public int Idnacionalidad { get; set; }

    public string? Nacionalidad1 { get; set; }

    public ulong? Estado { get; set; }

    public virtual ICollection<Ciudadano> Ciudadanos { get; set; } = new List<Ciudadano>();
}
