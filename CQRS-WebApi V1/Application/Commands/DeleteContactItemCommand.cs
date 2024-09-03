using System;
using MediatR;

namespace CQRS_WebApi_V1.Application.Commands
{
    public class DeleteContactItemCommand: IRequest<bool>
    {
        public string? Id { get; set; }
    }
}
