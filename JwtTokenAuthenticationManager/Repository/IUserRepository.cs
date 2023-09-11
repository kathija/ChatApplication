using WebRTCChat.Model;

namespace JwtTokenAuthenticationManager.Repository;


public interface IUserRepository
{
    IEnumerable<User> GetAll();

}

