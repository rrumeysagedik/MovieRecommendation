using AutoMapper;
using EntityLayer.DTOs;
using EntityLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieRecommendation.EntityLayer.DTOs.UserDto;
using MovieRecommendation.EntityLayer.Models;
using MovieRecommendation.EntityLayer.Security;
using MovieRecommendation.EntityLayer.Services;

namespace MovieRecommendation.API.Controllers
{
    public class LoginController : CustomBaseController
    {
        private readonly ILoginService _loginService;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public LoginController(ILoginService loginService, IConfiguration configuration, IMapper mapper)
        {
            _loginService = loginService;
            _configuration = configuration;
            _mapper = mapper;
        }

        [HttpPost("UserCreate")]
        public async Task<IActionResult> UserCreate(UserCreateDto userCreateDto)
        {   
            var userCreate =await _loginService.AddAsync(_mapper.Map<User>(userCreateDto));
            userCreateDto = _mapper.Map<UserCreateDto>(userCreate);
            return CreateActionResult(CustomResponseDto<UserCreateDto>.Success(200,userCreateDto));
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromForm] UserLoginDto userLogin)
        {
            var userL = await _loginService.UserLogin(userLogin);
            return Ok(userL);
        }

        [HttpGet("RefreshTokenLogin")]
        public async Task<IActionResult> RefreshTokenLogin([FromForm] string refreshToken)
        {
            var userL = await _loginService.RefreshTokenLogin(refreshToken);
            return Ok(userL);
        }
    }
}
