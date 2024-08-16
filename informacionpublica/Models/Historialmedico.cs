using System;
using System.Collections.Generic;

namespace InformacionPublica.Server.Models;

public partial class Historialmedico
{
    public int Idhistorialmedico { get; set; }

    public int? Ciudadano { get; set; }

    public string? Contactoemergencia { get; set; }

    public string? Intervencionesquirurjicas { get; set; }

    public string? Padecimientos { get; set; }

    public ulong? Estado { get; set; }

    public virtual Ciudadano? CiudadanoNavigation { get; set; }
}
