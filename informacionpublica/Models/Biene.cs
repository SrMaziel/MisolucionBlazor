using System;
using System.Collections.Generic;

namespace InformacionPublica.Server.Models;

public partial class Biene
{
    public int Idbienes { get; set; }

    public string? Bienes { get; set; }

    public ulong? Estado { get; set; }

    public virtual ICollection<Ciudadano> Ciudadanos { get; set; } = new List<Ciudadano>();
}
