using FoodOrderSystemAPI.DAL;

namespace FoodOrderSystemAPI.BL;

public class ReviewManager : IReviewManager
{
    #region Feilds & CTOR
    private readonly IUnitOfWork _unit;

    public ReviewManager(IUnitOfWork unit)
    {
        _unit = unit;
    }
    #endregion

    #region Methods
    public AddReviewOutputDto? Add(AddReviewInputDto inputDto)
    {
        var ToBeAddedReview = new ReviewModel
        {
            Comment = inputDto.Comment,
            Rating = inputDto.Rating,
            ProductId = inputDto.ProductId,
            CustomerId = inputDto.CustomerId,
        };


        _unit.Reveiws.Add(ToBeAddedReview);
        _unit.Reveiws.Update(ToBeAddedReview);
        //System.InvalidOperationException
        // TODO: throw error for error handler middleware
        try
        {
            _unit.Save();
        }
        catch (Exception)
        {
            return null;
        }
        var OutputDto = new AddReviewOutputDto
        {
            ProductId = inputDto.ProductId,
            CustomerId = inputDto.CustomerId,
        };
        return OutputDto;
    }

    public DeleteStatusEnum Delete(DeleteReviewInputDto inputDto)
    {
        var ToBeDeleted = _unit.Reveiws.GetByIds(inputDto.CustomerId, inputDto.ProductId);
        if (ToBeDeleted is null)
            return DeleteStatusEnum.NotFound;
        _unit.Reveiws.Delete(ToBeDeleted);
        _unit.Save();
        return DeleteStatusEnum.Successfull;
    }

    public List<GetAllReveiwsOutputDto> GetAll()
    {
        var AllReviews = _unit.Reveiws.GetAll();
        var Result = new List<GetAllReveiwsOutputDto>();
        foreach (var Reveiws in AllReviews)
        {
            Result.Add(new GetAllReveiwsOutputDto
            {
                Comment = Reveiws.Comment,
                Rating = Reveiws.Rating,
            });
        }
        return Result;
    }

    public GetReviewOutputDto? GetByIds(int customerId, int productId)
    {
        var TargetReview = _unit.Reveiws.GetByIds(customerId, productId);
        if (TargetReview is null)
            return null;
        var Result = new GetReviewOutputDto
        {
            Comment = TargetReview.Comment,
            Rating = TargetReview.Rating,
        };
        return Result;
    }

    public UpdateStatusEnum Update(UpdateReviewInputDto inputDto)
    {
        var ToBeUpdated = _unit.Reveiws.GetByIds(inputDto.CustomerId, inputDto.ProductId);
        if (ToBeUpdated is null)
            return UpdateStatusEnum.NotFound;

        ToBeUpdated.Comment = inputDto.Comment;
        ToBeUpdated.Rating = inputDto.Rating;
        ToBeUpdated.ProductId = inputDto.ProductId;
        ToBeUpdated.CustomerId = inputDto.CustomerId;
        _unit.Reveiws.Update(ToBeUpdated);
        _unit.Save();
        return UpdateStatusEnum.Successfull;
    }
    #endregion
}
