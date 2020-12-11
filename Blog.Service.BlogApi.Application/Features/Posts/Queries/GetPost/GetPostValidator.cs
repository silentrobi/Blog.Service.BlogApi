using FluentValidation;

namespace Blog.Service.BlogApi.Application.Features.Posts.Queries.GetPost
{
    public class GetPostValidator : AbstractValidator<GetPostQuery>
    {
        public GetPostValidator()
        {
            RuleFor(model => model.Id)
                .Length(24).WithMessage("Id length should be 24");
        }
    }
}
