using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Models
{
    public class MovieDetail
    {
        [Key]
        public int MovieDetailId { get; set; }
        public int Id { get; set; } //apiden gelen filmlerin kendi idleri
        public string OriginalLanguage { get; set; }
        public string Overview { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string Title { get; set; }
        public double VoteAverage { get; set; }
        public List<MovieScore> MovieScores { get; set; }
    }
}
