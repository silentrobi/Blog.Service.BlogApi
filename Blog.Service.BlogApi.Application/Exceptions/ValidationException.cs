using FluentValidation.Results;
using System;
using System.Collections.Generic;

namespace Blog.Service.BlogApi.Application.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException(IEnumerable<ValidationFailure> failures)
            : base(string.Join(", ", failures))
        {
        }
    }
}
