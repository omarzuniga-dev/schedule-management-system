using System;
using System.Collections.Generic;

namespace proyectoFinalDAE.Modelos;

public partial class Horario
{
    public int IdHorario { get; set; }

    public int IdSeccion { get; set; }

    public int? IdAula { get; set; }

    public int IdAsignatura { get; set; }

    public int? IdDocente { get; set; }

    public string TipoClase { get; set; } = null!;

    public string? SemanaRango { get; set; }

    public string Estado { get; set; } = null!;

    public string? ModalidadClase { get; set; }

    public string? Dia { get; set; }

    public TimeOnly? HoraInicio { get; set; }

    public TimeOnly? HoraFin { get; set; }

    public string? Carrera { get; set; }

    public string? Ciclo { get; set; }

    public string? Naturaleza { get; set; }

    public string? Familia { get; set; }

    public string? CodigoAula { get; set; }

    public virtual Asignatura IdAsignaturaNavigation { get; set; } = null!;

    public virtual Aula? IdAulaNavigation { get; set; }

    public virtual Docente? IdDocenteNavigation { get; set; }

    public virtual Seccion IdSeccionNavigation { get; set; } = null!;
}
