using System;
using System.Collections.Generic;

namespace proyectoFinalDAE.Modelos;

public partial class VwHorariosDetallado
{
    public int IdHorario { get; set; }

    public string? Carrera { get; set; }

    public string? Ciclo { get; set; }

    public string NombreAsignatura { get; set; } = null!;

    public string? Naturaleza { get; set; }

    public string NombreSeccion { get; set; } = null!;

    public string? Familia { get; set; }

    public TimeOnly? HoraInicio { get; set; }

    public TimeOnly? HoraFin { get; set; }

    public string? Dia { get; set; }

    public string? CodigoAula { get; set; }

    public string? ModalidadClase { get; set; }

    public string Docente { get; set; } = null!;

    public string Activo { get; set; } = null!;
}
