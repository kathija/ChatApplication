namespace JwtTokenAuthenticationManager.Repository;

using WebRTCChat.Common.Data;
using WebRTCChat.Model;

public class UserRepository : IUserRepository
{
    private DataContext _context;

    public UserRepository(
        DataContext context)
    {
        _context = context;
    }

    public IEnumerable<User> GetAll()
    {
        return _context.User;
    }

    public IEnumerable<User> GetById()
    {
        return _context.User;
    }

}