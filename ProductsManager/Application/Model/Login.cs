using System.ComponentModel.DataAnnotations;

namespace ProductsManager.Application.Model;

public class Login
{
    [Required]
    public required string User { get; set; }

    [Required]
    public required string Password { get; set; }
}