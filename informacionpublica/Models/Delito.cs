using System;
using System.Collections.Generic;

namespace InformacionPublica.Server.Models;

public partial class Delito
{
    public int Iddelitos { get; set; }

    public string? Delitos { get; set; }

    public int? Tiposdelitos { get; set; }

    public ulong? Estado { get; set; }

    public virtual ICollection<Antecedentesciudadano> Antecedentesciudadanos { get; set; } = new List<Antecedentesciudadano>();

    public virtual ICollection<Antecedentespenale> Antecedentespenales { get; set; } = new List<Antecedentespenale>();

    public virtual ICollection<Arrestopolicial> Arrestopolicials { get; set; } = new List<Arrestopolicial>();

    public virtual ICollection<Penaimpuestum> Penaimpuesta { get; set; } = new List<Penaimpuestum>();

    public virtual Tiposdelito? TiposdelitosNavigation { get; set; }
}
