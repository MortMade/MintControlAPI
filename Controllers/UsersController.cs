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
    // [controller] means the name of the controller minus "Controller"
    [ApiController]
    public class UsersController : Controller
    {
        private readonly UsersManager _manager;

        public UsersController(MintContext context)
        {
            _manager = new UsersManager(context);
        }
        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<UserModel> Get()
        {
            return _manager.GetAll();
        }

        // POST api/<UsersController>
        [HttpPost]
        public UserModel Post([FromBody] UserModel value)
        {
            return _manager.Add(value);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public UserModel Put(long id, [FromBody] UserModel value)
        {
            return _manager.Update(id, value);
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public UserModel Delete(long id)
        {
            return _manager.Delete(id);
        }
    }
}
