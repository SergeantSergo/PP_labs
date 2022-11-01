using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
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

        [HttpGet("{id}", Name = "SkladById")]
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
                var skladDto = _mapper.Map<SkladDto>(sklad);
                return Ok(skladDto);
            }
        }

        [HttpPost]
        public IActionResult CreateSklad([FromBody] SkladForCreationDto sklad)
        {
            if (sklad == null)
            {
                _logger.LogError("SkladForCreationDto object sent from client is null.");
            return BadRequest("SkladForCreationDto object is null");
            }
            var skladEntity = _mapper.Map<Sklad>(sklad);
            _repository.Sklad.CreateSklad(skladEntity);
            _repository.Save();
            var skladToReturn = _mapper.Map<SkladDto>(skladEntity);
            return CreatedAtRoute("SkladById", new { id = skladToReturn.Id },
            skladToReturn);
        }

        //[HttpGet("{id}", Name = "GetEmployeeForCompany")]
        //public IActionResult GetProductForSklad(Guid companyId, Guid id)
        //{
        //    var company = _repository.Company.GetCompany(companyId, trackChanges: false);
        //    if (company == null)
        //    {
        //        _logger.LogInfo($"Company with id: {companyId} doesn't exist in the database.");
        //        return NotFound();
        //    }
        //    var employeeDb = _repository.Employee.GetEmployee(companyId, id,
        //   trackChanges:
        //    false);
        //    if (employeeDb == null)
        //    {
        //        _logger.LogInfo($"Employee with id: {id} doesn't exist in the database.");
        //        return NotFound();
        //    }
        //    var employee = _mapper.Map<EmployeeDto>(employeeDb);
        //    return Ok(employee);
        //}
    }
}
