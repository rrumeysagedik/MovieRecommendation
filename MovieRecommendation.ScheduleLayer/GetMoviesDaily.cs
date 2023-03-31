using AutoMapper;
using DataAccessLayer;
using EntityLayer.DTOs;
using EntityLayer.Models;
using EntityLayer.Repositories;
using EntityLayer.Services;
using EntityLayer.UnitOfWorks;
using Newtonsoft.Json;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendation.ScheduleLayer
{
    public class GetMoviesDaily :IJob
    {
        private readonly IMovieDetailService _movieDetailService;
        private readonly IMapper _mapper;
        public GetMoviesDaily(IMovieDetailService movieDetailService, IMapper mapper)
        {
            _movieDetailService = movieDetailService;
            _mapper = mapper;
        }
        public async Task Execute(IJobExecutionContext context)
        {
            var movies = await _movieDetailService.GetMoviesAsync();
            for (int i = 0; i < movies.Count(); i++)
            {
                var movie = movies[i];
                await _movieDetailService.AddMovieAsync(_mapper.Map<MovieDto>(movie));

            }
            await Task.CompletedTask;
        }
    }
}
