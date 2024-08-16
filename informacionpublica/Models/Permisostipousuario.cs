using System;
using System.Collections.Generic;

namespace InformacionPublica.Server.Models;

public partial class Permisostipousuario
{
    public int Idpermisostipousuario { get; set; }

    public int? Usuarios { get; set; }

    public int? Tipousuarios { get; set; }

    public int? Permisos { get; set; }

    public ulong? Estado { get; set; }

    public virtual Permiso? PermisosNavigation { get; set; }

    public virtual Tipousuario? TipousuariosNavigation { get; set; }

    public virtual Usuario? UsuariosNavigation { get; set; }
}
