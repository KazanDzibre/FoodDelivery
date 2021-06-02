using AutoMapper;
using FoodDelivery.Dtos;
using FoodDelivery.Models;

namespace FoodDelivery.Profiles
{
	public class UsersProfile : Profile
	{
		public UsersProfile()
		{
			CreateMap<User,AuthenticateRequest>();
			CreateMap<AuthenticateRequest,User>();
			CreateMap<User,UserRegisterDto>();
			CreateMap<UserRegisterDto, User>();
			CreateMap<User,UserReadDto>();
			CreateMap<UserReadDto, User>();
		}
	}
}
