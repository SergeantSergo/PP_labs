using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using static System.Collections.Specialized.BitVector32;

namespace PPlabs.Controllers
{
    [Route("api/empoloyee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public EmployeeController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetEmployees()
        {
            var employees = _repository.Employee.GetAllEmployees(false);
            var employeesDto = employees.Select(c => new EmployeeDto
            {
                Id = c.Id,
                Name = c.Name,
                Age = c.Age,
                Position = c.Position,
                CompanyId = c.CompanyId,
            }).ToList();
            return Ok(employeesDto);
        }
    }
}
