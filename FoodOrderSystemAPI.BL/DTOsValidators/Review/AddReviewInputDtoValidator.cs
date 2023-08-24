using FluentValidation;

namespace FoodOrderSystemAPI.BL;

public class AddReviewInputDtoValidator : AbstractValidator<AddReviewInputDto>
{
    public AddReviewInputDtoValidator()
    {
        RuleFor(x => x.Comment)
            .MaximumLength(500);
        RuleFor(x => x.Rating)
            .InclusiveBetween(0, 5)
            .WithMessage("Rating must be from 0 to 5");
    }
}
