using AutoMapper;
using Business.Features.Auth.Commands.Register;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Features.Auth.Profiles
{
    public class AuthMappingProfile : Profile   // Auth için mapping  profile ekliyoruz. Profile'dan inherit ediyoruz
    {
        public AuthMappingProfile() 
        {
            CreateMap<User, RegisterCommand>().ReverseMap();    // User ile RegisterCommand arasında mapping oluşturuyoruz
        }
    }
}
