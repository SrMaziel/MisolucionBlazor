using System;
using System.Collections.Generic;

namespace InformacionPublica.Server.Models;

public partial class Tiposciudadano
{
    public int Idtiposciudadanos { get; set; }

    public string? Tiposciudadanos { get; set; }

    public ulong? Estado { get; set; }

    public virtual ICollection<Ciudadano> Ciudadanos { get; set; } = new List<Ciudadano>();

    public virtual ICollection<Arrestopolicial> Arrestopolicials { get; set; } = new List<Arrestopolicial>();

    public virtual ICollection<Historiallaboral> Historiallaborals { get; set; } = new List<Historiallaboral>();
}
