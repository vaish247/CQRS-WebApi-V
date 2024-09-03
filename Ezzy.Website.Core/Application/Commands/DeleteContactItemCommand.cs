using System;
using MediatR;

namespace Ezzy.Website.Core.Application.Commands
{
    public class DeleteContactItemCommand: IRequest<bool>
    {
        public string? Id { get; set; }
    }
}
