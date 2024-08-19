using AROUNDUS.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace AROUNDUS.Repositories
{
    public interface IAccountRepository
    {
        public Task<IdentityResult> SignUpAsync(SignUpVM signUpVM);
        public Task<string> LoginAsync(LoginVM loginVM);
    }
}
