using System;
using System.Collections.Generic;

namespace proyectoFinalDAE.Modelos;

public partial class VwAsignaturasSinProgramar
{
    public string NombreCarrera { get; set; } = null!;

    public string NombreCiclo { get; set; } = null!;

    public string CodigoAsignatura { get; set; } = null!;

    public string NombreAsignatura { get; set; } = null!;

    public string Naturaleza { get; set; } = null!;

    public byte Creditos { get; set; }
}
