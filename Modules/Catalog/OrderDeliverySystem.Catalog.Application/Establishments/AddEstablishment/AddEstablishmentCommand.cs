using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Catalog.Application.Establishments.AddEstablishment
{
    public class AddEstablishmentCommand : IRequest<Result<AddEstablishmentDto>>
    {
        public string Name { get; set; }

        public AddEstablishmentCommand(string name)
        {
            Name = name;
        }
    }
}
