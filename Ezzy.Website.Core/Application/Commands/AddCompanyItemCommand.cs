using System;
using MediatR;
using Ezzy.Website.Infrastructure.Domain.DTO;

namespace Ezzy.Website.Core.Application.Commands
{
    public class AddCompanyItemCommand : IRequest<CompanyItemDTO>
    {
        public string pk { get; set; }
        public string sk { get; set; }
        public string description { get; set; }
        public string email { get; set; }
        public string logo { get; set; }
        public string name { get; set; }
        public string service { get; set; }

    }
}
