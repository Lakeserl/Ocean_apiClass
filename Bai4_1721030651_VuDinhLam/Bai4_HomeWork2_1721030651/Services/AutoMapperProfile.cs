using AutoMapper;
using Bai4_HomeWork2_1721030651.Models;
//using ControllerAPI_1721030861.Database.Models.Bai2;

namespace Bai4_HomeWork2_1721030651.Services
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            CreateMap<Country, CountryDTO>().ReverseMap();
            CreateMap<District, DistrictDTO>().ReverseMap();
            CreateMap<Province, ProvinceDTO>().ReverseMap();
            CreateMap<Ward, WardDTO>().ReverseMap();
            CreateMap<Bank, BankDTO>().ReverseMap();
            CreateMap<BankType, BankTypeDTO>().ReverseMap();
            CreateMap<Folk, FolkDTO>().ReverseMap();
            CreateMap<Religion, ReligionDTO>().ReverseMap();
            CreateMap<School, SchoolDTO>().ReverseMap();
        }
    }
}
