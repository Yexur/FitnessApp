using FitnessApp.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FitnessApp.Core
{
    public class Repository<TEntity> : IRepository<TEntity>
    where TEntity : class, IEntity
    {
        protected DbSet<TEntity> DbSet { get; private set; }

        protected FitnessAppDbContext FitnessAppDbContext { get; private set; }

        public Repository(FitnessAppDbContext context)
        {
            FitnessAppDbContext = context;
            DbSet = FitnessAppDbContext.Set<TEntity>();
        }

        public virtual async Task<List<TEntity>> All(params Expression<Func<TEntity, object>>[] entitiesToInclude)
        {
            return await entitiesToInclude.Aggregate((IQueryable<TEntity>)DbSet,
                (current, entityToInclude) => current.Include(entityToInclude)).ToListAsync();
        }

        public virtual async void Insert(TEntity entity)
        {
            if (entity.Id <= 0)
            {
                //new entity - insert in to DB
                DbSet.Add(entity);
            }
            else
            {
                FitnessAppDbContext.Entry(entity).State = EntityState.Modified;
            }

            await FitnessAppDbContext.SaveChangesAsync();
        }

        public virtual async void Delete(int id)
        {
            var entity = await FindById(id);
            if (entity != null)
            {
                DbSet.Remove(entity);
                await FitnessAppDbContext.SaveChangesAsync();
            }
        }

        public virtual async Task<TEntity> FindById(int id, params Expression<Func<TEntity, object>>[] entitiesToInclude)
        {
            var  entity = await Find(x => x.Id == id, entitiesToInclude);
            return entity.SingleOrDefault();
        }

        public async Task<List<TEntity>> Find(Expression<Func<TEntity, bool>> predicate,
            params Expression<Func<TEntity, object>>[] entitiesToInclude)
        {
            return await entitiesToInclude.Aggregate(DbSet.Where(predicate),
                (current, entityToInclude) => current.Include(entityToInclude)).ToListAsync();
        }
    }
}
