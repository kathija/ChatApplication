using Microsoft.EntityFrameworkCore;
using WebRTCChat.Model;

namespace WebRTCChat.Common.Data
{
    public interface IDataContext
    {
        DbSet<User> User { get; set; }

        Task<int> SaveChanges();
    }
}
