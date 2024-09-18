using System;
using MediatR;
using Ezzy.Website.Infrastructure.Domain.DTO;
using Ezzy.Website.Infrastructure.Domain.Entities;

namespace Ezzy.Website.Core.Application.Commands
{
    public class AddCaseStudyItemCommand : IRequest<CaseStudyItemDTO>
    {
        public string pk { get; set; }
        public string sk { get; set; }
        public string author_role { get; set; }
        public string client_name { get; set; }
        public string overview { get; set; }
        public string service { get; set; }
        public string testimony { get; set; }
        public string testimony_author { get; set; }
        public CaseStudyItem.WhatWeDid what_we_did { get; set; }
        public string year { get; set; }
    }
}
