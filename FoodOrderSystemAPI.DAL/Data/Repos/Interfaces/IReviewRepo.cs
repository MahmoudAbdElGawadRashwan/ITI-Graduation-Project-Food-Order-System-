namespace FoodOrderSystemAPI.DAL;

public interface IReviewRepo : IEntityRepo<ReviewModel>
{
    ReviewModel? GetByIds(int customerId, int productId);
}
