using FluentValidation;

namespace Blog.Service.BlogApi.Application.Features.Posts.Commands.UpdatePost
{
    public class UpdatePostValidator : AbstractValidator<UpdatePostCommand>
    {
        public UpdatePostValidator()
        {
            RuleFor(model => model.Id)
               .Length(24).WithMessage("Id length should be 24");

            RuleFor(model => model.UpdatePostDto.Content)
              .Cascade(CascadeMode.Stop)
              .NotNull().WithMessage("Please ensure you have entered 'Content' field")
              .NotEmpty().WithMessage("Content field shouldn't be empty");
        }
    }
}
