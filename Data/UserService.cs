using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using FoodDelivery.Dtos;
using FoodDelivery.Helpers;
using FoodDelivery.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace FoodDelivery.Data
{
    public class UserService : IUserService
	{
        private readonly AppSettings _appSettings;
        private readonly UserContext _context;

		public UserService(IOptions<AppSettings> appSettings, UserContext context)
		{
			_appSettings = appSettings.Value;
			_context = context;
		}
        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
			var user = _context.Users.FirstOrDefault(x => x.UserName == model.UserName && x.Password == model.Password);
			if(user == null) return null;

			var token = generateJwtToken(user);

			return new AuthenticateResponse(user, token);
        }

        public IEnumerable<User> GetAll()
        {
			return _context.Users.ToList();
		}

        public User GetById(int id)
        {
			return _context.Users.FirstOrDefault(x => x.Id == id);
        }

        public void SignInUser(User user)
        {
			if(user == null)
			{
				throw new ArgumentNullException(nameof(user));
			}

			_context.Users.Add(user);
        }

		private string generateJwtToken(User user)
		{
			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString())}),
				Expires = DateTime.UtcNow.AddDays(7),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};
			var token = tokenHandler.CreateToken(tokenDescriptor);
			return tokenHandler.WriteToken(token);
		}

        public bool SaveChanges()
        {
			return (_context.SaveChanges() >= 0);
        }

        public void UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(User user)
        {
			if(user == null)
			{
				throw new ArgumentNullException(nameof(user));
			}
			_context.Users.Remove(user);
        }
    }
}
