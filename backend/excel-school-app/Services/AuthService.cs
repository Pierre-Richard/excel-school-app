using System;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using excel_school_app.Data;
using excel_school_app.DTOs;
using excel_school_app.Models;
using Microsoft.IdentityModel.Tokens;


namespace excel_school_app.Services
{
    public class AuthService : IAuthService
    {
        //J'inject AppDbContext dans mon construteur 

        private readonly AppDbContext _appDbContext;
        private readonly IConfiguration _configuration;

        public AuthService(AppDbContext appDbContext, IConfiguration configuration)
        {
            _appDbContext = appDbContext;
            _configuration = configuration;
        }

        private string GenerateToken(User user)
        {     
            // 1. Créer les claims
            var claims = new[]
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };

            // 2. Créer la clé de signature
            var key = new SymmetricSecurityKey(
                System.Text.Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // 3. Créer le token
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(24),
                signingCredentials: creds
            );

            // 4. Retourner le token en string
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public AuthResponseDto Login(LoginDto user)

        {
            //Retrouver l'utilisateur par email done
            //Vérifier que l'utilisateur existe done
            //Vérifier le mot de passe avec BCrypt.Verify
            //Générer le token
            //Retourner un AuthResponseDto

            // retrouver l'utilisateur utilisateur par son email
            var existantUser = _appDbContext.User.FirstOrDefault(u => u.Email == user.Email);
            //Vérifier que l'utilisateur existe
            if (existantUser == null)
            {
                throw new Exception("L'utilisateur n'existe pas");
            }

            //Mot de passe provenant de la DB
            var passwordFromDB = existantUser.PasswordHash;
         
            //Vérifier le mot de passe avec BCrypt.Verify
            var verifyPassword = BCrypt.Net.BCrypt.Verify(user.Password,passwordFromDB);

            if (verifyPassword != true)
            {
                throw new Exception("Le password n'existe pas");
            }

            var generateToken = GenerateToken(existantUser);
            
               //Retourner un AuthResponseDto
            var authResponseDto = new AuthResponseDto
            {
                Id = existantUser.Id,
                FirstName = existantUser.FirstName,
                LastName = existantUser.LastName,
                Email = existantUser.Email,
                Role = existantUser.Role,
                Token = generateToken,
            };

            return authResponseDto;

            
        }

        public AuthResponseDto Register(RegisterDto user)


        {
            // retrouver l'utilisateur utilisateur par son email
            var existantUser = _appDbContext.User.FirstOrDefault(u => u.Email == user.Email);
            //Vérifier si l'email existe déjà en BDD
            if (existantUser != null)
            {
                throw new Exception("L'utilisateur existe deja");
            }
            //Hasher le mot de passe avec BCrypt
            var hashPassword = BCrypt.Net.BCrypt.HashPassword(user.Password);

            //Créer un nouvel objet User
            var newUser = new User
            {
                FirstName = user.FirstName,
                LastName = user.LastName,   
                PasswordHash = hashPassword,
                Email = user.Email,
                Role = user.Role,
            };

            _appDbContext.User.Add(newUser);
            //Sauvegarder en BDD
            _appDbContext.SaveChanges();

           //Générer le token JWT
            var generateToken = GenerateToken(newUser); 

            //Retourner un AuthResponseDto
            var authResponseDto = new AuthResponseDto
            {
                Id = newUser.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Role = user.Role,
                Token = generateToken,
            };

            return authResponseDto;

        }
    }




}
