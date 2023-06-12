namespace TestApi.Helpers;

using AutoMapper;
using TestApi.Models;
using TestApi.Models.Prefix;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        // CreateRequest -> TbJobprefix
        CreateMap<CreateRequest, TbJobprefix>();
    }
}