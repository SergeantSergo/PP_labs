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
        public IActionResult GetProductsForSklad(Guid IDSklad)
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

        [HttpGet("{id}", Name = "GetProductForSklad")]
        public IActionResult GetProductForSklad(Guid IDSklad, Guid id)
        {
            var sklad = _repository.Sklad.GetSklad(IDSklad, trackChanges: false);
            if (sklad == null)
            {
                _logger.LogInfo($"Sklad with id: {IDSklad} doesn't exist in the database.");
                return NotFound();
            }
            var productDb = _repository.Product.GetProduct(IDSklad, id,
           trackChanges:
            false);
            if (productDb == null)
            {
                _logger.LogInfo($"Product with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            var product = _mapper.Map<ProductDto>(productDb);
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProductForSklad(Guid IDSklad, Guid id)
        {
            var sklad = _repository.Sklad.GetSklad(IDSklad, trackChanges: false);
            if (sklad == null)
            {
                _logger.LogInfo($"Company with id: {IDSklad} doesn't exist in the database.");
            return NotFound();
            }
            var productForSklad = _repository.Product.GetProduct(IDSklad, id, trackChanges: false);
            if (productForSklad == null)
            {
                _logger.LogInfo($"Employee with id: {id} doesn't exist in the database.");
            return NotFound();
            }
            _repository.Product.DeleteProduct(productForSklad);
            _repository.Save();
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProductForSklad(Guid IDSklad, Guid id, [FromBody] ProductForUpdateDto product)
        {
            if (product == null)
            {
                _logger.LogError("EmployeeForUpdateDto object sent from client is null.");
            return BadRequest("EmployeeForUpdateDto object is null");
            }
            var sklad = _repository.Sklad.GetSklad(IDSklad, trackChanges: false);
            if (sklad == null)
            {
                _logger.LogInfo($"Sklad with id: {IDSklad} doesn't exist in the database.");
                return NotFound();
            }
            var productEntity = _repository.Product.GetProduct(IDSklad, id,
           trackChanges:
            true);
            if (productEntity == null)
            {
                _logger.LogInfo($"Employee with id: {id} doesn't exist in the database.");
            return NotFound();
            }
            _mapper.Map(product, productEntity);
            _repository.Save();
            return NoContent();
        }

        //не работает


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
        //[HttpGet("{id}", Name = "GetProductForSklad")]
        //public IActionResult GetEmployeeForCompany(Guid companyId, Guid id)
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