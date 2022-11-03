using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using PPlabs.ModelBinders;

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
        public async Task<IActionResult> GetSklads()
        {
            var sklads = await _repository.Sklad.GetAllSkladsAsync(false);
            var skladDto = _mapper.Map<IEnumerable<SkladDto>>(sklads);
            return Ok(skladDto);
        }

        [HttpGet("{id}", Name = "SkladById")]
        public async Task<IActionResult> GetSklad(Guid id)
        {
            var sklad = await _repository.Sklad.GetSkladAsync(id, false);
            if (sklad == null)
            {
                _logger.LogInfo($"Company with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                var skladDto = _mapper.Map<SkladDto>(sklad);
                return Ok(skladDto);
            }
        }
       

        [HttpPost]
        public async Task<IActionResult> CreateSklad([FromBody] SkladForCreationDto sklad)
        {
            if (sklad == null)
            {
                _logger.LogError("CompanyForCreationDto object sent from client is null.");
                return BadRequest("CompanyForCreationDto object is null");
            }
            var skladEntity = _mapper.Map<Sklad>(sklad);
            _repository.Sklad.CreateSklad(skladEntity);
            await _repository.SaveAsync();
            var skladToReturn = _mapper.Map<SkladDto>(skladEntity);
            return CreatedAtRoute("SkladById", new { id = skladToReturn.Id }, skladToReturn);
        }

        [HttpGet("collection/({ids})", Name = "SkladCollection")]
        public async Task<IActionResult> GetSkladCollection([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
        {
            if (ids == null)
            {
                _logger.LogError("Parameter ids is null");
                return BadRequest("Parameter ids is null");
            }
            var skladEntities = await _repository.Sklad.GetByIdsAsync(ids, false);
            if (ids.Count() != skladEntities.Count())
            {
                _logger.LogError("Some ids are not valid in a collection");
                return NotFound();
            }
            var skladsToReturn =
            _mapper.Map<IEnumerable<SkladDto>>(skladEntities);
            return Ok(skladsToReturn);
        }
        [HttpPost("collection")]
        public async Task<IActionResult> CreateSkladCollection([FromBody] IEnumerable<SkladForCreationDto> skladCollection)
        {
            if (skladCollection == null)
            {
                _logger.LogError("Company collection sent from client is null.");
                return BadRequest("Company collection is null");
            }
            var skladEntities = _mapper.Map<IEnumerable<Sklad>>(skladCollection);
            foreach (var sklad in skladEntities)
            {
                _repository.Sklad.CreateSklad(sklad);
            }
            await _repository.SaveAsync();
            var skladCollectionToReturn = _mapper.Map<IEnumerable<SkladDto>>(skladEntities);
            var ids = string.Join(",", skladCollectionToReturn.Select(c => c.Id));
            return CreatedAtRoute("CompanyCollection", new { ids }, skladCollectionToReturn);
        }
        //[HttpPost]
        //public IActionResult CreateSklad([FromBody] SkladForCreationDto sklad)
        //{
        //    if (sklad == null)
        //    {
        //        _logger.LogError("SkladForCreationDto object sent from client is null.");
        //    return BadRequest("SkladForCreationDto object is null");
        //    }
        //    var skladEntity = _mapper.Map<Sklad>(sklad);
        //    _repository.Sklad.CreateSklad(skladEntity);
        //    _repository.Save();
        //    var skladToReturn = _mapper.Map<SkladDto>(skladEntity);
        //    return CreatedAtRoute("SkladById", new { id = skladToReturn.Id },
        //    skladToReturn);
        //}

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> CreateSkladCollection(Guid id)
        {
            var sklad = await _repository.Sklad.GetSkladAsync(id, false);
            if (sklad == null)
            {
                _logger.LogInfo($"Sklad with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            _repository.Sklad.DeleteSklad(sklad);
            _repository.Save();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSklad(Guid id, [FromBody] SkladForUpdateDto sklad)
        {
            if (sklad == null)
            {
                _logger.LogError("SkladForUpdateDto object sent from client is null.");
                return BadRequest("SkladForUpdateDto object is null");
            }
            var skladEntity = await _repository.Sklad.GetSkladAsync(id, true);
            if (skladEntity == null)
            {
                _logger.LogInfo($"Sklad with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            _mapper.Map(sklad, skladEntity);
            await _repository.SaveAsync();
            return NoContent();
        }

       
    }
}
