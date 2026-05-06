using System;
using System.Collections.Generic;

namespace proyectoFinalDAE.Modelos;

public partial class PlanDeEstudio
{
    public int IdPlan { get; set; }

    public int IdCarrera { get; set; }

    public string Version { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public virtual Carrera IdCarreraNavigation { get; set; } = null!;

    public virtual ICollection<PlanAsignatura> PlanAsignaturas { get; set; } = new List<PlanAsignatura>();
}
