using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MintControlAPI.Managers;
using MintControlAPI.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MintControlAPI.Controllers
{
    [Route("api/[controller]")]
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<FunctionModel>> Get()
        {
            List<FunctionModel> allFunc = _manager.GetAll();
            if (allFunc.Count == 0) return NotFound("Nothing found");
            return Ok(allFunc);
        }

        // GET: api/<FunctionsController>/<userId>
        [HttpGet("{userName}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<FunctionModel>> GetByUser(string userName)
        {
            List<FunctionModel> allFunc = _manager.GetByUserName(userName);
            if (allFunc.Count == 0) return NotFound("Nothing found");
            return Ok(allFunc);
        }

        // POST api/<FunctionsController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<FunctionModel> Post([FromBody] FunctionModel value)
        {
            try
            {
                FunctionModel postFunc = _manager.Add(value);
                string uri = Url.RouteUrl(RouteData.Values) + "/" + postFunc.FuncId;
                return Created(uri, postFunc);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<FunctionsController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<FunctionModel> Put(long id, [FromBody] FunctionModel value)
        {
            FunctionModel funcToUpdate = _manager.GetById(id);
            if (funcToUpdate == null) return NotFound("Not found");
            FunctionModel updatedFunction = _manager.Update(id, value);
            return Ok(updatedFunction);
        }

        // DELETE api/<FunctionsController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<FunctionModel> Delete(long id)
        {
            FunctionModel funcToDelete = _manager.GetById(id);
            if (funcToDelete == null) return NotFound("Not found");
            FunctionModel deletedFunction = _manager.Delete(id);
            return Ok(deletedFunction);
        }
    }
}
