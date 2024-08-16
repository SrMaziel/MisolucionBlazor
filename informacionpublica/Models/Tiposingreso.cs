using System;
using System.Collections.Generic;

namespace InformacionPublica.Server.Models;

public partial class Tiposingreso
{
    public int Idtiposingresos { get; set; }

    public string? Tiposingresos { get; set; }

    public ulong? Estado { get; set; }

    public virtual ICollection<Informacionfinanciera> Informacionfinancieras { get; set; } = new List<Informacionfinanciera>();
}
