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
        public IActionResult GetPlans()
        {
            var plans = _repository.Plan.GetAllPlans(false);
            var PlansDto = plans.Select(c => new PlanDto
            {
                Id = c.Id,
                Sklad1 = c.Sklad1,
                Sklad2 = c.Sklad2,
                Product = c.Product,
                Kolvo = c.Kolvo,
                Date = c.Date,

             }).ToList();
            return Ok(PlansDto);
        }

        [HttpGet("{id}")]
        public IActionResult GetPlan(Guid id)
        {
            var plan = _repository.Plan.GetPlan(id, trackChanges: false);
            if (plan == null)
            {
                _logger.LogInfo($"Plan with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                var planDto = _mapper.Map<PlanDto>(plan);
                return Ok(planDto);
            }
        }



        //[HttpGet]
        //public IActionResult GetPlans()
        //{
        //    try
        //    {
        //        var plans = _repository.Plan.GetAllPlans(trackChanges:
        //       false);
        //        var plansDto = _mapper.Map<IEnumerable<PlanDto>>(plans);
        //        return Ok(plansDto);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($"Something went wrong in the {nameof(GetPlans)} action {ex}  ");
        //        return StatusCode(500, "Internal server error");
        //    }
        //}
    }
}
