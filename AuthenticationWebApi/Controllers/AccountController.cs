using AuthenticationWebApi.Helper;
using AuthenticationWebApi.Model;
using AutoMapper;
using JwtTokenAuthenticationManager;
using JwtTokenAuthenticationManager.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebRTCChat.Common.Data;
using WebRTCChat.Model;
using BC= BCrypt.Net;

namespace AuthenticationWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IDataContext _dataContext;
        private readonly IJwtTokenHandler _jwtTokenHandler;
        private readonly IMapper _mapper;
        public AccountController(IDataContext dataContext, IJwtTokenHandler jwtTokenHandler, IMapper mapper)
        {
            _dataContext = dataContext;
            _jwtTokenHandler = jwtTokenHandler;
            _mapper = mapper;
        }
        

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(AuthenticationRequest model)
        {

            var user = await _dataContext.User.SingleOrDefaultAsync(x => x.UserName == model.UserName);

            // validate
            if (user == null || !BC.BCrypt.Verify(model.Password, user.Password))
                throw new AppException("Username or password is incorrect");
            // authentication successful
            var response = _jwtTokenHandler.GenerateToken(user);
            if (response == null) { return Unauthorized(); }
            else
                return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest model)
        {
            if (_dataContext.User.Any(x => x.UserName == model.Username))
                throw new AppException("Username '" + model.Username + "' is already taken");

            // map model to new user object
            var user = _mapper.Map<User>(model);
            // hash password
            user.Password = BC.BCrypt.HashPassword(model.Password);

            // save user
            await _dataContext.User.AddAsync(user);
            var response = await _dataContext.SaveChanges();
            if (response != 0)
            {
                return Ok(new { message = "Registration successful" });
            }
            else
            {
                return Ok(new { message = "Registration Failed" });

            }
        }
    }
}
