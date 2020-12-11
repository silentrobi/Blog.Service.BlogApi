using FluentValidation;

namespace Blog.Service.BlogApi.Application.Features.Comments.Commands.UpdateComment
{
    public class UpdateCommentValidator : AbstractValidator<UpdateCommentCommand>
    {
        public UpdateCommentValidator()
        {
            RuleFor(model => model.PostId)
               .Length(24).WithMessage("PostId length should be 24");

            RuleFor(model => model.Id)
                .Length(24).WithMessage("Id length should be 24");

            RuleFor(model => model.UpdateCommentDto.Content)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Please ensure you have entered 'content' field")
                .NotEmpty().WithMessage("Content field shouldn't be empty");
        }
    }
}
