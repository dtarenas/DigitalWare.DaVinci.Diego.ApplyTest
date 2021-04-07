namespace DigitalWare.DaVinci.Diego.ApplyTest.DAL.Repositories
{
    using DigitalWare.DaVinci.Diego.ApplyTest.Core.Models.Base;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    /// <summary>
    /// Base Repository Facade
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IBaseRepo<TEntity> where TEntity : BaseEntity
    {
        /// <summary>
        /// The get entity.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>
        /// The <see cref="IQueryable" />.
        /// </returns>
        IQueryable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null);

        /// <summary>
        /// Adds the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>
        /// Task
        /// </returns>
        Task<TEntity> AddAsync(TEntity entity);

        /// <summary>
        /// Adds the asynchronous.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>
        /// Task
        /// </returns>
        Task<IEnumerable<TEntity>> AddAsync(IEnumerable<TEntity> entities);

        /// <summary>
        /// Updates the specified author.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public TEntity Update(TEntity entity);

        /// <summary>
        /// Deletes the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task</returns>
        Task DeleteAsync(int id);

        /// <summary>
        /// Deletes the specified entities.
        /// </summary>
        /// <param name="entities">The entities.</param>
        public void Delete(IEnumerable<TEntity> entities);

        /// <summary>
        /// Saves the changes asynchronous.
        /// </summary>
        public Task SaveChangesAsync();

        /// <summary>
        /// Saves the changes.
        /// </summary>
        public void SaveChanges();
    }
}