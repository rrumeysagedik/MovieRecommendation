using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendation.EntityLayer.DTOs
{
    public class MovieDetailAndScoreDto
    {
        public int id { get; set; }
        public int MovieDetailId { get; set; }
        public string original_language { get; set; }
        public string overview { get; set; }
        public DateTime? release_date { get; set; }
        public string title { get; set; }
        public double vote_average { get; set; }
        public int Score { get; set; }
        public string Note { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
    }
}
