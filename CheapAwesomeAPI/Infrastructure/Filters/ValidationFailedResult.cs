using CheapAwesome.Domain.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheapAwesome.API.Infrastructure.Filters
{
    public class ValidationFailedResult : ObjectResult
    {
        public ValidationFailedResult(ModelStateDictionary modelState)
            : base(CommonResponse.CreateValidationErrorResponse(modelState))
        {
            StatusCode = StatusCodes.Status422UnprocessableEntity;

        }

    }
}
