using System.ComponentModel.DataAnnotations;

namespace WorkBuddyServer.DTO
{
    public class UserDTO
    {

        [Required]
        public string UserName { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
