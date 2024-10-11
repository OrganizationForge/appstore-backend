using Application.Features.Orders.Commands.CreateOrderCommand;
using Application.Features.Orders.Commands.UpdateOrderCommand;
using Application.Features.Orders.Queries.GetAllOrders;
using Application.Features.Orders.Queries.GetOrderById;
using Application.Features.Payments.Commands.CreatePaymentCommand;
using Application.Features.Products.Queries.GetAllProducts;
using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class CheckoutController : BaseApiController
    {

        [HttpPost]
        [Route("Payments")]
        public async Task<IActionResult> CreatePayment([FromBody] CreatePaymentCommand command)
        {
            return Ok(await Mediator.Send(command));
        }


        //[HttpGet("Orders")]
        //public async Task<IActionResult> GetOrdersAsync(Guid id)
        //{
        //    return Ok(await Mediator.Send(new GetOrderByIdQuery { Id = id }));
        //}

        [HttpGet("Orders")]
        public async Task<IActionResult> GetAllAsync([FromQuery] PaginationOrdersParameters filter)
        {
            return Ok(await Mediator.Send(new GetAllOrdersQuery
            {
                PageNumber = filter.PageNumber,
                PageSize = filter.PageSize,
                Status = filter.Status
            }));
        }


        [HttpGet("Orders/{id:Guid}")]
        public async Task<IActionResult> GetOrderbyIdAsync(Guid id)
        {
            return Ok(await Mediator.Send(new GetOrderByIdQuery { Id = id }));
        }


        [HttpPost]
        [Route("Orders")]

        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand command)
        {
            return Ok(await Mediator.Send(command));
        }


        [HttpPut]
        [Route("Orders")]
        public async Task<IActionResult> UpdateOrder([FromBody] UpdateOrderCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }


}
