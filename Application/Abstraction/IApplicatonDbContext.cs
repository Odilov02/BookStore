using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Application.Abstraction
{
    public interface IApplicatonDbcontext
    {
        EntityEntry Entry(object entity);
        DbSet<Book> Books { get; }
        DbSet<Commentary> Commentaries { get; }
        DbSet<Category> Categories { get; }
        DbSet<Author> Authors { get; }
        DbSet<Order> Orders { get; }
        public DbSet<Basket> Baskets { get; set; }
        Task<int> SaveChangesAsync(CancellationToken token = default);
    }
}
