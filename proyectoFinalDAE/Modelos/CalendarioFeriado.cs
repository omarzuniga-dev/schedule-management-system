using System;
using System.Collections.Generic;

namespace proyectoFinalDAE.Modelos;

public partial class CalendarioFeriado
{
    public int IdFeriado { get; set; }

    public int IdPeriodo { get; set; }

    public DateOnly FechaFeriado { get; set; }

    public string? Descripcion { get; set; }

    public virtual Periodo IdPeriodoNavigation { get; set; } = null!;
}
