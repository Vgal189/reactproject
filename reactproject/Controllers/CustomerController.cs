using MediatR;
using Microsoft.AspNetCore.Mvc;
using reactproject.Application.Commands.Customer;
using reactproject.Domain.AggregatesModel.Customer;
using reactproject.Repositories;

namespace reactproject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : Controller
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly Repository<CustomerInfo> _repository;
        private readonly IMediator _mediator;
        private const string COLLECTION_NAME = "customer";

        public CustomerController(ILogger<CustomerController> logger, Repository<CustomerInfo> repository, IMediator mediator)
        {

            _logger = logger;
            _repository = repository;
            _mediator = mediator;
        }

        [HttpGet]
        [Route("/api/customer")]
        public async Task<IActionResult> Get()
        {
            var documents = await _repository.GetAllAsync(COLLECTION_NAME);
            
            if (documents == null || documents.Count == 0)
                return NoContent();

            return Ok(documents);
        }

        [HttpGet]
        [Route("/api/customer/{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            var documents = await _repository.GetByIdAsync(COLLECTION_NAME, id);

            return Ok(documents);
        }

        [HttpPost]
        [Route("/api/customer")]
        public async Task<IActionResult> Create([FromBody] AddCustomerInfoRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpDelete]
        [Route("/api/customer/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _mediator.Send(new DeleteCustomerInfoRequest(id));

            return Ok(response);
        }
    }
}
