using AutoMapper;
using Bai4_1721030651_VuDinhLam.Models;

namespace Bai4_1721030651_VuDinhLam.Services
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<Account, AccountDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
        }
    }
}
