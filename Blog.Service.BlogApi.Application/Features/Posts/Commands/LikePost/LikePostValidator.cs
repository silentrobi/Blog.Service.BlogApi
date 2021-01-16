using FluentValidation;

namespace Blog.Service.BlogApi.Application.Features.Posts.Commands.LikePost
{
    public class UnlikePostValidator : AbstractValidator<LikePostCommand>
    {
        public UnlikePostValidator()
        {
            RuleFor(model => model.Id)
                .Length(24).WithMessage("Id length should be 24");
        }
    }
}
