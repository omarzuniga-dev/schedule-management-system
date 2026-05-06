using System;
using System.Collections.Generic;

namespace proyectoFinalDAE.Modelos;

public partial class VwHorariosOrdenado
{
    public string? Carrera { get; set; }

    public string? Ciclo { get; set; }

    public int IdAsignatura { get; set; }

    public string? Naturaleza { get; set; }

    public int IdSeccion { get; set; }

    public string? Familia { get; set; }

    public TimeOnly? HoraInicio { get; set; }

    public TimeOnly? HoraFin { get; set; }

    public string? Dia { get; set; }

    public string? CodigoAula { get; set; }

    public string? ModalidadClase { get; set; }

    public int? IdDocente { get; set; }

    public string Estado { get; set; } = null!;
}
