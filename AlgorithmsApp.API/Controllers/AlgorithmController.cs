using System.Threading.Tasks;
using AlgorithmsApp.API.Data;
using Microsoft.AspNetCore.Mvc;

namespace AlgorithmsApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlgorithmController : BaseController
    {
        public AlgorithmController(DataContext context) : base(context)
        {
        }

        [HttpGet("GetStatistics")]
        public async Task<IActionResult> GetStatistics()
        {

            var algStat = await dataManager.GetAlgoritmsStatisticAsync();
            return Ok(algStat);

        }


    }
}