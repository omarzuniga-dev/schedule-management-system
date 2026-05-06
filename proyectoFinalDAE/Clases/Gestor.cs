using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using proyectoFinalDAE.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static proyectoFinalDAE.Form1;

//"Server=192.168.0.14;Database=Horario_Escuela_Computacion;User Id=ravelar;Password=itca;TrustServerCertificate=True;Encrypt=False;"

namespace proyectoFinalDAE.Clases
{
    internal class Gestor
    {
        //Metodo para añadir docentes
        public void agregarDocente(Docente docente)
        {
            using (var context = new HorarioEscuelaComputacionContext())
            {
                context.Add(docente);
                context.SaveChanges();
            }
        }
        //Metodo para modificar docentes
        public void actualizarDocente(Docente docente)
        {
            using (var context = new HorarioEscuelaComputacionContext())
            {
                context.Update(docente);
                context.SaveChanges();
            }
        }
        //Metodo eliminar docentes 
        public void eliminarDocente(int idDocente)
        {
            using (var context = new HorarioEscuelaComputacionContext())
            {
                var docenteSeleccionado = context.Docentes.Find(idDocente);
                docenteSeleccionado.Estado = false;
                context.Update(docenteSeleccionado);
                context.SaveChanges();
            }
        }
        //Metodo para listar docentes
        /*
        public async Task<List<Docente>> listarDocentes()
        {
            using var context = new HorarioEscuelaComputacionContext();
            return await context.Docentes
                    .OrderBy(c => c.Nombres + ' ' + c.Apellidos)
                    .ToListAsync();
        }*/
        public async Task<bool> ExisteRegistro<T>(Expression<Func<T, bool>> condicion) where T : class
        {
            using var context = new HorarioEscuelaComputacionContext();
            return await context.Set<T>().AnyAsync(condicion);
        }
        public async Task<List<Docente>> listarDocentes()
        {
            using var context = new HorarioEscuelaComputacionContext();
            var query = context.Docentes.AsQueryable();
            if (SesionUsuario.EsTransversal)
            {
                query = query.Where(x => x.Especialidad == "Transversales");
            }
            return await query
                .OrderBy(c => c.Nombres + " " + c.Apellidos)
                .ToListAsync();
        }
        public async Task<List<string>> listarDocentesUsuario()
        {
            using var context = new HorarioEscuelaComputacionContext();
            return await context.Docentes
                    .Where(x => x.Nombres != null && x.Apellidos != null)
                    .Select(x => x.Nombres + "_" + x.Apellidos)
                    .ToListAsync();

        }
        //Metodos para consultar especialidad, categoria y nivel academico
        /*
        public async Task<List<string>> consultarEspecialidad()
        {
            using var context = new HorarioEscuelaComputacionContext();
            return await context.VwDocentes
                .Select(x => x.Especialidad)
                .Where(x => x != null)
                .Distinct()
                .OrderBy(x => x)
                .ToListAsync();
        }*/
        public async Task<List<string>> consultarEspecialidad()
        {
            using var context = new HorarioEscuelaComputacionContext();
            var query = context.VwDocentes.AsQueryable();
            if (SesionUsuario.EsTransversal)
            {
                query = query.Where(x => x.Especialidad == "Transversales");
            }
            return await query
                .Select(x => x.Especialidad)
                .Where(x => x != null)
                .Distinct()
                .OrderBy(x => x)
                .ToListAsync();
        }
        public async Task<List<string>> consultarCategoria()
        {
            using var context = new HorarioEscuelaComputacionContext();
            return await context.VwDocentes
                .Select(x => x.Categoria)
                .Where(x => x != null)
                .Distinct()
                .OrderBy(x => x)
                .ToListAsync();

        }
        public async Task<List<string>> consultarNvAcademico()
        {
            using var context = new HorarioEscuelaComputacionContext();
            return await context.VwDocentes
                .Select(x => x.NivelAcademico)
                .Where(x => x != null)
                .Distinct()
                .OrderBy(x => x)
                .ToListAsync();

        }
        //Metodo para iniciar sesion
        public Usuario ValidarLogin(string usuario, string contraseña)
        {
            using (var context = new HorarioEscuelaComputacionContext())
            {
                try
                {
                    // La consulta debe buscar el objeto, no solo verificar si existe (.Any()).
                    var usuarioObjeto = context.Usuarios
                        .FirstOrDefault(u => u.NombreUsuario == usuario &&
                                             u.ContraseñaHash == contraseña);

                    // FirstOrDefault devuelve el primer objeto que coincide o 'null' si no encuentra ninguno.
                    return usuarioObjeto;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al validar usuario: {ex.Message}", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                    // Devuelve null en caso de excepción
                    return null;
                }
            }
        }


        //Metodo para añadir materias
        public void agregarMateria(Asignatura asignatura)
        {
            using (var context = new HorarioEscuelaComputacionContext())
            {
                context.Add(asignatura);
                context.SaveChanges();
            }
        }
        //Metodo para modificar materias
        public void actualizarMateria(Asignatura asignatura)
        {
            using (var context = new HorarioEscuelaComputacionContext())
            {
                context.Update(asignatura);
                context.SaveChanges();
            }
        }
        //Metodo para listar materias
        public async Task<List<VwAsignaturasActualizadum>> listarMaterias()
        {
            using var context = new HorarioEscuelaComputacionContext();
            var query = context.VwAsignaturasActualizada.AsQueryable();
            if (SesionUsuario.EsTransversal)
            {
                query = query.Where(x => x.Naturaleza == "Transversal");
            }
            return query.ToList();
        }
        //Metodo para listar tipos de materias
        /*
        public async Task<List<string>> consultarTipoMaterias()
        {
            using var context = new HorarioEscuelaComputacionContext();
            return await context.Asignaturas
                .Select(x => x.Naturaleza)
                .Where(x => x != null)
                .Distinct()
                .OrderBy(x => x)
                .ToListAsync();
        }*/
        public async Task<List<string>> consultarTipoMaterias()
        {
            using var context = new HorarioEscuelaComputacionContext();
            var query = context.Asignaturas.AsQueryable();
            if (SesionUsuario.EsTransversal)
            {

                query = query.Where(x => x.Naturaleza == "Transversal");
            }
            return await query
                .Select(x => x.Naturaleza)
                .Where(x => x != null)
                .Distinct()
                .OrderBy(x => x)
                .ToListAsync();
        }
        //Metodos para listar carreras y especialidades
        public async Task<List<Carrera>> listarCarreras()
        {
            using (var context = new HorarioEscuelaComputacionContext())
            {
                return await context.Carreras
                    .OrderBy(c => c.NombreCarrera) 
                    .Where(c => c.Estado == true)
                    .ToListAsync();
            }
        }
        public async Task<List<Carrera>> listarCarrerasEsme()
        {

            using (var context = new HorarioEscuelaComputacionContext())
            {
                return await context.Carreras
                    .Where(c => c.Estado == true)               // trae solo las carreras activas (estado=true)
                    .OrderBy(c => c.NombreCarrera)
                    .ToListAsync(); // ejecuto la consulta y agrego a la lista
            }
        }
        public void agregarCarrera(Carrera carrera) //AGREGAR CARRERA con esto agrego una nueva carrera a la base de datos 
        {
            using var context = new HorarioEscuelaComputacionContext();

            var nombre = (carrera.NombreCarrera ?? "").Trim();  //para espacios y mayusculas y minusculas 

            if (string.IsNullOrWhiteSpace(nombre)) // si el usuario no escribio nada 
                throw new InvalidOperationException("El nombre de la carrera es obligatorio.");

            //esto es para revisar si en la BDD ya existe una carrera con el mismo nombre 
            bool existe = context.Carreras
                .Any(c =>
                    c.NombreCarrera != null &&
                    c.NombreCarrera.Trim() == nombre
                );

            if (existe) // si ya existe detengo el proceso 
                throw new InvalidOperationException("Ya existe una carrera con ese nombre.");
            //guarda nombre y marca la carrera como activa 
            carrera.NombreCarrera = nombre;
            carrera.Estado = true;     // cuando se guarda una carrera se marca en activa automaticamente      
            context.Add(carrera);   //agrego el objeto carrera al contexto para cuando se le da guardar se agregue a la BDD 
            context.SaveChanges(); // guardo en la BDD
        }

        public void actualizarCarrera(Carrera carrera) //ACTUALIZAR CARRERA POR SI QUIERO MODIFICAR ALGO EN UNA CARRERA YA EXISTENTE 
        {
            using var context = new HorarioEscuelaComputacionContext();

            context.Entry(carrera).State = EntityState.Detached;
            var actual = context.Carreras.Find(carrera.IdCarrera); // bus carrera BDD usando el id

            if (actual == null)
            {
                throw new InvalidOperationException("Carrera no encontrada.");
            }

            var nombre = (carrera.NombreCarrera ?? "").Trim(); // nombre carrera con mayusculas minusculas o espacios

            if (string.IsNullOrWhiteSpace(nombre)) // valido que no venga vacio 
                throw new InvalidOperationException("El nombre de la carrera es obligatorio.");
            //validar para que no exista otra carrera con ese nombre 
            bool duplicado = context.Carreras
                .Any(c =>
                    c.IdCarrera != carrera.IdCarrera && // que no sea la misma carrera 
                    c.NombreCarrera != null &&
                    c.NombreCarrera.Trim() == nombre // el nombre con espacios y mayuscula o minuscula 
                );

            if (duplicado)
            {
                throw new InvalidOperationException("Ya existe otra carrera con ese nombre.");
            }
            else
            {
                actual.NombreCarrera = nombre;
                actual.Tipo = carrera.Tipo;
                actual.Estado = carrera.Estado;
                context.SaveChanges(); //guardar en BDD 
            }
        }
        public void actualizarCarrrera(Carrera carrera)
        {
            using (var context = new HorarioEscuelaComputacionContext())
            {
                context.Update(carrera);
                context.SaveChanges();
            }
        }
        public void eliminarCarrera(int idCarrera) // ELIMINAR CARRERA EN ESTE CASO NO ES UN ELIMINAR DE DELETE ES UN SOFT DELETE O PASAR DE ESTADO ACTIVO A INACTIVO
        {
            using var context = new HorarioEscuelaComputacionContext();
            //busco la carrera por ID
            var carrera = context.Carreras.Find(idCarrera);
            if (carrera == null) return;

            carrera.Estado = false;   // esta parte es la que no elimina la carrera como tal solo la pasa a inactivo 
            context.SaveChanges();    // guardo el cambio 
        }

        //para el boton de mostrar activos e inactivos en el datagridview metodo listarCarreresInactivas

        public async Task<List<Carrera>> listarCarrerasInactivas()
        {
            using var context = new HorarioEscuelaComputacionContext();

            return await context.Carreras
                .Where(c => c.Estado == false)   // solo las inactivas
                .OrderBy(c => c.NombreCarrera)
                .ToListAsync(); // ejecuto la consulta y devuelvo la lista 
        }
        public async Task<List<string>> listarEspecialidades()
        {
            using (var context = new HorarioEscuelaComputacionContext())
            {
                return await context.Carreras
                    .Select(c => c.Tipo)
                    .Distinct()
                    .OrderBy(n => n) 
                    .ToListAsync();
            }
        }
        //Metodo para listar horarios
        public async Task<List<VwHorariosDetallado>> listarHorario(bool mostrarInactivos)
        {
            using (var context = new HorarioEscuelaComputacionContext())
            {
                IQueryable<VwHorariosDetallado> query = context.VwHorariosDetallados;
                if (mostrarInactivos)
                {
                    query = query.Where(h => h.Activo == "Inactivo");
                }
                else
                {
                    query = query.Where(h => h.Activo == "Activo");
                }
                return await query.ToListAsync();
            }
        }
        public async Task<List<Periodo>> listarCiclos()
        {
            using (var context = new HorarioEscuelaComputacionContext())
            {
                return await context.Periodos
                    .OrderBy(c => c.NombrePeriodo)
                    .ToListAsync();
            }
        }
        public async Task<List<Seccion>> listarSeccion()
        {
            using (var context = new HorarioEscuelaComputacionContext())
            {
                return await context.Seccions
                    .OrderBy(c => c.GrupoBase) 
                    .GroupBy(c => c.GrupoBase) 
                    .Select(g => g.First())    
                    .ToListAsync();
            }
        }
        /*
        public async Task<List<Asignatura>> listarMateriasConId()
        {
            using (var context = new HorarioEscuelaComputacionContext())
            {
                return await context.Asignaturas
                    .OrderBy(c => c.NombreAsignatura)
                    .Distinct()
                    .ToListAsync();
            }
        }*/
        public async Task<List<Asignatura>> listarMateriasConId()
        {
            using var context = new HorarioEscuelaComputacionContext();
            var query = context.Asignaturas.AsQueryable();
            if (SesionUsuario.EsTransversal)
            {
                query = query.Where(x => x.Naturaleza == "Transversal");
            }

            return await query
                .OrderBy(c => c.NombreAsignatura)
                .Distinct()
                .ToListAsync();
        }
        public async Task<List<VwSeccionesDetalle>> listarVistaSecciones()
        {
            using (var context = new HorarioEscuelaComputacionContext())
            {
                return await context.VwSeccionesDetalles
                    .OrderBy(c => c.GrupoBase)
                    .Distinct()
                    .ToListAsync();
            }
        }
        public async Task<List<Aula>> listarAulas()
        {
            using (var context = new HorarioEscuelaComputacionContext())
            {
                return await context.Aulas
                            .OrderBy(c => c.CodigoAula == "NA" ? 0 : 1)
                            .ThenBy(c => c.CodigoAula)
                            .ToListAsync();
            }
        }


        //Metodo para añadir horarios
        public async Task<string> agregarHorario(Horario nuevoHorario)
        {
            using (var context = new HorarioEscuelaComputacionContext())
            {
                string errorSeccion = await ValidarDisponibilidadSeccion(context, nuevoHorario);
                if (errorSeccion != null)
                {
                    return errorSeccion;
                }
                string errorDocente = await ValidarDisponibilidadDocente(context, nuevoHorario);
                if (errorDocente != null)
                {
                    return errorDocente;
                }
                string errorAula = await ValidarDisponibilidadAula(context, nuevoHorario);
                if (errorAula != null)
                {
                    return errorAula;
                }
                context.Horarios.Add(nuevoHorario);
                await context.SaveChangesAsync();
                return "Horario guardado correctamente.";
            }
        }


        private async Task<string> ValidarDisponibilidadDocente(HorarioEscuelaComputacionContext context, Horario nuevoHorario)
        {
            var conflicto = await context.Horarios
                .Where(h => h.IdDocente == nuevoHorario.IdDocente &&
                            h.Dia == nuevoHorario.Dia &&
                            h.HoraInicio < nuevoHorario.HoraFin && 
                            h.HoraFin > nuevoHorario.HoraInicio)  
                .FirstOrDefaultAsync();

            if (conflicto != null)
            {
                return $"El docente ya tiene un horario asignado el {nuevoHorario.Dia} de {conflicto.HoraInicio} a {conflicto.HoraFin}.";
            }
            return null; // Disponible
        }


        private async Task<string> ValidarDisponibilidadAula(HorarioEscuelaComputacionContext context, Horario nuevoHorario)
        {
            const int IdAulaVirtual = 1;
            if (nuevoHorario.IdAula == IdAulaVirtual || nuevoHorario.CodigoAula == "NA")
            {
                return null; // El aula virtual/NA nunca genera conflicto de tiempo.
            }
            var conflicto = await context.Horarios
                .Where(h => h.IdAula == nuevoHorario.IdAula &&
                            h.Dia == nuevoHorario.Dia &&
                            h.HoraInicio < nuevoHorario.HoraFin &&
                            h.HoraFin > nuevoHorario.HoraInicio)
                .FirstOrDefaultAsync();

            if (conflicto != null)
            {
                return $"El aula ya está reservada el {nuevoHorario.Dia} de {conflicto.HoraInicio} a {conflicto.HoraFin}.";
            }
            return null;
        }

        //Metodo para modificar horario
        public async Task<string> actualizarHorario(Horario horarioEditado)
        {
            using (var context = new HorarioEscuelaComputacionContext())
            {
                string errorSeccion = await ValidarDisponibilidadSeccion(context, horarioEditado, horarioEditado.IdHorario);
                if (errorSeccion != null)
                {
                    return errorSeccion;
                }
                string errorDocente = await ValidarActualizacionDocente(context, horarioEditado, horarioEditado.IdHorario);
                if (errorDocente != null)
                {
                    return errorDocente;
                }
                string errorAula = await ValidarActualizacionAula(context, horarioEditado, horarioEditado.IdHorario);
                if (errorAula != null)
                {
                    return errorAula;
                }
                context.Entry(horarioEditado).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return "Horario actualizado correctamente.";
            }
        }


        private async Task<string> ValidarActualizacionDocente(HorarioEscuelaComputacionContext context, Horario horario, int idHorarioExcluir)
        {
            var conflicto = await context.Horarios
                .Where(h => h.IdHorario != idHorarioExcluir && 
                            h.IdDocente == horario.IdDocente &&
                            h.Dia == horario.Dia &&
                            h.HoraInicio < horario.HoraFin &&
                            h.HoraFin > horario.HoraInicio)
                .FirstOrDefaultAsync();

            if (conflicto != null)
            {
                return $"Error: El docente ya tiene otro horario asignado el {horario.Dia} de {conflicto.HoraInicio} a {conflicto.HoraFin}.";
            }
            return null;
        }

        private async Task<string> ValidarActualizacionAula(HorarioEscuelaComputacionContext context, Horario horario, int idHorarioExcluir)
        {
            const int IdAulaVirtual = 1;
            if (horario.IdAula == IdAulaVirtual || horario.CodigoAula == "NA")
            {
                return null; // El aula virtual/NA nunca genera conflicto de tiempo.
            }
            var conflicto = await context.Horarios
                .Where(h => h.IdHorario != idHorarioExcluir &&
                            h.IdAula != IdAulaVirtual &&
                            h.Estado == "Activo" &&
                            h.IdAula == horario.IdAula &&
                            h.Dia == horario.Dia &&
                            h.HoraInicio < horario.HoraFin &&
                            h.HoraFin > horario.HoraInicio)
                .FirstOrDefaultAsync();

            if (conflicto != null)
            {
                return $"Error: El aula {horario.CodigoAula} ya está reservada el {horario.Dia} de {conflicto.HoraInicio}  a  {conflicto.HoraFin}.";
            }
            return null;
        }

        private async Task<string> ValidarDisponibilidadSeccion(HorarioEscuelaComputacionContext context, Horario horario, int idHorarioExcluir = 0)
        {

            var conflicto = await context.Horarios
            .Where(h =>
            h.IdHorario != idHorarioExcluir &&
            h.Estado == "Activo" &&
            h.IdSeccion == horario.IdSeccion &&
            h.Dia == horario.Dia &&
            h.HoraFin > horario.HoraInicio &&
            h.HoraInicio < horario.HoraFin
        )
        .FirstOrDefaultAsync();
            if (conflicto != null)
            {
                return $"Error: La sección ya tiene un horario asignado el {conflicto.Dia} de {conflicto.HoraInicio} a {conflicto.HoraFin}. No se puede asignar una segunda materia.";
            }
            return null; // Disponible
        }

        //Metodo eliminar horario
        public void eliminarHorario(int idHorario)
        {
            using (var context = new HorarioEscuelaComputacionContext())
            {
                var horarioSeleccionado = context.Horarios.Find(idHorario);
                if (horarioSeleccionado != null)
                {
                    horarioSeleccionado.Estado = "Inactivo";
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception($"No se encontró el horario con ID: {idHorario}");
                }
            }
        }
        //Metodo para añadir Secciones
        public void agregarSeccion(Seccion seccion)
        {
            using (var context = new HorarioEscuelaComputacionContext())
            {
                context.Add(seccion);
                context.SaveChanges();
            }
        }
        //Metodo para modificar secciones
        public void actualizarSecciones(Seccion seccion)
        {
            using (var context = new HorarioEscuelaComputacionContext())
            {
                context.Update(seccion);
                context.SaveChanges();
            }
        }
        //Metodo para añadir Ciclos
        public void agregarCiclos(Periodo periodo)
        {
            using (var context = new HorarioEscuelaComputacionContext())
            {
                context.Add(periodo);
                context.SaveChanges();
            }
        }
        //Metodo para modificar Ciclos
        public void actualizarCiclos(Periodo periodo)
        {
            using (var context = new HorarioEscuelaComputacionContext())
            {
                context.Update(periodo);
                context.SaveChanges();
            }
        }
        //Metodo para añadir aulas
        public void agregarAulas(Aula aula)
        {
            using (var context = new HorarioEscuelaComputacionContext())
            {
                context.Add(aula);
                context.SaveChanges();
            }
        }
        //Metodo para modificar aulas
        public void actualizarAula(Aula aula)
        {
            using (var context = new HorarioEscuelaComputacionContext())
            {
                context.Update(aula);
                context.SaveChanges();
            }
        }
        //Metodo eliminar aulas 
        public void eliminarAula(int idAula)
        {
            using (var context = new HorarioEscuelaComputacionContext())
            {
                var aulaSeleccionado = context.Aulas.Find(idAula);
                aulaSeleccionado.Disponible = false;
                context.Update(aulaSeleccionado);
                context.SaveChanges();
            }
        }
        public async Task<List<Usuario>> listarUsuarios()
        {
            using (var context = new HorarioEscuelaComputacionContext())
            {
                return await context.Usuarios
                            .OrderBy(c => c.NombreUsuario)
                            .Distinct()
                            .ToListAsync();
            }
        }
        public void agregarUsuario(Usuario usuario)
        {
            using (var context = new HorarioEscuelaComputacionContext())
            {
                context.Add(usuario);
                context.SaveChanges();
            }
        }
        public void actualizarUsuario(Usuario usuario)
        {
            using (var context = new HorarioEscuelaComputacionContext())
            {
                context.Update(usuario);
                context.SaveChanges();
            }
        }
        //Metodo eliminar docentes 
        public void eliminarUsuario(int idUsuario)
        {
            using (var context = new HorarioEscuelaComputacionContext())
            {
                var usuarioSeleccionado = context.Usuarios.Find(idUsuario);
                usuarioSeleccionado.Activo = false;
                context.Update(usuarioSeleccionado);
                context.SaveChanges();
            }
        }
        public async Task RegistrarLog(string accion, string tabla, string descripcion)
        {
            using var context = new HorarioEscuelaComputacionContext();

            var nuevoLog = new Log
            {
                Usuario = SesionUsuario.UsuarioActual ?? "Sistema",
                Fecha = DateTime.Now,
                Accion = accion,
                TablaAfectada = tabla,
                Descripcion = descripcion
            };

            // Agregamos a la tabla Logs
            context.Logs.Add(nuevoLog);

            // Guardamos
            await context.SaveChangesAsync();
        }
    }
}
