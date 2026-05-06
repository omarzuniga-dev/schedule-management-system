using System;
using System.Collections.Generic;

namespace proyectoFinalDAE.Modelos;

public partial class VwHorarioAsincrono
{
    public int IdHorario { get; set; }

    public string NombrePeriodo { get; set; } = null!;

    public string GrupoBase { get; set; } = null!;

    public string Familia { get; set; } = null!;

    public string? Turno { get; set; }

    public string CodigoAsignatura { get; set; } = null!;

    public string NombreAsignatura { get; set; } = null!;

    public byte Creditos { get; set; }

    public string Docente { get; set; } = null!;

    public string TipoClase { get; set; } = null!;

    public string? SemanaRango { get; set; }

    public string Estado { get; set; } = null!;

    public int IdBloque { get; set; }

    public byte? DiaSemana { get; set; }

    public TimeOnly? HoraInicio { get; set; }

    public TimeOnly? HoraFin { get; set; }
}
