using System;
using System.Collections.Generic;

namespace proyectoFinalDAE.Modelos;

public partial class VwBloquesAsincrono
{
    public int IdBloque { get; set; }

    public byte? DiaSemana { get; set; }

    public TimeOnly? HoraInicio { get; set; }

    public TimeOnly? HoraFin { get; set; }

    public int EsAsincrono { get; set; }
}
