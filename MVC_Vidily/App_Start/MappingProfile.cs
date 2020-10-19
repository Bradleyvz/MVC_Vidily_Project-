using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//Add Auto Mapper Namespace 
using AutoMapper;
using MVC_Vidily.DTO;
using MVC_Vidily.Models;

namespace MVC_Vidily.App_Start
{
    public class MappingProfile:Profile
    {   
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDTO>();
            Mapper.CreateMap<CustomerDTO, Customer>();

            //Mapper from Movie Class to MovieDTO
            Mapper.CreateMap<Movie, MovieDTO>();
            Mapper.CreateMap<MovieDTO, Movie>();
            // Dto to Domain
            Mapper.CreateMap<CustomerDTO, Customer>()
                .ForMember(c => c.Id, opt => opt.Ignore());

            Mapper.CreateMap<MovieDTO, Movie>()
                .ForMember(c => c.Id, opt => opt.Ignore());
        }

    }
}