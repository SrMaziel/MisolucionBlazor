using System;
using System.Collections.Generic;

namespace InformacionPublica.Server.Models;

public partial class Infraccione
{
    public int Idinfracciones { get; set; }

    public string? Infracciones { get; set; }

    public string? Tipoinfracciones { get; set; }

    public ulong? Estado { get; set; }

    public virtual ICollection<Infraccionesciudadano> Infraccionesciudadanos { get; set; } = new List<Infraccionesciudadano>();
}
