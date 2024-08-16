using System;
using System.Collections.Generic;

namespace InformacionPublica.Server.Models;

public partial class Informacionacademica
{
    public int Idinformacionacademica { get; set; }

    public int? Ciudadano { get; set; }

    public string? Escuela { get; set; }

    public string? Educacionmedia { get; set; }

    public string? Universidades { get; set; }

    public string? Estudiaactualmente { get; set; }

    public ulong? Estado { get; set; }

    public virtual Ciudadano? CiudadanoNavigation { get; set; }
}
