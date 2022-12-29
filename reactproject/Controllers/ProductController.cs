using MediatR;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using reactproject.AggregatesModel.Product;
using reactproject.Commands.Person;
using reactproject.Commands.Product;
using reactproject.Repositories;

namespace reactproject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly ILogger<PersonController> _logger;
        private readonly Repository<ProductModel> _repository;
        private readonly IMediator _mediator;
        private const string COLLECTION_NAME = "product";

        public ProductController(ILogger<PersonController> logger, Repository<ProductModel> repository, IMediator mediator)
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
