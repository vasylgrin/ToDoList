using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using TODOList.Controllers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        //// GET: api/<ValuesController>
        //[HttpGet("{Username}")]
        //public IEnumerable<ToDo> GET(string Username)
        //{
        //    var DbController = new DataBaseController();
        //    return DbController.Load().Where(x => x.Username == Username);
        //}

        ////// GET api/<ValuesController>/5
        ////[HttpGet("{id}")]
        ////public string Get(int id)
        ////{
        ////    return "value";
        ////}

        ////// POST api/<ValuesController>
        ////[HttpPost]
        ////public void Post([FromBody] string value)
        ////{
        ////}

        ////// PUT api/<ValuesController>/5
        ////[HttpPut("{id}")]
        ////public void Put(int id, [FromBody] string value)
        ////{
        ////}

        //// DELETE api/<ValuesController>/5
        //[HttpDelete("{id}")]
        //public bool Delete(int id)
        //{
        //    var DbController = new DataBaseController();
        //    DbController.Remove(id);

        //    if (DbController.Find(id) == null)
        //    {
        //        return true;
        //    }
        //    else
        //        return false;
        //}
    }
}
