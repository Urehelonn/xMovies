using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using xMovies.Dto;
using xMovies.Models;

namespace xMovies.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<Movie, MovieDto>();

            Mapper.CreateMap<CustomerDto, Customer>();
            Mapper.CreateMap<MovieDto, Movie>();
        }
    }
}