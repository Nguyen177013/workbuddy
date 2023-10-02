using WorkBuddyServer.Entity;
using WorkBuddyServer.Repository;

namespace WorkBuddyServer.Service.IMP
{
    public class WorkoutService : IWorkoutService
    {
        private readonly IRepository<Workout> _workoutRepository;

        public WorkoutService(IRepository<Workout> workoutRepository)
        {
            this._workoutRepository = workoutRepository;
        }
        public bool Add(Workout workout)
        {
            return _workoutRepository.Add(workout);
        }
        public bool Update(Workout workout)
        {
            return _workoutRepository.Update(workout);
        }
        public bool Delete(int id)
        {
            return _workoutRepository.Delete(id);
        }
        public Workout Get(int id)
        {
            return _workoutRepository.FindById(id);
        }
        public IEnumerable<Workout> GetAll()
        {
            return _workoutRepository.GetAll();
        }

    }
}
