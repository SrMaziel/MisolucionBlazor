using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace InformacionPublica.Server.Models;

public partial class InformacionpublicaContext : DbContext
{
    public InformacionpublicaContext()
    {
    }

    public InformacionpublicaContext(DbContextOptions<InformacionpublicaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Antecedentesciudadano> Antecedentesciudadanos { get; set; }

    public virtual DbSet<Antecedentespenale> Antecedentespenales { get; set; }

    public virtual DbSet<Arrestopolicial> Arrestopolicials { get; set; }

    public virtual DbSet<Biene> Bienes { get; set; }

    public virtual DbSet<Ciudadano> Ciudadanos { get; set; }

    public virtual DbSet<Delito> Delitos { get; set; }

    public virtual DbSet<Denuncium> Denuncia { get; set; }

    public virtual DbSet<Detencione> Detenciones { get; set; }

    public virtual DbSet<Documentosciudadano> Documentosciudadanos { get; set; }

    public virtual DbSet<Fronterasalvadoreña> Fronterasalvadoreñas { get; set; }

    public virtual DbSet<Historiallaboral> Historiallaborals { get; set; }

    public virtual DbSet<Historialmedico> Historialmedicos { get; set; }

    public virtual DbSet<Historialmigratorio> Historialmigratorios { get; set; }

    public virtual DbSet<Informacionacademica> Informacionacademicas { get; set; }

    public virtual DbSet<Informacionfinanciera> Informacionfinancieras { get; set; }

    public virtual DbSet<Infraccione> Infracciones { get; set; }

    public virtual DbSet<Infraccionesciudadano> Infraccionesciudadanos { get; set; }

    public virtual DbSet<Nacionalidad> Nacionalidads { get; set; }

    public virtual DbSet<Penaimpuestum> Penaimpuesta { get; set; }

    public virtual DbSet<Permiso> Permisos { get; set; }

    public virtual DbSet<Permisostipousuario> Permisostipousuarios { get; set; }

    public virtual DbSet<Tipodocumento> Tipodocumentos { get; set; }

    public virtual DbSet<Tiposciudadano> Tiposciudadanos { get; set; }

    public virtual DbSet<Tiposdelito> Tiposdelitos { get; set; }

    public virtual DbSet<Tiposingreso> Tiposingresos { get; set; }

    public virtual DbSet<Tipousuario> Tipousuarios { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Victima> Victimas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder.UseMySql("server=localhost;database=informacionpublica;user=root;password=pass123", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.4.0-mysql"));

    protected  override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Antecedentesciudadano>(entity =>
        {
            entity.HasKey(e => e.Idantecedentesciudadano).HasName("PRIMARY");

            entity.ToTable("antecedentesciudadano", tb => tb.HasComment("registro del ciudadano"));

            entity.HasIndex(e => e.Ciudadanos, "fk_antecedentesciudadano_ciudadano_idx");

            entity.HasIndex(e => e.Delitos, "fk_antecedentesciudadano_delitos_idx");

            entity.HasIndex(e => e.Detenciones, "fk_antecedentesciudadano_detenciones_idx");

            entity.HasIndex(e => e.Penaimpuesta, "fk_antecedentesciudadano_penaimpuesta_idx");

            entity.HasIndex(e => e.Tiposdelitos, "fk_antecedentesciudadano_tiposdelitos_idx");

            entity.Property(e => e.Idantecedentesciudadano)
                .HasComment("identificador del registro")
                .HasColumnName("idantecedentesciudadano");
            entity.Property(e => e.Ciudadanos).HasColumnName("ciudadano");
            entity.Property(e => e.Delitos).HasColumnName("delitos");
            entity.Property(e => e.Detenciones).HasColumnName("detenciones");
            entity.Property(e => e.Estado)
                .HasColumnType("bit(1)")
                .HasColumnName("estado");
            entity.Property(e => e.Fechadelito).HasColumnName("fechadelito");
            entity.Property(e => e.Penaimpuesta).HasColumnName("penaimpuesta");
            entity.Property(e => e.Tiposdelitos).HasColumnName("tiposdelitos");

            entity.HasOne(d => d.CiudadanosNavigation).WithMany(p => p.Antecedentesciudadanos)
                .HasForeignKey(d => d.Ciudadanos)
                .HasConstraintName("fk_antecedentesciudadano_ciudadano");

            entity.HasOne(d => d.DelitosNavigation).WithMany(p => p.Antecedentesciudadanos)
                .HasForeignKey(d => d.Delitos)
                .HasConstraintName("fk_antecedentesciudadano_delitos");

            entity.HasOne(d => d.DetencionesNavigation).WithMany(p => p.Antecedentesciudadanos)
                .HasForeignKey(d => d.Detenciones)
                .HasConstraintName("fk_antecedentesciudadano_detenciones");

            entity.HasOne(d => d.PenaimpuestaNavigation).WithMany(p => p.Antecedentesciudadanos)
                .HasForeignKey(d => d.Penaimpuesta)
                .HasConstraintName("fk_antecedentesciudadano_penaimpuesta");

            entity.HasOne(d => d.TiposdelitosNavigation).WithMany(p => p.Antecedentesciudadanos)
                .HasForeignKey(d => d.Tiposdelitos)
                .HasConstraintName("fk_antecedentesciudadano_tiposdelitos");
        });

        modelBuilder.Entity<Antecedentespenale>(entity =>
        {
            entity.HasKey(e => e.Idantecedentespenales).HasName("PRIMARY");

            entity.ToTable("antecedentespenales");

            entity.HasIndex(e => e.Ciudadano, "fk_antecedentespenales_ciudadano_idx");

            entity.HasIndex(e => e.Delitos, "fk_antecedentespenales_delitos_idx");

            entity.HasIndex(e => e.Penaimpuesta, "fk_antecedentespenales_penaimpuesta_idx");

            entity.HasIndex(e => e.Tiposdelitos, "fk_antecedentespenales_tiposdelitos_idx");

            entity.Property(e => e.Idantecedentespenales).HasColumnName("idantecedentespenales");
            entity.Property(e => e.Ciudadano)
                .HasComment("nombre del ciudadano")
                .HasColumnName("ciudadano");
            entity.Property(e => e.Delitos).HasColumnName("delitos");
            entity.Property(e => e.Estado)
                .HasColumnType("bit(1)")
                .HasColumnName("estado");
            entity.Property(e => e.Penaimpuesta).HasColumnName("penaimpuesta");
            entity.Property(e => e.Tiposdelitos).HasColumnName("tiposdelitos");

            entity.HasOne(d => d.CiudadanoNavigation).WithMany(p => p.Antecedentespenales)
                .HasForeignKey(d => d.Ciudadano)
                .HasConstraintName("fk_antecedentespenales_ciudadano");

            entity.HasOne(d => d.DelitosNavigation).WithMany(p => p.Antecedentespenales)
                .HasForeignKey(d => d.Delitos)
                .HasConstraintName("fk_antecedentespenales_delitos");

            entity.HasOne(d => d.PenaimpuestaNavigation).WithMany(p => p.Antecedentespenales)
                .HasForeignKey(d => d.Penaimpuesta)
                .HasConstraintName("fk_antecedentespenales_penaimpuesta");

            entity.HasOne(d => d.TiposdelitosNavigation).WithMany(p => p.Antecedentespenales)
                .HasForeignKey(d => d.Tiposdelitos)
                .HasConstraintName("fk_antecedentespenales_tiposdelitos");
        });

        modelBuilder.Entity<Arrestopolicial>(entity =>
        {
            entity.HasKey(e => e.Idarrestopolicial).HasName("PRIMARY");

            entity.ToTable("arrestopolicial");

            entity.HasIndex(e => e.Delitos, "fk_arrestopolicial_delitos_idx");

            entity.HasIndex(e => e.Denuncia, "fk_arrestopolicial_denuncia_idx");

            entity.HasIndex(e => e.Detenciones, "fk_arrestopolicial_detenciones_idx");

            entity.HasIndex(e => e.Tipociudadano, "fk_arrestopolicial_tiposciudadanos_idx");

            entity.HasIndex(e => e.Ciudadano, "fkarrestopolicial_ciudadano_idx");

            entity.Property(e => e.Idarrestopolicial).HasColumnName("idarrestopolicial");
            entity.Property(e => e.Ciudadano).HasColumnName("ciudadano");
            entity.Property(e => e.Delitos).HasColumnName("delitos");
            entity.Property(e => e.Denuncia).HasColumnName("denuncia");
            entity.Property(e => e.Denunciados)
                .HasMaxLength(75)
                .HasColumnName("denunciados");
            entity.Property(e => e.Denunciantes)
                .HasMaxLength(75)
                .HasColumnName("denunciantes");
            entity.Property(e => e.Detenciones).HasColumnName("detenciones");
            entity.Property(e => e.Estado)
                .HasColumnType("bit(1)")
                .HasColumnName("estado");
            entity.Property(e => e.Tipociudadano).HasColumnName("tipociudadano");

            entity.HasOne(d => d.CiudadanoNavigation).WithMany(p => p.Arrestopolicials)
                .HasForeignKey(d => d.Ciudadano)
                .HasConstraintName("fk_arrestopolicial_ciudadano");

            entity.HasOne(d => d.DelitosNavigation).WithMany(p => p.Arrestopolicials)
                .HasForeignKey(d => d.Delitos)
                .HasConstraintName("fk_arrestopolicial_delitos");

            entity.HasOne(d => d.DenunciaNavigation).WithMany(p => p.Arrestopolicials)
                .HasForeignKey(d => d.Denuncia)
                .HasConstraintName("fk_arrestopolicial_denuncia");

            entity.HasOne(d => d.DetencionesNavigation).WithMany(p => p.Arrestopolicials)
                .HasForeignKey(d => d.Detenciones)
                .HasConstraintName("fk_arrestopolicial_detenciones");

            entity.HasOne(d => d.TipociudadanoNavigation).WithMany(p => p.Arrestopolicials)
                .HasForeignKey(d => d.Tipociudadano)
                .HasConstraintName("fk_arrestopolicial_tiposciudadanos");
        });

        modelBuilder.Entity<Biene>(entity =>
        {
            entity.HasKey(e => e.Idbienes).HasName("PRIMARY");

            entity.ToTable("bienes");

            entity.Property(e => e.Idbienes).HasColumnName("idbienes");
            entity.Property(e => e.Bienes)
                .HasMaxLength(100)
                .HasColumnName("bienes");
            entity.Property(e => e.Estado)
                .HasColumnType("bit(1)")
                .HasColumnName("estado");
        });

        modelBuilder.Entity<Ciudadano>(entity =>
        {
            entity.HasKey(e => e.Idciudadano).HasName("PRIMARY");

            entity.ToTable("ciudadano", tb => tb.HasComment("informacion del ciudadano"));

            entity.HasIndex(e => e.Bienes, "fk_ciudadano_bienes_idx");

            entity.HasIndex(e => e.Nacionalidad, "fk_ciudadano_nacionalidad_idx");

            entity.HasIndex(e => e.Tipodedocumento, "fk_ciudadano_tipodocumentos_idx");

            entity.HasIndex(e => e.Tiposciudadanos, "fk_ciudadano_tiposciudadanos_idx");

            entity.Property(e => e.Idciudadano)
                .HasComment("identificador del ciudadano")
                .HasColumnName("idciudadano");
            entity.Property(e => e.Apellido)
                .HasMaxLength(45)
                .HasComment("apellido del ciudadano")
                .HasColumnName("apellido");
            entity.Property(e => e.Bienes).HasColumnName("bienes");
            entity.Property(e => e.Correoelectronico)
                .HasMaxLength(155)
                .HasColumnName("correoelectronico");
            entity.Property(e => e.Direccionciudadano)
                .HasMaxLength(250)
                .HasColumnName("direccionciudadano");
            entity.Property(e => e.Dui)
                .HasMaxLength(10)
                .HasComment("identificador del ciudadano")
                .HasColumnName("dui");
            entity.Property(e => e.Estado)
                .HasColumnType("bit(1)")
                .HasColumnName("estado");
            entity.Property(e => e.Fechanacimiento)
                .HasComment("fecha del ciudadano")
                .HasColumnName("fechanacimiento");
            entity.Property(e => e.Nacionalidad).HasColumnName("nacionalidad");
            entity.Property(e => e.Nombre)
                .HasMaxLength(45)
                .HasComment("nombre del ciudadano")
                .HasColumnName("nombre");
            entity.Property(e => e.Telefonofijio)
                .HasMaxLength(10)
                .HasColumnName("telefonofijio");
            entity.Property(e => e.Telefonomovil)
                .HasMaxLength(25)
                .HasColumnName("telefonomovil");
            entity.Property(e => e.Tipodedocumento).HasColumnName("tipodedocumento");
            entity.Property(e => e.Tiposciudadanos).HasColumnName("tiposciudadanos");

            entity.HasOne(d => d.BienesNavigation).WithMany(p => p.Ciudadanos)
                .HasForeignKey(d => d.Bienes)
                .HasConstraintName("fk_ciudadano_bienes");

            entity.HasOne(d => d.NacionalidadNavigation).WithMany(p => p.Ciudadanos)
                .HasForeignKey(d => d.Nacionalidad)
                .HasConstraintName("fk_ciudadano_nacionalidad");

            entity.HasOne(d => d.TipodedocumentoNavigation).WithMany(p => p.Ciudadanos)
                .HasForeignKey(d => d.Tipodedocumento)
                .HasConstraintName("fk_ciudadano_tipodocumentos");

            entity.HasOne(d => d.TiposciudadanoNavigation).WithMany(p => p.Ciudadanos)
                .HasForeignKey(d => d.Tiposciudadanos)
                .HasConstraintName("fk_ciudadano_Tiposciudadanos");
        });

        modelBuilder.Entity<Delito>(entity =>
        {
            entity.HasKey(e => e.Iddelitos).HasName("PRIMARY");

            entity.ToTable("delitos");

            entity.HasIndex(e => e.Delitos, "fk_delitos_penaimpuesta_idx");

            entity.HasIndex(e => e.Tiposdelitos, "fk_delitos_tiposdelitos_idx");

            entity.Property(e => e.Iddelitos).HasColumnName("iddelitos");
            entity.Property(e => e.Delitos)
                .HasMaxLength(75)
                .HasColumnName("delitos");
            entity.Property(e => e.Estado)
                .HasColumnType("bit(1)")
                .HasColumnName("estado");
            entity.Property(e => e.Tiposdelitos).HasColumnName("tiposdelitos");

            entity.HasOne(d => d.TiposdelitosNavigation).WithMany(p => p.Delitos)
                .HasForeignKey(d => d.Tiposdelitos)
                .HasConstraintName("fk_delitos_tiposdelitos");
        });

        modelBuilder.Entity<Denuncium>(entity =>
        {
            entity.HasKey(e => e.Iddenuncia).HasName("PRIMARY");

            entity.ToTable("denuncia");

            entity.Property(e => e.Iddenuncia).HasColumnName("iddenuncia");
            entity.Property(e => e.Denuncia)
                .HasMaxLength(255)
                .HasColumnName("denuncia");
            entity.Property(e => e.Denunciado)
                .HasMaxLength(75)
                .HasColumnName("denunciado");
            entity.Property(e => e.Denunciante)
                .HasMaxLength(75)
                .HasColumnName("denunciante");
            entity.Property(e => e.Estado)
                .HasColumnType("bit(1)")
                .HasColumnName("estado");
            entity.Property(e => e.Tipodenuncia)
                .HasMaxLength(50)
                .HasColumnName("tipodenuncia");
        });

        modelBuilder.Entity<Detencione>(entity =>
        {
            entity.HasKey(e => e.Iddetenciones).HasName("PRIMARY");

            entity.ToTable("detenciones");

            entity.Property(e => e.Iddetenciones).HasColumnName("iddetenciones");
            entity.Property(e => e.Detencion)
                .HasMaxLength(75)
                .HasColumnName("detencion");
            entity.Property(e => e.Estado)
                .HasColumnType("bit(1)")
                .HasColumnName("estado");
        });

        modelBuilder.Entity<Documentosciudadano>(entity =>
        {
            entity.HasKey(e => e.Iddocumentosciudadanos).HasName("PRIMARY");

            entity.ToTable("documentosciudadanos");

            entity.HasIndex(e => e.Ciudadano, "fk_documentosciudadanos_ciudadano_idx");

            entity.HasIndex(e => e.Tipodocumento, "fk_documentosciudadanos_documentos_idx");

            entity.Property(e => e.Iddocumentosciudadanos).HasColumnName("iddocumentosciudadanos");
            entity.Property(e => e.Ciudadano).HasColumnName("ciudadano");
            entity.Property(e => e.Estado)
                .HasColumnType("bit(1)")
                .HasColumnName("estado");
            entity.Property(e => e.Tipodocumento).HasColumnName("tipodocumento");

            entity.HasOne(d => d.CiudadanoNavigation).WithMany(p => p.Documentosciudadanos)
                .HasForeignKey(d => d.Ciudadano)
                .HasConstraintName("fk_documentosciudadanos_ciudadano");

            entity.HasOne(d => d.TipodocumentoNavigation).WithMany(p => p.Documentosciudadanos)
                .HasForeignKey(d => d.Tipodocumento)
                .HasConstraintName("fk_documentosciudadanos_tipodocumentos");
        });

        modelBuilder.Entity<Fronterasalvadoreña>(entity =>
        {
            entity.HasKey(e => e.Idfronterasalvadoreñas).HasName("PRIMARY");

            entity.ToTable("fronterasalvadoreñas");

            entity.Property(e => e.Idfronterasalvadoreñas).HasColumnName("idfronterasalvadoreñas");
            entity.Property(e => e.Estado)
                .HasColumnType("bit(1)")
                .HasColumnName("estado");
            entity.Property(e => e.Fronteras)
                .HasMaxLength(50)
                .HasColumnName("fronteras");
        });

        modelBuilder.Entity<Historiallaboral>(entity =>
        {
            entity.HasKey(e => e.Idhistoriallaboral).HasName("PRIMARY");

            entity.ToTable("historiallaboral");

            entity.HasIndex(e => e.Ciudadano, "fk_historiallaboral_ciudadano_idx");

            entity.HasIndex(e => e.Tiposciudadano, "fk_historiallaboral_tiposciudadanos_idx");

            entity.Property(e => e.Idhistoriallaboral).HasColumnName("idhistoriallaboral");
            entity.Property(e => e.Ciudadano).HasColumnName("ciudadano");
            entity.Property(e => e.Empleoactual)
                .HasMaxLength(95)
                .HasColumnName("empleoactual");
            entity.Property(e => e.Empleospasados)
                .HasMaxLength(60)
                .HasColumnName("empleospasados");
            entity.Property(e => e.Estado)
                .HasColumnType("bit(1)")
                .HasColumnName("estado");
            entity.Property(e => e.Tiposciudadano).HasColumnName("tiposciudadano");

            entity.HasOne(d => d.CiudadanoNavigation).WithMany(p => p.Historiallaborals)
                .HasForeignKey(d => d.Ciudadano)
                .HasConstraintName("fk_historiallaboral_ciudadano");

            entity.HasOne(d => d.TiposciudadanoNavigation).WithMany(p => p.Historiallaborals)
                .HasForeignKey(d => d.Tiposciudadano)
                .HasConstraintName("fk_historiallaboral_tiposciudadanos");
        });

        modelBuilder.Entity<Historialmedico>(entity =>
        {
            entity.HasKey(e => e.Idhistorialmedico).HasName("PRIMARY");

            entity.ToTable("historialmedico");

            entity.HasIndex(e => e.Ciudadano, "fk_historialmedico_ciudadano_idx");

            entity.Property(e => e.Idhistorialmedico).HasColumnName("idhistorialmedico");
            entity.Property(e => e.Ciudadano).HasColumnName("ciudadano");
            entity.Property(e => e.Contactoemergencia)
                .HasMaxLength(45)
                .HasColumnName("contactoemergencia");
            entity.Property(e => e.Estado)
                .HasColumnType("bit(1)")
                .HasColumnName("estado");
            entity.Property(e => e.Intervencionesquirurjicas)
                .HasMaxLength(75)
                .HasColumnName("intervencionesquirurjicas");
            entity.Property(e => e.Padecimientos)
                .HasMaxLength(100)
                .HasColumnName("padecimientos");

            entity.HasOne(d => d.CiudadanoNavigation).WithMany(p => p.Historialmedicos)
                .HasForeignKey(d => d.Ciudadano)
                .HasConstraintName("fk_historialmedico_ciudadano");
        });

        modelBuilder.Entity<Historialmigratorio>(entity =>
        {
            entity.HasKey(e => e.Idhistorialmigratorio).HasName("PRIMARY");

            entity.ToTable("historialmigratorio");

            entity.HasIndex(e => e.Ciudadano, "fk_historialmigratorio_ciudadano_idx");

            entity.HasIndex(e => e.Fronteraentrada, "fk_historialmigratorio_fronterasalvadoreña_idx");

            entity.HasIndex(e => e.Fronterasalvadoreña, "fk_historialmigratorio_fronterasalvadoreñas_idx");

            entity.HasIndex(e => e.Tiposdocumentos, "fk_historialmigratorio_tipodocumentos_idx");

            entity.Property(e => e.Idhistorialmigratorio).HasColumnName("idhistorialmigratorio");
            entity.Property(e => e.Ciudadano).HasColumnName("ciudadano");
            entity.Property(e => e.Destino)
                .HasMaxLength(15)
                .HasColumnName("destino");
            entity.Property(e => e.Estado)
                .HasColumnType("bit(1)")
                .HasColumnName("estado");
            entity.Property(e => e.Fechaentrada)
                .HasColumnType("datetime")
                .HasColumnName("fechaentrada");
            entity.Property(e => e.Fechasalida)
                .HasColumnType("datetime")
                .HasColumnName("fechasalida");
            entity.Property(e => e.Fronteraentrada)
                .HasMaxLength(45)
                .HasColumnName("fronteraentrada");
            entity.Property(e => e.Fronterasalida)
                .HasMaxLength(45)
                .HasColumnName("fronterasalida");
            entity.Property(e => e.Fronterasalvadoreña).HasColumnName("fronterasalvadoreña");
            entity.Property(e => e.Procedencia)
                .HasMaxLength(15)
                .HasColumnName("procedencia");
            entity.Property(e => e.Tiposdocumentos).HasColumnName("tiposdocumentos");

            entity.HasOne(d => d.CiudadanoNavigation).WithMany(p => p.Historialmigratorios)
                .HasForeignKey(d => d.Ciudadano)
                .HasConstraintName("fk_historialmigratorio_ciudadano");

            entity.HasOne(d => d.FronterasalvadoreñaNavigation).WithMany(p => p.Historialmigratorios)
                .HasForeignKey(d => d.Fronterasalvadoreña)
                .HasConstraintName("fk_historialmigratorio_fronterasalvadoreñas");

            entity.HasOne(d => d.TiposdocumentosNavigation).WithMany(p => p.Historialmigratorios)
                .HasForeignKey(d => d.Tiposdocumentos)
                .HasConstraintName("fk_historialmigratorio_tipodocumentos");
        });

        modelBuilder.Entity<Informacionacademica>(entity =>
        {
            entity.HasKey(e => e.Idinformacionacademica).HasName("PRIMARY");

            entity.ToTable("informacionacademica");

            entity.HasIndex(e => e.Ciudadano, "fk_informacionacademica_ciudadano_idx");

            entity.Property(e => e.Idinformacionacademica).HasColumnName("idinformacionacademica");
            entity.Property(e => e.Ciudadano).HasColumnName("ciudadano");
            entity.Property(e => e.Educacionmedia)
                .HasMaxLength(75)
                .HasColumnName("educacionmedia");
            entity.Property(e => e.Escuela)
                .HasMaxLength(75)
                .HasColumnName("escuela");
            entity.Property(e => e.Estado)
                .HasColumnType("bit(1)")
                .HasColumnName("estado");
            entity.Property(e => e.Estudiaactualmente)
                .HasMaxLength(2)
                .HasColumnName("estudiaactualmente");
            entity.Property(e => e.Universidades)
                .HasMaxLength(75)
                .HasColumnName("universidades");

            entity.HasOne(d => d.CiudadanoNavigation).WithMany(p => p.Informacionacademicas)
                .HasForeignKey(d => d.Ciudadano)
                .HasConstraintName("fk_informacionacademica_ciudadano");
        });

        modelBuilder.Entity<Informacionfinanciera>(entity =>
        {
            entity.HasKey(e => e.Idinformacionfinanciera).HasName("PRIMARY");

            entity.ToTable("informacionfinanciera");

            entity.HasIndex(e => e.Ciudadano, "fk_informacionfinanciera_ciudadano_idx");

            entity.HasIndex(e => e.Tipoingresos, "fk_informacionfinanciera_tiposingresos_idx");

            entity.Property(e => e.Idinformacionfinanciera).HasColumnName("idinformacionfinanciera");
            entity.Property(e => e.Ciudadano).HasColumnName("ciudadano");
            entity.Property(e => e.Declaracionimpuestos)
                .HasMaxLength(100)
                .HasColumnName("declaracionimpuestos");
            entity.Property(e => e.Estado)
                .HasColumnType("bit(1)")
                .HasColumnName("estado");
            entity.Property(e => e.Oficio)
                .HasMaxLength(45)
                .HasColumnName("oficio");
            entity.Property(e => e.Procedenciaingresos)
                .HasMaxLength(100)
                .HasColumnName("procedenciaingresos");
            entity.Property(e => e.Profesion)
                .HasMaxLength(45)
                .HasColumnName("profesion");
            entity.Property(e => e.Salarioanual)
                .HasMaxLength(45)
                .HasColumnName("salarioanual");
            entity.Property(e => e.Salariomensual)
                .HasMaxLength(45)
                .HasColumnName("salariomensual");
            entity.Property(e => e.Tipoingresos).HasColumnName("tipoingresos");

            entity.HasOne(d => d.CiudadanoNavigation).WithMany(p => p.Informacionfinancieras)
                .HasForeignKey(d => d.Ciudadano)
                .HasConstraintName("fk_informacionfinanciera_ciudadano");

            entity.HasOne(d => d.TipoingresosNavigation).WithMany(p => p.Informacionfinancieras)
                .HasForeignKey(d => d.Tipoingresos)
                .HasConstraintName("fk_informacionfinanciera_tiposingresos");
        });

        modelBuilder.Entity<Infraccione>(entity =>
        {
            entity.HasKey(e => e.Idinfracciones).HasName("PRIMARY");

            entity.ToTable("infracciones");

            entity.Property(e => e.Idinfracciones).HasColumnName("idinfracciones");
            entity.Property(e => e.Estado)
                .HasColumnType("bit(1)")
                .HasColumnName("estado");
            entity.Property(e => e.Infracciones)
                .HasMaxLength(45)
                .HasColumnName("infracciones");
            entity.Property(e => e.Tipoinfracciones)
                .HasMaxLength(10)
                .HasColumnName("tipoinfracciones");
        });

        modelBuilder.Entity<Infraccionesciudadano>(entity =>
        {
            entity.HasKey(e => e.Idinfraccionesciudadano).HasName("PRIMARY");

            entity.ToTable("infraccionesciudadano");

            entity.HasIndex(e => e.Ciudadano, "fk_infraccionesciudadano_ciudadano_idx");

            entity.HasIndex(e => e.Infracciones, "fk_infraccionesciudadano_infracciones_idx");

            entity.Property(e => e.Idinfraccionesciudadano).HasColumnName("idinfraccionesciudadano");
            entity.Property(e => e.Ciudadano).HasColumnName("ciudadano");
            entity.Property(e => e.Costomulta)
                .HasMaxLength(10)
                .HasColumnName("costomulta");
            entity.Property(e => e.Estado)
                .HasColumnType("bit(1)")
                .HasColumnName("estado");
            entity.Property(e => e.Infracciones).HasColumnName("infracciones");

            entity.HasOne(d => d.CiudadanoNavigation).WithMany(p => p.Infraccionesciudadanos)
                .HasForeignKey(d => d.Ciudadano)
                .HasConstraintName("fk_infraccionesciudadano_ciudadano");

            entity.HasOne(d => d.InfraccionesNavigation).WithMany(p => p.Infraccionesciudadanos)
                .HasForeignKey(d => d.Infracciones)
                .HasConstraintName("fk_infraccionesciudadano_infracciones");
        });

        modelBuilder.Entity<Nacionalidad>(entity =>
        {
            entity.HasKey(e => e.Idnacionalidad).HasName("PRIMARY");

            entity.ToTable("nacionalidad");

            entity.Property(e => e.Idnacionalidad).HasColumnName("idnacionalidad");
            entity.Property(e => e.Estado)
                .HasColumnType("bit(1)")
                .HasColumnName("estado");
            entity.Property(e => e.Nacionalidad1)
                .HasMaxLength(45)
                .HasColumnName("nacionalidad");
        });

        modelBuilder.Entity<Penaimpuestum>(entity =>
        {
            entity.HasKey(e => e.Idpenaimpuesta).HasName("PRIMARY");

            entity.ToTable("penaimpuesta");

            entity.HasIndex(e => e.Delitos, "fk_penaimpuesta_delitos_idx");

            entity.HasIndex(e => e.Tiposdelitos, "fk_penaimpuesta_tiposdelitos_idx");

            entity.Property(e => e.Idpenaimpuesta).HasColumnName("idpenaimpuesta");
            entity.Property(e => e.Delitos).HasColumnName("delitos");
            entity.Property(e => e.Estado)
                .HasColumnType("bit(1)")
                .HasColumnName("estado");
            entity.Property(e => e.Penaimpuesta)
                .HasMaxLength(50)
                .HasColumnName("penaimpuesta");
            entity.Property(e => e.Tiposdelitos).HasColumnName("tiposdelitos");

            entity.HasOne(d => d.DelitosNavigation).WithMany(p => p.Penaimpuesta)
                .HasForeignKey(d => d.Delitos)
                .HasConstraintName("fk_penaimpuesta_delitos");

            entity.HasOne(d => d.TiposdelitosNavigation).WithMany(p => p.Penaimpuesta)
                .HasForeignKey(d => d.Tiposdelitos)
                .HasConstraintName("fk_penaimpuesta_tiposdelitos");
        });

        modelBuilder.Entity<Permiso>(entity =>
        {
            entity.HasKey(e => e.Idpermisos).HasName("PRIMARY");

            entity.ToTable("permisos");

            entity.Property(e => e.Idpermisos).HasColumnName("idpermisos");
            entity.Property(e => e.Estado)
                .HasColumnType("bit(1)")
                .HasColumnName("estado");
            entity.Property(e => e.Permisos)
                .HasMaxLength(45)
                .HasColumnName("permisos");
        });

        modelBuilder.Entity<Permisostipousuario>(entity =>
        {
            entity.HasKey(e => e.Idpermisostipousuario).HasName("PRIMARY");

            entity.ToTable("permisostipousuario");

            entity.HasIndex(e => e.Permisos, "fk_permisostipousuario_permisos_idx");

            entity.HasIndex(e => e.Tipousuarios, "fk_permisostipousuario_tipousuarios_idx");

            entity.HasIndex(e => e.Usuarios, "fk_permisostipousuario_usuarios_idx");

            entity.Property(e => e.Idpermisostipousuario).HasColumnName("idpermisostipousuario");
            entity.Property(e => e.Estado)
                .HasColumnType("bit(1)")
                .HasColumnName("estado");
            entity.Property(e => e.Permisos).HasColumnName("permisos");
            entity.Property(e => e.Tipousuarios).HasColumnName("tipousuarios");
            entity.Property(e => e.Usuarios).HasColumnName("usuarios");

            entity.HasOne(d => d.PermisosNavigation).WithMany(p => p.Permisostipousuarios)
                .HasForeignKey(d => d.Permisos)
                .HasConstraintName("fk_permisostipousuario_permisos");

            entity.HasOne(d => d.TipousuariosNavigation).WithMany(p => p.Permisostipousuarios)
                .HasForeignKey(d => d.Tipousuarios)
                .HasConstraintName("fk_permisostipousuario_tipousuarios");

            entity.HasOne(d => d.UsuariosNavigation).WithMany(p => p.Permisostipousuarios)
                .HasForeignKey(d => d.Usuarios)
                .HasConstraintName("fk_permisostipousuario_usuarios");
        });

        modelBuilder.Entity<Tipodocumento>(entity =>
        {
            entity.HasKey(e => e.Idtipodocumentos).HasName("PRIMARY");

            entity.ToTable("tipodocumentos");

            entity.Property(e => e.Idtipodocumentos).HasColumnName("idtipodocumentos");
            entity.Property(e => e.Estado)
                .HasColumnType("bit(1)")
                .HasColumnName("estado");
            entity.Property(e => e.Tipodocumentos)
                .HasMaxLength(45)
                .HasColumnName("tipodocumentos");
        });

        modelBuilder.Entity<Tiposciudadano>(entity =>
        {
            entity.HasKey(e => e.Idtiposciudadanos).HasName("PRIMARY");

            entity.ToTable("tiposciudadanos");

            entity.Property(e => e.Idtiposciudadanos).HasColumnName("idtiposciudadanos");
            entity.Property(e => e.Estado)
                .HasColumnType("bit(1)")
                .HasColumnName("estado");
            entity.Property(e => e.Tiposciudadanos)
                .HasMaxLength(15)
                .HasColumnName("tiposciudadanos");
        });

        modelBuilder.Entity<Tiposdelito>(entity =>
        {
            entity.HasKey(e => e.Idtiposdelitos).HasName("PRIMARY");

            entity.ToTable("tiposdelitos");

            entity.Property(e => e.Idtiposdelitos).HasColumnName("idtiposdelitos");
            entity.Property(e => e.Estado)
                .HasColumnType("bit(1)")
                .HasColumnName("estado");
            entity.Property(e => e.Tiposdelitos)
                .HasMaxLength(25)
                .HasColumnName("tiposdelitos");
        });

        modelBuilder.Entity<Tiposingreso>(entity =>
        {
            entity.HasKey(e => e.Idtiposingresos).HasName("PRIMARY");

            entity.ToTable("tiposingresos");

            entity.Property(e => e.Idtiposingresos).HasColumnName("idtiposingresos");
            entity.Property(e => e.Estado)
                .HasColumnType("bit(1)")
                .HasColumnName("estado");
            entity.Property(e => e.Tiposingresos)
                .HasMaxLength(70)
                .HasColumnName("tiposingresos");
        });

        modelBuilder.Entity<Tipousuario>(entity =>
        {
            entity.HasKey(e => e.Idtipousuarios).HasName("PRIMARY");

            entity.ToTable("tipousuarios");

            entity.Property(e => e.Idtipousuarios).HasColumnName("idtipousuarios");
            entity.Property(e => e.Estado)
                .HasColumnType("bit(1)")
                .HasColumnName("estado");
            entity.Property(e => e.Tipousuarios)
                .HasMaxLength(45)
                .HasColumnName("tipousuarios");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Idusuarios).HasName("PRIMARY");

            entity.ToTable("usuarios");

            entity.HasIndex(e => e.Tipousuarios, "fk_usuarios_tipousuarios_idx");

            entity.Property(e => e.Idusuarios).HasColumnName("idusuarios");
            entity.Property(e => e.Estado)
                .HasColumnType("bit(1)")
                .HasColumnName("estado");
            entity.Property(e => e.Tipousuarios).HasColumnName("tipousuarios");
            entity.Property(e => e.Usuario1)
                .HasMaxLength(45)
                .HasColumnName("usuario");

            entity.HasOne(d => d.TipousuariosNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.Tipousuarios)
                .HasConstraintName("fk_usuarios_tipousuarios");
        });

        modelBuilder.Entity<Victima>(entity =>
        {
            entity.HasKey(e => e.Idvictimas).HasName("PRIMARY");

            entity.ToTable("victimas");

            entity.HasIndex(e => e.Ciudadano, "fk_victimas_ciudadano_idx");

            entity.Property(e => e.Idvictimas).HasColumnName("idvictimas");
            entity.Property(e => e.Accidente)
                .HasMaxLength(45)
                .HasColumnName("accidente");
            entity.Property(e => e.Ciudadano).HasColumnName("ciudadano");
            entity.Property(e => e.Estado)
                .HasColumnType("bit(1)")
                .HasColumnName("estado");
            entity.Property(e => e.Heridas)
                .HasMaxLength(45)
                .HasColumnName("heridas");

            entity.HasOne(d => d.CiudadanoNavigation).WithMany(p => p.Victimas)
                .HasForeignKey(d => d.Ciudadano)
                .HasConstraintName("fk_victimas_ciudadano");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
