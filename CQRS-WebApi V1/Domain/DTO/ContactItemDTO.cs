namespace CQRS_WebApi_V1.Domain.DTO
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
