using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PPlabs.Controllers
{
    [Route("api/sklad")]
    [ApiController]
    public class SkladController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public SkladController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetSklads()
        {
            var sklads = _repository.Sklad.GetAllSklads(false);
            var skladsDto = sklads.Select(c => new SkladDto
            {
                Id = c.Id,
                SkladName = c.SkladName,
            }).ToList();
            return Ok(skladsDto);
        }

        [HttpGet("{id}")]
        public IActionResult GetSklad(Guid id)
        {
            var sklad = _repository.Sklad.GetSklad(id, trackChanges: false);
            if (sklad == null)
            {
                _logger.LogInfo($"Sklad with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                var skladDto = _mapper.Map<ProductDto>(sklad);
                return Ok(skladDto);
            }
        }
    }
}
