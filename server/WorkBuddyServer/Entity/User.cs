using System.ComponentModel.DataAnnotations;

namespace WorkBuddyServer.Entity
{
    public class User
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; } =   string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;


        public ICollection<Workout> Workouts { get; set; } = new List<Workout>();
    }
}
