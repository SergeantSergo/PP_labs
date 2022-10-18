using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PPlabs.Controllers
{
    [Route("api/plan")]
    [ApiController]
    public class PlanController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public PlanController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetPlan()
        {
            var plan = _repository.Plan.GetAllPlan(false);
            var PlanDto = plan.Select(c => new PlanDto
            {
                Id = c.Id,
                Sklad1 = c.Sklad1,
                Sklad2 = c.Sklad2,
                Product = c.Product,
                Kolvo = c.Kolvo,
                Date = c.Date,

             }).ToList();
            return Ok(PlanDto);
        }
    }
}
