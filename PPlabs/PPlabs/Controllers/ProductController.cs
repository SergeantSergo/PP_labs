using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PPlabs.Controllers
{
    [Route("api/sklad/{IDSklad}/product")] //api
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public ProductController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetProductForSklad(Guid IDSklad)
        {
            var sklad = _repository.Sklad.GetSklad(IDSklad, trackChanges: false);
            if (sklad == null)
            {
                _logger.LogInfo($"Company with id: {IDSklad} doesn't exist in the database.");
            return NotFound();
            }

            var productsFromDb = _repository.Product.GetProducts(IDSklad, trackChanges: false);
            var productsDto = _mapper.Map<IEnumerable<ProductDto>>(productsFromDb);
            //var productsFromDb = _repository.Product.GetProduct(IDSklad,trackChanges: false);
            return Ok(productsFromDb);
        }

        //[HttpGet]
        //public IActionResult GetProductForSklad(Guid companyId)
        //{
        //    var company = _repository.Company.GetCompany(companyId, trackChanges: false);
        //    if (company == null)
        //    {
        //        _logger.LogInfo($"Company with id: {companyId} doesn't exist in the database.");
        //    return NotFound();
        //    }
        //    var employeesFromDb = _repository.Employee.GetEmployees(companyId,
        //    trackChanges: false);
        //    var employeesDto = _mapper.Map<IEnumerable<EmployeeDto>>(employeesFromDb);
        //    return Ok(employeesDto);
        //}
        //[HttpGet]
        //public IActionResult GetProducts()
        //{
        //    var products = _repository.Product.GetAllProducts(false);
        //    var productsDto = products.Select(c => new ProductDto
        //    {
        //        Id = c.Id,
        //        NameProduct = c.NameProduct,
        //        Kolvo = c.Kolvo,
        //        IDSklad = c.IDSklad,
        //    }).ToList();
        //    return Ok(productsDto);
        //}
        [HttpPost]
        public IActionResult CreateProductForSklad(Guid IDSklad, [FromBody] ProductForCreationDto product)
        {
            if (product == null)
            {
                _logger.LogError("ProductForCreationDto object sent from client is null.");
            return BadRequest("ProductForCreationDto object is null");
            }
            var Sklad = _repository.Sklad.GetSklad(IDSklad, trackChanges: false);
            if (Sklad == null)
            {
                _logger.LogInfo($"Company with id: {IDSklad} doesn't exist in the database.");
            return NotFound();
            }
            var productEntity = _mapper.Map<Product>(product);
            _repository.Product.CreateProductForSklad(IDSklad, productEntity);
            _repository.Save();
            var productToReturn = _mapper.Map<ProductDto>(productEntity);
            return CreatedAtRoute("GetProductForCompany", new
            {
                IDSklad,
                id = productToReturn.Id
            }, productToReturn);
        }

        //[HttpGet("{id}")]
        //public IActionResult GetProduct(Guid id)
        //{
        //    var product = _repository.Product.GetProduct(id, trackChanges: false);
        //    if (product == null)
        //    {
        //        _logger.LogInfo($"Product with id: {id} doesn't exist in the database.");
        //        return NotFound();
        //    }
        //    else
        //    {
        //        var productDto = _mapper.Map<ProductDto>(product);
        //        return Ok(productDto);
        //    }
        //}
    }
}
//