using System;
using System.Threading.Tasks;
using AlgorithmsApp.API.Data;
using Microsoft.AspNetCore.Mvc;

namespace AlgorithmsApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MocksController : BaseController
    {
        public MocksController(DataContext context) : base(context)
        {
        }

        // GET api/mocks/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }


        [HttpPut("{length}")]
        public async Task<IActionResult> Put(int lenght)
        {
            try
            {
                var response = await dataManager.GenerateMocks(lenght);
                if (response) return Ok();
                else return Ok("Already exist");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
    }
}