using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WorkBuddyServer.Entity;
using WorkBuddyServer.Service;
namespace WorkBuddyServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "AuthorizeOnly")]
    public class WorkoutController : Controller
    {
        private readonly IWorkoutService _workoutService;

        public WorkoutController(IWorkoutService workoutService)
        {
            this._workoutService = workoutService;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Workout>))]
        public IActionResult GetWorkouts()
        {
            var user = User.Identity as ClaimsIdentity;
            var id = user?.FindFirst("UserId")?.Value ?? "";
            var workouts = _workoutService.GetAll(Int32.Parse(id));
            return Ok(workouts);
        }
        [HttpGet("{workoutId}")]
        [ProducesResponseType(200, Type = typeof(Workout))]
        public IActionResult GetWorkout(int workoutId)
        {
            var workout = _workoutService.Get(workoutId);
            return Ok(workout);
        }
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(string))]
        public IActionResult AddWorkout([FromBody] Workout workout)
        {
            bool result = _workoutService.Add(workout);
            if (!result)
            {
                ModelState.AddModelError("AddWorkout", "Something went wrong");
                return BadRequest(ModelState);
            }
            return Ok("Workout had been added");
        }
        [HttpPatch]
        [ProducesResponseType(200, Type = typeof(string))]
        public IActionResult UpdateWorkout([FromBody] Workout workout)
        {
            bool result = _workoutService.Update(workout);
            if (!result)
            {
                ModelState.AddModelError("UpdateWorkout", "Something went wrong");
                return BadRequest(ModelState);
            }
            return Ok("Workout had been updated");
        }
        [HttpDelete("{workoutId}")]
        [ProducesResponseType(200, Type = typeof(string))]
        public IActionResult DeleteWorkout(int workoutId)
        {
            bool result = _workoutService.Delete(workoutId);
            if (!result)
            {
                ModelState.AddModelError("DeleteWorkout", "Something went wrong");
                return BadRequest(ModelState);
            }
            return Ok("Workout had been deleted");
        }


    }
}
