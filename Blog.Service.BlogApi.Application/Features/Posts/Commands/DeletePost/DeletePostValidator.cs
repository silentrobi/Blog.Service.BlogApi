using FluentValidation;

namespace Blog.Service.BlogApi.Application.Features.Posts.Commands.DeletePost
{
    public class DeletePostValidator : AbstractValidator<DeletePostCommand>
    {
        public DeletePostValidator()
        {
            RuleFor(model => model.Id)
                .Length(24).WithMessage("Id length should be 24");
        }
    }
}
