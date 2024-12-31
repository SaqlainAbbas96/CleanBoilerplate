namespace Domain.Interfaces
{
    /// <summary>
    /// Defines the contract for a generic repository that provides basic CRUD operations.
    /// </summary>
    /// <typeparam name="T">The type of entity that the repository will manage, constrained to classes.</typeparam>
    public interface IGenericRepository<T> where T : class 
    {
        /// <summary>
        /// Retrieves all entities of type <typeparamref name="T"/> from the data source.
        /// </summary>
        /// <returns>A task representing the asynchronous operation, with a list of entities of type <typeparamref name="T"/>.</returns>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        /// Retrieves an entity by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the entity.</param>
        /// <returns>A task representing the asynchronous operation, with the entity or null if not found.</returns>
        Task<T?> GetByIdAsync(int id);

        /// <summary>
        /// Adds a new entity of type <typeparamref name="T"/> to the data source.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task AddAsync(T entity);

        /// <summary>
        /// Updates an existing entity of type <typeparamref name="T"/> in the data source.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task UpdateAsync(T entity);

        /// <summary>
        /// Deletes an existing entity of type <typeparamref name="T"/> from the data source.
        /// </summary>
        /// <param name="entity">The entity to delete.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task DeleteAsync(T entity);
    }
}
