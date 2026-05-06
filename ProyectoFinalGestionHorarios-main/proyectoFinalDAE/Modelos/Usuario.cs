using System;
using System.Collections.Generic;

namespace proyectoFinalDAE.Modelos;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string NombreUsuario { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string ContraseñaHash { get; set; } = null!;

    public bool Activo { get; set; }

    public virtual ICollection<Rol> IdRols { get; set; } = new List<Rol>();
}
