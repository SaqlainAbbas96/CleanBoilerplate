using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    /// <summary>
    /// A generic repository class providing common data access methods for entities of type T.
    /// Implements the <see cref="IGenericRepository{T}"/> interface, supporting CRUD operations for any entity type.
    /// </summary>
    /// <typeparam name="T">The type of entity this repository is managing. T must be a class.</typeparam>
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext; // Database context for accessing the database
        private readonly DbSet<T> _dbSet; // DbSet representing the collection of entities of type T

        /// <summary>
        /// Initializes a new instance of the GenericRepository class with the specified database context.
        /// </summary>
        /// <param name="dbContext">The database context used to access the database.</param>
        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>(); // Initialize the DbSet for the specific entity type
        }

        /// <summary>
        /// Adds a new entity asynchronously to the database.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Updates an existing entity in the database asynchronously.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes an existing entity from the database asynchronously.
        /// </summary>
        /// <param name="entity">The entity to delete.</param>
        public async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Retrieves all entities of type T from the database asynchronously.
        /// </summary>
        /// <returns>A list of all entities of type T.</returns>
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// Retrieves an entity by its primary key asynchronously.
        /// </summary>
        /// <param name="id">The primary key of the entity.</param>
        /// <returns>The entity with the specified primary key, or null if not found.</returns>
        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }
    }
}
