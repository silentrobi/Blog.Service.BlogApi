using FluentValidation;

namespace Blog.Service.BlogApi.Application.Features.Posts.Commands.CreatePost
{
    public class CreatePostValidator : AbstractValidator<CreatePostCommand>
    {
        public CreatePostValidator()
        {
            RuleFor(model => model.CreatePostDto.UserId)
              .Cascade(CascadeMode.Stop)
              .NotNull().WithMessage("Please ensure you have entered 'UserId' field")

            RuleFor(model => model.CreatePostDto.Content)
              .Cascade(CascadeMode.Stop)
              .NotNull().WithMessage("Please ensure you have entered 'Content' field")
              .NotEmpty().WithMessage("Content field shouldn't be empty");

        }
    }
}
