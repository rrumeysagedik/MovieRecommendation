using MovieRecommendation.EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Models
{
    public class MovieScore
    {
        public int Id { get; set; }
        public int Score { get; set; }
        public string Note { get; set; }
        public int MovieDetailId { get; set; }
        public MovieDetail MovieDetail { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } 
    }
}
