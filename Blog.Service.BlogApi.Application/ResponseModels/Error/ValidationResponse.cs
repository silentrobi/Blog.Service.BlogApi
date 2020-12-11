using System.Collections.Generic;

namespace Blog.Service.BlogApi.Application.ErrorModels
{
    public class ValidationResponse
    {
        public List<string> Errors { get; set; }
    }
}
