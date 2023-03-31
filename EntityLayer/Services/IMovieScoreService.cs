using EntityLayer.Models;
using EntityLayer.Services;
using MovieRecommendation.EntityLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendation.EntityLayer.Services
{
    public interface IMovieScoreService : IService<MovieScore>
    {
        Task AddMovieScore(AddMovieScoreDto addMovieScore);
    }
}
