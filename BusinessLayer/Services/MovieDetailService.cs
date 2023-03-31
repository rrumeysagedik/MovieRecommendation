using AutoMapper;
using DataAccessLayer.Repositories;
using EntityLayer.DTOs;
using EntityLayer.Models;
using EntityLayer.Repositories;
using EntityLayer.Services;
using EntityLayer.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using MovieRecommendation.EntityLayer.DTOs;
using MovieRecommendation.EntityLayer.Models;
using MovieRecommendation.EntityLayer.PaginationFilter;
using Newtonsoft.Json;

namespace BusinessLayer.Services
{
    public class MovieDetailService : Service<MovieDetail>, IMovieDetailService
    {
        private readonly IGenericRepository<MovieDetail> _movieDetailRepository;
        private readonly IGenericRepository<MovieScore> _movieScoreRepository;
        private readonly IGenericRepository<User> _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public MovieDetailService(IGenericRepository<MovieDetail> movieDetailRepository, IUnitOfWork unitOfWork, IMapper mapper, IGenericRepository<MovieScore> movieScoreRepository, IGenericRepository<User> userRepository) : base(movieDetailRepository, unitOfWork)
        {
            _movieDetailRepository = movieDetailRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _movieScoreRepository = movieScoreRepository;
            _userRepository = userRepository;
        }

        public async Task<List<MovieDetailAndScoreDto>> GetMovieDetailAndMovieScore(int id)
        {
            var movieDetailAndScores = from score in _movieScoreRepository.GetAll()
                                       join movie in _movieDetailRepository.GetAll() on score.MovieDetailId equals movie.MovieDetailId
                                       join user in _userRepository.GetAll() on score.UserId equals user.Id
                                       where movie.MovieDetailId == id
                                       select new MovieDetailAndScoreDto
                                       {
                                           id = movie.Id,
                                           MovieDetailId = score.MovieDetailId,
                                           title = movie.Title,
                                           overview = movie.Overview,
                                           vote_average = movie.VoteAverage,
                                           original_language = movie.OriginalLanguage,
                                           release_date = movie.ReleaseDate,
                                           Note = score.Note,
                                           Score = score.Score,
                                           Name = user.Name,
                                           SurName = user.SurName
                                       };
            if (movieDetailAndScores != null && movieDetailAndScores.Count() > 0)
            {
                var movieDetailAndScore = await movieDetailAndScores.ToListAsync();
                return movieDetailAndScore;
            }
            else
                return null;

        }

        public async Task<List<MovieDetailDto>> GetMovieDetailsAsync(PaginationFilter filter)
        {
            var movieDetails = await _movieDetailRepository.GetAll()
               .Skip((filter.PageNumber - 1) * filter.PageSize)
               .Take(filter.PageSize)
               .ToListAsync();
            var movieDetailsDto = _mapper.Map<List<MovieDetailDto>>(movieDetails);
            if (movieDetails != null && movieDetails.Count > 0)
                return movieDetailsDto;
            else
                return null;
        }

        public async Task<List<GetMovieDto>> GetMoviesAsync()
        {
            //ilk film detayları uçuuccak post metodunda 

            GetMovieDto movie = new GetMovieDto();
            List<GetMovieDto> movies = new List<GetMovieDto>();
            //string connection = "https://api.themoviedb.org//3//movie//popular?api_key=7b03ee69bb87022df832cd1f2c135fec&page=1";
            //using (var client = new HttpClient())
            //{
            //    using (var response = client.GetAsync(connection).Result)
            //    {
            //        if (response.IsSuccessStatusCode)
            //        {
            //            var movieJsonString = await response.Content.ReadAsStringAsync();
            //            movie = JsonConvert.DeserializeObject<GetMovieDto>(movieJsonString);
            //            movies.Add(movie);
            //        }
            //        else
            //        {
            //            throw new Exception();
            //        }
            //    }
            //}
            for (int i = 1; i <= 10/**movie.total_pages **/; i++)
            {
                string connection2 = "https://api.themoviedb.org//3//movie//popular?api_key=7b03ee69bb87022df832cd1f2c135fec&page=" + $"{i}";
                using (var client = new HttpClient())
                {
                    using (var response = client.GetAsync(connection2).Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var movieJsonString = await response.Content.ReadAsStringAsync();
                            movies.Add(JsonConvert.DeserializeObject<GetMovieDto>(movieJsonString));
                        }
                        else
                        {
                            throw new Exception();
                        }
                    }
                }
            }

            return movies;
        }
        public async Task AddMovieAsync(MovieDto movie)
        {

            var moviedetails = await GetAllAsync();
            var movieIds = moviedetails.Select(s => s.Id).ToList();

            foreach (var movieResult in movie.results)
            {
                if (!movieIds.Contains(movieResult.id))
                {
                    movieIds.Add(movieResult.id);
                    await _movieDetailRepository.AddAsync(_mapper.Map<MovieDetail>(movieResult));
                }
            }
            await _unitOfWork.CommitAsync();
        }
    }
}
