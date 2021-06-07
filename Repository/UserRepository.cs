using System.Collections.Generic;
using System.Linq;
using FoodDelivery.Core;
using FoodDelivery.Dtos;
using FoodDelivery.Models;

namespace FoodDelivery.Repository
{
	public class UserRepository : Repository<User>, IUserRepository
	{

		public readonly Context _context;

		public UserRepository(Context context)
		{
			_context = context;	
		}

        public User Authenticate(AuthenticateRequest model)
        {
			User user = _context.Users.FirstOrDefault(x => x.UserName == model.UserName && x.Password == model.Password);
			return user;
        }

        public IEnumerable<User> GetAllUsers()
        {
			return _context.Users.ToList();			
        }

        public User GetUserById(int id)
        {
			return _context.Users.Where(x => x.Id == id).FirstOrDefault();
        }

        public User GetUserWithRegistrationToken(string token)
        {
            throw new System.NotImplementedException();
        }
    }
}
