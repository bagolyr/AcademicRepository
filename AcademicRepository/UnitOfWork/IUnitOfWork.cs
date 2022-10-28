using Microsoft.EntityFrameworkCore;
using _2022_09_23.Entities;
using _2022_09_23.Repository;

namespace _2022_09_23.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : AbstractEntity;
        DbSet<TEntity> GetDbSet<TEntity>() where TEntity : AbstractEntity;
        int SaveChanges();
        Task SaveChangesAsync();
        DbContext Context();
    }
}
