using System;
using System.Collections.Generic;

namespace InformacionPublica.Server.Models;

public partial class Documentosciudadano
{
    public int Iddocumentosciudadanos { get; set; }

    public int? Ciudadano { get; set; }

    public int? Tipodocumento { get; set; }

    public ulong? Estado { get; set; }

    public virtual Ciudadano? CiudadanoNavigation { get; set; }

    public virtual Tipodocumento? TipodocumentoNavigation { get; set; }
}
