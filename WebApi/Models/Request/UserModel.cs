using WebApi.Common.Enum;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Request;

public class UserModel
{
    /// <summary> </summary>
    [Required]
    [MaxLength(255)]
    public string Name { get; set; } = string.Empty;

    /// <summary> </summary>
    [Required]
    [MaxLength(255)]
    public string Email { get; set; } = string.Empty;

    /// <summary> </summary>
    [Required]
    [MaxLength(10)]
    public string Contact { get; set; } = string.Empty;

    /// <summary> </summary>
    [Required]
    [MaxLength(50)]
    public string Password { get; set; } = string.Empty;

    /// <summary> </summary>
    [Required]
    public Guid RoleId { get; set; }

    /// <summary> </summary>
    public Gender Gender { get; set; }

    /// <summary> </summary>
    public bool? Status { get; set; }
}

