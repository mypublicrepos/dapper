using System.ComponentModel.DataAnnotations;

namespace WebApi.Infrastructure.Entity;
public class Role
{
    [Key]
    public Guid Id { get; set; }

    [MaxLength(255)]
    public string RoleName { get; set; } = string.Empty;

    [Required]
    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public DateTime? UpdatedDate { get; set; }
}
