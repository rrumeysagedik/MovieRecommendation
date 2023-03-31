using DataAccessLayer.Repositories;
using DataAccessLayer;
using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieRecommendation.EntityLayer.Repositories;

namespace MovieRecommendation.DataAccessLayer.Repositories
{
    public class MovieScoreRepository : GenericRepository<MovieScore>, IMovieScoreRepository
    {
        public MovieScoreRepository(AppDbContext context) : base(context)
        {
        }
    }
}
