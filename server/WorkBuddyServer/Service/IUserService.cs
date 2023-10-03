using System.Linq.Expressions;
using WorkBuddyServer.DTO;
using WorkBuddyServer.Entity;

namespace WorkBuddyServer.Service
{
    public interface IUserService
    {
        bool Add(User user);
        bool Delete(int id);
        User Get(int id);
        IEnumerable<User> GetAll();
        bool Update(int userId, UserDTO userDto);
        User FindUser(UserDTO userDTO);
        User CheckUserLogin(UserDTO userDTO);
        public AuthResponse GenerateToken(User user);
    }
}