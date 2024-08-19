using AROUNDUS.Repositories;
using AROUNDUS.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AROUNDUS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository accountRepo;

        public AccountController(IAccountRepository repo)
        {
            accountRepo = repo;
        }
        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(SignUpVM signUpVM)
        {
            var result = await accountRepo.SignUpAsync(signUpVM);
            if (result.Succeeded)
                return Ok(result);
            return Unauthorized();
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            var result = await accountRepo.LoginAsync(loginVM);
            if (string.IsNullOrEmpty(result))
                return Unauthorized();
            return Ok(result);
        }

    }
}
