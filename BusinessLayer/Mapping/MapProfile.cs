using AutoMapper;
using EntityLayer.DTOs;
using EntityLayer.Models;
using MovieRecommendation.EntityLayer.DTOs;
using MovieRecommendation.EntityLayer.DTOs.UserDto;
using MovieRecommendation.EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {

            CreateMap<MovieDetail, MovieDetailDto>()
                .ForMember(x => x.id, y => y.MapFrom(l => l.Id))
                .ForMember(x => x.original_language, y => y.MapFrom(l => l.OriginalLanguage))
                .ForMember(x => x.overview, y => y.MapFrom(l => l.Overview))
                .ForMember(x => x.release_date, y => y.MapFrom(l => l.ReleaseDate))
                .ForMember(x => x.title, y => y.MapFrom(l => l.Title))
                .ForMember(x => x.vote_average, y => y.MapFrom(l => l.VoteAverage)).ReverseMap();

            CreateMap<MovieDetail, MovieDetailAndScoreDto>()
                .ForMember(x => x.original_language, y => y.MapFrom(l => l.OriginalLanguage))
                .ForMember(x => x.overview, y => y.MapFrom(l => l.Overview))
                .ForMember(x => x.release_date, y => y.MapFrom(l => l.ReleaseDate))
                .ForMember(x => x.title, y => y.MapFrom(l => l.Title))
                .ForMember(x => x.vote_average, y => y.MapFrom(l => l.VoteAverage)).ReverseMap();
                
            CreateMap<GetMovieDto, MovieDto>().ReverseMap();
            CreateMap<MovieScore, AddMovieScoreDto>().ReverseMap();
            CreateMap<User, UserLoginDto>().ReverseMap();
            CreateMap<User, UserCreateDto>().ReverseMap();

        }
    }
}
