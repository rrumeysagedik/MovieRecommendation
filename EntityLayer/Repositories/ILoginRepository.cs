using EntityLayer.Repositories;
using MovieRecommendation.EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendation.EntityLayer.Repositories
{
    public interface ILoginRepository:IGenericRepository<User>
    {
    }
}
