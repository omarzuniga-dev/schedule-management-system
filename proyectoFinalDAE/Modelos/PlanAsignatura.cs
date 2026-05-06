using System;
using System.Collections.Generic;

namespace proyectoFinalDAE.Modelos;

public partial class PlanAsignatura
{
    public int IdPlan { get; set; }

    public int IdAsignatura { get; set; }

    public int IdCiclo { get; set; }

    public byte HorasTeoricasSemana { get; set; }

    public byte HorasPracticasSemana { get; set; }

    public virtual Asignatura IdAsignaturaNavigation { get; set; } = null!;

    public virtual Ciclo IdCicloNavigation { get; set; } = null!;

    public virtual PlanDeEstudio IdPlanNavigation { get; set; } = null!;
}
