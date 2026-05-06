using System;
using System.Collections.Generic;

namespace proyectoFinalDAE.Modelos;

public partial class VwCargaDocente
{
    public string NombrePeriodo { get; set; } = null!;

    public int IdDocente { get; set; }

    public string Docente { get; set; } = null!;

    public int? HorasTeoricasSemana { get; set; }

    public int? HorasPracticasSemana { get; set; }

    public int? HorasTotalesSemana { get; set; }
}
