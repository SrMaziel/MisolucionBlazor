using System;
using System.Collections.Generic;

namespace InformacionPublica.Server.Models;

public partial class Fronterasalvadoreña
{
    public int Idfronterasalvadoreñas { get; set; }

    public string? Fronteras { get; set; }

    public ulong? Estado { get; set; }

    public virtual ICollection<Historialmigratorio> Historialmigratorios { get; set; } = new List<Historialmigratorio>();
}
