﻿using Flashcards.Domain.Exceptions;
using Flashcards.Domain.Interfaces;
using Flashcards.Domain.Models;
using Flashcards.Domain.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Flashcards.Service.DataServices
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly AuthenticationSettings _authenticationSettings;

        public AccountService(IPasswordHasher<User> passwordHasher, IAccountRepository accountRepository, AuthenticationSettings authenticationSettings)
        {
            _accountRepository = accountRepository;
            _passwordHasher = passwordHasher;
            _authenticationSettings = authenticationSettings;
        }

        public async Task<User> Register(User entity)
        {
            return await _accountRepository.Register(entity);
        }

        public string GenerateJwt(User entity)
        {
            var user = _accountRepository.GetUserByEmail(entity.Email);

            if (user is null)
            {
                throw new BadRequestException("Invalid e-mail or password");
            }

            var result = _passwordHasher.VerifyHashedPassword(user, user.Password, entity.Password);

            if (result == PasswordVerificationResult.Failed)
            {
                throw new BadRequestException("Invalid e-mail or password");
            }

            var claims = new List<Claim>()
            {
                new Claim("UserId", user.UserId.ToString()),
                new Claim("Name", user.Name.ToString()),
                new Claim("E-mail", user.Email.ToString()),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(_authenticationSettings.JwtExpireDays);

            var token = new JwtSecurityToken(_authenticationSettings.JwtIssuer,
                _authenticationSettings.JwtIssuer,
                claims,
                expires,
                signingCredentials: cred);

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }
    }
}
