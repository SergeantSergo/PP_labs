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
        public IActionResult GetSklad()
        {
            var sklad = _repository.Sklad.GetAllSklad(false);
            var skladDto = sklad.Select(c => new SkladDto
            {
                Id = c.Id,
                SkladName = c.SkladName,
            }).ToList();
            return Ok(skladDto);
        }
    }
}
