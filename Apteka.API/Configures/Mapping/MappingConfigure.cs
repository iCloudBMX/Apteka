using Apteka.API.Dtos;
using Apteka.API.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apteka.API.Configures.Mapping
{
    public class MappingConfigure : Profile
    {
        public MappingConfigure()
        {
            CreateMap<Dori, DoriDto>().ReverseMap();
            CreateMap<Dori, DoriForCreationDto>().ReverseMap();

            CreateMap<ApiUser, UserDto>().ReverseMap();

            CreateMap<DoriFirma, FirmaDto>().ReverseMap();
            CreateMap<DoriFirma, FirmaForCreationDto>().ReverseMap();
        }
    }
}
