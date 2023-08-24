using Microsoft.EntityFrameworkCore;

namespace FoodOrderSystemAPI.DAL;

public class ProductRepo : EntityRepo<ProductModel>, IProductRepo
{

    private readonly SystemContext _dbContext;

    public ProductRepo(SystemContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public override IEnumerable<ProductModel> GetAll()
    {
        return _dbContext.Set<ProductModel>().AsNoTracking().Include(p=>p.restaurant);
    }

    public virtual ProductModel? GetById(int id)
    {
        return _dbContext.Set<ProductModel>().Include(p => p.restaurant).FirstOrDefault(p=>p.ProductId==id);
    }

    public IEnumerable<String> GetProductTags()
    {
        return _dbContext.Set<ProductTag>().Select(t=>t.tag).Distinct();
    }
}
