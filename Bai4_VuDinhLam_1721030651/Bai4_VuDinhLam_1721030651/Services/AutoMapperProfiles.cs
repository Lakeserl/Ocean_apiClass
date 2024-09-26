using AutoMapper;
using Bai4_VuDinhLam_1721030651.Models;


namespace Bai4_VuDinhLam_1721030651.Services
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles() {
            CreateMap<Address, AddressDTO>().ReverseMap();
            CreateMap<Shippers, ShippersDTO>().ReverseMap(); 
            CreateMap<Supplier, SupplierDTO>().ReverseMap();
        }
    }
}
