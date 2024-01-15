using Business.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.DAL.Repositories.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BaseEntity , new()
    {
        Task<IQueryable<TEntity>> GetAllAsync(
            Expression<Func<TEntity,bool>> expression=null,
            Expression<Func<TEntity,bool>> OrderByExpression=null,
            bool IsDescending=false,
            params string[] includes
            );

        DbSet<TEntity> Table { get; }
        Task<TEntity> GetById(int id);
        Task Delete(int id);
        Task Update(TEntity entity);
        Task Create(TEntity entity);
        Task SaveChanges();
    }
}
