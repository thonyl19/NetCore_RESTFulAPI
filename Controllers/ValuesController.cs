using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NetCore_RESTFulAPI.Controllers
{
    [Route("[controller]")]
    //[ApiController]
    public class ValuesController : Controller//ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
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

        /// <summary>
        /// pattern:/api/Values/user?name=$
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [Route("user"),HttpGet]
        public ActionResult<string> User_Get(string name)
        {
            return name;
        }
    }
}
