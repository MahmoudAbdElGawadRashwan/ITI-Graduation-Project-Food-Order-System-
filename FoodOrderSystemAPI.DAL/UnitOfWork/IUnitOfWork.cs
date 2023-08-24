namespace FoodOrderSystemAPI.DAL;

public interface IUnitOfWork: IDisposable
{
    public IAdminRepo Admins { get; }
    ICustomerRepo Customers { get; }
    IOrderRepo Orders { get; }
    IOrderProductRepo OrdersProducts { get; }
    IProductRepo Products { get; }
    IProductTagRepo ProductTags { get; }
    IReviewRepo Reveiws { get; }
    IRestaurantRepo Restaurants { get; }

    int Save();
}
