using Application.Features.Orders.Commands.CreateOrderCommand;
using Application.Features.Orders.Commands.UpdateOrderCommand;
using Application.Features.Orders.Commands.UpdateOrderStatusCommand;
using Application.Features.Orders.Queries.GetAllOrders;
using Application.Features.Orders.Queries.GetOrderById;
using Application.Features.Orders.Queries.GetOrderPdfQuery;
using Application.Features.Payments.Commands.CreatePaymentCommand;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class OrdersController : BaseApiController
    {

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] PaginationOrdersParameters filter)
        {
            return Ok(await Mediator.Send(new GetAllOrdersQuery
            {
                PageNumber = filter.PageNumber,
                PageSize = filter.PageSize,
                Status = filter.Status
            }));
        }


        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetOrderbyIdAsync(Guid id)
        {
            return Ok(await Mediator.Send(new GetOrderByIdQuery { Id = id }));
        }


        [HttpPost]

        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand command)
        {
            return Ok(await Mediator.Send(command));
        }


        [HttpPut]
        public async Task<IActionResult> UpdateOrder([FromBody] UpdateOrderCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut]
        [Route("status")]
        public async Task<IActionResult> UpdateOrderStatus([FromBody] UpdateOrderStatusCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet]
        [Route("pdf")]
        public async Task<IActionResult> DownloadOrderPdf(Guid id)
        {
            var pdf = await Mediator.Send(new GetOrderPdfQuery { Id = id });

            return File(pdf, "application/pdf", $"order_{id}.pdf");
        }
    }


}
