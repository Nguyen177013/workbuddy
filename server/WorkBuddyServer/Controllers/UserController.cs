using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorkBuddyServer.DTO;
using WorkBuddyServer.Entity;
using WorkBuddyServer.Service;

namespace WorkBuddyServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            this._userService = userService;
            this._mapper = mapper;
        }

        [HttpGet]
        [Route("GetUsers")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<User>))]
        public IActionResult GetUsers()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }
        
        [HttpGet("{userId}")]
        public IActionResult GetUser(int userId)
        {
            var user = _userService.Get(userId);
            return Ok(user);
        }
        [HttpPost("CreateUser")]
        public IActionResult AddUser([FromBody] UserDTO userDTO)
        {
            User user = _userService.FindUser(userDTO);
            if(user != null) {
                ModelState.AddModelError("AddUser", "User already exist");
                return BadRequest(ModelState);
            }
            User userMap = _mapper.Map<User>(userDTO);
            bool result = _userService.Add(userMap);
            if (!result)
            {
                ModelState.AddModelError("AddUser", "Something went wrong");
                return BadRequest(ModelState);
            }
            return Ok("User had been added");
        }
        [HttpPatch("UpdateUser")]
        public IActionResult UpdateUser([FromBody] UserDTO userDto)
        {
            User userMap = _mapper.Map<User>(userDto);
            bool result = _userService.Update(userMap);
            if (!result)
            {
                ModelState.AddModelError("UpdateUser", "Something went wrong");
                return BadRequest(ModelState);
            }
            return Ok("User had been updated");
        }
        [HttpDelete("DeleteUser/{userId}")]
        public IActionResult DeleteUser(int userId)
        {
            bool result = _userService.Delete(userId);
            if (!result)
            {
                ModelState.AddModelError("DeleteUser", "Something went wrong");
                return BadRequest(ModelState);
            }
            return Ok("User had been deleted");
        }
        [HttpPost("Login")]
        public IActionResult Login([FromBody] UserDTO userDTO)
        {
            var checkUser = _userService.FindUser(userDTO);
            if (checkUser != null)
            {
                
            }
            return Ok();
        }
    }
}
