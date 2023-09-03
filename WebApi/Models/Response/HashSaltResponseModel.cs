namespace WebApi.Models.Response;

public class HashSaltResponseModel
{
    public string Hash { get; set; } = string.Empty;

    public string Salt { get; set; } = string.Empty;

    public Guid RoleId { get; set; }
}
