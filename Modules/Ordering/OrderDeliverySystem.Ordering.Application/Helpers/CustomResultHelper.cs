using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Ordering.Application.Helpers
{
    public static class CustomResultHelper
    {
        public static Result ToResult<T>(Result<T> originalResult)
           => Result.Fail(originalResult.Reasons.Select(x => x.Message));
    }
}
