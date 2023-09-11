using JwtTokenAuthenticationManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebRTCChat.Model;

namespace JwtTokenAuthenticationManager
{
    public interface IJwtTokenHandler
    {
        public AuthenticationResponse GenerateToken(User user);
    }
}
