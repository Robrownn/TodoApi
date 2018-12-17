﻿using AutoMapper;
using TodoAPI.Dtos;
using TodoAPI.Entities;

namespace TodoAPI.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}
