using FluentValidation;

namespace Blog.Service.BlogApi.Application.Features.Comments.Commands.DeleteComment
{
    public class DeleteCommentValidator : AbstractValidator<DeleteCommentCommand>
    {
        public DeleteCommentValidator()
        {
            RuleFor(model => model.PostId)
                .Length(24).WithMessage("PostId length should be 24");

            RuleFor(model => model.Id)
                .Length(24).WithMessage("Id length should be 24");
        }
    }
}
