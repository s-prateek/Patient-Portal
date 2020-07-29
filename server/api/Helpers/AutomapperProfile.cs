using api.Models;
using AutoMapper;
using iMedOneDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Helpers
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Patient, TBLPATIENT>().ReverseMap();

            CreateMap<City, Tblcity>().ReverseMap();

            CreateMap<State, Tblstate>().ReverseMap();
        }
    }
}
