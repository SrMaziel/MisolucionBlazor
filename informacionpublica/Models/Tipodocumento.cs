using System;
using System.Collections.Generic;

namespace InformacionPublica.Server.Models;

public partial class Tipodocumento
{
    public int Idtipodocumentos { get; set; }

    public string? Tipodocumentos { get; set; }

    public ulong? Estado { get; set; }

    public virtual ICollection<Ciudadano> Ciudadanos { get; set; } = new List<Ciudadano>();

    public virtual ICollection<Documentosciudadano> Documentosciudadanos { get; set; } = new List<Documentosciudadano>();

    public virtual ICollection<Historialmigratorio> Historialmigratorios { get; set; } = new List<Historialmigratorio>();
}
