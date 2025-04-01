using AutoMapper;
using CookCraft.Domain.Dtos;
using CookCraft.Repositories.Entities;
using CookCraft.Repositories.Interfaces;
using CookCraft.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace CookCraft.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IConfiguration _config;


        public UserService(IUserRepository userRepository, IConfiguration config, IMapper mapper, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _config = config;
            _mapper = mapper;
            _roleRepository = roleRepository;
        }

        public async Task<User> Login(string email, string password)
        {
            var user = await _userRepository.FindUser(email);
            var passwordHashed = HashPassword(password, user.Salt);
            if (user != null && user.PasswordHash == passwordHashed)
                return user;

            return null;
        }

        public async Task<bool> EmailExist(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email cannot be null or empty.", nameof(email));

            return await _userRepository.EmailExist(email);
        }

        public async Task<bool> SignUp(UserSignUpDto userDto)
        {
            // Validacija podataka
            if (!userDto.Email.Contains("@"))
                throw new ArgumentException("Invalid email format.");

            if (userDto.Password.Length < 8 ||
                !userDto.Password.Any(char.IsUpper) ||
                !userDto.Password.Any(char.IsDigit))
            {
                throw new ArgumentException("Password must be at least 8 characters long, contain an uppercase letter, and a digit.");
            }

            if (await _userRepository.EmailExist(userDto.Email))
                throw new InvalidOperationException("Email already exists.");

            // Generisanje Salt-a i hashovanje lozinke
            var salt = GenerateSalt();
            var passwordHash = HashPassword(userDto.Password, salt);

            // Mapiranje DTO-a u entitet koristeći AutoMapper
            var user = _mapper.Map<User>(userDto);
            user.PasswordHash = passwordHash;
            user.Salt = salt;
            user.Id = new Guid();
            var roleUser = await _roleRepository.GetRoleByNameAsync("User");
            user.RoleId = roleUser.Id;
            await _userRepository.AddUser(user);
            return true;
        }

        private byte[] GenerateSalt()
        {
            var salt = new byte[16]; // Veličina salta (16 bajtova je uobičajeno)
            RandomNumberGenerator.Fill(salt); // Generiše sigurne nasumične bajtove
            return salt;
        }


        private string HashPassword(string password, byte[] salt)
        {
            using (var hmac = new HMACSHA256(salt))
            {
                var passwordBytes = Encoding.UTF8.GetBytes(password);
                var hash = hmac.ComputeHash(passwordBytes);
                return Convert.ToBase64String(hash);
            }
        }

        public string GenerateJwtToken(Guid id)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, id.ToString()),
                new Claim(JwtRegisteredClaimNames.Aud, _config["Jwt:Audience"]),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: null,
                claims: claims,
                expires: DateTime.Now.AddHours(5),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

