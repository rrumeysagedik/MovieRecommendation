using AutoMapper;
using BusinessLayer.Services;
using EntityLayer.Models;
using EntityLayer.Repositories;
using EntityLayer.UnitOfWorks;
using MovieRecommendation.EntityLayer.DTOs;
using MovieRecommendation.EntityLayer.Models;
using MovieRecommendation.EntityLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendation.BusinessLayer.Services
{
    public class MovieScoreService : Service<MovieScore>, IMovieScoreService
    {
        private readonly IGenericRepository<MovieScore> _movieScoreRepository;
        private readonly IGenericRepository<MovieDetail> _movieDetailRepository;
        private readonly IGenericRepository<User> _userRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public MovieScoreService(IGenericRepository<MovieScore> movieScoreRepository,
            IGenericRepository<MovieDetail> movieDetailRepository, IUnitOfWork unitOfWork,
            IMapper mapper, IGenericRepository<User> userRepository) : base(movieScoreRepository, unitOfWork)
        {
            _movieScoreRepository = movieScoreRepository;
            _movieDetailRepository = movieDetailRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }

        public async Task AddMovieScore(AddMovieScoreDto addMovieScoreDto)
        {
            var movieDetay = _movieDetailRepository.Where(x => x.MovieDetailId == addMovieScoreDto.Id).FirstOrDefault();
            var user = _userRepository.Where(u => u.Id == addMovieScoreDto.UserId).FirstOrDefault();
            if (user != null)
            {
                if (movieDetay != null)
                {
                    MovieScore movieScore = new MovieScore
                    {
                        MovieDetailId = addMovieScoreDto.Id,
                        Note = $"{addMovieScoreDto.Note}",
                        Score = addMovieScoreDto.Score,
                        UserId = addMovieScoreDto.UserId,
                    };
                    await _movieScoreRepository.AddAsync(movieScore);
                    await _unitOfWork.CommitAsync();
                }
                else
                    throw new Exception("Böyle bir film bulunmamaktadır.");
            }
            else
                throw new Exception("Böyle bir kullanıcı bulunmamaktadır.");

        }
    }
}
