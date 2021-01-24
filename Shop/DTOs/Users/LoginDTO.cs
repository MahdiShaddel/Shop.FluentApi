using System.ComponentModel.DataAnnotations;

namespace Shop.Host.DTOs.Users
{
    public class LoginDTO
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
