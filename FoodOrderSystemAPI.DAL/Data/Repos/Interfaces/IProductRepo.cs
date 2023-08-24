namespace FoodOrderSystemAPI.DAL;

public interface IProductRepo : IEntityRepo<ProductModel>
{
    public IEnumerable<String> GetProductTags();
}
