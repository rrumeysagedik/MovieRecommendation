using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTOs
{
    public class GetMovieDto
    {
        public int page { get; set; }
        public List<MovieDetailDto> results { get; set; }
        public int total_pages { get; set; }
        public int total_results { get; set; }
    }
}
