using System;
using System.Collections.Generic;

namespace proyectoFinalDAE.Modelos;

public partial class VwHorarioDetalle
{
    public int IdHorario { get; set; }

    public string NombrePeriodo { get; set; } = null!;

    public string GrupoBase { get; set; } = null!;

    public string Familia { get; set; } = null!;

    public string NombreCarrera { get; set; } = null!;

    public string NombreCiclo { get; set; } = null!;

    public string CodigoAula { get; set; } = null!;

    public string TipoAula { get; set; } = null!;

    public byte DiaSemana { get; set; }

    public TimeOnly? HoraInicio { get; set; }

    public TimeOnly? HoraFin { get; set; }

    public string CodigoAsignatura { get; set; } = null!;

    public string NombreAsignatura { get; set; } = null!;

    public byte Creditos { get; set; }

    public string Naturaleza { get; set; } = null!;

    public string Docente { get; set; } = null!;

    public string Categoria { get; set; } = null!;

    public string TipoClase { get; set; } = null!;

    public string? SemanaRango { get; set; }

    public string Estado { get; set; } = null!;
}
