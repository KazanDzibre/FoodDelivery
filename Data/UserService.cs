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

        // probna lista pre baze
        private List<User> _users = new List<User>
		{
			new User { Id = 1, FirstName = "test", LastName = "User", UserName = "test", Type = "Admin", longitude = 15, latitude = 15, Password = "test"}
		};	

		public UserService(IOptions<AppSettings> appSettings)
		{
			_appSettings = appSettings.Value;
		}
        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
			var user = _users.SingleOrDefault(x => x.UserName == model.UserName && x.Password == model.Password);
			if(user == null) return null;

			var token = generateJwtToken(user);

			return new AuthenticateResponse(user, token);
        }

        public IEnumerable<User> GetAll()
        {
			return _users;
		}

        public User GetById(int id)
        {
			return _users.FirstOrDefault(x => x.Id == id);
        }

        public void SignInUser(User user)
        {
            throw new System.NotImplementedException();
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
    }
}
