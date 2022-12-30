using MediatR;
using Microsoft.AspNetCore.Mvc;
using reactproject.AggregatesModel.Products;
using reactproject.Commands.Products;
using reactproject.Repositories;

namespace reactproject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly ILogger<CostumerController> _logger;
        private readonly Repository<Product> _repository;
        private readonly IMediator _mediator;
        private const string COLLECTION_NAME = "product";

        public ProductController(ILogger<CostumerController> logger, Repository<Product> repository, IMediator mediator)
        {
            _logger = logger;
            _repository = repository;
            _mediator = mediator;
        }

        [HttpGet]
        [Route("/api/product")]
        public async Task<IActionResult> Get()
        {
            var documents = await _repository.GetAllAsync(COLLECTION_NAME);
            
            if (documents == null || documents.Count == 0)
                return NoContent();

            return Ok(documents);
        }

        [HttpGet]
        [Route("/api/product/{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            var documents = await _repository.GetByIdAsync(COLLECTION_NAME, id);

            return Ok(documents);
        }

        [HttpPost]
        [Route("/api/product")]
        public async Task<IActionResult> Create([FromBody] AddProductRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpDelete]
        [Route("/api/product/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _mediator.Send(new DeleteProductRequest(id));

            return Ok(response);
        }
    }
}
