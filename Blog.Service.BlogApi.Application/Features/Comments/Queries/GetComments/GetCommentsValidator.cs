using FluentValidation;

namespace Blog.Service.BlogApi.Application.Features.Comments.Queries.GetComments
{
    public class GetCommentsValidator : AbstractValidator<GetCommentsQuery>
    {
        public GetCommentsValidator()
        {
            RuleFor(model => model.PostId)
              .Length(24).WithMessage("PostId length should be 24");
        }
    }
}
