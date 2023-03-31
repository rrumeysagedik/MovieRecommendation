using EntityLayer.Models;
using EntityLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendation.EntityLayer.Repositories
{
    public interface IMovieScoreRepository : IGenericRepository<MovieScore>
    {
    }
}
