namespace DigitalWare.DaVinci.Diego.ApplyTest.DAL.Repositories
{
    using DigitalWare.DaVinci.Diego.ApplyTest.Core.Models.Base;
    using DigitalWare.DaVinci.Diego.ApplyTest.DAL.EFDatabaseContext;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    /// <summary>
    /// Base Repository Implementation
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <seealso cref="DigitalWare.DaVinci.Diego.ApplyTest.DAL.Repositories.IBaseRepo{TEntity}" />
    public class BaseRepo<TEntity> : IBaseRepo<TEntity> where TEntity : BaseEntity
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly DigitalWareDavinCiInvoiceSystemContext _context;

        /// <summary>
        /// The database set
        /// </summary>
        public readonly DbSet<TEntity> DbSet;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRepo{TEntity}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public BaseRepo(DigitalWareDavinCiInvoiceSystemContext context)
        {
            this._context = context;
            this.DbSet = this._context.Set<TEntity>();
        }

        /// <summary>
        /// Adds the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>
        /// Task
        /// </returns>
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await this.DbSet.AddAsync(entity);
            return entity;
        }

        /// <summary>
        /// Creates the asynchronous.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>
        /// Task
        /// </returns>
        public async Task<IEnumerable<TEntity>> AddAsync(IEnumerable<TEntity> entities)
        {
            await this.DbSet.AddRangeAsync(entities);
            return entities;
        }

        /// <summary>
        /// Deletes the specified entities.
        /// </summary>
        /// <param name="entities">The entities.</param>
        public void Delete(IEnumerable<TEntity> entities)
        {
            this._context.RemoveRange(entities);
        }

        /// <summary>
        /// Deletes the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public async Task DeleteAsync(int id)
        {
            var entity = await this.DbSet.FindAsync(id);
            this._context.Remove(entity);
        }

        /// <summary>
        /// The get entity.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>
        /// The <see cref="T:System.Linq.IQueryable" />.
        /// </returns>
        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null)
        {
            var query = this.DbSet.AsQueryable();
            if (filter != null)
            {
                query = query.Where(filter);
            }

            return query;
        }

        /// <summary>
        /// Saves the changes.
        /// </summary>
        public void SaveChanges()
        {
            this._context.SaveChanges();
        }

        /// <summary>
        /// Saves the changes asynchronous.
        /// </summary>
        public async Task SaveChangesAsync()
        {
            await this._context.SaveChangesAsync();
        }

        /// <summary>
        /// Updates the specified author.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public TEntity Update(TEntity entity)
        {
            this.DbSet.Attach(entity);
            this._context.Update(entity);
            return entity;
        }
    }
}