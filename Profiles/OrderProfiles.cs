using AutoMapper;
using FoodDelivery.Dtos;
using FoodDelivery.Models;

namespace FoodDelivery.Profiles
{
	public class OrdersProfile : Profile
	{
		public OrdersProfile()
		{
			CreateMap<Order,CreateOrderDto>();
			CreateMap<CreateOrderDto, Order>();
			CreateMap<ReadOrderDto, Order>();
			CreateMap<Order, ReadOrderDto>();
			CreateMap<Order, UpdateOrderDto>();
			CreateMap<UpdateOrderDto, Order>();
		}
	}
}
