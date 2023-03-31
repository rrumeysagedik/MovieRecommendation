using EntityLayer.DTOs;
using EntityLayer.Models;
using EntityLayer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieRecommendation.EntityLayer.DTOs;
using MovieRecommendation.EntityLayer.Services;
using MovieRecommendation.EntityLayer.PaginationFilter;
using MovieRecommendation.BusinessLayer.Services;
using MovieRecommendation.EntityLayer.Security;
using MovieRecommendation.BusinessLayer.Services.TokenHandlerService;
using Microsoft.AspNetCore.Authorization;

namespace MovieRecommendation.API.Controllers
{
   //[Authorize]
    public class MovieDetailController : CustomBaseController
    {
   
        private readonly IMovieDetailService _movieDetailService;
        private readonly IConfiguration _configuration;
        public MovieDetailController(IMovieDetailService movieDetailService, IConfiguration configuration)
        {
            _movieDetailService = movieDetailService;
            _configuration = configuration;
        }

        [HttpGet("GetMovieDetails")]
        public async Task<IActionResult> GetMovieDetails([FromQuery] PaginationFilter filter)
        {         
            var response = await _movieDetailService.GetMovieDetailsAsync(filter);
            return Ok(response);       
        }

        [HttpGet("GetMovieDetailAndMovieScore")]
        public async Task<IActionResult> GetMovieDetailAndMovieScore(int id)
        {
            var response = await _movieDetailService.GetMovieDetailAndMovieScore(id);
            return Ok(response);
        }

        //[HttpGet("AccessTokenandRefreshToken")]
        //public IActionResult AccessTokenandRefreshToken()
        //{
        //    Token token = TokenHandler.CreateAccessToken(_configuration);
        //    return Ok(token);
        //}
    }
}
