using System.Linq.Expressions;

namespace FoodOrderSystemAPI.DAL;

public interface IEntityRepo<T> where T : class
{
    T? GetById(int id);
    IEnumerable<T> GetAll();
    void Add(T entity);
    void Delete(T entity);
    void Update(T entity);
    IEnumerable<T> Search(Expression<Func<T, bool>> predicate);
}
