using System;
using System.Collections.Generic;

namespace proyectoFinalDAE.Modelos;

public partial class VwHorarioPorCarrera
{
    public int IdCarrera { get; set; }

    public string NombreCarrera { get; set; } = null!;

    public int IdCiclo { get; set; }

    public string NombreCiclo { get; set; } = null!;

    public byte OrdenCiclo { get; set; }

    public int IdSeccion { get; set; }

    public string GrupoBase { get; set; } = null!;

    public string Familia { get; set; } = null!;

    public string? Turno { get; set; }

    public int IdHorario { get; set; }

    public string TipoClase { get; set; } = null!;

    public string? SemanaRango { get; set; }

    public string Estado { get; set; } = null!;

    public string CodigoAsignatura { get; set; } = null!;

    public string NombreAsignatura { get; set; } = null!;

    public string Naturaleza { get; set; } = null!;

    public byte Creditos { get; set; }

    public string Docente { get; set; } = null!;

    public byte? DiaSemana { get; set; }

    public string DiaSemanaNombre { get; set; } = null!;

    public TimeOnly? HoraInicio { get; set; }

    public TimeOnly? HoraFin { get; set; }

    public string CodigoAula { get; set; } = null!;

    public string TipoAula { get; set; } = null!;
}
