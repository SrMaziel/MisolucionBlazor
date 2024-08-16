using System;
using System.Collections.Generic;

namespace InformacionPublica.Server.Models;

public partial class Informacionfinanciera
{
    public int Idinformacionfinanciera { get; set; }

    public int? Ciudadano { get; set; }

    public string? Profesion { get; set; }

    public string? Oficio { get; set; }

    public string? Salariomensual { get; set; }

    public string? Salarioanual { get; set; }

    public int? Tipoingresos { get; set; }

    public string? Procedenciaingresos { get; set; }

    public string? Declaracionimpuestos { get; set; }

    public ulong? Estado { get; set; }

    public virtual Ciudadano? CiudadanoNavigation { get; set; }

    public virtual Tiposingreso? TipoingresosNavigation { get; set; }
}
