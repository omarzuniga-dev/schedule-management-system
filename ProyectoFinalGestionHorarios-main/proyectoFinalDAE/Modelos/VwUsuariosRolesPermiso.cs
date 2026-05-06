using System;
using System.Collections.Generic;

namespace proyectoFinalDAE.Modelos;

public partial class VwUsuariosRolesPermiso
{
    public int IdUsuario { get; set; }

    public string NombreUsuario { get; set; } = null!;

    public string Email { get; set; } = null!;

    public bool Activo { get; set; }

    public int? IdRol { get; set; }

    public string? NombreRol { get; set; }

    public int? IdPermiso { get; set; }

    public string? NombrePermiso { get; set; }
}
