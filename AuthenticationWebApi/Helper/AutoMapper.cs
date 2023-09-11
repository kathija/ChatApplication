namespace AuthenticationWebApi.Helper;

using AuthenticationWebApi.Model;
using AutoMapper;
using WebRTCChat.Model;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {

        // RegisterRequest -> User
        CreateMap<RegisterRequest, User>();

    }
}