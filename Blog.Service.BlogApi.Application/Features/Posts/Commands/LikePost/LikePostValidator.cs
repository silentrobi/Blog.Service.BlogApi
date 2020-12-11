using FluentValidation;

namespace Blog.Service.BlogApi.Application.Features.Posts.Commands.LikePost
{
    public class UnlikePostValidator : AbstractValidator<LikePostCommand>
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
