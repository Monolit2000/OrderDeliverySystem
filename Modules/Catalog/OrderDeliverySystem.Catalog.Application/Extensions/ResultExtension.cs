using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Catalog.Application.Extensions
{
    public static class ResultExtension
    {
        public static Result CombineResults(IEnumerable<Result> results)
        {
            foreach (var result in results)
            {
                if (result.IsFailed)
                    return result;
            }
            return Result.Ok();
        }
    }
}
