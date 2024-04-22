using PresentationLayer.DTOs;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IAuthenticationUserServices
    {
        public Task Register(RegisterDto registerDto);
        public Task ChangePassword(ChangePasswordDto changePasswordDto);
        public Task Login(LoginDto loginDto);
    }
}
