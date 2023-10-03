using WorkBuddyServer.DTO;
using WorkBuddyServer.Entity;

namespace WorkBuddyServer.Service
{
    public interface IWorkoutService
    {
        bool Add(Workout workout);
        bool Delete(int id);
        Workout Get(int id);
        IEnumerable<Workout> GetAll(int userId);
        bool Update(Workout workout);
    }
}