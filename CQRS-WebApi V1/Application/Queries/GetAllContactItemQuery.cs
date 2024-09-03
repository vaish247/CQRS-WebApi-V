using System.Collections.Generic;
using MediatR;
using CQRS_WebApi_V1.Domain.Entities;

namespace CQRS_WebApi_V1.Application.Queries
{
    public class GetAllContactItemQuery: IRequest<IEnumerable<ContactItem>>
    {
    }
}
