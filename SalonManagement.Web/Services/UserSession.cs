using SalonManagement.Application.Dtos;

namespace SalonManagement.Web.Services
{
    public class UserSession
    {
        public UserDto? CurrentUser { get; set; }

        public bool IsLoggedIn => CurrentUser != null;
    }
}
