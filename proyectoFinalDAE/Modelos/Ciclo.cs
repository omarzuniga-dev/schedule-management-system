using System;
using System.Collections.Generic;

namespace proyectoFinalDAE.Modelos;

public partial class Ciclo
{
    public int IdCiclo { get; set; }

    public string NombreCiclo { get; set; } = null!;

    public byte Orden { get; set; }

    public virtual ICollection<PlanAsignatura> PlanAsignaturas { get; set; } = new List<PlanAsignatura>();

    public virtual ICollection<Seccion> Seccions { get; set; } = new List<Seccion>();
}
