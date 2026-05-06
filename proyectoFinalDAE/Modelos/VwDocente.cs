using System;
using System.Collections.Generic;

namespace proyectoFinalDAE.Modelos;

public partial class VwDocente
{
    public int IdDocente { get; set; }

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string Categoria { get; set; } = null!;

    public string? Especialidad { get; set; }

    public string? NivelAcademico { get; set; }

    public string? Telefono { get; set; }

    public bool Estado { get; set; }
}
