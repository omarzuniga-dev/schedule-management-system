using System;
using System.Collections.Generic;

namespace proyectoFinalDAE.Modelos;

public partial class Periodo
{
    public int IdPeriodo { get; set; }

    public string NombrePeriodo { get; set; } = null!;

    public DateOnly FechaInicio { get; set; }

    public DateOnly FechaFin { get; set; }

    public string EstadoPeriodo { get; set; } = null!;

    public virtual ICollection<CalendarioFeriado> CalendarioFeriados { get; set; } = new List<CalendarioFeriado>();

    public virtual ICollection<Seccion> Seccions { get; set; } = new List<Seccion>();
}
