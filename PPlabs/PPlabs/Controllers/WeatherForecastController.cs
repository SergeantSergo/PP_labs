using Contracts;
using Microsoft.AspNetCore.Mvc;

namespace lrs.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        public WeatherForecastController(IRepositoryManager repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            _repository.Company.AnyMethodFromCompanyRepository();
            _repository.Employee.AnyMethodFromEmployeeRepository();
            _repository.Plan.AnyMethodFromPlanRepository();
            _repository.Sklad.AnyMethodFromSkladRepository();
            _repository.Product.AnyMethodFromProductRepository();
            return new string[] { "value1", "value2" };

            var a = DateTime.Now.ToLongDateString;
        }
    }
}