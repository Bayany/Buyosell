using AutoMapper;
using Buyosell.Api.Resources;
using Buyosell.Api.Resources.Categories;
using Buyosell.Core.Models;

namespace Buyosell.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CarAdResource, Ad>();
            CreateMap<ClothesAdResource, Ad>();
            CreateMap<RealStateAdResource, Ad>();
            CreateMap<UserResource, User>();
        }
    }
}