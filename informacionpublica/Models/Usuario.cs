using System;
using System.Collections.Generic;

namespace InformacionPublica.Server.Models;

public partial class Usuario
{
    public int Idusuarios { get; set; }

    public string? Usuario1 { get; set; }

    public int? Tipousuarios { get; set; }

    public ulong? Estado { get; set; }

    public virtual ICollection<Permisostipousuario> Permisostipousuarios { get; set; } = new List<Permisostipousuario>();

    public virtual Tipousuario? TipousuariosNavigation { get; set; }
}
