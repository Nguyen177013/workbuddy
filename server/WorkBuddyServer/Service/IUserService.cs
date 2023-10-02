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
        bool Update(User user);
        User FindUser(UserDTO userDTO);
        bool CheckUserLogin(UserDTO userDTO);
    }
}