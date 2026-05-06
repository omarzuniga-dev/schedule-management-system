using System;
using System.Collections.Generic;

namespace proyectoFinalDAE.Modelos;

public partial class Docente
{
    public int IdDocente { get; set; }

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string Categoria { get; set; } = null!;

    public string? Telefono { get; set; }

    public string? NivelAcademico { get; set; }

    public string? Especialidad { get; set; }

    public bool Estado { get; set; }

    public string NombreCompleto
    {
        get { return Nombres + " " + Apellidos; }
    }

    public string NombreUsuario
    {
        get { return Nombres + "_" + Apellidos; }
    }

    public virtual ICollection<Horario> Horarios { get; set; } = new List<Horario>();

    public virtual ICollection<Asignatura> IdAsignaturas { get; set; } = new List<Asignatura>();
}
