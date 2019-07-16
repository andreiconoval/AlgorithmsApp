using System.Threading.Tasks;
using AlgorithmsApp.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AlgorithmsApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SortingController: BaseController
    {
        public SortingController(DataContext context) : base(context)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAlgorithms()
        {
            var algorithms = await dataManager.GetAlgorithmsAsync();
            return Ok(algorithms);
        }

        public async Task<IActionResult> AlgorithmsStatistics()
        {
            var algStat = await dataManager.GetAlgoritmsStatisticAsync();
            return Ok(algStat);

        }
    }
}