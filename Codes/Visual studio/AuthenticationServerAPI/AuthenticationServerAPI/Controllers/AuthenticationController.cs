using AuthenticationServerAPI.Models;
using AuthenticationServerAPI.Models.Request;
using AuthenticationServerAPI.Models.Response;
using AuthenticationServerAPI.Services.PasswordHashers;
using AuthenticationServerAPI.Services.UserRepositories;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationServerAPI.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IUserRepository _userRepository;
       
        private readonly IPasswordHasher _passwordHasher;

        public AuthenticationController(IUserRepository userRepository,IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest registerRequest)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<string> errorMessage=ModelState.Values.SelectMany(x=>x.Errors.Select(y=>y.ErrorMessage));
                return BadRequest(new ErrorResponse(errorMessage));
            }

            if (registerRequest.Password != registerRequest.ConfirmPassword) 
            {
                return BadRequest(new ErrorResponse("Password does not match confirm password"));
            }
            
            User existingUserByEmail = await _userRepository.GetByEmail(registerRequest.Email);
            if (existingUserByEmail != null)
            {
                return Conflict(new ErrorResponse("Email already exists"));
            }

            User existingUserByUserName = await _userRepository.GetByUsername(registerRequest.Username);
            if (existingUserByUserName != null)
            {
                return Conflict(new ErrorResponse("User already exists"));
            }

            string passwordHash=_passwordHasher.HashPassword(registerRequest.Password);
            User registrationUser = new User()
            {
                Email = registerRequest.Email,
                Username = registerRequest.Username,
                PasswordHash = passwordHash
            };
            await _userRepository.Create(registrationUser);

            return Ok();

        }
    }
}
