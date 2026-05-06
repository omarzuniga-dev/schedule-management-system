using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace proyectoFinalDAE.Modelos;

public partial class HorarioEscuelaComputacionContext : DbContext
{
    public HorarioEscuelaComputacionContext()
    {
    }

    public HorarioEscuelaComputacionContext(DbContextOptions<HorarioEscuelaComputacionContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Log> Logs { get; set; }

    public virtual DbSet<Asignatura> Asignaturas { get; set; }

    public virtual DbSet<Aula> Aulas { get; set; }

    public virtual DbSet<BloqueHorario> BloqueHorarios { get; set; }

    public virtual DbSet<CalendarioFeriado> CalendarioFeriados { get; set; }

    public virtual DbSet<Carrera> Carreras { get; set; }

    public virtual DbSet<Ciclo> Ciclos { get; set; }

    public virtual DbSet<Docente> Docentes { get; set; }

    public virtual DbSet<Horario> Horarios { get; set; }

    public virtual DbSet<Periodo> Periodos { get; set; }

    public virtual DbSet<Permiso> Permisos { get; set; }

    public virtual DbSet<PlanAsignatura> PlanAsignaturas { get; set; }

    public virtual DbSet<PlanDeEstudio> PlanDeEstudios { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Seccion> Seccions { get; set; }

    public virtual DbSet<Sede> Sedes { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<VwAsignatura> VwAsignaturas { get; set; }

    public virtual DbSet<VwAsignaturasActualizadum> VwAsignaturasActualizada { get; set; }

    public virtual DbSet<VwAsignaturasSinProgramar> VwAsignaturasSinProgramars { get; set; }

    public virtual DbSet<VwBloquesAsincrono> VwBloquesAsincronos { get; set; }

    public virtual DbSet<VwCargaDocente> VwCargaDocentes { get; set; }

    public virtual DbSet<VwCarrerasPlan> VwCarrerasPlans { get; set; }

    public virtual DbSet<VwDetalleSeccion> VwDetalleSeccions { get; set; }

    public virtual DbSet<VwDocente> VwDocentes { get; set; }

    public virtual DbSet<VwDocentesTecnico> VwDocentesTecnicos { get; set; }

    public virtual DbSet<VwDocentesTransversale> VwDocentesTransversales { get; set; }

    public virtual DbSet<VwHorarioAsincrono> VwHorarioAsincronos { get; set; }

    public virtual DbSet<VwHorarioCompleto> VwHorarioCompletos { get; set; }

    public virtual DbSet<VwHorarioDetalle> VwHorarioDetalles { get; set; }

    public virtual DbSet<VwHorarioFiltroGeneral> VwHorarioFiltroGenerals { get; set; }

    public virtual DbSet<VwHorarioPorCarrera> VwHorarioPorCarreras { get; set; }

    public virtual DbSet<VwHorarioPorDocente> VwHorarioPorDocentes { get; set; }

    public virtual DbSet<VwHorariosDetallado> VwHorariosDetallados { get; set; }

    public virtual DbSet<VwHorariosOrdenado> VwHorariosOrdenados { get; set; }

    public virtual DbSet<VwMateriasTecnica> VwMateriasTecnicas { get; set; }

    public virtual DbSet<VwMateriasTransversale> VwMateriasTransversales { get; set; }

    public virtual DbSet<VwSeccionesDetalle> VwSeccionesDetalles { get; set; }

    public virtual DbSet<VwUsoAula> VwUsoAulas { get; set; }

    public virtual DbSet<VwUsuariosRolesPermiso> VwUsuariosRolesPermisos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configuration = new ConfigurationBuilder()
        .AddJsonFile(Path.Combine(AppContext.BaseDirectory, "appsettings.json"), optional:
        false, reloadOnChange: true)
        .Build();
        var connectionString = configuration.GetConnectionString("ConexionBD");
        optionsBuilder.UseSqlServer(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Asignatura>(entity =>
        {
            entity.HasKey(e => e.IdAsignatura).HasName("PK__Asignatu__DD251214F3C09CCC");

            entity.ToTable("Asignatura");

            entity.HasIndex(e => e.CodigoAsignatura, "UQ__Asignatu__015B13993659CB20").IsUnique();

            entity.Property(e => e.IdAsignatura).HasColumnName("idAsignatura");
            entity.Property(e => e.CodigoAsignatura)
                .HasMaxLength(20)
                .HasColumnName("codigoAsignatura");
            entity.Property(e => e.Creditos).HasColumnName("creditos");
            entity.Property(e => e.EsTransversal).HasColumnName("esTransversal");
            entity.Property(e => e.Especialidad)
                .HasMaxLength(80)
                .HasColumnName("especialidad");
            entity.Property(e => e.IdCarrera).HasColumnName("idCarrera");
            entity.Property(e => e.Modalidad)
                .HasMaxLength(20)
                .HasColumnName("modalidad");
            entity.Property(e => e.Naturaleza)
                .HasMaxLength(20)
                .HasColumnName("naturaleza");
            entity.Property(e => e.NombreAsignatura)
                .HasMaxLength(120)
                .HasColumnName("nombreAsignatura");

            entity.HasOne(d => d.IdCarreraNavigation).WithMany(p => p.Asignaturas)
                .HasForeignKey(d => d.IdCarrera)
                .HasConstraintName("FK_Asig_Carrera");

            entity.HasMany(d => d.IdDocentes).WithMany(p => p.IdAsignaturas)
                .UsingEntity<Dictionary<string, object>>(
                    "AsignaturaDocente",
                    r => r.HasOne<Docente>().WithMany()
                        .HasForeignKey("IdDocente")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Asignatur__idDoc__662B2B3B"),
                    l => l.HasOne<Asignatura>().WithMany()
                        .HasForeignKey("IdAsignatura")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Asignatur__idAsi__65370702"),
                    j =>
                    {
                        j.HasKey("IdAsignatura", "IdDocente").HasName("PK_AsigDoc");
                        j.ToTable("AsignaturaDocente");
                        j.IndexerProperty<int>("IdAsignatura").HasColumnName("idAsignatura");
                        j.IndexerProperty<int>("IdDocente").HasColumnName("idDocente");
                    });
        });

        modelBuilder.Entity<Aula>(entity =>
        {
            entity.HasKey(e => e.IdAula).HasName("PK__Aula__D861CCCB385C3904");

            entity.ToTable("Aula");

            entity.HasIndex(e => new { e.IdSede, e.CodigoAula }, "UQ_Aula").IsUnique();

            entity.Property(e => e.IdAula).HasColumnName("idAula");
            entity.Property(e => e.Capacidad).HasColumnName("capacidad");
            entity.Property(e => e.CodigoAula)
                .HasMaxLength(20)
                .HasColumnName("codigoAula");
            entity.Property(e => e.Disponible)
                .HasDefaultValue(true)
                .HasColumnName("disponible");
            entity.Property(e => e.IdSede).HasColumnName("idSede");
            entity.Property(e => e.Tipo)
                .HasMaxLength(20)
                .HasColumnName("tipo");

            entity.HasOne(d => d.IdSedeNavigation).WithMany(p => p.Aulas)
                .HasForeignKey(d => d.IdSede)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Aula__idSede__5812160E");
        });

        modelBuilder.Entity<BloqueHorario>(entity =>
        {
            entity.HasKey(e => e.IdBloque).HasName("PK__BloqueHo__EF4379A8B876097E");

            entity.ToTable("BloqueHorario");

            entity.Property(e => e.IdBloque).HasColumnName("idBloque");
            entity.Property(e => e.DiaSemana).HasColumnName("diaSemana");
            entity.Property(e => e.HoraFin).HasColumnName("horaFin");
            entity.Property(e => e.HoraInicio).HasColumnName("horaInicio");
        });

        modelBuilder.Entity<CalendarioFeriado>(entity =>
        {
            entity.HasKey(e => e.IdFeriado).HasName("PK__Calendar__777694483995A68A");

            entity.Property(e => e.IdFeriado).HasColumnName("idFeriado");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(150)
                .HasColumnName("descripcion");
            entity.Property(e => e.FechaFeriado).HasColumnName("fechaFeriado");
            entity.Property(e => e.IdPeriodo).HasColumnName("idPeriodo");

            entity.HasOne(d => d.IdPeriodoNavigation).WithMany(p => p.CalendarioFeriados)
                .HasForeignKey(d => d.IdPeriodo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Calendari__idPer__3C69FB99");
        });

        modelBuilder.Entity<Carrera>(entity =>
        {
            entity.HasKey(e => e.IdCarrera).HasName("PK__Carrera__7B19E791875B72CF");

            entity.ToTable("Carrera");

            entity.HasIndex(e => e.NombreCarrera, "UQ__Carrera__F1357427EFB69217").IsUnique();

            entity.Property(e => e.IdCarrera).HasColumnName("idCarrera");
            entity.Property(e => e.Estado).HasDefaultValue(true);
            entity.Property(e => e.NombreCarrera)
                .HasMaxLength(100)
                .HasColumnName("nombreCarrera");
            entity.Property(e => e.Tipo)
                .HasMaxLength(20)
                .HasColumnName("tipo");
        });

        modelBuilder.Entity<Ciclo>(entity =>
        {
            entity.HasKey(e => e.IdCiclo).HasName("PK__Ciclo__75424820E534E7EE");

            entity.ToTable("Ciclo");

            entity.Property(e => e.IdCiclo).HasColumnName("idCiclo");
            entity.Property(e => e.NombreCiclo)
                .HasMaxLength(20)
                .HasColumnName("nombreCiclo");
            entity.Property(e => e.Orden).HasColumnName("orden");
        });

        modelBuilder.Entity<Docente>(entity =>
        {
            entity.HasKey(e => e.IdDocente).HasName("PK__Docente__595F5B9C885C2CC4");

            entity.ToTable("Docente");

            entity.Property(e => e.IdDocente).HasColumnName("idDocente");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(80)
                .HasColumnName("apellidos");
            entity.Property(e => e.Categoria)
                .HasMaxLength(30)
                .HasColumnName("categoria");
            entity.Property(e => e.Especialidad)
                .HasMaxLength(80)
                .HasColumnName("especialidad");
            entity.Property(e => e.Estado)
                .HasDefaultValue(true)
                .HasColumnName("estado");
            entity.Property(e => e.NivelAcademico)
                .HasMaxLength(40)
                .HasColumnName("nivelAcademico");
            entity.Property(e => e.Nombres)
                .HasMaxLength(80)
                .HasColumnName("nombres");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Horario>(entity =>
        {
            entity.HasKey(e => e.IdHorario).HasName("PK__Horario__DE60F33A30134884");

            entity.ToTable("Horario", tb => tb.HasTrigger("trg_Horario_ValidarVirtualSinAula"));

            entity.Property(e => e.IdHorario).HasColumnName("idHorario");
            entity.Property(e => e.Carrera)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Ciclo)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.CodigoAula)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("codigoAula");
            entity.Property(e => e.Dia)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("dia");
            entity.Property(e => e.Estado)
                .HasMaxLength(15)
                .HasDefaultValue("Activo")
                .HasColumnName("estado");
            entity.Property(e => e.Familia)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("familia");
            entity.Property(e => e.HoraFin).HasColumnName("horaFin");
            entity.Property(e => e.HoraInicio).HasColumnName("horaInicio");
            entity.Property(e => e.IdAsignatura).HasColumnName("idAsignatura");
            entity.Property(e => e.IdAula).HasColumnName("idAula");
            entity.Property(e => e.IdDocente).HasColumnName("idDocente");
            entity.Property(e => e.IdSeccion).HasColumnName("idSeccion");
            entity.Property(e => e.ModalidadClase)
                .HasMaxLength(15)
                .HasColumnName("modalidadClase");
            entity.Property(e => e.Naturaleza)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("naturaleza");
            entity.Property(e => e.SemanaRango)
                .HasMaxLength(20)
                .HasColumnName("semanaRango");
            entity.Property(e => e.TipoClase)
                .HasMaxLength(10)
                .HasColumnName("tipoClase");

            entity.HasOne(d => d.IdAsignaturaNavigation).WithMany(p => p.Horarios)
                .HasForeignKey(d => d.IdAsignatura)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Horario__idAsign__71D1E811");

            entity.HasOne(d => d.IdAulaNavigation).WithMany(p => p.Horarios)
                .HasForeignKey(d => d.IdAula)
                .HasConstraintName("FK__Horario__idAula__70DDC3D8");

            entity.HasOne(d => d.IdDocenteNavigation).WithMany(p => p.Horarios)
                .HasForeignKey(d => d.IdDocente)
                .HasConstraintName("FK__Horario__idDocen__72C60C4A");

            entity.HasOne(d => d.IdSeccionNavigation).WithMany(p => p.Horarios)
                .HasForeignKey(d => d.IdSeccion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Horario__idSecci__6EF57B66");
        });

        modelBuilder.Entity<Periodo>(entity =>
        {
            entity.HasKey(e => e.IdPeriodo).HasName("PK__Periodo__90A7D3D8DB196AB2");

            entity.ToTable("Periodo");

            entity.HasIndex(e => e.NombrePeriodo, "UQ__Periodo__E9015E4437D589DA").IsUnique();

            entity.Property(e => e.IdPeriodo).HasColumnName("idPeriodo");
            entity.Property(e => e.EstadoPeriodo)
                .HasMaxLength(20)
                .HasColumnName("estadoPeriodo");
            entity.Property(e => e.FechaFin).HasColumnName("fechaFin");
            entity.Property(e => e.FechaInicio).HasColumnName("fechaInicio");
            entity.Property(e => e.NombrePeriodo)
                .HasMaxLength(20)
                .HasColumnName("nombrePeriodo");
        });

        modelBuilder.Entity<Permiso>(entity =>
        {
            entity.HasKey(e => e.IdPermiso).HasName("PK__Permiso__06A58486ED5D3A73");

            entity.ToTable("Permiso");

            entity.HasIndex(e => e.Codigo, "UQ_Permiso_Codigo").IsUnique();

            entity.HasIndex(e => e.NombrePermiso, "UQ__Permiso__3A3FB5287CA8ADCB").IsUnique();

            entity.Property(e => e.IdPermiso).HasColumnName("idPermiso");
            entity.Property(e => e.Codigo)
                .HasMaxLength(80)
                .HasColumnName("codigo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(150)
                .HasColumnName("descripcion");
            entity.Property(e => e.NombrePermiso)
                .HasMaxLength(120)
                .HasColumnName("nombrePermiso");
        });

        modelBuilder.Entity<PlanAsignatura>(entity =>
        {
            entity.HasKey(e => new { e.IdPlan, e.IdAsignatura, e.IdCiclo });

            entity.ToTable("PlanAsignatura");

            entity.Property(e => e.IdPlan).HasColumnName("idPlan");
            entity.Property(e => e.IdAsignatura).HasColumnName("idAsignatura");
            entity.Property(e => e.IdCiclo).HasColumnName("idCiclo");
            entity.Property(e => e.HorasPracticasSemana).HasColumnName("horasPracticasSemana");
            entity.Property(e => e.HorasTeoricasSemana).HasColumnName("horasTeoricasSemana");

            entity.HasOne(d => d.IdAsignaturaNavigation).WithMany(p => p.PlanAsignaturas)
                .HasForeignKey(d => d.IdAsignatura)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PlanAsign__idAsi__4F7CD00D");

            entity.HasOne(d => d.IdCicloNavigation).WithMany(p => p.PlanAsignaturas)
                .HasForeignKey(d => d.IdCiclo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PlanAsign__idCic__5070F446");

            entity.HasOne(d => d.IdPlanNavigation).WithMany(p => p.PlanAsignaturas)
                .HasForeignKey(d => d.IdPlan)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PlanAsign__idPla__4E88ABD4");
        });

        modelBuilder.Entity<PlanDeEstudio>(entity =>
        {
            entity.HasKey(e => e.IdPlan).HasName("PK__PlanDeEs__BECFB9966DBA48B9");

            entity.Property(e => e.IdPlan).HasColumnName("idPlan");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .HasColumnName("estado");
            entity.Property(e => e.IdCarrera).HasColumnName("idCarrera");
            entity.Property(e => e.Version)
                .HasMaxLength(20)
                .HasColumnName("version");

            entity.HasOne(d => d.IdCarreraNavigation).WithMany(p => p.PlanDeEstudios)
                .HasForeignKey(d => d.IdCarrera)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PlanDeEst__idCar__4316F928");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__Rol__3C872F766BBE57B1");

            entity.ToTable("Rol");

            entity.HasIndex(e => e.NombreRol, "UQ__Rol__2787B00C0697EC16").IsUnique();

            entity.Property(e => e.IdRol).HasColumnName("idRol");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(120)
                .HasColumnName("descripcion");
            entity.Property(e => e.NombreRol)
                .HasMaxLength(40)
                .HasColumnName("nombreRol");

            entity.HasMany(d => d.IdPermisos).WithMany(p => p.IdRols)
                .UsingEntity<Dictionary<string, object>>(
                    "RolPermiso",
                    r => r.HasOne<Permiso>().WithMany()
                        .HasForeignKey("IdPermiso")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_RolPermiso_Permiso"),
                    l => l.HasOne<Rol>().WithMany()
                        .HasForeignKey("IdRol")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_RolPermiso_Rol"),
                    j =>
                    {
                        j.HasKey("IdRol", "IdPermiso");
                        j.ToTable("RolPermiso");
                        j.IndexerProperty<int>("IdRol").HasColumnName("idRol");
                        j.IndexerProperty<int>("IdPermiso").HasColumnName("idPermiso");
                    });
        });

        modelBuilder.Entity<Seccion>(entity =>
        {
            entity.HasKey(e => e.IdSeccion).HasName("PK__Seccion__94B87A7C88B1D21D");

            entity.ToTable("Seccion");

            entity.HasIndex(e => new { e.IdPeriodo, e.IdCarrera, e.IdCiclo, e.GrupoBase, e.Familia }, "UQ_Seccion").IsUnique();

            entity.Property(e => e.IdSeccion).HasColumnName("idSeccion");
            entity.Property(e => e.CupoMax).HasColumnName("cupoMax");
            entity.Property(e => e.Familia)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("familia");
            entity.Property(e => e.GrupoBase)
                .HasMaxLength(20)
                .HasColumnName("grupoBase");
            entity.Property(e => e.IdCarrera).HasColumnName("idCarrera");
            entity.Property(e => e.IdCiclo).HasColumnName("idCiclo");
            entity.Property(e => e.IdPeriodo).HasColumnName("idPeriodo");
            entity.Property(e => e.Turno)
                .HasMaxLength(10)
                .HasColumnName("turno");

            entity.HasOne(d => d.IdCarreraNavigation).WithMany(p => p.Seccions)
                .HasForeignKey(d => d.IdCarrera)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Seccion__idCarre__6383C8BA");

            entity.HasOne(d => d.IdCicloNavigation).WithMany(p => p.Seccions)
                .HasForeignKey(d => d.IdCiclo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Seccion__idCiclo__6477ECF3");

            entity.HasOne(d => d.IdPeriodoNavigation).WithMany(p => p.Seccions)
                .HasForeignKey(d => d.IdPeriodo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Seccion__idPerio__628FA481");
        });

        modelBuilder.Entity<Sede>(entity =>
        {
            entity.HasKey(e => e.IdSede).HasName("PK__Sede__C5AF63D0E8CF9888");

            entity.ToTable("Sede");

            entity.Property(e => e.IdSede).HasColumnName("idSede");
            entity.Property(e => e.Direccion)
                .HasMaxLength(160)
                .HasColumnName("direccion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(80)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__645723A6AB1D68AF");

            entity.ToTable("Usuario");

            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.Activo)
                .HasDefaultValue(true)
                .HasColumnName("activo");
            entity.Property(e => e.ContraseñaHash)
                .HasMaxLength(255)
                .HasColumnName("contraseñaHash");
            entity.Property(e => e.Email)
                .HasMaxLength(120)
                .HasColumnName("email");
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(40)
                .HasColumnName("nombreUsuario");

            entity.HasMany(d => d.IdRols).WithMany(p => p.IdUsuarios)
                .UsingEntity<Dictionary<string, object>>(
                    "UsuarioRol",
                    r => r.HasOne<Rol>().WithMany()
                        .HasForeignKey("IdRol")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_UsuarioRol_Rol"),
                    l => l.HasOne<Usuario>().WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_UsuarioRol_Usuario"),
                    j =>
                    {
                        j.HasKey("IdUsuario", "IdRol");
                        j.ToTable("UsuarioRol");
                        j.IndexerProperty<int>("IdUsuario").HasColumnName("idUsuario");
                        j.IndexerProperty<int>("IdRol").HasColumnName("idRol");
                    });
        });

        modelBuilder.Entity<VwAsignatura>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_Asignaturas");

            entity.Property(e => e.CodigoAsignatura)
                .HasMaxLength(20)
                .HasColumnName("codigoAsignatura");
            entity.Property(e => e.Creditos).HasColumnName("creditos");
            entity.Property(e => e.IdAsignatura)
                .ValueGeneratedOnAdd()
                .HasColumnName("idAsignatura");
            entity.Property(e => e.Naturaleza)
                .HasMaxLength(20)
                .HasColumnName("naturaleza");
            entity.Property(e => e.NombreAsignatura)
                .HasMaxLength(120)
                .HasColumnName("nombreAsignatura");
        });

        modelBuilder.Entity<VwAsignaturasActualizadum>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_AsignaturasActualizada");

            entity.Property(e => e.CodigoAsignatura)
                .HasMaxLength(20)
                .HasColumnName("codigoAsignatura");
            entity.Property(e => e.Creditos).HasColumnName("creditos");
            entity.Property(e => e.EsTransversal).HasColumnName("esTransversal");
            entity.Property(e => e.Especialidad)
                .HasMaxLength(80)
                .HasColumnName("especialidad");
            entity.Property(e => e.IdAsignatura).HasColumnName("idAsignatura");
            entity.Property(e => e.Modalidad)
                .HasMaxLength(20)
                .HasColumnName("modalidad");
            entity.Property(e => e.Naturaleza)
                .HasMaxLength(20)
                .HasColumnName("naturaleza");
            entity.Property(e => e.NombreAsignatura)
                .HasMaxLength(120)
                .HasColumnName("nombreAsignatura");
            entity.Property(e => e.NombreCarrera)
                .HasMaxLength(100)
                .HasColumnName("nombreCarrera");
        });

        modelBuilder.Entity<VwAsignaturasSinProgramar>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_Asignaturas_SinProgramar");

            entity.Property(e => e.CodigoAsignatura)
                .HasMaxLength(20)
                .HasColumnName("codigoAsignatura");
            entity.Property(e => e.Creditos).HasColumnName("creditos");
            entity.Property(e => e.Naturaleza)
                .HasMaxLength(20)
                .HasColumnName("naturaleza");
            entity.Property(e => e.NombreAsignatura)
                .HasMaxLength(120)
                .HasColumnName("nombreAsignatura");
            entity.Property(e => e.NombreCarrera)
                .HasMaxLength(100)
                .HasColumnName("nombreCarrera");
            entity.Property(e => e.NombreCiclo)
                .HasMaxLength(20)
                .HasColumnName("nombreCiclo");
        });

        modelBuilder.Entity<VwBloquesAsincrono>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_Bloques_Asincronos");

            entity.Property(e => e.DiaSemana).HasColumnName("diaSemana");
            entity.Property(e => e.EsAsincrono).HasColumnName("esAsincrono");
            entity.Property(e => e.HoraFin).HasColumnName("horaFin");
            entity.Property(e => e.HoraInicio).HasColumnName("horaInicio");
            entity.Property(e => e.IdBloque)
                .ValueGeneratedOnAdd()
                .HasColumnName("idBloque");
        });

        modelBuilder.Entity<VwCargaDocente>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_Carga_Docente");

            entity.Property(e => e.Docente)
                .HasMaxLength(161)
                .HasColumnName("docente");
            entity.Property(e => e.HorasPracticasSemana).HasColumnName("horasPracticasSemana");
            entity.Property(e => e.HorasTeoricasSemana).HasColumnName("horasTeoricasSemana");
            entity.Property(e => e.HorasTotalesSemana).HasColumnName("horasTotalesSemana");
            entity.Property(e => e.IdDocente).HasColumnName("idDocente");
            entity.Property(e => e.NombrePeriodo)
                .HasMaxLength(20)
                .HasColumnName("nombrePeriodo");
        });

        modelBuilder.Entity<VwCarrerasPlan>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_Carreras_Plan");

            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .HasColumnName("estado");
            entity.Property(e => e.IdCarrera).HasColumnName("idCarrera");
            entity.Property(e => e.IdPlan).HasColumnName("idPlan");
            entity.Property(e => e.NombreCarrera)
                .HasMaxLength(100)
                .HasColumnName("nombreCarrera");
            entity.Property(e => e.Tipo)
                .HasMaxLength(20)
                .HasColumnName("tipo");
            entity.Property(e => e.Version)
                .HasMaxLength(20)
                .HasColumnName("version");
        });

        modelBuilder.Entity<VwDetalleSeccion>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_Detalle_Seccion");

            entity.Property(e => e.ClasesActivas).HasColumnName("clasesActivas");
            entity.Property(e => e.ClasesProgramadas).HasColumnName("clasesProgramadas");
            entity.Property(e => e.CupoMax).HasColumnName("cupoMax");
            entity.Property(e => e.DocentesDistintos).HasColumnName("docentesDistintos");
            entity.Property(e => e.Familia)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("familia");
            entity.Property(e => e.GrupoBase)
                .HasMaxLength(20)
                .HasColumnName("grupoBase");
            entity.Property(e => e.IdCarrera).HasColumnName("idCarrera");
            entity.Property(e => e.IdCiclo).HasColumnName("idCiclo");
            entity.Property(e => e.IdSeccion).HasColumnName("idSeccion");
            entity.Property(e => e.NombreCarrera)
                .HasMaxLength(100)
                .HasColumnName("nombreCarrera");
            entity.Property(e => e.NombreCiclo)
                .HasMaxLength(20)
                .HasColumnName("nombreCiclo");
            entity.Property(e => e.NombrePeriodo)
                .HasMaxLength(20)
                .HasColumnName("nombrePeriodo");
            entity.Property(e => e.OrdenCiclo).HasColumnName("ordenCiclo");
            entity.Property(e => e.Turno)
                .HasMaxLength(10)
                .HasColumnName("turno");
        });

        modelBuilder.Entity<VwDocente>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_Docentes");

            entity.Property(e => e.Apellidos)
                .HasMaxLength(80)
                .HasColumnName("apellidos");
            entity.Property(e => e.Categoria)
                .HasMaxLength(30)
                .HasColumnName("categoria");
            entity.Property(e => e.Especialidad)
                .HasMaxLength(80)
                .HasColumnName("especialidad");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.IdDocente)
                .ValueGeneratedOnAdd()
                .HasColumnName("idDocente");
            entity.Property(e => e.NivelAcademico)
                .HasMaxLength(40)
                .HasColumnName("nivelAcademico");
            entity.Property(e => e.Nombres)
                .HasMaxLength(80)
                .HasColumnName("nombres");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<VwDocentesTecnico>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_Docentes_Tecnicos");

            entity.Property(e => e.Apellidos)
                .HasMaxLength(80)
                .HasColumnName("apellidos");
            entity.Property(e => e.Categoria)
                .HasMaxLength(30)
                .HasColumnName("categoria");
            entity.Property(e => e.Especialidad)
                .HasMaxLength(80)
                .HasColumnName("especialidad");
            entity.Property(e => e.IdDocente).HasColumnName("idDocente");
            entity.Property(e => e.NivelAcademico)
                .HasMaxLength(40)
                .HasColumnName("nivelAcademico");
            entity.Property(e => e.Nombres)
                .HasMaxLength(80)
                .HasColumnName("nombres");
        });

        modelBuilder.Entity<VwDocentesTransversale>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_Docentes_Transversales");

            entity.Property(e => e.Apellidos)
                .HasMaxLength(80)
                .HasColumnName("apellidos");
            entity.Property(e => e.Categoria)
                .HasMaxLength(30)
                .HasColumnName("categoria");
            entity.Property(e => e.Especialidad)
                .HasMaxLength(80)
                .HasColumnName("especialidad");
            entity.Property(e => e.IdDocente).HasColumnName("idDocente");
            entity.Property(e => e.NivelAcademico)
                .HasMaxLength(40)
                .HasColumnName("nivelAcademico");
            entity.Property(e => e.Nombres)
                .HasMaxLength(80)
                .HasColumnName("nombres");
        });

        modelBuilder.Entity<VwHorarioAsincrono>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_Horario_Asincrono");

            entity.Property(e => e.CodigoAsignatura)
                .HasMaxLength(20)
                .HasColumnName("codigoAsignatura");
            entity.Property(e => e.Creditos).HasColumnName("creditos");
            entity.Property(e => e.DiaSemana).HasColumnName("diaSemana");
            entity.Property(e => e.Docente)
                .HasMaxLength(161)
                .HasColumnName("docente");
            entity.Property(e => e.Estado)
                .HasMaxLength(15)
                .HasColumnName("estado");
            entity.Property(e => e.Familia)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("familia");
            entity.Property(e => e.GrupoBase)
                .HasMaxLength(20)
                .HasColumnName("grupoBase");
            entity.Property(e => e.HoraFin).HasColumnName("horaFin");
            entity.Property(e => e.HoraInicio).HasColumnName("horaInicio");
            entity.Property(e => e.IdBloque).HasColumnName("idBloque");
            entity.Property(e => e.IdHorario).HasColumnName("idHorario");
            entity.Property(e => e.NombreAsignatura)
                .HasMaxLength(120)
                .HasColumnName("nombreAsignatura");
            entity.Property(e => e.NombrePeriodo)
                .HasMaxLength(20)
                .HasColumnName("nombrePeriodo");
            entity.Property(e => e.SemanaRango)
                .HasMaxLength(20)
                .HasColumnName("semanaRango");
            entity.Property(e => e.TipoClase)
                .HasMaxLength(10)
                .HasColumnName("tipoClase");
            entity.Property(e => e.Turno)
                .HasMaxLength(10)
                .HasColumnName("turno");
        });

        modelBuilder.Entity<VwHorarioCompleto>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_Horario_Completo");

            entity.Property(e => e.CategoriaDocente)
                .HasMaxLength(30)
                .HasColumnName("categoriaDocente");
            entity.Property(e => e.CicloOrden).HasColumnName("cicloOrden");
            entity.Property(e => e.CodigoAsignatura)
                .HasMaxLength(20)
                .HasColumnName("codigoAsignatura");
            entity.Property(e => e.CodigoAula)
                .HasMaxLength(20)
                .HasColumnName("codigoAula");
            entity.Property(e => e.Creditos).HasColumnName("creditos");
            entity.Property(e => e.DiaSemana).HasColumnName("diaSemana");
            entity.Property(e => e.Docente)
                .HasMaxLength(161)
                .HasColumnName("docente");
            entity.Property(e => e.Estado)
                .HasMaxLength(15)
                .HasColumnName("estado");
            entity.Property(e => e.Familia)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("familia");
            entity.Property(e => e.GrupoBase)
                .HasMaxLength(20)
                .HasColumnName("grupoBase");
            entity.Property(e => e.HoraFin).HasColumnName("horaFin");
            entity.Property(e => e.HoraInicio).HasColumnName("horaInicio");
            entity.Property(e => e.IdHorario).HasColumnName("idHorario");
            entity.Property(e => e.Naturaleza)
                .HasMaxLength(20)
                .HasColumnName("naturaleza");
            entity.Property(e => e.NombreAsignatura)
                .HasMaxLength(120)
                .HasColumnName("nombreAsignatura");
            entity.Property(e => e.NombreCarrera)
                .HasMaxLength(100)
                .HasColumnName("nombreCarrera");
            entity.Property(e => e.NombreCiclo)
                .HasMaxLength(20)
                .HasColumnName("nombreCiclo");
            entity.Property(e => e.NombrePeriodo)
                .HasMaxLength(20)
                .HasColumnName("nombrePeriodo");
            entity.Property(e => e.SemanaRango)
                .HasMaxLength(20)
                .HasColumnName("semanaRango");
            entity.Property(e => e.TipoAula)
                .HasMaxLength(20)
                .HasColumnName("tipoAula");
            entity.Property(e => e.TipoClase)
                .HasMaxLength(10)
                .HasColumnName("tipoClase");
            entity.Property(e => e.Turno)
                .HasMaxLength(10)
                .HasColumnName("turno");
        });

        modelBuilder.Entity<VwHorarioDetalle>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_Horario_Detalle");

            entity.Property(e => e.Categoria)
                .HasMaxLength(30)
                .HasColumnName("categoria");
            entity.Property(e => e.CodigoAsignatura)
                .HasMaxLength(20)
                .HasColumnName("codigoAsignatura");
            entity.Property(e => e.CodigoAula)
                .HasMaxLength(20)
                .HasColumnName("codigoAula");
            entity.Property(e => e.Creditos).HasColumnName("creditos");
            entity.Property(e => e.DiaSemana).HasColumnName("diaSemana");
            entity.Property(e => e.Docente)
                .HasMaxLength(161)
                .HasColumnName("docente");
            entity.Property(e => e.Estado)
                .HasMaxLength(15)
                .HasColumnName("estado");
            entity.Property(e => e.Familia)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("familia");
            entity.Property(e => e.GrupoBase)
                .HasMaxLength(20)
                .HasColumnName("grupoBase");
            entity.Property(e => e.HoraFin).HasColumnName("horaFin");
            entity.Property(e => e.HoraInicio).HasColumnName("horaInicio");
            entity.Property(e => e.IdHorario).HasColumnName("idHorario");
            entity.Property(e => e.Naturaleza)
                .HasMaxLength(20)
                .HasColumnName("naturaleza");
            entity.Property(e => e.NombreAsignatura)
                .HasMaxLength(120)
                .HasColumnName("nombreAsignatura");
            entity.Property(e => e.NombreCarrera)
                .HasMaxLength(100)
                .HasColumnName("nombreCarrera");
            entity.Property(e => e.NombreCiclo)
                .HasMaxLength(20)
                .HasColumnName("nombreCiclo");
            entity.Property(e => e.NombrePeriodo)
                .HasMaxLength(20)
                .HasColumnName("nombrePeriodo");
            entity.Property(e => e.SemanaRango)
                .HasMaxLength(20)
                .HasColumnName("semanaRango");
            entity.Property(e => e.TipoAula)
                .HasMaxLength(20)
                .HasColumnName("tipoAula");
            entity.Property(e => e.TipoClase)
                .HasMaxLength(10)
                .HasColumnName("tipoClase");
        });

        modelBuilder.Entity<VwHorarioFiltroGeneral>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_Horario_FiltroGeneral");

            entity.Property(e => e.CodigoAsignatura)
                .HasMaxLength(20)
                .HasColumnName("codigoAsignatura");
            entity.Property(e => e.CodigoAula)
                .HasMaxLength(20)
                .HasColumnName("codigoAula");
            entity.Property(e => e.DiaSemana).HasColumnName("diaSemana");
            entity.Property(e => e.Docente).HasMaxLength(161);
            entity.Property(e => e.Estado)
                .HasMaxLength(15)
                .HasColumnName("estado");
            entity.Property(e => e.Familia)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("familia");
            entity.Property(e => e.GrupoBase)
                .HasMaxLength(20)
                .HasColumnName("grupoBase");
            entity.Property(e => e.HoraFin).HasColumnName("horaFin");
            entity.Property(e => e.HoraInicio).HasColumnName("horaInicio");
            entity.Property(e => e.IdAsignatura).HasColumnName("idAsignatura");
            entity.Property(e => e.IdAula).HasColumnName("idAula");
            entity.Property(e => e.IdBloque).HasColumnName("idBloque");
            entity.Property(e => e.IdDocente).HasColumnName("idDocente");
            entity.Property(e => e.IdHorario).HasColumnName("idHorario");
            entity.Property(e => e.IdSeccion).HasColumnName("idSeccion");
            entity.Property(e => e.Naturaleza)
                .HasMaxLength(20)
                .HasColumnName("naturaleza");
            entity.Property(e => e.NombreAsignatura)
                .HasMaxLength(120)
                .HasColumnName("nombreAsignatura");
            entity.Property(e => e.NombrePeriodo)
                .HasMaxLength(20)
                .HasColumnName("nombrePeriodo");
            entity.Property(e => e.SemanaRango)
                .HasMaxLength(20)
                .HasColumnName("semanaRango");
            entity.Property(e => e.TipoClase)
                .HasMaxLength(10)
                .HasColumnName("tipoClase");
        });

        modelBuilder.Entity<VwHorarioPorCarrera>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_Horario_PorCarrera");

            entity.Property(e => e.CodigoAsignatura)
                .HasMaxLength(20)
                .HasColumnName("codigoAsignatura");
            entity.Property(e => e.CodigoAula)
                .HasMaxLength(20)
                .HasColumnName("codigoAula");
            entity.Property(e => e.Creditos).HasColumnName("creditos");
            entity.Property(e => e.DiaSemana).HasColumnName("diaSemana");
            entity.Property(e => e.DiaSemanaNombre)
                .HasMaxLength(9)
                .HasColumnName("diaSemanaNombre");
            entity.Property(e => e.Docente)
                .HasMaxLength(161)
                .HasColumnName("docente");
            entity.Property(e => e.Estado)
                .HasMaxLength(15)
                .HasColumnName("estado");
            entity.Property(e => e.Familia)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("familia");
            entity.Property(e => e.GrupoBase)
                .HasMaxLength(20)
                .HasColumnName("grupoBase");
            entity.Property(e => e.HoraFin).HasColumnName("horaFin");
            entity.Property(e => e.HoraInicio).HasColumnName("horaInicio");
            entity.Property(e => e.IdCarrera).HasColumnName("idCarrera");
            entity.Property(e => e.IdCiclo).HasColumnName("idCiclo");
            entity.Property(e => e.IdHorario).HasColumnName("idHorario");
            entity.Property(e => e.IdSeccion).HasColumnName("idSeccion");
            entity.Property(e => e.Naturaleza)
                .HasMaxLength(20)
                .HasColumnName("naturaleza");
            entity.Property(e => e.NombreAsignatura)
                .HasMaxLength(120)
                .HasColumnName("nombreAsignatura");
            entity.Property(e => e.NombreCarrera)
                .HasMaxLength(100)
                .HasColumnName("nombreCarrera");
            entity.Property(e => e.NombreCiclo)
                .HasMaxLength(20)
                .HasColumnName("nombreCiclo");
            entity.Property(e => e.OrdenCiclo).HasColumnName("ordenCiclo");
            entity.Property(e => e.SemanaRango)
                .HasMaxLength(20)
                .HasColumnName("semanaRango");
            entity.Property(e => e.TipoAula)
                .HasMaxLength(20)
                .HasColumnName("tipoAula");
            entity.Property(e => e.TipoClase)
                .HasMaxLength(10)
                .HasColumnName("tipoClase");
            entity.Property(e => e.Turno)
                .HasMaxLength(10)
                .HasColumnName("turno");
        });

        modelBuilder.Entity<VwHorarioPorDocente>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_Horario_PorDocente");

            entity.Property(e => e.Categoria)
                .HasMaxLength(30)
                .HasColumnName("categoria");
            entity.Property(e => e.CodigoAsignatura)
                .HasMaxLength(20)
                .HasColumnName("codigoAsignatura");
            entity.Property(e => e.CodigoAula)
                .HasMaxLength(20)
                .HasColumnName("codigoAula");
            entity.Property(e => e.Creditos).HasColumnName("creditos");
            entity.Property(e => e.DiaSemana).HasColumnName("diaSemana");
            entity.Property(e => e.DiaSemanaNombre)
                .HasMaxLength(9)
                .HasColumnName("diaSemanaNombre");
            entity.Property(e => e.Docente)
                .HasMaxLength(161)
                .HasColumnName("docente");
            entity.Property(e => e.Estado)
                .HasMaxLength(15)
                .HasColumnName("estado");
            entity.Property(e => e.Familia)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("familia");
            entity.Property(e => e.GrupoBase)
                .HasMaxLength(20)
                .HasColumnName("grupoBase");
            entity.Property(e => e.HoraFin).HasColumnName("horaFin");
            entity.Property(e => e.HoraInicio).HasColumnName("horaInicio");
            entity.Property(e => e.IdDocente).HasColumnName("idDocente");
            entity.Property(e => e.IdHorario).HasColumnName("idHorario");
            entity.Property(e => e.NombreAsignatura)
                .HasMaxLength(120)
                .HasColumnName("nombreAsignatura");
            entity.Property(e => e.NombreCiclo)
                .HasMaxLength(20)
                .HasColumnName("nombreCiclo");
            entity.Property(e => e.NombrePeriodo)
                .HasMaxLength(20)
                .HasColumnName("nombrePeriodo");
            entity.Property(e => e.SemanaRango)
                .HasMaxLength(20)
                .HasColumnName("semanaRango");
            entity.Property(e => e.TipoAula)
                .HasMaxLength(20)
                .HasColumnName("tipoAula");
            entity.Property(e => e.TipoClase)
                .HasMaxLength(10)
                .HasColumnName("tipoClase");
            entity.Property(e => e.Turno)
                .HasMaxLength(10)
                .HasColumnName("turno");
        });

        modelBuilder.Entity<VwHorariosDetallado>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_HorariosDetallados");

            entity.Property(e => e.Activo).HasMaxLength(15);
            entity.Property(e => e.Carrera)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Ciclo)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.CodigoAula)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("codigoAula");
            entity.Property(e => e.Dia)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("dia");
            entity.Property(e => e.Docente).HasMaxLength(161);
            entity.Property(e => e.Familia)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("familia");
            entity.Property(e => e.HoraFin).HasColumnName("horaFin");
            entity.Property(e => e.HoraInicio).HasColumnName("horaInicio");
            entity.Property(e => e.IdHorario).HasColumnName("idHorario");
            entity.Property(e => e.ModalidadClase)
                .HasMaxLength(15)
                .HasColumnName("modalidadClase");
            entity.Property(e => e.Naturaleza)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("naturaleza");
            entity.Property(e => e.NombreAsignatura).HasMaxLength(120);
            entity.Property(e => e.NombreSeccion).HasMaxLength(20);
        });

        modelBuilder.Entity<VwHorariosOrdenado>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_HorariosOrdenados");

            entity.Property(e => e.Carrera)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Ciclo)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.CodigoAula)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("codigoAula");
            entity.Property(e => e.Dia)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("dia");
            entity.Property(e => e.Estado)
                .HasMaxLength(15)
                .HasColumnName("estado");
            entity.Property(e => e.Familia)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("familia");
            entity.Property(e => e.HoraFin).HasColumnName("horaFin");
            entity.Property(e => e.HoraInicio).HasColumnName("horaInicio");
            entity.Property(e => e.IdAsignatura).HasColumnName("idAsignatura");
            entity.Property(e => e.IdDocente).HasColumnName("idDocente");
            entity.Property(e => e.IdSeccion).HasColumnName("idSeccion");
            entity.Property(e => e.ModalidadClase)
                .HasMaxLength(15)
                .HasColumnName("modalidadClase");
            entity.Property(e => e.Naturaleza)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("naturaleza");
        });

        modelBuilder.Entity<VwMateriasTecnica>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_Materias_Tecnicas");

            entity.Property(e => e.CodigoAsignatura)
                .HasMaxLength(20)
                .HasColumnName("codigoAsignatura");
            entity.Property(e => e.Creditos).HasColumnName("creditos");
            entity.Property(e => e.IdAsignatura)
                .ValueGeneratedOnAdd()
                .HasColumnName("idAsignatura");
            entity.Property(e => e.Naturaleza)
                .HasMaxLength(20)
                .HasColumnName("naturaleza");
            entity.Property(e => e.NombreAsignatura)
                .HasMaxLength(120)
                .HasColumnName("nombreAsignatura");
        });

        modelBuilder.Entity<VwMateriasTransversale>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_Materias_Transversales");

            entity.Property(e => e.CodigoAsignatura)
                .HasMaxLength(20)
                .HasColumnName("codigoAsignatura");
            entity.Property(e => e.Creditos).HasColumnName("creditos");
            entity.Property(e => e.IdAsignatura)
                .ValueGeneratedOnAdd()
                .HasColumnName("idAsignatura");
            entity.Property(e => e.Naturaleza)
                .HasMaxLength(20)
                .HasColumnName("naturaleza");
            entity.Property(e => e.NombreAsignatura)
                .HasMaxLength(120)
                .HasColumnName("nombreAsignatura");
        });

        modelBuilder.Entity<VwSeccionesDetalle>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_Secciones_Detalle");

            entity.Property(e => e.CupoMax).HasColumnName("cupoMax");
            entity.Property(e => e.Familia)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("familia");
            entity.Property(e => e.GrupoBase)
                .HasMaxLength(20)
                .HasColumnName("grupoBase");
            entity.Property(e => e.IdSeccion).HasColumnName("idSeccion");
            entity.Property(e => e.NombreCarrera)
                .HasMaxLength(100)
                .HasColumnName("nombreCarrera");
            entity.Property(e => e.NombreCiclo)
                .HasMaxLength(20)
                .HasColumnName("nombreCiclo");
            entity.Property(e => e.NombrePeriodo)
                .HasMaxLength(20)
                .HasColumnName("nombrePeriodo");
            entity.Property(e => e.Turno)
                .HasMaxLength(10)
                .HasColumnName("turno");
        });

        modelBuilder.Entity<VwUsoAula>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_Uso_Aulas");

            entity.Property(e => e.CodigoAsignatura)
                .HasMaxLength(20)
                .HasColumnName("codigoAsignatura");
            entity.Property(e => e.CodigoAula)
                .HasMaxLength(20)
                .HasColumnName("codigoAula");
            entity.Property(e => e.DiaSemana).HasColumnName("diaSemana");
            entity.Property(e => e.Docente)
                .HasMaxLength(161)
                .HasColumnName("docente");
            entity.Property(e => e.Estado)
                .HasMaxLength(15)
                .HasColumnName("estado");
            entity.Property(e => e.Familia)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("familia");
            entity.Property(e => e.GrupoBase)
                .HasMaxLength(20)
                .HasColumnName("grupoBase");
            entity.Property(e => e.HoraFin).HasColumnName("horaFin");
            entity.Property(e => e.HoraInicio).HasColumnName("horaInicio");
            entity.Property(e => e.IdAula).HasColumnName("idAula");
            entity.Property(e => e.NombreAsignatura)
                .HasMaxLength(120)
                .HasColumnName("nombreAsignatura");
            entity.Property(e => e.NombrePeriodo)
                .HasMaxLength(20)
                .HasColumnName("nombrePeriodo");
            entity.Property(e => e.TipoAula)
                .HasMaxLength(20)
                .HasColumnName("tipoAula");
            entity.Property(e => e.TipoClase)
                .HasMaxLength(10)
                .HasColumnName("tipoClase");
        });

        modelBuilder.Entity<VwUsuariosRolesPermiso>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_Usuarios_RolesPermisos");

            entity.Property(e => e.Activo).HasColumnName("activo");
            entity.Property(e => e.Email)
                .HasMaxLength(120)
                .HasColumnName("email");
            entity.Property(e => e.IdPermiso).HasColumnName("idPermiso");
            entity.Property(e => e.IdRol).HasColumnName("idRol");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.NombrePermiso)
                .HasMaxLength(50)
                .HasColumnName("nombrePermiso");
            entity.Property(e => e.NombreRol)
                .HasMaxLength(40)
                .HasColumnName("nombreRol");
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(40)
                .HasColumnName("nombreUsuario");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
