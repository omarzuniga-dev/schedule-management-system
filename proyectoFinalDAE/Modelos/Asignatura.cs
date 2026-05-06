using System;
using System.Collections.Generic;

namespace proyectoFinalDAE.Modelos;

public partial class Asignatura
{
    public int IdAsignatura { get; set; }

    public string CodigoAsignatura { get; set; } = null!;

    public string NombreAsignatura { get; set; } = null!;

    public string Naturaleza { get; set; } = null!;

    public byte Creditos { get; set; }

    public string? Modalidad { get; set; }

    public string? Especialidad { get; set; }

    public int? IdCarrera { get; set; }

    public bool EsTransversal { get; set; }

    public virtual ICollection<Horario> Horarios { get; set; } = new List<Horario>();

    public virtual Carrera? IdCarreraNavigation { get; set; }

    public virtual ICollection<PlanAsignatura> PlanAsignaturas { get; set; } = new List<PlanAsignatura>();

    public virtual ICollection<Docente> IdDocentes { get; set; } = new List<Docente>();
}
