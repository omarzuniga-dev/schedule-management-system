using System;
using System.Collections.Generic;

namespace proyectoFinalDAE.Modelos;

public partial class VwSeccionesDetalle
{
    public int IdSeccion { get; set; }

    public string GrupoBase { get; set; } = null!;

    public string Familia { get; set; } = null!;

    public string? Turno { get; set; }

    public short CupoMax { get; set; }

    public string NombreCarrera { get; set; } = null!;

    public string NombreCiclo { get; set; } = null!;

    public string NombrePeriodo { get; set; } = null!;
}
