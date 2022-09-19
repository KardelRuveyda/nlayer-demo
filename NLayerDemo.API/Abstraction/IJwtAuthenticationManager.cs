
using NLayerDemo.Core.DTOs.Authentication;

namespace NLayerDemo.API.Abstraction
{
    public interface IJwtAuthenticationManager
    {
        AuthResponseDto Authenticate(string userName, string password);
    }
}
