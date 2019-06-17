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
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<Genre, GenreDto>();

            Mapper.CreateMap<MovieAccessRecordDto, MovieAccessRecord>();
            Mapper.CreateMap<MovieAccessRecord,MovieAccessRecordDto>();

            Mapper.CreateMap<CustomerDto, Customer>().ForMember(c=>c.Id, opt=>opt.Ignore());
            Mapper.CreateMap<MovieDto, Movie>().ForMember(c => c.Id, opt => opt.Ignore());

        }
    }
}