using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderSystemAPI.BL;

public class UpdateReviewInputDtoValidator : AbstractValidator<UpdateReviewInputDto>
{
    public UpdateReviewInputDtoValidator()
    {
        RuleFor(x => x.Comment)
            .MaximumLength(500);
        RuleFor(x => x.Rating)
            .InclusiveBetween(0, 5)
            .WithMessage("Rating must be from 0 to 5");
    }
}
