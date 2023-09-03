using WebApi.Common.Enum;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Infrastructure.Entity;

public class User
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(255)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [MaxLength(255)]
    public string Email { get; set; } = string.Empty;

    [Required]
    [MaxLength(10)]
    public string Contact { get; set; } = string.Empty;

    public Gender Gender { get; set; }

    public bool? Status { get; set; }

    [Required]
    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public DateTime? UpdatedDate { get; set; }
}
