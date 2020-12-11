using FluentValidation;

namespace Blog.Service.BlogApi.Application.Features.Comments.Queries.GetComment
{
    public class GetCommentValidator : AbstractValidator<GetCommentQuery>
    {
        public GetCommentValidator()
        {
            RuleFor(model => model.PostId)
              .Length(24).WithMessage("PostId length should be 24");

            RuleFor(model => model.Id)
                .Length(24).WithMessage("Id length should be 24");
        }
    }
}
