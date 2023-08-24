using FoodOrderSystemAPI.DAL;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FoodOrderSystemAPI;

public class EntityRepo<TEntity> : IEntityRepo<TEntity> where TEntity : class
{
    private readonly SystemContext _dbContext;

    public EntityRepo(SystemContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    ///     Generic method adds entity to the database
    /// </summary>
    /// <param name="entity"> 
    ///     entity to be added
    /// </param>
    public void Add(TEntity entity)
    {
        if (entity is not null)
            _dbContext.Set<TEntity>().Add(entity);
    }

    /// <summary>
    ///     Generic method deletes entity from database
    /// </summary>
    /// <param name="entity"> entity that will be deleted </param>
    public void Delete(TEntity entity)
    {
        _dbContext.Set<TEntity>().Remove(entity);
    }

    /// <summary>
    ///     gets all entities
    /// </summary>
    /// <returns>
    ///     IEnumerable holds all entities
    /// </returns>
    public virtual IEnumerable<TEntity> GetAll()
    {
        return _dbContext.Set<TEntity>().AsNoTracking();
    }

    /// <summary>
    ///     generic method gets entity by it's id
    /// </summary>
    /// <param name="id"> 
    ///     entity key that it will search with
    /// </param>
    /// <returns></returns>
    public virtual TEntity? GetById(int id)
    {
        return _dbContext.Set<TEntity>().Find(id);
    }

    /// <summary>
    ///     generic method to search for entites  
    /// </summary>
    /// <param name="predicate"> 
    ///     linq expression to search with in database 
    /// </param>
    /// <returns>
    ///     IEnumerable of entities matches specified expression
    /// </returns>
    public IEnumerable<TEntity> Search(Expression<Func<TEntity, bool>> predicate)
    {
        DbSet<TEntity> dbSet = _dbContext.Set<TEntity>();
        return dbSet.Where(predicate);
    }

    public void Update(TEntity entity)
    {
    }
}

