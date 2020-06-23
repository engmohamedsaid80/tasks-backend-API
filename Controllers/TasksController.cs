using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tasks_backend_api.Interfaces;
using tasks_backend_api.Models;

namespace tasks_backend_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskProvider provider;
        public TasksController(ITaskProvider provider)
        {
            this.provider = provider;
        }
        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await provider.GetTasksAsync();

            if (result.isSuccess) return Ok(result.results);

            return NotFound();
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

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
