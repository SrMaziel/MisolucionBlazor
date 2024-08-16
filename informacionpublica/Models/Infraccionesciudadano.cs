using System;
using System.Collections.Generic;

namespace InformacionPublica.Server.Models;

public partial class Infraccionesciudadano
{
    public int Idinfraccionesciudadano { get; set; }

    public int? Ciudadano { get; set; }

    public int? Infracciones { get; set; }

    public string? Costomulta { get; set; }

    public ulong? Estado { get; set; }

    public virtual Ciudadano? CiudadanoNavigation { get; set; }

    public virtual Infraccione? InfraccionesNavigation { get; set; }
}
