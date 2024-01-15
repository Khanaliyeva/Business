using Business.Core.Entity;
using Business.DAL.Context;
using Business.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.DAL.Repositories.Implimentations
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity, new()
    {
        private readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }
        public DbSet<TEntity> Table => _context.Set<TEntity>();

        public async Task Create(TEntity entity)
        {
            await Table.AddAsync(entity);
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            Table.Remove(entity);
        }

        public async Task<IQueryable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression = null, Expression<Func<TEntity, bool>> OrderByExpression = null, bool IsDescending = false, params string[] includes)
        {
            IQueryable<TEntity> query = Table;
            if(expression != null)
            {
                query = query.Where(expression);
            }
            if (OrderByExpression != null)
            {
                query = IsDescending ? query.OrderByDescending(OrderByExpression) :
                    query.OrderBy(OrderByExpression);
            }
            if(includes != null)
            {
                for(int i=0;i<includes.Length; i++)
                {
                    query = query.Include(includes[i]);
                }
            }
            return query;
        }

        public  async Task<TEntity> GetById(int id)
        {
            return await Table.FindAsync(id);
        }

        public async Task SaveChanges()
        {
            _context.SaveChangesAsync();
        }

        public async Task Update(TEntity entity)
        {
            Table.Update(entity);
        }
    }
}
