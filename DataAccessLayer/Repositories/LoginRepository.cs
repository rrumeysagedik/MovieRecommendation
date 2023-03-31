using DataAccessLayer;
using DataAccessLayer.Repositories;
using MovieRecommendation.EntityLayer.Models;
using MovieRecommendation.EntityLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendation.DataAccessLayer.Repositories
{
    public class LoginRepository : GenericRepository<User>, ILoginRepository
    {
        public LoginRepository(AppDbContext context) : base(context)
        {
        }
    }
}
