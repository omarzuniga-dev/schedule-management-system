using System;
using System.Collections.Generic;

namespace proyectoFinalDAE.Modelos;

public partial class VwAsignaturasActualizadum
{
    public int IdAsignatura { get; set; }

    public string CodigoAsignatura { get; set; } = null!;

    public string NombreAsignatura { get; set; } = null!;

    public string Naturaleza { get; set; } = null!;

    public byte Creditos { get; set; }

    public string? Modalidad { get; set; }

    public string? Especialidad { get; set; }

    public string NombreCarrera { get; set; } = null!;

    public bool EsTransversal { get; set; }
}
