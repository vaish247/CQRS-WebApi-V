using Ezzy.Website.Infrastructure.Domain.Entities;

namespace Ezzy.Website.Infrastructure.Domain.DTO
{
    public record CaseStudyItemDTO
    (
        string pk,
        string sk,
        string author_role,
        string client_name,
        string overview,
        string service,
        string testimony,
        string testimony_author,
        CaseStudyItem.WhatWeDid what_we_did,
        string year
    );
}
