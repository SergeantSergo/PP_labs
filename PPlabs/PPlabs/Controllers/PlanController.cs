using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
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
        public async Task<IActionResult> GetPlanForProduct(Guid IDSklad, Guid productId)
        {
            var sklad = await _repository.Sklad.GetSkladAsync(IDSklad, trackChanges: false);
            if (sklad == null)
            {
                _logger.LogInfo($"Company with id: {IDSklad} doesn't exist in the database.");
                return NotFound();
            }
            var plan = await _repository.Product.GetProductAsync(productId, trackChanges: false);
            if (plan == null)
            {
                _logger.LogInfo($"Company with id: {IDSklad} doesn't exist in the database.");
                return NotFound();
            }

            var plansFromDb = await _repository.Plan.GetPlansAsync(productId, false);
            var plansDto = _mapper.Map<IEnumerable<PlanDto>>(plansFromDb);
            return Ok(plansDto);
        }
        

        [HttpGet("{id}", Name = "GetPlan")]
        public async Task<IActionResult> GetPlansForProduct(Guid IDSklad, Guid productId, Guid id)
        {
            var sklad = await _repository.Sklad.GetSkladAsync(IDSklad, trackChanges: false);
            if (sklad == null)
            {
                _logger.LogInfo($"Company with id: {IDSklad} doesn't exist in the database.");
                return NotFound();
            }
            var product = await _repository.Product.GetProductAsync(productId, trackChanges: false);
            if (product == null)
            {
                _logger.LogInfo($"Company with id: {productId} doesn't exist in the database.");
                return NotFound();
            }
            var planDb = await _repository.Plan.GetPlanAsync(productId, id, false);
            if (planDb == null)
            {
                _logger.LogInfo($"Ticket with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            var plan = _mapper.Map<PlanDto>(planDb);
            return Ok(plan);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlanForProduct(Guid IDSklad, Guid productId, Guid IDSklad2, [FromBody] PlanForCreationDto plan)
        {
            if (plan == null)
            {
                _logger.LogError("TicketCreationDto object sent from client is null.");
                return BadRequest("TicketCreationDto object is null");
            }
            var sklad = await _repository.Sklad.GetSkladAsync(IDSklad, trackChanges: false);
            if (sklad == null)
            {
                _logger.LogInfo($"Company with id: {IDSklad} doesn't exist in the database.");
                return NotFound();
            }
            var sklad2 = await _repository.Sklad.GetSkladAsync(IDSklad2, trackChanges: false);
            if (sklad2 == null)
            {
                _logger.LogInfo($"Company with id: {IDSklad2} doesn't exist in the database.");
                return NotFound();
            }
            var product = await _repository.Product.GetProductAsync(productId, trackChanges: false);
            if (product == null)
            {
                _logger.LogInfo($"Company with id: {IDSklad} doesn't exist in the database.");
                return NotFound();
            }
            var planEntity = _mapper.Map<Plan>(plan);
            _repository.Plan.CreatePlan(IDSklad, IDSklad2, productId, planEntity);
            await _repository.SaveAsync();
            var planReturn = _mapper.Map<PlanDto>(planEntity);
            return CreatedAtRoute("GetPlan", new
            {
                IDSklad,
                IDSklad2,
                productId,
               Id = planReturn.Id
            }, planReturn);
        }

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeletePlanForProduct(Guid IDSklad, Guid IDSklad2, Guid productId, Guid id)
        //{
        //    var sklad = await _repository.Sklad.GetSkladAsync(IDSklad, trackChanges: false);
        //    if (sklad == null)
        //    {
        //        _logger.LogInfo($"Sklad with id: {IDSklad} doesn't exist in the database.");
        //        return NotFound();
        //    }
        //    var sklad2 = await _repository.Sklad.GetSkladAsync(IDSklad2, trackChanges: false);
        //    if (sklad2 == null)
        //    {
        //        _logger.LogInfo($"Company with id: {IDSklad2} doesn't exist in the database.");
        //        return NotFound();
        //    }
        //    var product = await _repository.Product.GetProductAsync(productId, trackChanges: false);
        //    if (product == null)
        //    {
        //        _logger.LogInfo($"Company with id: {productId} doesn't exist in the database.");
        //        return NotFound();
        //    }
        //    var planForproduct = _repository.Plan.GetPlanAsync(productId,  id,  false);
        //    if (planForproduct == null)
        //    {
        //        _logger.LogInfo($"Plan with id: {id} doesn't exist in the database.");
        //        return NotFound();
        //    }
        //     _repository.Plan.DeletePlan(planForproduct);
        //    await _repository.SaveAsync();
        //    return NoContent();
        //}

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePlanForProduct(Guid IDSklad, Guid IDSklad2, Guid productId, Guid id, [FromBody] PlanForUpdateDto plan)
        {
            if (plan == null)
            {
                _logger.LogError("EmployeeForUpdateDto object sent from client is null.");
                return BadRequest("EmployeeForUpdateDto object is null");
            }
            var sklad = await _repository.Sklad.GetSkladAsync(IDSklad, trackChanges: false);
            if (sklad == null)
            {
                _logger.LogInfo($"Sklad1 with id: {IDSklad} doesn't exist in the database.");
                return NotFound();
            }
            var sklad2 = await _repository.Sklad.GetSkladAsync(IDSklad2, trackChanges: false);
            if (sklad2 == null)
            {
                _logger.LogInfo($"Sklad2 with id: {IDSklad2} doesn't exist in the database.");
                return NotFound();
            }
            var product = await _repository.Product.GetProductAsync(productId, trackChanges: false);
            if (product == null)
            {
                _logger.LogInfo($"Product with id: {productId} doesn't exist in the database.");
                return NotFound();
            }
            var planEntity = _repository.Plan.GetPlanAsync(productId, id,
           trackChanges:
            true);
            if (planEntity == null)
            {
                _logger.LogInfo($"Plan with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            _mapper.Map(product, planEntity);
            await _repository.SaveAsync();
            return NoContent();
        }

        //[HttpPatch("{id}")]
        //public IActionResult PatchUpdatePlan(Guid IDSklad, Guid IDSklad2, Guid productId, Guid id, [FromBody] JsonPatchDocument<PlanForUpdateDto> plan)
        //{
        //    if (plan == null)
        //    {
        //        _logger.LogError("PlanForUpdateDto object sent from client is null.");
        //        return BadRequest("PlanForUpdateDto object is null");
        //    }
        //    var sklad = _repository.Sklad.GetSklad(IDSklad, trackChanges: false);
        //    if (sklad == null)
        //    {
        //        _logger.LogInfo($"Sklad1 with id: {IDSklad} doesn't exist in the database.");
        //        return NotFound();
        //    }
        //    var sklad2 = _repository.Sklad.GetSklad(IDSklad2, trackChanges: false);
        //    if (sklad2 == null)
        //    {
        //        _logger.LogInfo($"Sklad2 with id: {IDSklad2} doesn't exist in the database.");
        //        return NotFound();
        //    }
        //    var product = _repository.Product.GetProducts(productId, trackChanges: false);
        //    if (product == null)
        //    {
        //        _logger.LogInfo($"Product with id: {productId} doesn't exist in the database.");
        //        return NotFound();
        //    }
        //    var planEntity = _repository.Plan.GetPlan(productId, id, true);
        //    if (planEntity == null)
        //    {
        //        _logger.LogInfo($"Plan with id: {id} doesn't exist in the database.");
        //        return NotFound();
        //    }
        //    var planToPatch = _mapper.Map<PlanForUpdateDto>(planEntity);
        //    plan.ApplyTo(planToPatch);
        //    _mapper.Map(planToPatch, planEntity);
        //    _repository.Save();
        //    return NoContent();
        //}

        //[HttpDelete("{id}")]
        //public IActionResult DeletePlan(Guid id)
        //{
        //    var plan = _repository.Plan.GetPlan(id, trackChanges: false);
        //    if (plan == null)
        //    {
        //        _logger.LogInfo($"Company with id: {id} doesn't exist in the database.");
        //        return NotFound();
        //    }
        //    _repository.Plan.DeletePlan(plan);
        //    _repository.Save();
        //    return NoContent();
        //}

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
