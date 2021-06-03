using System.Collections.Generic;
using AutoMapper;
using FoodDelivery.Data;
using FoodDelivery.Dtos;
using FoodDelivery.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace FoodDelivery.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class OrdersController : ControllerBase
	{
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrdersController(IOrderService orderService, IMapper mapper)
		{
			_orderService = orderService;
			_mapper = mapper;
		}

		//POST orders/post
		[Authorize("Dispatcher")]
		[HttpPost("post")]
		public ActionResult CreateOrder(CreateOrderDto createOrderDto)
		{
			var orderModel = _mapper.Map<Order>(createOrderDto);
			_orderService.CreateOrder(orderModel);
			_orderService.SaveChanges();

			return Ok();
		}

		// GET orders
		[HttpGet]
		public ActionResult<IEnumerable<ReadOrderDto>> GetAll()
		{
			var orderItems = _orderService.GetAll();

			return Ok(_mapper.Map<IEnumerable<ReadOrderDto>>(orderItems));
		}

		//GET orders/{id}
		[HttpGet("{id}", Name="GetOrdersById")]
		public ActionResult<ReadOrderDto> GetOrdersById(int id)
		{
			var orderItem = _orderService.GetOrdersById(id);
			if(orderItem != null)
			{
				return Ok(_mapper.Map<ReadOrderDto>(orderItem));
			}
			return NotFound();
		}

		//DELETE /orders/{id}
		[HttpDelete("{id}")]
		public ActionResult DeleteOrder(int id)
		{
			var orderModelFromRepo = _orderService.GetOrdersById(id);
			if(orderModelFromRepo == null)
			{
				return NotFound();
			}
			_orderService.DeleteOrder(orderModelFromRepo);
			_orderService.SaveChanges();

			return NoContent();
		}

		//PUT orders/{id}
		[HttpPut("{id}")]
		public ActionResult UpdateOrder(int id, CreateOrderDto createOrderDto)
		{
			var orderModelFromRepo = _orderService.GetOrdersById(id);
			if(orderModelFromRepo == null)
			{
				return NotFound();
			}
			_mapper.Map(createOrderDto,orderModelFromRepo);

			_orderService.UpdateOrder(orderModelFromRepo); // ovo zapravo ne radi nista, jer ovaj mapping gore odradi to za mene, tako da ovo mozemo i da skinemo ili da implementiram UpdateUser u UserService.cs

			_orderService.SaveChanges();

			return NoContent();
		}

		//PATCH orders/{id}
		[HttpPatch("{id}")]
		public ActionResult PartialOrderUpdate(int id, JsonPatchDocument<CreateOrderDto> patchDoc)
		{
			var orderModelFromRepo = _orderService.GetOrdersById(id);
			if(orderModelFromRepo == null)
			{
				return NotFound();
			}

			var orderToPatch = _mapper.Map<CreateOrderDto>(orderModelFromRepo);
			patchDoc.ApplyTo(orderToPatch, ModelState);

			if(!TryValidateModel(orderToPatch))
			{
				return ValidationProblem(ModelState);
			}

			_mapper.Map(orderToPatch, orderModelFromRepo);

			_orderService.UpdateOrder(orderModelFromRepo);
			_orderService.SaveChanges();

			return NoContent();
		}
	}
}
