using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Ordering.Application.Extensions
{
    public static class ResultExtensions
    {

        public static Result MapToResult<T>(Result<T> originalResult)
        {
            var result = Result.Fail(originalResult.Errors);
            foreach (var reason in originalResult.Reasons.Where(r => r is Error))
            {
                result.WithError((Error)reason);
            }
            return result;
        }

        public static Result MapToResult(this Result originalResult)
        {
            var result = Result.Fail(originalResult.Errors);
            foreach (var reason in originalResult.Reasons.Where(r => r is Error))
            {
                result.WithError((Error)reason);
            }
            return result;
        }

        public static Result ToResul(this Result originalResult)
            => Result.Fail(originalResult.Reasons.Select(x => x.Message));
        
    }
}
