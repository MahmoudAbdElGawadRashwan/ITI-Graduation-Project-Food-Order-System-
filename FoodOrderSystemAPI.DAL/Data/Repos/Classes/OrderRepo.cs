using Microsoft.EntityFrameworkCore;

namespace FoodOrderSystemAPI.DAL;

public class OrderRepo : EntityRepo<OrderModel>, IOrderRepo
{
    private readonly SystemContext _dbContext;

    public OrderRepo(SystemContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;

    }

    public List <OrderModel> GetOrdersByResturantId (int ResturantId) 
    {

        //_dbContext.Orders.Include(Orders=>Orders.OrderProducts).ThenInclude(Orderproduct=>Orderproduct.Product).ThenInclude(product=>product.restaurant).Where(product=>product.)
        var orders = _dbContext.Orders.Include(O=>O.Customer).Include(o=>o.OrderProducts).ThenInclude(p => p.Product)
        .Join(
            _dbContext.OrdersProducts,
            order => order.OrderId,
            orderProduct => orderProduct.OrderId,
            (order, orderProduct) => new { Order = order, OrderProduct = orderProduct }
        )
        .Join(
            _dbContext.Products,
            joinedData => joinedData.OrderProduct.ProductId,
            product => product.ProductId,
            (joinedData, product) => new { Order = joinedData.Order, Product = product }
        )
        .Where(joinedData => joinedData.Product.RestaurantID == ResturantId)
        .Select(joinedData => joinedData.Order)
        .ToList();

        return orders;
    }

}
