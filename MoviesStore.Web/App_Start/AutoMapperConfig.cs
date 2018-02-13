using AutoMapper;
using MoviesStore.Web.Models;
using MoviesStore.Web.Service.Facade.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoviesStore.Web
{
    public class AutoMapperConfig
    {
        public static void AutoMapperConfiguration()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<MovieViewModel, MovieDTO>().ReverseMap();
                cfg.CreateMap<ProducerViewModel, ProducerDTO>().ReverseMap();
                cfg.CreateMap<ActorViewModel, ActorDTO>().ReverseMap();
                cfg.CreateMap<YearViewModel, YearDTO>().ReverseMap();

            });
        }
    }
}