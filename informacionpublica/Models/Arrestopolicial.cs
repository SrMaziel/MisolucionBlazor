using System;
using System.Collections.Generic;

namespace InformacionPublica.Server.Models;

public partial class Arrestopolicial
{
    public int Idarrestopolicial { get; set; }

    public int? Tipociudadano { get; set; }

    public int? Ciudadano { get; set; }

    public int? Delitos { get; set; }

    public string? Denunciantes { get; set; }

    public string? Denunciados { get; set; }

    public int? Detenciones { get; set; }

    public int? Denuncia { get; set; }

    public ulong? Estado { get; set; }

    public virtual Ciudadano? CiudadanoNavigation { get; set; }

    public virtual Delito? DelitosNavigation { get; set; }

    public virtual Denuncium? DenunciaNavigation { get; set; }

    public virtual Detencione? DetencionesNavigation { get; set; }

    public virtual Tiposciudadano? TipociudadanoNavigation { get; set; }
}
