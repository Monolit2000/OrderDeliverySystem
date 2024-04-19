using FluentResults;
using OrderDeliverySystem.CommonModule.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OrderDeliverySystem.UserAccess.Domain.Users
{
    public class PhoneNumber : ValueObject
    {
        private const string phoneRegex = @"^(\+?38)?(0\d{2})?\d{7}$";

        public string Number { get; }

        private PhoneNumber(string number) 
        {
            Number = number;    
        }

        public static Result<PhoneNumber> Create(string inputNumebr)
        {
            if(string.IsNullOrWhiteSpace(inputNumebr))
                return Result.Fail(new Error("ValueIsInvalid"));

            if(Regex.IsMatch(inputNumebr, phoneRegex) == false)
                return Result.Fail(new Error("ValueIsInvalid"));

            return new PhoneNumber(inputNumebr);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Number;
        }
    }
}
