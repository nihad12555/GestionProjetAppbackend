using Microsoft.AspNetCore.Identity;

namespace GestionProjetAppBack.Models.Entities
{
    public class User : IdentityUser
    {
   public string FullName { get; set; } = string.Empty;
   public string Password { get; set; } = string.Empty;
    }
}