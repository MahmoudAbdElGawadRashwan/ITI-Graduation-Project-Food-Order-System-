namespace FoodOrderSystemAPI;

public interface IReviewManager
{
    List<GetAllReveiwsOutputDto> GetAll();
    GetReviewOutputDto? GetByIds(int customerId, int productId);
    AddReviewOutputDto? Add(AddReviewInputDto inputDto);
    UpdateStatusEnum Update(UpdateReviewInputDto inputDto);
    DeleteStatusEnum Delete(DeleteReviewInputDto inputDto);
}
