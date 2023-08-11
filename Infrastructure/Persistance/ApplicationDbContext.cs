using Application.Comman.Interfaces;
using Infrastructure.Persistance.Interceptors;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Persistance;

public class ApplicationDbContext : IdentityDbContext<User>, IApplicatonDbcontext
{
    private readonly AuditableEntitySaveChangesnterceptor _auditableEntitySaveChangesnterceptor;
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, AuditableEntitySaveChangesnterceptor auditableEntitySaveChangesnterceptor)
        : base(options)
    {
        _auditableEntitySaveChangesnterceptor = auditableEntitySaveChangesnterceptor;
    }
    public DbSet<Book> Books { get; set; }
    public DbSet<Commentary> Commentaries { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Basket> Baskets { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_auditableEntitySaveChangesnterceptor);
        base.OnConfiguring(optionsBuilder);
    }
}
