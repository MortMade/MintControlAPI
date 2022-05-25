using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MintControlAPI.Managers;
using MintControlAPI.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MintControlAPI.Controllers
{
    [Route("api/[controller]")]
    // the controller is available on ..../api/books
    // [controller] means the name of the controller minus "Controller"
    [ApiController]
    public class FunctionsController : Controller
    {
        private readonly FunctionsManager _manager;

        public FunctionsController(MintContext context)
        {
            _manager = new FunctionsManager(context);
        }
        // GET: api/<FunctionsController>
        [HttpGet]
        public IEnumerable<FunctionModel> Get()
        {
            return _manager.GetAll();
        }

        // POST api/<FunctionsController>
        [HttpPost]
        public FunctionModel Post([FromBody] FunctionModel value)
        {
            return _manager.Add(value);
        }

        // PUT api/<FunctionsController>/5
        [HttpPut("{id}")]
        public FunctionModel Put(int id, [FromBody] FunctionModel value)
        {
            return _manager.Update(id, value);
        }

        // DELETE api/<FunctionsController>/5
        [HttpDelete("{id}")]
        public FunctionModel Delete(int id)
        {
            return _manager.Delete(id);
        }
    }
}
