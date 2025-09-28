using System.ComponentModel.DataAnnotations;

namespace ProductsManager.Application.Model;

public class Login
{
    public int Id { get; set; }
    [Required]
    public required string User { get; set; }

    [Required]
    public required string Password { get; set; }

    [Required]
    public required string Role { get; set; }
}