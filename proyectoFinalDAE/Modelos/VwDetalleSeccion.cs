using System;
using System.Collections.Generic;

namespace proyectoFinalDAE.Modelos;

public partial class VwDetalleSeccion
{
    public int IdSeccion { get; set; }

    public string GrupoBase { get; set; } = null!;

    public string Familia { get; set; } = null!;

    public string? Turno { get; set; }

    public short CupoMax { get; set; }

    public string NombrePeriodo { get; set; } = null!;

    public int IdCarrera { get; set; }

    public string NombreCarrera { get; set; } = null!;

    public int IdCiclo { get; set; }

    public string NombreCiclo { get; set; } = null!;

    public byte OrdenCiclo { get; set; }

    public int? ClasesProgramadas { get; set; }

    public int? DocentesDistintos { get; set; }

    public int? ClasesActivas { get; set; }
}
