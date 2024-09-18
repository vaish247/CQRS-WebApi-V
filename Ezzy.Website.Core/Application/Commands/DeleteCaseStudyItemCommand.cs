using System;
using MediatR;

namespace Ezzy.Website.Core.Application.Commands
{
    public class DeleteCaseStudyItemCommand: IRequest<bool>
    {
        public string pk { get; set; }
        public string sk { get; set; }

    }
}
