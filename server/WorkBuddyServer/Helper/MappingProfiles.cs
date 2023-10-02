using AutoMapper;
using WorkBuddyServer.DTO;
using WorkBuddyServer.Entity;

namespace WorkBuddyServer.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Workout, WorkoutDTO>().ReverseMap();
        }
    }
}
