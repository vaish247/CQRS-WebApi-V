using System;
namespace Ezzy.Website.Infrastructure.Domain.Entities
{
    public class CaseStudyItem
    {
        public string pk { get; set; }
        public string sk { get; set; }    
        public string author_role { get; set; }
        public string client_name { get; set; }
        public string overview { get; set; }
        public string service { get; set; }
        public string testimony { get; set; }
        public string testimony_author { get; set; }
        public WhatWeDid what_we_did { get; set; }
        public string year { get; set; }

        public class WhatWeDid
        {
            public string custom_cms { get; set; } // Custom CMS
            public string frontend { get; set; } // Next.js
            public string infrastructure { get; set; } // Infrastructure
            public string seo { get; set; } // SEO
        }


    }



}
