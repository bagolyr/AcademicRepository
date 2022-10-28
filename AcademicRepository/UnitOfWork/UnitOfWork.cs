using Microsoft.EntityFrameworkCore;
using _2022_09_23.UnitOfWork;
using _2022_09_23.Entities.DbContextNamespace;
using _2022_09_23.Entities;
using _2022_09_23.Repository;

namespace _2022_09_23.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Academic3DbContext _academicDbContext;
        private Dictionary<Type, object> _repositories;


        public UnitOfWork(Academic3DbContext academicAPIDbContext)
        {
            _academicDbContext = academicAPIDbContext;
        }

        public DbContext Context()
        {
            return _academicDbContext;
        }

        public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : AbstractEntity
        {
            if (_repositories == null)
            {
                _repositories = new Dictionary<Type, object>();
            }

            var type = typeof(TEntity);
            if (!_repositories.ContainsKey(type))
            {
                _repositories[type] = new GenericRepository<TEntity>(_academicDbContext);
            }

            return (IGenericRepository<TEntity>)_repositories[type];

        }

        public int SaveChanges()
        {
            return _academicDbContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _academicDbContext.Dispose();
            }
        }

        public DbSet<TEntity> GetDbSet<TEntity>() where TEntity : AbstractEntity
        {
            return _academicDbContext.Set<TEntity>();
        }

        public Task SaveChangesAsync()
        {
            return _academicDbContext.SaveChangesAsync();
        }
    }
}