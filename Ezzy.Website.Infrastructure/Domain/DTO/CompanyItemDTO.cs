namespace Ezzy.Website.Infrastructure.Domain.DTO
{
    public record CompanyItemDTO
    (
        string pk,
        string sk,
        string description,
        string email,
        string logo,
        string name,
        string service
    );
}
