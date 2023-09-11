namespace UserManagementWebApi.Repository;

using AutoMapper;
using WebRTCChat.Model;
using BCrypt.Net;
using UserManagementWebApi.Model;

public interface IUserRepository
{
    void Update(UpdateRequest model);
    User GetById(int id);

    IEnumerable<User> GetAll();

}

