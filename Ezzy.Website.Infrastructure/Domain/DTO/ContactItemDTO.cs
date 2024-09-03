namespace Ezzy.Website.Infrastructure.Domain.DTO
{
    public record ContactItemDTO
    (
        string? Id,
        string Name,
        string Email,
        string Phone,
        string Company,
        string Message,
        string Budget
    );
}
