using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using BOL;
using BOL.Dto;

namespace API.App_Start
{
    public class MappingProfile: AutoMapper.Profile
    {
        public MappingProfile()
        {
            //var config = new MapperConfiguration(cfg => {
            //    cfg.CreateMap<User, UserDto>();
            //});

            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<User, LoginDto>();
            CreateMap<LoginDto, User>();
            CreateMap<User, RegistrationDto>();
            CreateMap<RegistrationDto, User>();

        }
    }
}