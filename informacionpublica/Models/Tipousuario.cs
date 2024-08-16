using System;
using System.Collections.Generic;

namespace InformacionPublica.Server.Models;

public partial class Tipousuario
{
    public int Idtipousuarios { get; set; }

    public string? Tipousuarios { get; set; }

    public ulong? Estado { get; set; }

    public virtual ICollection<Permisostipousuario> Permisostipousuarios { get; set; } = new List<Permisostipousuario>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
