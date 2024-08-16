using System;
using System.Collections.Generic;

namespace InformacionPublica.Server.Models;

public partial class Historialmigratorio
{
    public int Idhistorialmigratorio { get; set; }

    public int? Ciudadano { get; set; }

    public int? Tiposdocumentos { get; set; }

    public string? Fronteraentrada { get; set; }

    public string? Fronterasalida { get; set; }

    public DateTime? Fechaentrada { get; set; }

    public DateTime? Fechasalida { get; set; }

    public string? Procedencia { get; set; }

    public string? Destino { get; set; }

    public int? Fronterasalvadoreña { get; set; }

    public ulong? Estado { get; set; }

    public virtual Ciudadano? CiudadanoNavigation { get; set; }

    public virtual Fronterasalvadoreña? FronterasalvadoreñaNavigation { get; set; }

    public virtual Tipodocumento? TiposdocumentosNavigation { get; set; }
}
