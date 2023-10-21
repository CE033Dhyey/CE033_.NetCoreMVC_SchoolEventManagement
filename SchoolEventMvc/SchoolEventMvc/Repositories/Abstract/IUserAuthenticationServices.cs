
using SchoolEventMvc.Models.Domain.DTO;
using SchoolEventMvc.Models.Domain.DTO.SchoolEventMvc.Models.DTO;
using SchoolEventMvc.Models.DTO;

namespace SchoolEventMvc.Repositories.Abstract
{
    public interface IUserAuthenticationServices
    {
        Task<Status> LoginAsync(LoginModel model);
        Task LogoutAsync();
        Task<Status> RegisterAsync(RegistrationModel model);
      //  Task<Status> ChangePasswordAsync(ChangePasswordModel model, string)
    }
}
