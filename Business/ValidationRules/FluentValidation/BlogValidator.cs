using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(b => b.BlogTitle).NotEmpty();
            RuleFor(b => b.BlogContent).MinimumLength(35);
            RuleFor(b => b.BlogContent).NotEmpty();
        }
    }
}


