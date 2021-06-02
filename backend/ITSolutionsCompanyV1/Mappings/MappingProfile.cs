using AutoMapper;
using ITSolutionsCompanyV1.Models;
using ITSolutionsCompanyV1.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITSolutionsCompanyV1.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<Project, ProjectDto>()
                //.ForMember(R => R.Request,opt => opt.UseDestinationValue())
                .ForMember(p => p.Request, opt => opt.Ignore());
            CreateMap<Request, RequestDto>();
        }
    }
}


//*

