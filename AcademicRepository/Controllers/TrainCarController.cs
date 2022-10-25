using _2022_09_23.Entities;
using _2022_09_23.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _2022_09_23.Controllers
{
    [Route("api/[controller]/[action]")]
    public class TrainCarController : Controller
    {

        private readonly ITrainCarService _trainCarService;

        public TrainCarController(ITrainCarService trainCarService)
        {
            _trainCarService = trainCarService;
        }

        [HttpGet]
        public IActionResult List()
        {
            return Ok(_trainCarService.List());
        }

        [HttpGet("{siteName}")]
        public IActionResult GetBySiteName(string siteName)
        {
            return Ok(_trainCarService.GetBySiteName(siteName));
        }
        [HttpPost]
        public IActionResult Create([FromBody] TrainCar trainCar)
        {
            return Ok(_trainCarService.Create(trainCar));
        }

    }
}
