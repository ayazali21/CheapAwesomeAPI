using CheapAwesome.Domain.Models.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheapAwesome.API.Infrastructure.Validator
{
    public class GetHotelRequestValidator:AbstractValidator<GetHotelRequest>
    {
        public GetHotelRequestValidator()
        {

            RuleFor(x => x.destId).GreaterThan(0);
            RuleFor(x => x.noOfNights).GreaterThan(0);
        }
    }
}
