using System;
using System.Collections.Generic;

namespace proyectoFinalDAE.Modelos;

public partial class Sede
{
    public int IdSede { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Direccion { get; set; }

    public virtual ICollection<Aula> Aulas { get; set; } = new List<Aula>();
}
