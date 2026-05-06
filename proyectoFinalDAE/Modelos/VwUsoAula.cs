using System;
using System.Collections.Generic;

namespace proyectoFinalDAE.Modelos;

public partial class VwUsoAula
{
    public string NombrePeriodo { get; set; } = null!;

    public int IdAula { get; set; }

    public string CodigoAula { get; set; } = null!;

    public string TipoAula { get; set; } = null!;

    public byte? DiaSemana { get; set; }

    public TimeOnly? HoraInicio { get; set; }

    public TimeOnly? HoraFin { get; set; }

    public string GrupoBase { get; set; } = null!;

    public string Familia { get; set; } = null!;

    public string CodigoAsignatura { get; set; } = null!;

    public string NombreAsignatura { get; set; } = null!;

    public string Docente { get; set; } = null!;

    public string TipoClase { get; set; } = null!;

    public string Estado { get; set; } = null!;
}
