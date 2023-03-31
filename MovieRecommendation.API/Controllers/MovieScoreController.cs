using EntityLayer.DTOs;
using EntityLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieRecommendation.EntityLayer.DTOs;
using MovieRecommendation.EntityLayer.Services;

namespace MovieRecommendation.API.Controllers
{
    //[Authorize]
    public class MovieScoreController  : CustomBaseController
    {
        private readonly IMovieScoreService _movieScoreService;

        public MovieScoreController(IMovieScoreService movieScoreService)
        {
            _movieScoreService = movieScoreService;
        }

        [HttpPost("AddMovieScore")]
        public async Task<IActionResult> AddMovieScore(AddMovieScoreDto addMovieScore)
        {
            await _movieScoreService.AddMovieScore(addMovieScore);
            return CreateActionResult(CustomResponseDto<MovieScore>.Success(200));
        }
    }
}
