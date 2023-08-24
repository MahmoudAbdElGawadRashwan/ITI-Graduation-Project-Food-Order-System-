using FluentValidation;

namespace FoodOrderSystemAPI.BL;

public class GetAllReviewsOutputDtoValidator : AbstractValidator<GetAllReveiwsOutputDto>
{
    public GetAllReviewsOutputDtoValidator()
    {
        RuleFor(x => x.Comment)
            .MaximumLength(500);
        RuleFor(x => x.Rating)
            .InclusiveBetween(0, 5)
            .WithMessage("Rating must be from 0 to 5");
    }
}
