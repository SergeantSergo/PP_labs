using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;

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
        //[HttpGet]
        //public async Task<IActionResult> GetProductsForSklad(Guid IDSklad)
        //{
        //    var sklad = await _repository.Sklad.GetSkladAsync(IDSklad, false);
        //    if (sklad == null)
        //    {
        //        _logger.LogInfo($"Company with id: {IDSklad} doesn't exist in the database.");
        //        return NotFound();
        //    }
        //    var productsFromDb = await _repository.Employee.GetEmployeesAsync(companyId, false);
        //    var productsDto = _mapper.Map<IEnumerable<EmployeeDto>>(employeesFromDb);
        //    return Ok(employeesDto);
        //}
        [HttpGet]
        public async Task<IActionResult> GetProductsForSklad(Guid IDSklad)
        {
            var sklad = await _repository.Sklad.GetSkladAsync(IDSklad, false);
            if (sklad == null)
            {
                _logger.LogInfo($"Company with id: {IDSklad} doesn't exist in the database.");
                return NotFound();
            }

            var productsFromDb = await _repository.Employee.GetEmployeesAsync(IDSklad, false);
            var productsDto = _mapper.Map<IEnumerable<ProductDto>>(productsFromDb);
            //var productsFromDb = _repository.Product.GetProduct(IDSklad,trackChanges: false);
            return Ok(productsDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductForSklad(Guid IDSklad, [FromBody] ProductForCreationDto product)
        {
            if (product == null)
            {
                _logger.LogError("ProductForCreationDto object sent from client is null.");
                return BadRequest("ProductForCreationDto object is null");
            }
            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the ProductForCreationDto object");
                return UnprocessableEntity(ModelState);
            }
            var Sklad = _repository.Sklad.GetSkladAsync(IDSklad, trackChanges: false);
            if (Sklad == null)
            {
                _logger.LogInfo($"Company with id: {IDSklad} doesn't exist in the database.");
                return NotFound();
            }

            var productEntity = _mapper.Map<Product>(product);
            _repository.Product.CreateProductForSklad(IDSklad, productEntity);
            _repository.Save();
            var productToReturn = _mapper.Map<ProductDto>(productEntity);
            return CreatedAtRoute("GetProductForSklad", new
            {
                IDSklad,
                id = productToReturn.Id
            }, productToReturn);
        }

        [HttpGet("{id}", Name = "GetProductForSklad")]
        public async Task<IActionResult> GetProductsForSklad(Guid IDSklad, Guid id)
        {
            var sklad = await _repository.Sklad.GetSkladAsync(IDSklad, trackChanges: false);
            if (sklad == null)
            {
                _logger.LogInfo($"Sklad with id: {IDSklad} doesn't exist in the database.");
                return NotFound();
            }
            var productDb = await _repository.Product.GetProductsAsync(IDSklad, id, false);
            if (productDb == null)
            {
                _logger.LogInfo($"Product with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            var employee = _mapper.Map<EmployeeDto>(productDb);
            return Ok(employee);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductForSklad(Guid IDSklad, Guid id)
        {
            var sklad = await _repository.Sklad.GetSkladAsync(IDSklad, trackChanges: false);
            if (sklad == null)
            {
                _logger.LogInfo($"Company with id: {IDSklad} doesn't exist in the database.");
                return NotFound();
            }
            var productForSklad = await _repository.Product.GetProductsAsync(IDSklad, id, trackChanges: false);
            if (productForSklad == null)
            {
                _logger.LogInfo($"Employee with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            _repository.Product.DeleteProduct(productForSklad);
            await _repository.SaveAsync();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProductForSklad(Guid IDSklad, Guid id, [FromBody] ProductForUpdateDto product)
        {
            if (product == null)
            {
                _logger.LogError("ProductForUpdateDto object sent from client is null.");
                return BadRequest("ProductForUpdateDto object is null");
            }
            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the ProductForUpdateDto object");
                return UnprocessableEntity(ModelState);
            }
            var sklad = await _repository.Sklad.GetSkladAsync(IDSklad, trackChanges: false);
            if (sklad == null)
            {
                _logger.LogInfo($"Sklad with id: {IDSklad} doesn't exist in the database.");
                return NotFound();
            }
            var productEntity = await _repository.Product.GetProductsAsync(IDSklad, id,
           trackChanges:
            true);
            if (productEntity == null)
            {
                _logger.LogInfo($"product with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            _mapper.Map(product, productEntity);
            _repository.SaveAsync();
            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PartiallyUpdateProductForSklad(Guid IDSklad, Guid id, [FromBody] JsonPatchDocument<ProductForUpdateDto> patchDoc)
        {
            if (patchDoc == null)
            {
                _logger.LogError("patchDoc object sent from client is null.");
                return BadRequest("patchDoc object is null");
            }
            var sklad = await _repository.Sklad.GetSkladAsync(IDSklad, false);
            if (sklad == null)
            {
                _logger.LogInfo($"Sklad with id: {IDSklad} doesn't exist in the database.");
                return NotFound();
            }
            var productEntity = await _repository.Employee.GetEmployeeAsync(IDSklad, id, true);
            if (productEntity == null)
            {
                _logger.LogInfo($"product with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            var productToPatch = _mapper.Map<ProductForUpdateDto>(productEntity);
            patchDoc.ApplyTo(productToPatch, ModelState);
            TryValidateModel(productToPatch);
            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the patch document");
                return UnprocessableEntity(ModelState);
            }
            _mapper.Map(productToPatch, productEntity);
            _repository.Save();
            return NoContent();

        }
    }
}

//