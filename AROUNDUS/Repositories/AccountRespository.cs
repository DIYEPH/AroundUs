using AROUNDUS.Models;
using AROUNDUS.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AROUNDUS.Repositories
{
    public class AccountRespository(UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration configuration) : IAccountRepository
    {
        public async Task<string> LoginAsync(LoginVM loginVM)
        {
            var result = await signInManager.PasswordSignInAsync(loginVM.Email, loginVM.Password, true, false);
            if (!result.Succeeded)
                return string.Empty;
            var authClaims = new List<Claim>
            {
                new (ClaimTypes.Email , loginVM.Email),
                new (JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };
            var secret = configuration["JWT:Secret"];
            if (string.IsNullOrEmpty(secret))
            {
                throw new InvalidOperationException("JWT:Secret configuration value is missing.");
            }
            var authenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var token = new JwtSecurityToken(
                issuer: configuration["JWT:ValidIssuer"],
                audience: configuration["ValidAudience"],
                expires: DateTime.UtcNow.AddMinutes(20),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authenKey, SecurityAlgorithms.HmacSha256Signature)
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<IdentityResult> SignUpAsync(SignUpVM signUpVM)
        {
            var user = new User
            {
                Email = signUpVM.Email,
                UserName = signUpVM.Email,
                LastName = signUpVM.LastName,
                MiddleName = signUpVM.MiddleName,
            };
            return await userManager.CreateAsync(user, signUpVM.Password);
        }
    }
}
