using System;
using System.Threading.Tasks;
using AlgorithmsApp.API.Algorithms;
using AlgorithmsApp.API.Data;
using AlgorithmsApp.API.Dtos;
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


        public async Task<IActionResult> Put([FromBody]MockSettings mockSettings)
        {

            try
            {
                if(mockSettings == null) mockSettings = new MockSettings();
                var gen = new ListGenerator();
                var steps = gen.GetSeps(mockSettings);
                var mockLength = mockSettings.MinValue;
                for (int i = 0; i < steps.Length - 1; i++)
                {
                    int[] arr = gen.ListOfIntegers(mockLength);
                    await dataManager.GenerateMocks(string.Join(',', arr),mockLength);
                    mockLength += (int)steps[i];      
                }
                if (true) return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
    }
}