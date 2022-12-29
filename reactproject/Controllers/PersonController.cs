using MediatR;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using reactproject.AggregatesModel.Person;
using reactproject.Commands.Person;
using reactproject.Repositories;

namespace reactproject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : Controller
    {
        private readonly ILogger<PersonController> _logger;
        private readonly Repository<PersonModel> _repository;
        private readonly IMediator _mediator;
        private const string COLLECTION_NAME = "person";

        public PersonController(ILogger<PersonController> logger, Repository<PersonModel> repository, IMediator mediator)
        {

            _logger = logger;
            _repository = repository;
            _mediator = mediator;
        }

        [HttpGet]
        [Route("/api/person")]
        public async Task<IActionResult> Get()
        {
            var documents = await _repository.GetAllAsync(COLLECTION_NAME);
            return Ok(documents);
        }

        [HttpGet]
        [Route("/api/person/{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            var documents = await _repository.GetByIdAsync(COLLECTION_NAME, id);

            return Ok(documents);
        }

        [HttpPost]
        [Route("/api/person")]
        public async Task<IActionResult> Create([FromBody]AddPersonRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpDelete]
        [Route("/api/person/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _mediator.Send(new DeletePersonRequest(id));

            return Ok(response);
        }
    }
}
