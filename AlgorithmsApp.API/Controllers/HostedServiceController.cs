using System;
using System.Threading.Tasks;
using AlgorithmsApp.API.Data;
using AlgorithmsApp.API.Scheduler;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace AlgorithmsApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchedulerController : ControllerBase
    {
        private readonly ScheduleTask _hostedService;
        public SchedulerController(IHostedService hostedService) : base()
        {
            _hostedService = hostedService as ScheduleTask;
        }

        [HttpGet("Start")]
        public async Task<IActionResult> Start()
        {
            try
            {
                await _hostedService.StartAsync(new System.Threading.CancellationToken());
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }


        }

        [HttpGet("Stop")]
        public async Task<IActionResult> Stop()
        {
            try
            {
                await _hostedService.StopAsync(new System.Threading.CancellationToken());
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


    }
}