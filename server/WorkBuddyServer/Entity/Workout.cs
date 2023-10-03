using System.ComponentModel.DataAnnotations;

namespace WorkBuddyServer.Entity
{
    public class Workout
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public int Reps { get; set; }

        [Required]
        public int Load { get; set; }

        public virtual User User { get; set; } = new User();
    }
}
