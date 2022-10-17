using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using static System.Collections.Specialized.BitVector32;

namespace PPlabs.Controllers
{
    [Route("api/companies")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        //private readonly IRepositoryManager _repository;
        //private readonly ILoggerManager _logger;
        //public EmployeeController(IRepositoryManager repository, ILoggerManager logger)
        //{
        //    _repository = repository;
        //    _logger = logger;
        //}
        //[HttpGet]
        //public IActionResult GetEmployee()
        //{
        //    try
        //    {
        //        var employee = _repository.Employee.GetAllEmployee(trackChanges:false);
        //        return Ok(employee);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($"Something went wrong in the{ nameof(GetEmployee)}action { ex}");
        //    return StatusCode(500, "Internal server error");
        //    }
        //}
    }
}
