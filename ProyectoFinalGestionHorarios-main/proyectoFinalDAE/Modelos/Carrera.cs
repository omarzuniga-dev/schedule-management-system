using System;
using System.Collections.Generic;

namespace proyectoFinalDAE.Modelos;

public partial class Carrera
{
    public int IdCarrera { get; set; }

    public string NombreCarrera { get; set; } = null!;

    public string Tipo { get; set; } = null!;

    public bool Estado { get; set; }

    public virtual ICollection<Asignatura> Asignaturas { get; set; } = new List<Asignatura>();

    public virtual ICollection<PlanDeEstudio> PlanDeEstudios { get; set; } = new List<PlanDeEstudio>();

    public virtual ICollection<Seccion> Seccions { get; set; } = new List<Seccion>();
}
