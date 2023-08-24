namespace FoodOrderSystemAPI.DAL;

public interface IOrderRepo: IEntityRepo<OrderModel>
{
    public List<OrderModel> GetOrdersByResturantId(int ResturantId);
}
