using System;
using System.Collections.Generic;

namespace InformacionPublica.Server.Models;

public partial class Antecedentespenale
{
    public int Idantecedentespenales { get; set; }

    /// <summary>
    /// nombre del ciudadano
    /// </summary>
    public int? Ciudadano { get; set; }

    public int? Delitos { get; set; }

    public int? Tiposdelitos { get; set; }

    public int? Penaimpuesta { get; set; }

    public ulong? Estado { get; set; }

    public virtual Ciudadano? CiudadanoNavigation { get; set; }

    public virtual Delito? DelitosNavigation { get; set; }

    public virtual Penaimpuestum? PenaimpuestaNavigation { get; set; }

    public virtual Tiposdelito? TiposdelitosNavigation { get; set; }
}
