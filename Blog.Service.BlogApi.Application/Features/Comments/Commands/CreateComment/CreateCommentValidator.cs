using Blog.Service.BlogApi.Application.Commands.CreateComment;
using FluentValidation;

namespace Blog.Service.BlogApi.Application.Features.Comments.Commands.CreateComment
{
    public class CreateCommentValidator : AbstractValidator<CreateCommentCommand>
    {
        public CreateCommentValidator()
        {
            RuleFor(model => model.CreateCommentDto.Content)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Please ensure you have entered 'content' field")
                .NotEmpty().WithMessage("Content field shouldn't be empty");

            RuleFor(model => model.CreateCommentDto.ParentCommentId)
                .NotEmpty().WithMessage("ParentCommentId field shouldn't be empty")
                .When(s => s.CreateCommentDto.ParentCommentId != null);
        }
    }
}
