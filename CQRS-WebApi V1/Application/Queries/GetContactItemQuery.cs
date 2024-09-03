using System;
using MediatR;
using CQRS_WebApi_V1.Domain.Entities;

namespace CQRS_WebApi_V1.Application.Queries
{
    public class GetContactItemQuery :IRequest<ContactItem>
    {
        public string Id { get; set; }
    }
}
