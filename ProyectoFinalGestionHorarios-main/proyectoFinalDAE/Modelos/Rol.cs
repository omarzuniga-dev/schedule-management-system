using System;
using System.Collections.Generic;

namespace proyectoFinalDAE.Modelos;

public partial class Rol
{
    public int IdRol { get; set; }

    public string NombreRol { get; set; } = null!;

    public string? Descripcion { get; set; }

    public virtual ICollection<Permiso> IdPermisos { get; set; } = new List<Permiso>();

    public virtual ICollection<Usuario> IdUsuarios { get; set; } = new List<Usuario>();
}
