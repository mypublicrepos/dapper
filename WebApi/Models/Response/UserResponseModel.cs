using WebApi.Common.Enum;

namespace WebApi.Models.Response;

public class UserResponseModel
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Contact { get; set; } = string.Empty;

    public Gender Gender { get; set; }

    public bool? Status { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }
}
