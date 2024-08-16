using System;
using System.Collections.Generic;

namespace InformacionPublica.Server.Models;

public partial class Penaimpuestum
{
    public int Idpenaimpuesta { get; set; }

    public int? Delitos { get; set; }

    public int? Tiposdelitos { get; set; }

    public string? Penaimpuesta { get; set; }

    public ulong? Estado { get; set; }

    public virtual ICollection<Antecedentesciudadano> Antecedentesciudadanos { get; set; } = new List<Antecedentesciudadano>();

    public virtual ICollection<Antecedentespenale> Antecedentespenales { get; set; } = new List<Antecedentespenale>();

    public virtual Delito? DelitosNavigation { get; set; }

    public virtual Tiposdelito? TiposdelitosNavigation { get; set; }
}
