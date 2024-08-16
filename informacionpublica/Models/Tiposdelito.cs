using System;
using System.Collections.Generic;

namespace InformacionPublica.Server.Models;

public partial class Tiposdelito
{
    public int Idtiposdelitos { get; set; }

    public string? Tiposdelitos { get; set; }

    public ulong? Estado { get; set; }

    public virtual ICollection<Antecedentesciudadano> Antecedentesciudadanos { get; set; } = new List<Antecedentesciudadano>();

    public virtual ICollection<Antecedentespenale> Antecedentespenales { get; set; } = new List<Antecedentespenale>();

    public virtual ICollection<Delito> Delitos { get; set; } = new List<Delito>();

    public virtual ICollection<Penaimpuestum> Penaimpuesta { get; set; } = new List<Penaimpuestum>();
}
