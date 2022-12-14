using Microsoft.EntityFrameworkCore;
using _2022_09_23.Entities;

namespace _2022_09_23.Repository
{
        public interface IGenericRepository<TEntity> where TEntity : class
        {
            IQueryable<TEntity> GetAll();
            Task<TEntity> GetById(int id);
            Task<TEntity> Create(TEntity entity);
            void Update(TEntity entity);
            Task Delete(int id);
            Task<TEntity> DeleteSoft(int id);
        }

}
