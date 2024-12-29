using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolt.Core.DTOs;
using Wolt.Core.Models;

namespace Wolt.Core
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<Orders,OrderDto>().ReverseMap();
            CreateMap<Customer, CustomerGetDto>().ReverseMap();
            CreateMap<Orders,OrderGetDto>().ReverseMap();
            CreateMap<Supply_company, Supply_CompanyDto>().ReverseMap();
            CreateMap<Supply_CompanyGetDto,Supply_company>().ReverseMap();
        }
    }
}
