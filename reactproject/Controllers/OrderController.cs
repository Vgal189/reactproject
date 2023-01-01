using MediatR;
using Microsoft.AspNetCore.Mvc;
using reactproject.Commands.Orders;
using reactproject.Repositories;

namespace reactproject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : Controller
    {
        private readonly ILogger<OrderController> _logger;
        private readonly OrderRepository _repository;
        private readonly IMediator _mediator;
        private const string COLLECTION_NAME = "order";

        public OrderController(ILogger<OrderController> logger, IMediator mediator, OrderRepository orderRepository)
        {

            _logger = logger;
            _mediator = mediator;
            _repository = orderRepository;
        }

        [HttpGet]
        [Route("/api/order")]
        public async Task<IActionResult> GetOrders()
        {
            var documents = await _repository.GetAllOrdersAsync();

            if (documents == null || documents.Count == 0)
                return NoContent();

            return Ok(documents);
        }

        [HttpGet]
        [Route("/api/order/{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            var documents = await _repository.GetByIdAsync(COLLECTION_NAME, id);

            return Ok(documents);
        }

        [HttpPost]
        [Route("/api/order")]
        public async Task<IActionResult> Create([FromBody] AddOrderRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpDelete]
        [Route("/api/order/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _mediator.Send(new DeleteOrderRequest(id));

            return Ok(response);
        }
    }
}