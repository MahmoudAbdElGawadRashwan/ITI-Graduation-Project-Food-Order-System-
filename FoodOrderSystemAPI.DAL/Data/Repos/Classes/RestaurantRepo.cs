using Microsoft.EntityFrameworkCore;

namespace FoodOrderSystemAPI.DAL;

public class RestaurantRepo : EntityRepo<RestaurantModel>, IRestaurantRepo
{
    private readonly SystemContext _dbContext;

    public RestaurantRepo(SystemContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public IEnumerable<RestaurantModel?> GetRestaurantsWithProducts()
    {
        return _dbContext.Set<RestaurantModel>()
            .Include(r => r.Products)
            .AsNoTracking();
    }

    //public string? GetPaymentMethodById(int id)
    //{
    //    var paymentDetails = _dbContext.Set<RestaurantModel>()
    //        .Where(r => r.Id == id)
    //        .Select(r => r.PaymentMethods)
    //        .FirstOrDefault();
    //    return paymentDetails;
    //}

    public IEnumerable<ProductModel>? GetRestaurantProductsById(int id)
    {
        var restaurant = _dbContext.Set<RestaurantModel>()
            .Include(r => r.Products)
            .FirstOrDefault(r => r.Id == id);

        return restaurant?.Products;
    }
}
