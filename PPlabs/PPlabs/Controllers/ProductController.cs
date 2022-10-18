using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PPlabs.Controllers
{
    [Route("api/product")] //api
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
        public IActionResult GetProduct()
        {
            var product = _repository.Product.GetAllProduct(false);
            var productDto = product.Select(c => new ProductDto
            {
                Id = c.Id,
                NameProduct = c.NameProduct,
                Kolvo = c.Kolvo,
                IDSklad = c.IDSklad,
            }).ToList();
            return Ok(productDto);
        }
    }
}
