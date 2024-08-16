using System;
using System.Collections.Generic;

namespace InformacionPublica.Server.Models;

public partial class Historiallaboral
{
    public int Idhistoriallaboral { get; set; }

    public int? Ciudadano { get; set; }

    public int? Tiposciudadano { get; set; }

    public string? Empleoactual { get; set; }

    public string? Empleospasados { get; set; }

    public ulong? Estado { get; set; }

    public virtual Ciudadano? CiudadanoNavigation { get; set; }

    public virtual Tiposciudadano? TiposciudadanoNavigation { get; set; }
}
