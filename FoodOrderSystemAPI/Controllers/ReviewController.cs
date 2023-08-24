using Microsoft.AspNetCore.Mvc;

namespace FoodOrderSystemAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReviewController : ControllerBase
{
    #region CTOR & Fields

    private IReviewManager _reviewManager;

    public ReviewController(IReviewManager reviewManager)
    {
        _reviewManager = reviewManager;
    }
    #endregion


    #region Endpoints

    [HttpGet]
    public ActionResult<List<GetAllReveiwsOutputDto>> GetAll()
    {
        return _reviewManager.GetAll();
    }

    [HttpGet]
    [Route("{customerId}/{productId}")]
    public ActionResult<GetReviewOutputDto> GetReview(int customerId, int productId)
    {
        var TargetReview = _reviewManager.GetByIds(customerId, productId);
        if (TargetReview is null)
            return NotFound();
        return TargetReview;
    }

    [HttpPost]
    public ActionResult<AddReviewOutputDto> AddReview(AddReviewInputDto toBeAddedReviewDto)
    {
        var AddedReviewOutputDto = _reviewManager.Add(toBeAddedReviewDto);
        if(AddedReviewOutputDto is null)
            return NotFound();
        return AddedReviewOutputDto;
    }

    [HttpPut]
    public ActionResult<UpdateStatusEnum> UpdateReview(UpdateReviewInputDto updatedReviewDto)
    {
        var updateResult = _reviewManager.Update(updatedReviewDto);
        if (updateResult == UpdateStatusEnum.NotFound)
            return NotFound();
        if (updateResult == UpdateStatusEnum.InvalidInput)
            return BadRequest();
        return updateResult;
    }

    [HttpDelete]
    [Route("{customerId}/{productId}")]
    public ActionResult<DeleteStatusEnum> DeleteReview([FromRoute] DeleteReviewInputDto deleteInputDto)
    {
        var deleteResult = _reviewManager.Delete(deleteInputDto);
        if (deleteResult == DeleteStatusEnum.NotFound)
            return NotFound();
        return deleteResult;
    }
    #endregion
}
