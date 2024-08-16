using System;
using System.Collections.Generic;

namespace InformacionPublica.Server.Models;

public partial class Permiso
{
    public int Idpermisos { get; set; }

    public string? Permisos { get; set; }

    public ulong? Estado { get; set; }

    public virtual ICollection<Permisostipousuario> Permisostipousuarios { get; set; } = new List<Permisostipousuario>();
}
