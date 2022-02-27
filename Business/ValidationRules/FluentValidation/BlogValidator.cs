using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


