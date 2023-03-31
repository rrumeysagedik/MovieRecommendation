using EntityLayer.Models;
using EntityLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class MovieDetailRepository : GenericRepository<MovieDetail>, IMovieDetailRepository
    {
        public MovieDetailRepository(AppDbContext context) : base(context)
        {
        }
    }
}
