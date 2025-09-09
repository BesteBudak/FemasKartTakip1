using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Entities.Dtos;
using Entities.Models;

namespace Business
{
   
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.UserName,
                           opt => opt.MapFrom(src => $"{src.Name} {src.Surname}"));
        }
    }

}
