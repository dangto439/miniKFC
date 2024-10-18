using Microsoft.IdentityModel.Tokens;
using MiniKFCStore.Models;
using MiniKFCStore.Repositories.Interface;
using MiniKFCStore.Services.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MiniKFCStore.Services.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public UserService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public Task<IEnumerable<User>> GetAllUsersAsync() => _userRepository.GetAllAsync();
        public Task<User> GetUserByIdAsync(Guid id) => _userRepository.GetByIdAsync(id);
        public Task CreateUserAsync(User user) => _userRepository.AddAsync(user);
        public Task UpdateUserAsync(User user) => _userRepository.UpdateAsync(user);
        public Task DeleteUserAsync(Guid id) => _userRepository.SoftDeleteAsync(id);

        public async Task<User> Authenticate(string username, string password)
        {
            var user = await _userRepository.GetByUsername(username);

            // Kiểm tra thông tin đăng nhập
            if (user == null || !VerifyPassword(user.Password, password))
            {
                return null; // Người dùng không hợp lệ
            }

            return user; // Người dùng hợp lệ
        }

        private bool VerifyPassword(string storedPassword, string providedPassword)
        {
            // Kiểm tra mật khẩu (bạn có thể sử dụng mã hóa hoặc băm nếu cần)
            return storedPassword == providedPassword;
        }

        public string GenerateJwtToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Role, user.Role)
        };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
