using System.ComponentModel.DataAnnotations;

namespace WorkBuddyServer.DTO
{
    public class WorkoutDTO
    {

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public int Reps { get; set; }

        [Required]
        public int Load { get; set; }
    }
}
