using System;
using System.Collections.Generic;

namespace proyectoFinalDAE.Modelos;

public partial class VwCarrerasPlan
{
    public int IdCarrera { get; set; }

    public string NombreCarrera { get; set; } = null!;

    public string Tipo { get; set; } = null!;

    public int IdPlan { get; set; }

    public string Version { get; set; } = null!;

    public string Estado { get; set; } = null!;
}
