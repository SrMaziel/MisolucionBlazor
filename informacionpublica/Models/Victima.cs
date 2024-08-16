using System;
using System.Collections.Generic;

namespace InformacionPublica.Server.Models;

public partial class Victima
{
    public int Idvictimas { get; set; }

    public int? Ciudadano { get; set; }

    public string? Accidente { get; set; }

    public string? Heridas { get; set; }

    public ulong? Estado { get; set; }

    public virtual Ciudadano? CiudadanoNavigation { get; set; }
}
