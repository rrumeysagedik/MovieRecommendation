using EntityLayer.DTOs;
using EntityLayer.Models;
using MovieRecommendation.EntityLayer.DTOs;
using MovieRecommendation.EntityLayer.PaginationFilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Services
{
    public interface IMovieDetailService:IService<MovieDetail>
    {
        Task<List<MovieDetailDto>> GetMovieDetailsAsync(PaginationFilter filter);
        Task<List<MovieDetailAndScoreDto>> GetMovieDetailAndMovieScore(int id);
        Task<List<GetMovieDto>> GetMoviesAsync();        
        Task AddMovieAsync(MovieDto movieRequest);
        
    }
}
