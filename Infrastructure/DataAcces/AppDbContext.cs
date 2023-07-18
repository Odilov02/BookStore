using Application.Abstraction;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using System.Security.Claims;

namespace Infrastructure.DataAcces;

public class AppDbContext : IdentityDbContext<User>, IApplicatonDbcontext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
    public DbSet<Book> Books { get; set; }
    public DbSet<Commentary> Commentaries { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<User> Users { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<User>().HasData(
            new User()
            {
                Email = "diyorbek02odilov@gmail.com",
                UserName = "diyorbek02odilov@gmail.com",
                PasswordHash="020819",
            }
            );
    }
}