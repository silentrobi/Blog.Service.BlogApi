using FluentValidation;

namespace Blog.Service.BlogApi.Application.Features.Posts.Commands.UnlikePost
{
    public class UnlikePostValidator : AbstractValidator<UnlikePostCommand>
    {
        public UnlikePostValidator()
        {
            RuleFor(model => model.UserId)
               .Length(24).WithMessage("UserId length should be 24");

            RuleFor(model => model.Id)
                .Length(24).WithMessage("Id length should be 24");
        }
    }
}
