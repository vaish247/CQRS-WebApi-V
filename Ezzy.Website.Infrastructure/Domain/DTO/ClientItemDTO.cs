using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ezzy.Website.Infrastructure.Domain.DTO
{
    public record ClientItemDTO
    (
        string pk,
        string sk,
        string client_logo,
        string client_name

    );
}
