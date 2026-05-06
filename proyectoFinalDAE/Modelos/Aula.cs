using System;
using System.Collections.Generic;

namespace proyectoFinalDAE.Modelos;

public partial class Aula
{
    public int IdAula { get; set; }

    public int IdSede { get; set; }

    public string CodigoAula { get; set; } = null!;

    public short Capacidad { get; set; }

    public string Tipo { get; set; } = null!;

    public bool Disponible { get; set; }

    public virtual ICollection<Horario> Horarios { get; set; } = new List<Horario>();

    public virtual Sede IdSedeNavigation { get; set; } = null!;
}
