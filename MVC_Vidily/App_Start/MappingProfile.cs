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
        }
    }
}