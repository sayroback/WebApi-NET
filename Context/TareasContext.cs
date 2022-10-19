using webapi.Models;
using Microsoft.EntityFrameworkCore;

namespace webapi.context
{
  public class TareasContext : DbContext
  {
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Tarea> Tareas { get; set; }
    public TareasContext(DbContextOptions<TareasContext> options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      List<Categoria> categoriaInit = new List<Categoria>();
      categoriaInit.Add(new Categoria() { CategoriaId = Guid.Parse("1a64ed3b-c5cc-43a4-9063-2000b6fc1989"), Nombre = "Actividades Pendientes", Peso = 20 });
      categoriaInit.Add(new Categoria() { CategoriaId = Guid.Parse("af6cba23-37cc-4712-804a-8401705b4408"), Nombre = "Actividades Personales", Peso = 50 });

      modelBuilder.Entity<Categoria>(categoria =>
      {
        categoria.ToTable("Categoria");
        categoria.HasKey(p => p.CategoriaId);
        categoria.Property(p => p.Nombre).IsRequired().HasMaxLength(150);
        categoria.Property(p => p.Descripcion).IsRequired(false);
        categoria.Property(p => p.Peso);
        categoria.HasData(categoriaInit);
      });

      List<Tarea> tareasInit = new List<Tarea>();
      tareasInit.Add(new Tarea() { TareaId = Guid.Parse("1c24b509-9e93-4005-945b-cb414b1b4807"), CategoriaId = Guid.Parse("1a64ed3b-c5cc-43a4-9063-2000b6fc1989"), Titulo = "Factura Electricidad", PrioridadTarea=Prioridad.Media, FechaCreacion = DateTime.Now });
      tareasInit.Add(new Tarea() { TareaId = Guid.Parse("0e509909-841b-4739-bef5-824e83b42fef"), CategoriaId = Guid.Parse("af6cba23-37cc-4712-804a-8401705b4408"), Titulo = "Tarjeta de credito", PrioridadTarea = Prioridad.Alta, FechaCreacion = DateTime.Now });
      modelBuilder.Entity<Tarea>(tarea =>
      {
        tarea.ToTable("Tarea");
        tarea.HasKey(p => p.TareaId);
        tarea.HasOne(p => p.Categoria).WithMany(p => p.Tareas).HasForeignKey(p => p.CategoriaId);
        tarea.Property(p => p.Titulo).IsRequired().HasMaxLength(200);
        tarea.Property(p => p.Descripcion).IsRequired(false);
        tarea.Property(p => p.PrioridadTarea);
        tarea.Property(p => p.FechaCreacion);
        tarea.Ignore(p => p.Resumen);
        tarea.HasData(tareasInit);
      });
    }
  }
}
