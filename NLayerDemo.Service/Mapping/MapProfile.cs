using AutoMapper;
using NLayerDemo.Core;
using NLayerDemo.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLayerDemo.Service.Mapping
{
    public  class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<UserDto, User>();
        }
    }
}
