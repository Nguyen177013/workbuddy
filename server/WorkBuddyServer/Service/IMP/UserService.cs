using WorkBuddyServer.DTO;
using WorkBuddyServer.Entity;
using WorkBuddyServer.Repository;
using WorkBuddyServer.Utils;

namespace WorkBuddyServer.Service.IMP
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IConfiguration _configuration;
        private readonly UserSecurity userSecurity;
        public UserService(IRepository<User> userRepository, IConfiguration configuration)
        {
            this._userRepository = userRepository;
            this._configuration = configuration;
            userSecurity = new UserSecurity(_configuration);
        }
        public bool Add(User user)
        {
            user.Password = userSecurity.MD5Hash(user.Password);
            var result = _userRepository.Add(user);
            return result;
        }
        public bool Update(User user)
        {
            return _userRepository.Update(user);
        }
        public bool Delete(int id)
        {
            return _userRepository.Delete(id);
        }
        public User Get(int id)
        {
            return _userRepository.FindById(id);
        }
        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User FindUser(UserDTO userDTO)
        {
            return _userRepository.Find(user => user.UserName.TrimEnd().ToUpper() == userDTO
            .UserName.TrimEnd().ToUpper() && user.Email.TrimEnd().ToUpper() == userDTO
            .Email.TrimEnd().ToUpper());
        }
        public bool CheckUserLogin(UserDTO userDTO)
        {
            User user = _userRepository.Find(user =>user.UserName.TrimEnd().ToUpper() == userDTO
            .UserName.TrimEnd().ToUpper());
            if(user == null)
            {
                return false;
            }
            bool checkUser = userSecurity.CompareMD5Hash(userDTO.Password, user.Password);
            return checkUser;
        }
    }
}
