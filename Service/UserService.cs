using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using FoodDelivery.Configuration;
using FoodDelivery.Dtos;
using FoodDelivery.Helpers;
using FoodDelivery.Models;
using FoodDelivery.Repository;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace FoodDelivery.Service
{
    public class UserService
	{
        private readonly AppSettings _appSettings;
        private readonly Context _context;

		public UserService(ProjectConfiguration configuration)
		{
		}

		public UserService(){  }

		public User Add(User user)
		{
			if(user == null)
			{
				return null;
			}
			try
			{
				using (var unitOfWork = new UnitOfWork(new Context()))
				{
					unitOfWork.Users.Add(user);
					unitOfWork.Complete();
				}
			}
			catch(Exception e)
			{
				return null;
			}
			return user;
		}
		public AuthenticateResponse Authenticate(AuthenticateRequest model)
		{
			if(model == null)
			{
				return null;
			}
			try
			{
				using (var unitOfWork = new UnitOfWork(new Context()))
				{
					var user = unitOfWork.Users.Authenticate(model);
					if (user == null)
					{
						return null;
					}
					var token = generateJwtToken(user);

					return new AuthenticateResponse(user,token);
				}
			}
			catch(Exception e)
			{
				return null;
			}

		}

		public User GetById(int id)
		{
			try
			{
				using(var unitOfWork = new UnitOfWork(new Context()))
				{
					var user = unitOfWork.Users.GetUserById(id);
					if (user == null)
					{
						return null;
					}
					return user;
				}
			}
			catch(Exception e)
			{
				return null;
			}
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

        // public IEnumerable<User> GetAll()
        // {
			// return _context.Users.ToList();
		// }

        // public User GetById(int id)
        // {
			// return _context.Users.FirstOrDefault(x => x.Id == id);
        // }

        // public void SignInUser(User user)
        // {
			// if(user == null)
			// {
				// throw new ArgumentNullException(nameof(user));
			// }

			// _context.Users.Add(user);
        // }


        // public bool SaveChanges()
        // {
			// return (_context.SaveChanges() >= 0);
        // }

        // public void UpdateUser(User user)
        // {
			// //Nothing
        // }

        // public void DeleteUser(User user)
        // {
			// if(user == null)
			// {
				// throw new ArgumentNullException(nameof(user));
			// }
			// _context.Users.Remove(user);
        // }
    // }
// }
