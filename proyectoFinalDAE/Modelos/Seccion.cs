using System;
using System.Collections.Generic;

namespace proyectoFinalDAE.Modelos;

public partial class Seccion
{
    public int IdSeccion { get; set; }

    public int IdPeriodo { get; set; }

    public int IdCarrera { get; set; }

    public int IdCiclo { get; set; }

    public string GrupoBase { get; set; } = null!;

    public string Familia { get; set; } = null!;

    public string? Turno { get; set; }

    public short CupoMax { get; set; }

    public virtual ICollection<Horario> Horarios { get; set; } = new List<Horario>();

    public virtual Carrera IdCarreraNavigation { get; set; } = null!;

    public virtual Ciclo IdCicloNavigation { get; set; } = null!;

    public virtual Periodo IdPeriodoNavigation { get; set; } = null!;
}
