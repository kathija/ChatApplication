namespace UserManagementWebApi.Helpers;

using AutoMapper;
using UserManagementWebApi.Model;
using WebRTCChat.Model;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {

        // RegisterRequest -> User
        CreateMap<UpdateRequest, User>();

    }
}