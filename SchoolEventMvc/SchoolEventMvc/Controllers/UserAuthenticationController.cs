using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp;
using SchoolEventMvc.Models.Domain.DTO.SchoolEventMvc.Models.DTO;
using SchoolEventMvc.Models.DTO;
using SchoolEventMvc.Repositories.Abstract;
using SchoolEventMvc.Repositories.Implementation;

namespace SchoolEventMvc.Controllers
{
    public class UserAuthenticationController : Controller
    {
        private IUserAuthenticationServices authService;
        public UserAuthenticationController(IUserAuthenticationServices authService)
        {
            this.authService = authService;
        }
       /* public async Task<IActionResult> Register()
        {
            var model = new RegistrationModel
            {
                Email = "dhyey@gmail.com",
                Username = "Dhyey",
                Name = "Dhyey",
                Password = "Dhyey@123",
                PasswordConfirm = "Dhyey@123",
                Role = "User"
            };
            var result = await authService.RegisterAsync(model);
            return Ok(result.Message);

        }*/
        public async Task<IActionResult> Login() 
        {
            return View();
        }
        [HttpPost] 

        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await authService.LoginAsync(model);
            if (result.StatusCode == 1) 
            {
                return RedirectToAction("Index", "Home");
            }
            else 
            {
                TempData["msg"] = "Could not log in..";
                return RedirectToAction(nameof(Login));
            }
           
        }
        public async Task<IActionResult> Logout() 
        {
             await authService.LogoutAsync();
            return RedirectToAction(nameof(Login));
        }

        
    }
}
