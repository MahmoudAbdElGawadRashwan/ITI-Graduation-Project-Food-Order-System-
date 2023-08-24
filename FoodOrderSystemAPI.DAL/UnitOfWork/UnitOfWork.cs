namespace FoodOrderSystemAPI.DAL;

public class UnitOfWork : IUnitOfWork
{
    private readonly SystemContext _context;

    public UnitOfWork(SystemContext context)
    {
        _context = context;
    }

    public IAdminRepo Admins => new AdminRepo(_context);

    public ICustomerRepo Customers => new CustomerRepo(_context);

    public IOrderRepo Orders => new OrderRepo(_context);

    public IOrderProductRepo OrdersProducts => new OrderProductRepo(_context);

    public IProductRepo Products => new ProductRepo(_context);
    public IProductTagRepo ProductTags => new ProductTagRepo(_context);

    public IReviewRepo Reveiws => new ReviewRepo(_context);

    public IRestaurantRepo Restaurants => new RestaurantRepo(_context);

    public void Dispose()
    {
        _context.Dispose();
    }

    public int Save()
    {
        return _context.SaveChanges();
    }
}
