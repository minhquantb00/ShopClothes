using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ShopClothes.Application.ResponseModels;
using ShopClothes.Domain.Entities;
using ShopClothes.Domain.InterfaceRepositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BcryptNet = BCrypt.Net.BCrypt;

namespace ShopClothes.Application.UseCases.Implements.User_UseCase.LoginUser
{
    public class LoginUserUseCase : IUseCase<LoginUserUseCaseInput, LoginUserUseCaseOutput>
    {
        private readonly IRepository<User> _repository;
        private readonly IConfiguration _configuration;
        private readonly IRepository<UserRole> _basePermissionRepository;
        private readonly IRepository<Role> _baseRoleRepository;
        private readonly IRepository<RefreshToken> _baseRefreshTokenRepository;
        public LoginUserUseCase(IRepository<User> repository, IConfiguration configuration, IRepository<UserRole> basePermissionRepository, IRepository<Role> baseRoleRepository, IRepository<RefreshToken> baseRefreshTokenRepository)
        {
            _repository = repository;
            _configuration = configuration;
            _basePermissionRepository = basePermissionRepository;
            _baseRoleRepository = baseRoleRepository;
            _baseRefreshTokenRepository = baseRefreshTokenRepository;
        }

        public async Task<LoginUserUseCaseOutput> ExcuteAsync(LoginUserUseCaseInput input)
        {
            var resultOuput = new LoginUserUseCaseOutput
            {
                Succeeded = false
            };
            try
            {
                var user = await _repository.GetUserByUsername(input.UserName);
                if(user == null)
                {
                    resultOuput.Errors = new string[] { "Tài khoản không tồn tại trên hệ thống" };
                    return resultOuput;
                }
                var checkPassword = BcryptNet.Verify(input.Password, user.Password);
                if (!checkPassword)
                {
                    resultOuput.Errors = new string[] { "Mật khẩu không chính xác" };
                    return resultOuput;
                }
                if (user.UserStatus.ToString().Equals("UnActivated"))
                {
                    resultOuput.Errors = new string[] { "Tài khoản của người dùng chưa được kích hoạt" };
                    return resultOuput;
                }
                return new LoginUserUseCaseOutput
                {
                    Succeeded = true,
                    Data = new DataResponseLogin
                    {
                        AccessToken = GetJwtTokenAsync(user).Result.AccessToken,
                        RefreshToken = GetJwtTokenAsync(user).Result.RefreshToken
                    }
                };
            }catch(Exception ex)
            {
                resultOuput.Succeeded = false;
                resultOuput.Errors = new string[] { ex.Message };
                return resultOuput;
            }
        }





        #region Handle Token
        private async Task<DataResponseLogin> GetJwtTokenAsync(User user)
        {
            var permissions = await _basePermissionRepository.GetAllAsync(x => x.UserId == user.Id);
            var roles = await _baseRoleRepository.GetAllAsync();

            var authClaims = new List<Claim>
            {
                new Claim("Id", user.Id.ToString()),
                new Claim("UserName", user.UserName),
                new Claim("Email", user.Email),
                new Claim("FullName", user.FullName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            foreach (var permission in permissions)
            {
                foreach (var role in roles)
                {
                    if (role.Id == permission.RoleId)
                    {
                        authClaims.Add(new Claim("Permission", role.RoleName));
                    }
                }
            }

            var userRoles = await _repository.GetRolesOfUserAsync(user);
            foreach (var role in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, role));
            }

            var jwtToken = GetToken(authClaims);
            var refreshToken = GenerateRefreshToken();
            _ = int.TryParse(_configuration["JWT:RefreshTokenValidity"], out int refreshTokenValidity);

            RefreshToken rf = new RefreshToken
            {
                UserId = user.Id,
                ExpiryTime = DateTime.UtcNow.AddHours(refreshTokenValidity),
                Token = refreshToken
            };

            rf = await _baseRefreshTokenRepository.CreateAsync(rf);

            return new DataResponseLogin 
            { 
                    AccessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken),
                    RefreshToken = refreshToken,
            };
        }
        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            _ = int.TryParse(_configuration["JWT:TokenValidityInMinutes"], out int tokenValidityInMinutes);
            var expirationTimeUtc = DateTime.UtcNow.AddHours(tokenValidityInMinutes);
            var localTimeZone = TimeZoneInfo.Local;
            var expirationTimeInLocalTimeZone = TimeZoneInfo.ConvertTimeFromUtc(expirationTimeUtc, localTimeZone);

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: expirationTimeInLocalTimeZone,
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }
        private string GenerateRefreshToken()
        {
            var randomNumber = new Byte[64];
            var range = RandomNumberGenerator.Create();
            range.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        public Task<LoginUserUseCaseOutput> ExcuteAsync(int? id, LoginUserUseCaseInput input)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}