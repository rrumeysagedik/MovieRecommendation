using AutoMapper;
using BusinessLayer.Services;
using EntityLayer.Models;
using EntityLayer.Repositories;
using EntityLayer.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MovieRecommendation.BusinessLayer.Services.TokenHandlerService;
using MovieRecommendation.EntityLayer.DTOs.UserDto;
using MovieRecommendation.EntityLayer.Models;
using MovieRecommendation.EntityLayer.Security;
using MovieRecommendation.EntityLayer.Services;


namespace MovieRecommendation.BusinessLayer.Services
{
    public class LoginService : Service<User>, ILoginService
    {

        private readonly IGenericRepository<User> _userRepository;
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public LoginService(IUnitOfWork unitOfWork, IMapper mapper, IGenericRepository<User> userRepository, IConfiguration configuration) : base(userRepository, unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public async Task<Token> UserLogin(UserLoginDto userLogin)
        {
            User user = await _userRepository.Where(x => x.Email == userLogin.Email && x.Password == userLogin.Password).FirstOrDefaultAsync();
            if (user != null)
            {
                //Token üretiliyor.
                TokenHandler tokenHandler = new TokenHandler(_configuration);
                Token token = tokenHandler.CreateAccessToken(user);
                //Refresh token Users tablosuna işleniyor.
                user.RefreshToken = token.RefreshToken;
                user.RefreshTokenEndDate = token.Expiration.AddMinutes(10);
                _unitOfWork.CommitAsync();
                return token;
            }
            return null;
        }

        public async Task<Token> RefreshTokenLogin(string refreshToken)
        {
            User user = await _userRepository.Where(x =>x.RefreshToken==refreshToken).FirstOrDefaultAsync();
            if (user != null && user?.RefreshTokenEndDate > DateTime.Now)
            {
                TokenHandler tokenHandler = new TokenHandler(_configuration);
                Token token = tokenHandler.CreateAccessToken(user);
                user.RefreshToken = token.RefreshToken;
                user.RefreshTokenEndDate = token.Expiration.AddMinutes(3);
                _unitOfWork.CommitAsync();

                return token;
            }
            return null;
        }
    }
}
