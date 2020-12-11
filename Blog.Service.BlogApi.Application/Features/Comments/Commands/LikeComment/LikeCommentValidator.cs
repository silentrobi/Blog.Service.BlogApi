using FluentValidation;

namespace Blog.Service.BlogApi.Application.Features.Comments.Commands.LikeComment
{
    public class LikeCommentValidator : AbstractValidator<LikeCommentCommand>
    {
        public LikeCommentValidator()
        {
            RuleFor(model => model.PostId)
                .Length(24).WithMessage("PostId length should be 24");

            RuleFor(model => model.Id)
                .Length(24).WithMessage("Id length should be 24");

            RuleFor(model => model.UserId)
                .Length(24).WithMessage("UserId length should be 24");
        }
    }
}
