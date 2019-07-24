using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlgorithmsApp.API.Algorithms;
using AlgorithmsApp.API.Algorithms.Sorting;
using AlgorithmsApp.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace AlgorithmsApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            var list = new List<AlgStat>();
            long insertTime, selectTime, bubbleTIme = 1;
            var gen = new ListGenerator();
            var insert = new InsertionSorter();
            var select = new SelectionSorter();
            var bubble = new BubbleSorter();

            int[] arr = gen.ListOfIntegers(1000);

            insertTime = insert.Iterative(arr);
            selectTime = select.Iterative(arr);
            bubbleTIme = bubble.Iterative(arr);

            list.Add(new AlgStat() { ExecTime = insertTime, Name = "Insert" });
            list.Add(new AlgStat() { ExecTime = selectTime, Name = "select" });
            list.Add(new AlgStat() { ExecTime = bubbleTIme, Name = "bubble" });


            return Ok(list);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
