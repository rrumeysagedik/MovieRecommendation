using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendation.EntityLayer.DTOs
{
    public class AddMovieScoreDto
    {
        public int Id { get; set; }
        public int Score { get; set; }
        public string Note { get; set; }
        public int UserId { get; set; }
    }
}
