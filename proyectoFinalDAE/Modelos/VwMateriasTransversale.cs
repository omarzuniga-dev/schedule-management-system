using System;
using System.Collections.Generic;

namespace proyectoFinalDAE.Modelos;

public partial class VwMateriasTransversale
{
    public int IdAsignatura { get; set; }

    public string CodigoAsignatura { get; set; } = null!;

    public string NombreAsignatura { get; set; } = null!;

    public string Naturaleza { get; set; } = null!;

    public byte Creditos { get; set; }
}
