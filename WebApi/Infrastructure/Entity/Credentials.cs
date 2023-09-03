using System.ComponentModel.DataAnnotations;

namespace WebApi.Infrastructure.Entity;

public class Credentials
{
    [Key]
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public Guid RoleId { get; set; }

    public string Hash { get; set; } = string.Empty;

    public string Salt { get; set; } = string.Empty;

    [Required]
    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public DateTime? UpdatedDate { get; set; }
}
