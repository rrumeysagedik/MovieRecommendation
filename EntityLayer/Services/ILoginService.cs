using EntityLayer.Services;
using MovieRecommendation.EntityLayer.DTOs.UserDto;
using MovieRecommendation.EntityLayer.Models;
using MovieRecommendation.EntityLayer.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendation.EntityLayer.Services
{
    public interface ILoginService:IService<User>
    {
        public Task<Token> UserLogin(UserLoginDto userLogin);

        public Task<Token> RefreshTokenLogin(string refreshToken);
    }
}
