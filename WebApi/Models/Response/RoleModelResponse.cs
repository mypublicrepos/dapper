namespace WebApi.Models.Response;

public class RoleModelResponse
{
    public Guid Id { get; set; }

    public string RoleName { get; set; } = string.Empty;

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }
}
