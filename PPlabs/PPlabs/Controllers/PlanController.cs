using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PPlabs.Controllers
{
    [Route("api/sklad/{IDSklad}/{IDSklad2}/product/{productId}/plan")]
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
        public IActionResult GetPlanForProduct(Guid IDSklad, Guid productId)
        {
            var sklad = _repository.Sklad.GetSklad(IDSklad, trackChanges: false);
            if (sklad == null)
            {
                _logger.LogInfo($"Company with id: {IDSklad} doesn't exist in the database.");
                return NotFound();
            }
            var plan = _repository.Product.GetProducts(productId, trackChanges: false);
            if (plan == null)
            {
                _logger.LogInfo($"Company with id: {IDSklad} doesn't exist in the database.");
                return NotFound();
            }

            var plansFromDb = _repository.Plan.GetPlans(productId,  false);
            var plansDto = _mapper.Map<IEnumerable<PlanDto>>(plansFromDb);
            return Ok(plansDto);
        }

        [HttpGet("{id}", Name = "GetPlan")]
        public IActionResult GetPlan(Guid IDSklad, Guid productId, Guid id)
        {
            var sklad = _repository.Sklad.GetSklad(IDSklad, trackChanges: false);
            if (sklad == null)
            {
                _logger.LogInfo($"Sklad with id: {IDSklad} doesn't exist in the database.");
                return NotFound();
            }
            var product = _repository.Product.GetProducts(productId, trackChanges: false);
            if (product == null)
            {
                _logger.LogInfo($"Product with id: {productId} doesn't exist in the database.");
                return NotFound();
            }
            var planDb = _repository.Plan.GetPlan(productId, id, false);
            if (planDb == null)
            {
                _logger.LogInfo($"Plan with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            var plan = _mapper.Map<PlanDto>(planDb);
            return Ok(plan);
        }

        [HttpPost]
        public IActionResult CreatePlan(Guid IDSklad, Guid productId, Guid IDSklad2, [FromBody] PlanForCreationDto plan)
        {
            if (plan == null)
            {
                _logger.LogError("TicketCreationDto object sent from client is null.");
                return BadRequest("TicketCreationDto object is null");
            }
            var sklad = _repository.Sklad.GetSklad(IDSklad, trackChanges: false);
            if (sklad == null)
            {
                _logger.LogInfo($"Company with id: {IDSklad} doesn't exist in the database.");
                return NotFound();
            }
            var sklad2 = _repository.Sklad.GetSklad(IDSklad2, trackChanges: false);
            if (sklad2 == null)
            {
                _logger.LogInfo($"Company with id: {IDSklad} doesn't exist in the database.");
                return NotFound();
            }
            var product = _repository.Product.GetProducts(productId, trackChanges: false);
            if (product == null)
            {
                _logger.LogInfo($"product with id: {IDSklad} doesn't exist in the database.");
                return NotFound();
            }
            var planEntity = _mapper.Map<Plan>(plan);
            _repository.Plan.CreatePlan(IDSklad, IDSklad2, productId, planEntity);
            _repository.Save();
            var planReturn = _mapper.Map<PlanDto>(planEntity);
            return CreatedAtRoute("GetPlan", new
            {
                IDSklad,
                IDSklad2,
                productId,
                planReturn.Id
            }, planReturn);
        }

        //[HttpGet("{id}")]
        //public IActionResult GetPlan(Guid id)
        //{
        //    var plan = _repository.Plan.GetPlan(id, trackChanges: false);
        //    if (plan == null)
        //    {
        //        _logger.LogInfo($"Plan with id: {id} doesn't exist in the database.");
        //        return NotFound();
        //    }
        //    else
        //    {
        //        var planDto = _mapper.Map<PlanDto>(plan);
        //        return Ok(planDto);
        //    }
        //}



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
