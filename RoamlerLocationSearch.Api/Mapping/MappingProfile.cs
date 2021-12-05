using AutoMapper;
using RoamlerLocationSearch.Core.Models;
using RoamlerLocationSearch.Services.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoamlerLocationSearch.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Resource
            CreateMap<Location, LocationDomain>();

            // Domain to Resource
            CreateMap<LocationDomain, Location>();
        }
    }
}
