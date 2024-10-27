using CarBook.Application.Features.Mediator.Commands.ReviewCommands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Validators.ReviewValidator
{
    public class UpdateReviewValidator:AbstractValidator<UpdateReviewCommand>
    {
        public UpdateReviewValidator()
        {
            RuleFor(x => x.CustomerName).NotEmpty().WithMessage("Please, enter CustomerName");
            RuleFor(x => x.CustomerName).MinimumLength(5).WithMessage("Please, enter 5 character minimum.");
            RuleFor(x => x.RaytingValue).NotEmpty().WithMessage("Please, enter point value.");
            RuleFor(x => x.Comment).MinimumLength(50).WithMessage("Please, enter 50 character minimum.");
            RuleFor(x => x.Comment).MaximumLength(500).WithMessage("Please, enter 500 character max.");
            RuleFor(x => x.CustomerImage).NotEmpty().WithMessage("Please, enter an Image").MinimumLength(10).WithMessage("Please add 10 character min.")
                .MaximumLength(200).WithMessage("Please enter 200 character max.");
        }
    }
}
